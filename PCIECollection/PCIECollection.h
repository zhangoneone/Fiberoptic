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
}Config_Err_Mask;//0x00��ʾ��������

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
	int collection_num;//�ɼ�������
	int sampIntv;//�������

}ConfigSession;//c#���͵����ýṹ��

typedef struct
{
	protocol prl;
	ConfigSession configSession;
	bool buff_is_valid;
	void *buffer;
}CollectionSession;

//DataCollection��
class DataCollection{
public:	
	static DataCollection *GetSingleton();//����ģʽ
	static DataCollection GetInstance(){return *GetSingleton();}
	int register_Card();//ע��ɼ���
	int logout_Card();//ע���ɼ���
	int base_config();//�ɼ�����������
	int re_config(DataCollection &dc);//�ɼ�����������
	int data_save_tofile(const char *filename,short *buffer);//���ݱ��浽�ļ�
	int data_emit();//���ݷ���
	DWORD WINAPI CollectionCallback(LPVOID lpParamter);//����windows api�Ķ��̻߳ص�����
	friend int proxy_for_cPlus(DataCollection &);//��Ԫ������������
	int Register_function(DataCollection &dc);
	int Logout_function(DataCollection &dc);
	int Set_function(DataCollection &dc);
	int Get_function(DataCollection &dc);

	CollectionSession *cs;
protected:
private:
	I16 card_num;//�ɼ������
	I16 m_dev;//�豸���
	U16 buf_id;//buff��id
	U32 buffernum;//�ɼ�������
	U32 startPos;//buffҪ��
	U32 accessCnt;//buffҪ��
	U32 scantlv;//ɨ����
	U32 samptvl;//�������
	BOOLEAN stopped;//�첽�ɼ�֪ͨ��־λ
	short data_buffer[];//�ɼ�������
	static DataCollection * m_singleton ;
	DataCollection();
	DataCollection(int num);//���캯��
	DataCollection(const DataCollection &){}//���ƹ��캯��
	~DataCollection(void);//��������
};
DataCollection *DataCollection::m_singleton=NULL;
HANDLE hMutex = NULL;//������

extern "C" MYDLL_API  CollectionSession proxy(CollectionSession *cs);

typedef struct
{
	protocol prl;
	ConfigSession configSession;
	bool buff_is_valid;
	void *buffer;
}test;

extern "C" MYDLL_API  test proxyx(test *cs);