namespace FiberopticServer
{
    partial class ServerForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.StartCollect = new System.Windows.Forms.Button();
            this.DataList = new System.Windows.Forms.TextBox();
            this.StartBand = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.启动板卡ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.基本配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.配置1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更多模式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.软触发ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.缓存设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.单缓存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.双缓存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.参数设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.采样点数量ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.扫描采样间隔ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox2 = new System.Windows.Forms.ToolStripComboBox();
            this.数据写文件间隔ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox3 = new System.Windows.Forms.ToolStripComboBox();
            this.异常点记录间隔ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox4 = new System.Windows.Forms.ToolStripComboBox();
            this.采集方式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.异步采集ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.回调采集ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.同步采集ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据侦听ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.无放大ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.放大侦听ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.历史记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据写文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.异常点记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭写数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.停止记录异常点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据查看ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.异常点查看ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.运行日志ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1data写文件 = new System.Windows.Forms.Timer(this.components);
            this.timer2point写文件 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartCollect
            // 
            this.StartCollect.Location = new System.Drawing.Point(646, 436);
            this.StartCollect.Name = "StartCollect";
            this.StartCollect.Size = new System.Drawing.Size(162, 31);
            this.StartCollect.TabIndex = 0;
            this.StartCollect.Text = "多线程采集";
            this.StartCollect.UseVisualStyleBackColor = true;
            this.StartCollect.Click += new System.EventHandler(this.StartCollect_Click);
            // 
            // DataList
            // 
            this.DataList.Location = new System.Drawing.Point(646, 31);
            this.DataList.Multiline = true;
            this.DataList.Name = "DataList";
            this.DataList.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.DataList.Size = new System.Drawing.Size(162, 255);
            this.DataList.TabIndex = 1;
            // 
            // StartBand
            // 
            this.StartBand.Location = new System.Drawing.Point(646, 292);
            this.StartBand.Name = "StartBand";
            this.StartBand.Size = new System.Drawing.Size(162, 31);
            this.StartBand.TabIndex = 2;
            this.StartBand.Text = "启动板卡";
            this.StartBand.UseVisualStyleBackColor = true;
            this.StartBand.Click += new System.EventHandler(this.StartBand_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(646, 368);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 31);
            this.button1.TabIndex = 4;
            this.button1.Text = "基本配置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(646, 502);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(162, 31);
            this.button2.TabIndex = 5;
            this.button2.Text = "数据修正";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.启动板卡ToolStripMenuItem,
            this.基本配置ToolStripMenuItem,
            this.参数设置ToolStripMenuItem,
            this.采集方式ToolStripMenuItem,
            this.数据侦听ToolStripMenuItem,
            this.历史记录ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(820, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 启动板卡ToolStripMenuItem
            // 
            this.启动板卡ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.启动板卡ToolStripMenuItem.Name = "启动板卡ToolStripMenuItem";
            this.启动板卡ToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.启动板卡ToolStripMenuItem.Text = "启动板卡";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.toolStripMenuItem2.Size = new System.Drawing.Size(135, 22);
            this.toolStripMenuItem2.Text = "9842";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(135, 22);
            this.toolStripMenuItem3.Text = "9852";
            // 
            // 基本配置ToolStripMenuItem
            // 
            this.基本配置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.配置1ToolStripMenuItem,
            this.更多模式ToolStripMenuItem,
            this.缓存设置ToolStripMenuItem});
            this.基本配置ToolStripMenuItem.Enabled = false;
            this.基本配置ToolStripMenuItem.Name = "基本配置ToolStripMenuItem";
            this.基本配置ToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.基本配置ToolStripMenuItem.Text = "基本配置";
            // 
            // 配置1ToolStripMenuItem
            // 
            this.配置1ToolStripMenuItem.Name = "配置1ToolStripMenuItem";
            this.配置1ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.配置1ToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.配置1ToolStripMenuItem.Text = "基本模式";
            this.配置1ToolStripMenuItem.Click += new System.EventHandler(this.配置1ToolStripMenuItem_Click);
            // 
            // 更多模式ToolStripMenuItem
            // 
            this.更多模式ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolStripMenuItem1,
            this.软触发ToolStripMenuItem});
            this.更多模式ToolStripMenuItem.Name = "更多模式ToolStripMenuItem";
            this.更多模式ToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.更多模式ToolStripMenuItem.Text = "触发源";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(115, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItem1.Text = "外部触发";
            // 
            // 软触发ToolStripMenuItem
            // 
            this.软触发ToolStripMenuItem.Name = "软触发ToolStripMenuItem";
            this.软触发ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.软触发ToolStripMenuItem.Text = "软触发";
            // 
            // 缓存设置ToolStripMenuItem
            // 
            this.缓存设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.单缓存ToolStripMenuItem,
            this.双缓存ToolStripMenuItem});
            this.缓存设置ToolStripMenuItem.Name = "缓存设置ToolStripMenuItem";
            this.缓存设置ToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.缓存设置ToolStripMenuItem.Text = "缓存设置";
            // 
            // 单缓存ToolStripMenuItem
            // 
            this.单缓存ToolStripMenuItem.Name = "单缓存ToolStripMenuItem";
            this.单缓存ToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.单缓存ToolStripMenuItem.Text = "单缓存";
            // 
            // 双缓存ToolStripMenuItem
            // 
            this.双缓存ToolStripMenuItem.Name = "双缓存ToolStripMenuItem";
            this.双缓存ToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.双缓存ToolStripMenuItem.Text = "双缓存";
            // 
            // 参数设置ToolStripMenuItem
            // 
            this.参数设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.采样点数量ToolStripMenuItem,
            this.扫描采样间隔ToolStripMenuItem,
            this.数据写文件间隔ToolStripMenuItem,
            this.异常点记录间隔ToolStripMenuItem});
            this.参数设置ToolStripMenuItem.Enabled = false;
            this.参数设置ToolStripMenuItem.Name = "参数设置ToolStripMenuItem";
            this.参数设置ToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.参数设置ToolStripMenuItem.Text = "参数设置";
            // 
            // 采样点数量ToolStripMenuItem
            // 
            this.采样点数量ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1});
            this.采样点数量ToolStripMenuItem.Name = "采样点数量ToolStripMenuItem";
            this.采样点数量ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.采样点数量ToolStripMenuItem.Text = "采样点数量";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "8000",
            "10000",
            "12000",
            "14000",
            "16000",
            "18000",
            "20000",
            "22000",
            "24000",
            "26000",
            "28000",
            "30000"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 20);
            this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            // 
            // 扫描采样间隔ToolStripMenuItem
            // 
            this.扫描采样间隔ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox2});
            this.扫描采样间隔ToolStripMenuItem.Name = "扫描采样间隔ToolStripMenuItem";
            this.扫描采样间隔ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.扫描采样间隔ToolStripMenuItem.Text = "扫描/采样间隔";
            // 
            // toolStripComboBox2
            // 
            this.toolStripComboBox2.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.toolStripComboBox2.Name = "toolStripComboBox2";
            this.toolStripComboBox2.Size = new System.Drawing.Size(121, 20);
            this.toolStripComboBox2.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox2_SelectedIndexChanged);
            // 
            // 数据写文件间隔ToolStripMenuItem
            // 
            this.数据写文件间隔ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox3});
            this.数据写文件间隔ToolStripMenuItem.Name = "数据写文件间隔ToolStripMenuItem";
            this.数据写文件间隔ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.数据写文件间隔ToolStripMenuItem.Text = "数据写文件间隔(s)";
            // 
            // toolStripComboBox3
            // 
            this.toolStripComboBox3.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8",
            "16",
            "32",
            "64",
            "128",
            "256",
            "512",
            "1024"});
            this.toolStripComboBox3.Name = "toolStripComboBox3";
            this.toolStripComboBox3.Size = new System.Drawing.Size(121, 20);
            this.toolStripComboBox3.Tag = "200";
            this.toolStripComboBox3.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox3_SelectedIndexChanged);
            // 
            // 异常点记录间隔ToolStripMenuItem
            // 
            this.异常点记录间隔ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox4});
            this.异常点记录间隔ToolStripMenuItem.Name = "异常点记录间隔ToolStripMenuItem";
            this.异常点记录间隔ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.异常点记录间隔ToolStripMenuItem.Text = "异常点记录间隔(ms)";
            // 
            // toolStripComboBox4
            // 
            this.toolStripComboBox4.Items.AddRange(new object[] {
            "200",
            "400",
            "600",
            "800",
            "1000",
            "2000",
            "4000",
            "8000"});
            this.toolStripComboBox4.Name = "toolStripComboBox4";
            this.toolStripComboBox4.Size = new System.Drawing.Size(121, 20);
            this.toolStripComboBox4.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox4_SelectedIndexChanged);
            // 
            // 采集方式ToolStripMenuItem
            // 
            this.采集方式ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.异步采集ToolStripMenuItem,
            this.回调采集ToolStripMenuItem,
            this.同步采集ToolStripMenuItem});
            this.采集方式ToolStripMenuItem.Enabled = false;
            this.采集方式ToolStripMenuItem.Name = "采集方式ToolStripMenuItem";
            this.采集方式ToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.采集方式ToolStripMenuItem.Text = "采集方式";
            // 
            // 异步采集ToolStripMenuItem
            // 
            this.异步采集ToolStripMenuItem.Name = "异步采集ToolStripMenuItem";
            this.异步采集ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.异步采集ToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.异步采集ToolStripMenuItem.Text = "异步采集";
            this.异步采集ToolStripMenuItem.Click += new System.EventHandler(this.异步采集ToolStripMenuItem_Click);
            // 
            // 回调采集ToolStripMenuItem
            // 
            this.回调采集ToolStripMenuItem.Name = "回调采集ToolStripMenuItem";
            this.回调采集ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.回调采集ToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.回调采集ToolStripMenuItem.Text = "回调采集";
            this.回调采集ToolStripMenuItem.Click += new System.EventHandler(this.回调采集ToolStripMenuItem_Click);
            // 
            // 同步采集ToolStripMenuItem
            // 
            this.同步采集ToolStripMenuItem.Name = "同步采集ToolStripMenuItem";
            this.同步采集ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.同步采集ToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.同步采集ToolStripMenuItem.Text = "同步采集";
            // 
            // 数据侦听ToolStripMenuItem
            // 
            this.数据侦听ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.无放大ToolStripMenuItem,
            this.放大侦听ToolStripMenuItem});
            this.数据侦听ToolStripMenuItem.Enabled = false;
            this.数据侦听ToolStripMenuItem.Name = "数据侦听ToolStripMenuItem";
            this.数据侦听ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.数据侦听ToolStripMenuItem.Text = "侦听";
            // 
            // 无放大ToolStripMenuItem
            // 
            this.无放大ToolStripMenuItem.Name = "无放大ToolStripMenuItem";
            this.无放大ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.无放大ToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.无放大ToolStripMenuItem.Text = "无放大侦听";
            this.无放大ToolStripMenuItem.Click += new System.EventHandler(this.无放大ToolStripMenuItem_Click);
            // 
            // 放大侦听ToolStripMenuItem
            // 
            this.放大侦听ToolStripMenuItem.Name = "放大侦听ToolStripMenuItem";
            this.放大侦听ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.放大侦听ToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.放大侦听ToolStripMenuItem.Text = "放大侦听";
            this.放大侦听ToolStripMenuItem.Click += new System.EventHandler(this.无放大ToolStripMenuItem_Click);
            // 
            // 历史记录ToolStripMenuItem
            // 
            this.历史记录ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数据写文件ToolStripMenuItem,
            this.异常点记录ToolStripMenuItem,
            this.关闭写数据ToolStripMenuItem,
            this.停止记录异常点ToolStripMenuItem,
            this.数据查看ToolStripMenuItem,
            this.异常点查看ToolStripMenuItem,
            this.运行日志ToolStripMenuItem1});
            this.历史记录ToolStripMenuItem.Name = "历史记录ToolStripMenuItem";
            this.历史记录ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.历史记录ToolStripMenuItem.Text = "记录";
            this.历史记录ToolStripMenuItem.Click += new System.EventHandler(this.历史记录ToolStripMenuItem_Click);
            // 
            // 数据写文件ToolStripMenuItem
            // 
            this.数据写文件ToolStripMenuItem.Name = "数据写文件ToolStripMenuItem";
            this.数据写文件ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.数据写文件ToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.数据写文件ToolStripMenuItem.Text = "数据写文件";
            this.数据写文件ToolStripMenuItem.Click += new System.EventHandler(this.数据写文件ToolStripMenuItem_Click);
            // 
            // 异常点记录ToolStripMenuItem
            // 
            this.异常点记录ToolStripMenuItem.Name = "异常点记录ToolStripMenuItem";
            this.异常点记录ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.异常点记录ToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.异常点记录ToolStripMenuItem.Text = "异常点记录";
            this.异常点记录ToolStripMenuItem.Click += new System.EventHandler(this.异常点记录ToolStripMenuItem_Click);
            // 
            // 关闭写数据ToolStripMenuItem
            // 
            this.关闭写数据ToolStripMenuItem.Enabled = false;
            this.关闭写数据ToolStripMenuItem.Name = "关闭写数据ToolStripMenuItem";
            this.关闭写数据ToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.关闭写数据ToolStripMenuItem.Text = "关闭写数据";
            this.关闭写数据ToolStripMenuItem.Click += new System.EventHandler(this.关闭写数据ToolStripMenuItem_Click);
            // 
            // 停止记录异常点ToolStripMenuItem
            // 
            this.停止记录异常点ToolStripMenuItem.Enabled = false;
            this.停止记录异常点ToolStripMenuItem.Name = "停止记录异常点ToolStripMenuItem";
            this.停止记录异常点ToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.停止记录异常点ToolStripMenuItem.Text = "停止记录异常点";
            this.停止记录异常点ToolStripMenuItem.Click += new System.EventHandler(this.停止记录异常点ToolStripMenuItem_Click);
            // 
            // 数据查看ToolStripMenuItem
            // 
            this.数据查看ToolStripMenuItem.Name = "数据查看ToolStripMenuItem";
            this.数据查看ToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.数据查看ToolStripMenuItem.Text = "数据查看";
            this.数据查看ToolStripMenuItem.Click += new System.EventHandler(this.数据查看ToolStripMenuItem_Click);
            // 
            // 异常点查看ToolStripMenuItem
            // 
            this.异常点查看ToolStripMenuItem.Name = "异常点查看ToolStripMenuItem";
            this.异常点查看ToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.异常点查看ToolStripMenuItem.Text = "异常点查看";
            this.异常点查看ToolStripMenuItem.Click += new System.EventHandler(this.异常点查看ToolStripMenuItem_Click);
            // 
            // 运行日志ToolStripMenuItem1
            // 
            this.运行日志ToolStripMenuItem1.Name = "运行日志ToolStripMenuItem1";
            this.运行日志ToolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
            this.运行日志ToolStripMenuItem1.Text = "运行日志";
            this.运行日志ToolStripMenuItem1.Click += new System.EventHandler(this.运行日志ToolStripMenuItem1_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.帮助ToolStripMenuItem});
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.帮助ToolStripMenuItem.Text = "帮助";
            this.帮助ToolStripMenuItem.Click += new System.EventHandler(this.帮助ToolStripMenuItem_Click);
            // 
            // timer1data写文件
            // 
            this.timer1data写文件.Interval = 1000;
            this.timer1data写文件.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2point写文件
            // 
            this.timer2point写文件.Interval = 1000;
            this.timer2point写文件.Tick += new System.EventHandler(this.timer2point写文件_Tick);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 545);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.StartBand);
            this.Controls.Add(this.DataList);
            this.Controls.Add(this.StartCollect);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "ServerForm";
            this.Tag = "";
            this.Text = "光纤数据采集服务器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerForm_FormClosing);
            this.Load += new System.EventHandler(this.ServerForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartCollect;
        private System.Windows.Forms.TextBox DataList;
        private System.Windows.Forms.Button StartBand;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 启动板卡ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 基本配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 参数设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 采集方式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据侦听ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 历史记录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 配置1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 异步采集ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 回调采集ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 无放大ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 放大侦听ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 采样点数量ToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripMenuItem 扫描采样间隔ToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox2;
        private System.Windows.Forms.ToolStripMenuItem 数据写文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 异常点记录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem 更多模式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 软触发ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 缓存设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 单缓存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 双缓存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据查看ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 异常点查看ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 运行日志ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 数据写文件间隔ToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox3;
        private System.Windows.Forms.ToolStripMenuItem 异常点记录间隔ToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox4;
        private System.Windows.Forms.Timer timer1data写文件;
        private System.Windows.Forms.Timer timer2point写文件;
        private System.Windows.Forms.ToolStripMenuItem 关闭写数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 停止记录异常点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 同步采集ToolStripMenuItem;
    }
}

