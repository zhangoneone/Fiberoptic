using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FiberopticServer.common;
using _98421;
using System.Threading;
using System.Runtime.InteropServices;
using System.Collections;
using System.IO;
namespace FiberopticServer
{
    public partial class ServerForm : Form
    {
        public int ret;
        static uint buffernum = 4000;
        public static short[] abc = new short[7];//用于凑出16字节地址对齐，取值为8*n-3(1,3,5,7),调试时要加上，运行exe时去掉这句就ok
        public static short[] data_buffer = new short[buffernum]; //接收到板卡的数据数组
        int test, test1, test2, test3, test4, test5;        //测试buff更新的数据
        List< short[]> storeData = new List< short[]>();
        public short[] cache_buffer = new short[buffernum];//数据保存回内存
        public static double[] demo = new double[buffernum];//对照数组
        public double[] amend_buffer = new double[buffernum];//保存修正后的数据
        public short[] exdatanum = new short[buffernum];//对应点数据触动的个数0~256
        int startTime = 10000;  //10000表示10000ms,第10s时开始采集
        int endTime = 12000;    //12000表示12000ms，第12s时结束采集
        Queue msgque = new Queue();//消息触动队列
        public ushort buf_id;
        public byte stopped = 0;
        public uint access_cnt = 0, StartPos = 0;
        private int m_dev;
        byte scantlv = 1, samptvl = 1;
        int wrtdata = 200 , wrtpoint = 200;
        CallbackDelegate m_del;
        string s = "采集方式：异步单buffer\r\n数据个数:" + buffernum + "\r\n" + "统计数据情况\r\n";
        long time = 0;
        static int timeCount = 0;//标志采集数据的轮数,这里1ms一轮，相当于计算时间了;
        byte circle = 0;//256次采集后为一个周期
        bool iscompleted = false;//数据转换完成标志位
        System.Diagnostics.Stopwatch t = new System.Diagnostics.Stopwatch();
        long fre = System.Diagnostics.Stopwatch.Frequency;//获取计时器频率，静态方法
        Thread Amend, Collectdata, CallbackThr,Recorddata,RecordPoint;//修正、采集、回调,记录线程

        unsafe static bool testaddr()//用于测试地址对齐
        {
            fixed (short* q = &abc[0])
            {
                Console.WriteLine("abc[0] addr=" + (int)q);
            }
            fixed (short* p = &data_buffer[0])
            {
                Console.WriteLine("data_buffer[0] addr=" + (int)p);
                if ((int)p % 16 != 0)
                {
                    Console.WriteLine("不是16字节对齐");
                    return false;
                }
                else
                {
                    Console.WriteLine("是16字节对齐");
                    return true;
                }
            }
        }
        private void TextInput(short[] dataInput,int i)//数据写文件
        {
            foreach (var b in dataInput)
            {
                LogClass.WriteInforLog(b.ToString()+" ",i);
            }
        }
        private void TextInput(double[] dataInput, int i)//数据写文件
        {
            foreach (var b in dataInput)
            {
                LogClass.WriteInforLog(b.ToString() + " ", i);
            }
        }
        private void TextInput()//cache_buffer数据写文件
        {
            string s=Directory.GetCurrentDirectory();
        //    System.IO.File.WriteAllText(@s+"//实时数据.txt",string.Empty);//先清空txt
            foreach (var b in cache_buffer)
            {
              LogClass.WriteInforLognotime(b.ToString() + " ", "实时数据");
            }
        }

