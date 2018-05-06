// PCIECollection.cpp : 定义 DLL 应用程序的导出函数。
#include "stdafx.h"
#include "PCIECollection.h"
#include "Wd-dask.h"
#include <fstream>
#include<string>
using namespace std;
//构造函数
DataCollection::DataCollection()
{
	card_num = 0;
	buffernum = 4000;
	stopped=0;
	cs->buff_is_valid=false;
	cs->prl.class_code=cs->prl.command_code=cs->prl.data=0;//初始化协议码
	cs->buffer = new short[buffernum];//设置buf大小
}
DataCollection::DataCollection(int num)
{
	card_num = 0;
	buffernum=num;
	stopped=0;
	cs->buff_is_valid=false;
	cs->prl.class_code=cs->prl.command_code=cs->prl.data=0;//初始化协议码
	cs->buffer = new short[buffernum];//设置buf大小
}
DataCollection::~DataCollection()
{
}
DataCollection *DataCollection::GetSingleton()
	{	
		if(NULL==m_singleton)
		{
			m_singleton=new DataCollection();
		}
		return m_singleton;
	}//单件模式
int DataCollection::register_Card()
{
	m_dev = WD_Register_Card (PCIe_9842, card_num);

	if(m_dev < 0)
	{
		WD_Release_Card(m_dev);//释放设备
		return Register_card_err;
	}
	return Config_OK;
}
int DataCollection::logout_Card()
{
	int ret = 0;
	ret = WD_AI_AsyncClear(m_dev, &startPos, &accessCnt);
	ret = WD_Buffer_Free(m_dev, data_buffer);     
    ret = WD_AI_ContBufferReset(m_dev);
    ret = WD_Release_Card(m_dev);
	return ret;
}
int DataCollection::base_config()
{
	int ret=0;
		 	 //-1代表所有信道，0-7信道
			 //+-5V
	 ret = WD_AI_CH_Config(m_dev,-1,AD_B_1_V);
	 if(ret < 0)
	 {
		 WD_Buffer_Free (m_dev, data_buffer);//释放buffer
		 WD_Release_Card(m_dev);//释放设备
		 return AI_CH_Config;
	 }
			//参数2 选择时钟源，此处为内部时钟源
			//参数3 是否激活 ad duty循环恢复
			//参数4 ad转换源的选择
			//参数5 是否开启ad ping pong模式
			//参数6 模拟输入完成后，是否重置模拟ai的缓存
	ret = WD_AI_Config(m_dev,WD_IntTimeBase, true,WD_AI_ADCONVSRC_TimePacer, false, true);
	if(ret < 0)
	{
		 WD_Buffer_Free (m_dev, data_buffer);//释放buffer
		 WD_Release_Card(m_dev);//释放设备
		 return AI_Config;
	}
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
	ret = WD_AI_Trig_Config(m_dev, 0, 2, 1, 0, 1.0, 0, 0, 0, 1);
    if (ret < 0)
     {
		 WD_Buffer_Free (m_dev, data_buffer);//释放buffer
		 WD_Release_Card(m_dev);//释放设备
		 return AI_Trig_Config;
     }
            //每调用一次该函数，产生一个ai缓存，用来保存连续不断的ai。最多两个
            //2.存储数据的缓存首地址，该地址需要16字节对齐。
            //3.缓存的大小(in sample)
            //4 当前建立的缓存索引
     ret = WD_AI_ContBufferSetup(m_dev, data_buffer, buffernum,&buf_id);//对接模拟数据的buffer
     if (ret < 0)
      {
		  WD_Buffer_Free(m_dev, data_buffer);     //这里设置失败尝试把buffer大小设置大一点
          WD_AI_ContBufferReset(m_dev);
          WD_Release_Card(m_dev);
          return AI_ContBufferSetup;
      }
	 CollectionCallback(NULL);//启动采集，本函数可以使用多线程方式
	 return Config_OK;
}
int DataCollection::re_config(DataCollection &dc)
{
	int ret = 0;
	//注销采集卡
	if( (ret = logout_Card() )!= 0) goto err;
	//判断要更新的配置值
	switch(dc.cs->prl.command_code)
	{
	case Collection_num:dc.buffernum = dc.cs->configSession.collection_num;break;
	case SampIntv:dc.scantlv = dc.samptvl = dc.cs->configSession.sampIntv;break;
	default:break;
	}
	//更新DataCollection的值，执行一次默认配置，写入更新的配置值，即可
	if( ( ret = base_config())!=0 ) goto err;
	//下面还要重启采集过程
	///todo
	//采集过程使用多线程，查询方式。会定时刷新参数，无须重新写入参数值
err:
	return ret;

}
int DataCollection::data_save_tofile(const char *filename,short *buffer)
{
	string tmp_filename=filename;
	tmp_filename+=".txt";
	 ofstream out(tmp_filename); 
     if (!out.is_open())   
     {  
		 return Save_tofile_failed;
     }  
	  out << buffer;  
      out.close();  
     return Config_OK;
}
int DataCollection::data_emit(){return 0;}
DWORD WINAPI DataCollection::CollectionCallback(LPVOID lpParamter)//完成从采集卡采集数据的过程
{
    int ret = 0;
    if( ret = WD_AI_ContReadChannel(m_dev, 0, buf_id, buffernum, scantlv, samptvl,ASYNCH_OP)!=0 )goto err;
	do
	{
		//此函数消耗时间约0.006ms,此函数调用一次，只做一次检测
        //参数2 true时，代表异步模拟输入结束或发生错误，可以取数据了。false代表异步输入还没有结束
		ret = WD_AI_AsyncCheck(m_dev,&stopped,&accessCnt);//stop为true代表异步模拟输入结束,执行异步操作
		if (ret < 0)goto err;
		if (stopped == 1)//异步输入结束,处理数据
		{

			//一次采集完成，通知下一步处理
		}
		//在指定的频道以接近指定的速率，执行连续不断的ad转换，双缓存模式的连续不断的ad转换仅仅支持post触发和延时触发模式
        //参数1 执行该操作的卡id
        //参数2 模拟频道id
        //参数3 由buffersetup函数返回的一个参数，id索引的缓存数组，包含了捕获的数据
        //参数4 扫描的总个数，应该是8的倍数
        //参数5 扫描间隔的长度/计数值 1-65535
        //参数6 采样间隔的长度/计数值 1-65535
       //参数7 声明同步或者异步执行。打开pre-/middle trigger时，该函数是异步执行的
       //同步转换时，函数会阻塞，直到ad转换完成。异步转换时，函数正常返回
		if( ret = WD_AI_ContReadChannel(m_dev, 0, buf_id, buffernum, scantlv, samptvl,ASYNCH_OP)!=0 )goto err;
		stopped = 0;//置0
	} while (true);
err:
	return ret;
}
int DataCollection::Register_function(DataCollection &dc)
{
    //注册消息，需完成采集卡注册、配置等任务
	int ret = 0;
	ret = dc.register_Card();//注册
	ret = dc.base_config();//默认配置
	return ret;
}
int DataCollection::Logout_function(DataCollection &dc)
{
	int ret = 0;
	ret = dc.logout_Card();
	return ret;
}
int DataCollection::Set_function(DataCollection &dc)
{
	int ret=0;
	ret = re_config(dc);
	return ret;
}
int DataCollection::Get_function(DataCollection &dc)
{
	return 0;
}
//c#调用接口
extern "C" MYDLL_API CollectionSession proxy(CollectionSession *cs)
{
	static DataCollection *dc = DataCollection::GetSingleton();//单例模式
	dc->cs=cs;//接收c#传来的CollectionSession
	proxy_for_cPlus(*dc);
	return *(dc->cs);//返回CollectionSession
}
extern "C" MYDLL_API  test proxyx(test *cs)
{
	return *cs;
}

//友元函数解析协议码
int proxy_for_cPlus(DataCollection &dc) 
{
	int ret = 0;
	switch(dc.cs->prl.class_code)
	{
	case Register_code:ret = dc.Register_function(dc);break;
	case Logout_code:ret = dc.Logout_function(dc);break;
	case Set_code:ret = dc.Set_function(dc);break;
	case Get_code:ret = dc.Get_function(dc);break;
	default:ret = -1;break;
	}
	return ret;
}
