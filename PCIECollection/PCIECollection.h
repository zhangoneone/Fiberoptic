#include "stdafx.h"
#include "Wd-dask.h"
#include <windows.h>
#ifndef MYDLL_EXPORTS
#define MYDLL_API __declspec(dllexport)
#else
#define MYDLL_API __declspec(dllimport)
#endif
typedef enum{
	Config_OK=0x00,
	Register_card_err=0x01,
	AI_CH_Config=0x02,
	AI_Config=0x03,
	AI_Trig_Config=0x04,
	AI_ContBufferSetup=0x05,
	Save_tofile_failed=0x06
}Config_Err_Mask;//0x00表示正常返回

typedef enum{
	Register_code=0x00,
	Logout_code=0x01,
	Set_code=0x02,
	Get_code=0x03,
	Response_code=0x04
}Class_Code;

typedef enum{
	Collection_num=0x00,
	SampIntv=0x01,
}Command_Code;

typedef enum{

}Data;

typedef struct{
		short class_code:3;
		short command_code:5;
		short data:8;
}protocol;

typedef struct{
	int collection_num;//采集点数量
	int sampIntv;//采样间隔

}ConfigSession;//c#发送的配置结构体

typedef struct
{
	protocol prl;
	ConfigSession configSession;
	bool buff_is_valid;
	void *buffer;
}CollectionSession;

//DataCollection类
class DataCollection{
public:	
	static DataCollection *GetSingleton();//单例模式
	static DataCollection GetInstance(){return *GetSingleton();}
	int register_Card();//注册采集卡
	int logout_Card();//注销采集卡
	int base_config();//采集卡基本配置
	int re_config(DataCollection &dc);//采集卡重新配置
	int data_save_tofile(const char *filename,short *buffer);//数据保存到文件
	int data_emit();//数据发送
	DWORD WINAPI CollectionCallback(LPVOID lpParamter);//调用windows api的多线程回调函数
	friend int proxy_for_cPlus(DataCollection &);//友元函数，代理函数
	int Register_function(DataCollection &dc);
	int Logout_function(DataCollection &dc);
	int Set_function(DataCollection &dc);
	int Get_function(DataCollection &dc);

	CollectionSession *cs;
protected:
private:
	I16 card_num;//采集卡编号
	I16 m_dev;//设备编号
	U16 buf_id;//buff的id
	U32 buffernum;//采集点数量
	U32 startPos;//buff要用
	U32 accessCnt;//buff要用
	U32 scantlv;//扫描间隔
	U32 samptvl;//采样间隔
	BOOLEAN stopped;//异步采集通知标志位
	short data_buffer[];//采集卡数据
	static DataCollection * m_singleton ;
	DataCollection();
	DataCollection(int num);//构造函数
	DataCollection(const DataCollection &){}//复制构造函数
	~DataCollection(void);//析构函数
};
DataCollection *DataCollection::m_singleton=NULL;
HANDLE hMutex = NULL;//互斥量

extern "C" MYDLL_API  CollectionSession proxy(CollectionSession *cs);

typedef struct
{
	protocol prl;
	ConfigSession configSession;
	bool buff_is_valid;
	void *buffer;
}test;

extern "C" MYDLL_API  test proxyx(test *cs);