        private void TextInput(short[] data)//cache_buffer数据写文件
        {
            string s = Directory.GetCurrentDirectory();
            System.IO.File.WriteAllText(@s + "//实时数据.txt", string.Empty);//先清空txt
            foreach (var b in data)
            {
                LogClass.WriteInforLognotime(b.ToString() + " ", "实时数据");
            }
        }
        private void PointInput()//Point数据写文件
        {
            foreach (var b in msgque)
            {
                LogClass.WriteInforLog(b.ToString() + " ", "异常点");
            }
        }
        private void logtext(string s)//保存测试信息
        {
            LogClass.WriteErrorLog(s + " ");
        }
        public ServerForm()//窗口初始化
        {
            InitializeComponent();
        }
        private void ServerForm_Load(object sender, EventArgs e)
        {
            //创建运行日志
            LogClass.WriteErrorLog("服务器启动...");
            if (testaddr())
            {
                DataList.Text += "buffer地址已对齐！\r\n";
            }
            else
            {
                DataList.Text += "buffer地址未对齐，请检查程序!\r\n";
            }
        }//窗口加载事件
        public int basicconfig()//基本配置函数体
        {
            ret = 0;
            ret = WD_DASK.WD_AI_CH_Config((ushort)m_dev, -1, WD_DASK.AD_B_1_V);
            //-1代表所有信道，0-7信道
            //+-5V
            if (ret < 0)
            {
             //   MessageBox.Show("WD_AI_CH_Config error!\r\n"+ret.ToString());
                return -1;
            }

            ret = WD_DASK.WD_AI_Config((ushort)m_dev, WD_DASK.WD_IntTimeBase, true, WD_DASK.WD_AI_ADCONVSRC_TimePacer, false, true);
            //参数2 选择时钟源，此处为内部时钟源
            //参数3 是否激活 ad duty循环恢复
            //参数4 ad转换源的选择
            //参数5 是否开启ad ping pong模式
            //参数6 模拟输入完成后，是否重置模拟ai的缓存
            if (ret < 0)
            {
                //             MessageBox.Show("WD_AI_Config error!\r\n"+ret.ToString());
                return -1;
            }
            ret = WD_DASK.WD_AI_Trig_Config((ushort)m_dev, 0, 2, 1, 0, 1.0, 0, 0, 0, 1);
            //设置触发源 模式 性能，必须在任何ai之前调用该函数
            //2触发模式只能选择delay 或者post 触发0x00是post 0x03是delay
            //3 触发源 可选soft触发 外部触发 ssi触发（两种） 参数对应0 2 3 4
            //4 上升或下降沿触发 1上升沿 0下降沿
            //5 信道选择
            //6 触发阈值选择 数字信号输入阈值选择是0-3.3.默认1.67
            //7 仅用于中间触发。表明了触发时间传递来的数据量
            //8 没看懂
            //9 事件触发后，延迟x个tick后执行？
            //10 
            if (ret < 0)
            {
                //           MessageBox.Show("Trigger error\r\n"+ret.ToString());
                return -1;
            }

            ret = WD_DASK.WD_AI_ContBufferSetup((ushort)m_dev, data_buffer, buffernum, out buf_id);//对接模拟数据的buffer
            //每调用一次该函数，产生一个ai缓存，用来保存连续不断的ai。最多两个
            //2.存储数据的缓存首地址，该地址需要16字节对齐。
            //3.缓存的大小(in sample)
            //4 当前建立的缓存索引
            if (ret < 0)
            {
                WD_DASK.WD_Buffer_Free((ushort)m_dev, data_buffer);     //这里设置失败尝试把buffer大小设置大一点
                WD_DASK.WD_AI_ContBufferReset((ushort)m_dev);
                WD_DASK.WD_Release_Card((ushort)m_dev);
                //           MessageBox.Show("WD_AI_ContBufferSetup error!\r\n"+ret.ToString());
                return -1;
            }
            return 0;
        }
        public void CollectionDatasyn()//异步采集函数（0异常）
        {
            int noupdata=0;
            int updata = 0;
            int i=0;
            ret = 0;
            ret = WD_DASK.WD_AI_ContReadChannel((ushort)m_dev, 0, buf_id, buffernum, scantlv, samptvl, WD_DASK.ASYNCH_OP);
            do
            {
                iscompleted = false;
                ret = WD_DASK.WD_AI_AsyncCheck((ushort)m_dev, out stopped, out access_cnt);//stop为true代表异步模拟输入结束,执行异步操作
              //此函数消耗时间约0.006ms,此函数调用一次，只做一次检测
              //参数2 true时，代表异步模拟输入结束或发生错误，可以取数据了。false代表异步输入还没有结束
                if (ret < 0)//函数出错
                {
                    MessageBox.Show("WD_AI_AsyncCheck error!\r\n" + ret.ToString());
                    break;
                }
                if (stopped == 1)//异步输入结束,处理数据
                {
                    for (short x = 0; x < buffernum; x++)//数据放回内存数组
                    {
                        cache_buffer[x] = data_buffer[x];
                    }
                    timeCount++;   //时间增加
                    if (timeCount > startTime && timeCount <= endTime)
                    {
                        storeData.Add(cache_buffer);
                    }
                    if (timeCount == endTime)
                    {
                        // 保存数据
                        foreach (short[] temData in storeData)
                        {
                            TextInput(temData);
                            LogClass.WriteInforLognotime("\r\n", "实时数据");
                        }
                        DataList.Text += "数据保存完成\r\n"; ;
                    }
                    ret = WD_DASK.WD_AI_ContReadChannel((ushort)m_dev, 0, buf_id, buffernum, scantlv, samptvl, WD_DASK.ASYNCH_OP);
                    //在指定的频道以接近指定的速率，执行连续不断的ad转换，双缓存模式的连续不断的ad转换仅仅支持post触发和延时触发模式
                    //参数1 执行该操作的卡id
                    //参数2 模拟频道id
                    //参数3 由buffersetup函数返回的一个参数，id索引的缓存数组，包含了捕获的数据
                    //参数4 扫描的总个数，应该是8的倍数
                    //参数5 扫描间隔的长度/计数值 1-65535
                    //参数6 采样间隔的长度/计数值 1-65535
                    //参数7 声明同步或者异步执行。打开pre-/middle trigger时，该函数是异步执行的
                    //同步转换时，函数会阻塞，直到ad转换完成。异步转换时，函数正常返回
                     stopped = 0;//置0
                }
            } while (true);
        }
        private void Amend_Handlex()//修正函数体(无公式)
        {
            int tongji = 0;
            int dx;//dx=k*10,10是点间距离
            bool f = true;
            while (true)//不断检查转换
            {
                while (iscompleted)
                {
                    iscompleted = false;
                    for (short k = 0; k < buffernum; k++)
                    {
                        if (iscompleted == true)
                        {
                            //               Console.WriteLine("buffer已刷新或上一轮未完成更新，修正失败！");
                            circle++;
                            tongji++;
                            break;
                        }
                        //下面检查数据
                        if (Math.Abs(cache_buffer[k]) - Math.Abs(demo[k]) > Math.Abs(demo[k] * 0.6))//阈值50%
                        {
                            exdatanum[k]++;//对应点异常值加1
                        }
                        if (exdatanum[k] > 52)//对应位置50%的点产生触动256/128
                        {
                            if (!msgque.Contains(k * 10))//确定k*10是否在队列里
                            {
                                msgque.Enqueue(k * 10);//放入队列的是触动点到第一个点的距离/m
                                Console.WriteLine(k * 10 + "点异常");
                            }
                        }
                    }
                    if (circle < 10 && f == true && tongji == 0)
                    {
                        for (short x = 0; x < buffernum; x++)
                        {
                            demo[x] = (demo[x] + cache_buffer[x]) / 2;
                        }
                        if (circle > 20)
                        {
                            f = false;
                        }
                    }
                    circle++;
                    if (circle == 0)//完成了一个周期
                    {
                     if(tongji>0){   Console.WriteLine("本轮未处理完成数据：" + tongji);}
                        tongji = 0;
                        for (int x = 0; x < buffernum;x++)//数组清0
                        {
                            exdatanum[x] = 0;
                        }
                    }
                }
            }

        }
        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)//窗口关闭事件
        {
            if (m_dev >= 0)
            {
                //功能:停止异步模拟输入
                //如果是pre或者middle触发模式，startpos返回ad buffer第一个数据的位置
                //如果是pre或者middle触发模式，access_cnt返回ad buffer的数据个数。如果是双buffer，返回第二个buffer的数据首位置
                //    WD_DASK.WD_Buffer_Free((ushort)m_dev, data_buffer);
           //     WD_DASK.WD_AI_AsyncClear((ushort)m_dev, out StartPos, out access_cnt);
                WD_DASK.WD_Release_Card((ushort)m_dev);//释放卡
            }

        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)//启动板卡
        {
            importdll.CollectionSession cs = new importdll.CollectionSession();
            cs = importdll.proxy(ref cs);
            m_dev = 0;
            uint sdramsize = 0;
            m_dev = WD_DASK.WD_Register_Card(WD_DASK.PCI_9842, 0);
            if (m_dev < 0)
            {
                MessageBox.Show("注册失败！");
                LogClass.WriteErrorLog("注册失败！");
            }
            else
            {
                //           MessageBox.Show("WD_Register_Card Success!");
                WD_DASK.WD_Get_SDRAMSize((ushort)m_dev, out sdramsize);
                DataList.Text += "注册成功!板载SDRAM大小是:" + sdramsize + "MB\r\n";
                LogClass.WriteErrorLog("注册成功!板载SDRAM大小是:" + sdramsize + "MB\r\n");
                toolStripMenuItem2.Enabled = false;
                基本配置ToolStripMenuItem.Enabled = true;
                参数设置ToolStripMenuItem.Enabled = true;
            }
        }
        private void 配置1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ret = basicconfig();
            采集方式ToolStripMenuItem.Enabled = true;
            数据侦听ToolStripMenuItem.Enabled = true;
            if (ret < 0)
            {
                MessageBox.Show("配置失败!");
                LogClass.WriteErrorLog("配置失败!");
                采集方式ToolStripMenuItem.Enabled = false;
                数据侦听ToolStripMenuItem.Enabled = false;
            }
        }
        private void 异步采集ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Collectdata = new Thread(CollectionDatasyn);//异步采集
            Collectdata.Priority = ThreadPriority.Highest;
            Collectdata.Start();
            DataList.Text += "正在采集数据...\r\n";
            回调采集ToolStripMenuItem.Enabled = false;
        }
        private void 回调采集ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            异步采集ToolStripMenuItem.Enabled = false;
        }
        private void 无放大ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Amend = new Thread(Amend_Handlex);
            Amend.Priority = ThreadPriority.Highest;
            Amend.Start();
            DataList.Text += "侦测中...\r\n";
            放大侦听ToolStripMenuItem.Enabled = false;
        }
        private void 放大侦听ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Amend = new Thread(Amend_Handlex);
            Amend.Priority = ThreadPriority.Highest;
            Amend.Start();
            DataList.Text += "侦测中...\r\n";
            无放大ToolStripMenuItem.Enabled = false;
        }
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            buffernum = (uint)toolStripComboBox1.SelectedItem;
        }
        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            scantlv = samptvl = (byte)toolStripComboBox2.SelectedItem;
        }
        private void 数据查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe",Directory.GetCurrentDirectory()+"\\实时数据.txt");
        }
        private void toolStripComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            wrtdata = (int)toolStripComboBox3.SelectedItem;
            timer1data写文件.Interval = wrtdata;
        }
        private void toolStripComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            wrtpoint = (int)toolStripComboBox4.SelectedItem;
            timer2point写文件.Interval = wrtpoint;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Recorddata = new Thread(TextInput);
            Recorddata.Priority = ThreadPriority.BelowNormal;
            Recorddata.Start();
        }
        private void timer2point写文件_Tick(object sender, EventArgs e)
        {
            RecordPoint = new Thread(PointInput);
            RecordPoint.Priority = ThreadPriority.BelowNormal;
            RecordPoint.Start();
        }
        private void 数据写文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            数据写文件ToolStripMenuItem.Enabled = false;
            关闭写数据ToolStripMenuItem.Enabled = true;
            timer1data写文件.Enabled = true;
            timer1data写文件.Start();
        }
        private void 关闭写数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            关闭写数据ToolStripMenuItem.Enabled = false;
            数据写文件ToolStripMenuItem.Enabled = true;
            timer1data写文件.Stop();//关闭写文件定时器
            Recorddata.Abort();
            timer1data写文件.Enabled = false;
        }
        private void 停止记录异常点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            停止记录异常点ToolStripMenuItem.Enabled = false;
            异常点记录ToolStripMenuItem.Enabled = true;
            RecordPoint.Abort();
            timer2point写文件.Stop();
            timer2point写文件.Enabled = false;
        }
        private void 异常点记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            异常点记录ToolStripMenuItem.Enabled = false;
            停止记录异常点ToolStripMenuItem.Enabled = true;
            timer2point写文件.Enabled = true;
            timer2point写文件.Start();
        }
        private void 异常点查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe", Directory.GetCurrentDirectory() + "\\异常点.txt");
        }
        private void 运行日志ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe", Directory.GetCurrentDirectory() + "\\运行日志.txt");
        }
        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("iexplore.exe",Directory.GetCurrentDirectory()+"\\帮助文档.html");
        }

        private void 历史记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void StartBand_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void StartCollect_Click(object sender, EventArgs e)
        {

        }

    }
}
