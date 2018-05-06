//导入环境配置、链接库里的驱动函数
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
namespace FiberopticServer
{
    static class importdll
    {
    enum Config_Err_Mask{
	Config_OK=0x00,
	Register_card_err=0x01,
	AI_CH_Config=0x02,
	AI_Config=0x03,
	AI_Trig_Config=0x04,
	AI_ContBufferSetup=0x05,
	Save_tofile_failed=0x06
};//0x00表示正常返回

enum Class_Code{
	Register_code=0x00,
	Logout_code=0x01,
	Set_code=0x02,
	Get_code=0x03,
	Response_code=0x04
};

enum Command_Code{
	 Collection_num=0x00,
	 SampIntv=0x01,
};

enum Data{

};

public struct protocol{
    public Int16 class_code;
    public Int16 command_code;
    public Int16 data;
};

public struct ConfigSession{
    public System.Int32 collection_num;//采集点数量
    public System.Int32 sampIntv;//采样间隔

};//c#发送的配置结构体

public struct CollectionSession
{
	public protocol prl;
	public ConfigSession configSession;
    public Int32 buff_is_valid;
    public System.IntPtr buffer;
};
public struct test
{
    public protocol prl;
    public ConfigSession configSession;
    Int32 buff_is_valid;
    public System.IntPtr buffer;
};
        [DllImport("PCIECollection.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern CollectionSession proxy(ref CollectionSession cs);
        [DllImport("PCIECollection.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern test proxyx(ref test cs);
    }
}
