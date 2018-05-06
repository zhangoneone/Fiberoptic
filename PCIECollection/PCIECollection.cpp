// PCIECollection.cpp : ���� DLL Ӧ�ó���ĵ���������
#include "stdafx.h"
#include "PCIECollection.h"
#include "Wd-dask.h"
#include <fstream>
#include<string>
using namespace std;
//���캯��
DataCollection::DataCollection()
{
	card_num = 0;
	buffernum = 4000;
	stopped=0;
	cs->buff_is_valid=false;
	cs->prl.class_code=cs->prl.command_code=cs->prl.data=0;//��ʼ��Э����
	cs->buffer = new short[buffernum];//����buf��С
}
DataCollection::DataCollection(int num)
{
	card_num = 0;
	buffernum=num;
	stopped=0;
	cs->buff_is_valid=false;
	cs->prl.class_code=cs->prl.command_code=cs->prl.data=0;//��ʼ��Э����
	cs->buffer = new short[buffernum];//����buf��С
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
	}//����ģʽ
int DataCollection::register_Card()
{
	m_dev = WD_Register_Card (PCIe_9842, card_num);

	if(m_dev < 0)
	{
		WD_Release_Card(m_dev);//�ͷ��豸
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
		 	 //-1���������ŵ���0-7�ŵ�
			 //+-5V
	 ret = WD_AI_CH_Config(m_dev,-1,AD_B_1_V);
	 if(ret < 0)
	 {
		 WD_Buffer_Free (m_dev, data_buffer);//�ͷ�buffer
		 WD_Release_Card(m_dev);//�ͷ��豸
		 return AI_CH_Config;
	 }
			//����2 ѡ��ʱ��Դ���˴�Ϊ�ڲ�ʱ��Դ
			//����3 �Ƿ񼤻� ad dutyѭ���ָ�
			//����4 adת��Դ��ѡ��
			//����5 �Ƿ���ad ping pongģʽ
			//����6 ģ��������ɺ��Ƿ�����ģ��ai�Ļ���
	ret = WD_AI_Config(m_dev,WD_IntTimeBase, true,WD_AI_ADCONVSRC_TimePacer, false, true);
	if(ret < 0)
	{
		 WD_Buffer_Free (m_dev, data_buffer);//�ͷ�buffer
		 WD_Release_Card(m_dev);//�ͷ��豸
		 return AI_Config;
	}
            //���ô���Դ ģʽ ���ܣ��������κ�ai֮ǰ���øú���
            //2����ģʽֻ��ѡ��delay ����post ����0x00��post 0x03��delay
            //3 ����Դ ��ѡsoft���� �ⲿ���� ssi���������֣� ������Ӧ0 2 3 4
            //4 �������½��ش��� 1������ 0�½���
            //5 �ŵ�ѡ��
            //6 ������ֵѡ�� �����ź�������ֵѡ����0-3.3.Ĭ��1.67
            //7 �������м䴥���������˴���ʱ�䴫������������
            //8 û����
            //9 �¼��������ӳ�x��tick��ִ�У�
            //10 
	ret = WD_AI_Trig_Config(m_dev, 0, 2, 1, 0, 1.0, 0, 0, 0, 1);
    if (ret < 0)
     {
		 WD_Buffer_Free (m_dev, data_buffer);//�ͷ�buffer
		 WD_Release_Card(m_dev);//�ͷ��豸
		 return AI_Trig_Config;
     }
            //ÿ����һ�θú���������һ��ai���棬���������������ϵ�ai���������
            //2.�洢���ݵĻ����׵�ַ���õ�ַ��Ҫ16�ֽڶ��롣
            //3.����Ĵ�С(in sample)
            //4 ��ǰ�����Ļ�������
     ret = WD_AI_ContBufferSetup(m_dev, data_buffer, buffernum,&buf_id);//�Խ�ģ�����ݵ�buffer
     if (ret < 0)
      {
		  WD_Buffer_Free(m_dev, data_buffer);     //��������ʧ�ܳ��԰�buffer��С���ô�һ��
          WD_AI_ContBufferReset(m_dev);
          WD_Release_Card(m_dev);
          return AI_ContBufferSetup;
      }
	 CollectionCallback(NULL);//�����ɼ�������������ʹ�ö��̷߳�ʽ
	 return Config_OK;
}
int DataCollection::re_config(DataCollection &dc)
{
	int ret = 0;
	//ע���ɼ���
	if( (ret = logout_Card() )!= 0) goto err;
	//�ж�Ҫ���µ�����ֵ
	switch(dc.cs->prl.command_code)
	{
	case Collection_num:dc.buffernum = dc.cs->configSession.collection_num;break;
	case SampIntv:dc.scantlv = dc.samptvl = dc.cs->configSession.sampIntv;break;
	default:break;
	}
	//����DataCollection��ֵ��ִ��һ��Ĭ�����ã�д����µ�����ֵ������
	if( ( ret = base_config())!=0 ) goto err;
	//���滹Ҫ�����ɼ�����
	///todo
	//�ɼ�����ʹ�ö��̣߳���ѯ��ʽ���ᶨʱˢ�²�������������д�����ֵ
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
DWORD WINAPI DataCollection::CollectionCallback(LPVOID lpParamter)//��ɴӲɼ����ɼ����ݵĹ���
{
    int ret = 0;
    if( ret = WD_AI_ContReadChannel(m_dev, 0, buf_id, buffernum, scantlv, samptvl,ASYNCH_OP)!=0 )goto err;
	do
	{
		//�˺�������ʱ��Լ0.006ms,�˺�������һ�Σ�ֻ��һ�μ��
        //����2 trueʱ�������첽ģ����������������󣬿���ȡ�����ˡ�false�����첽���뻹û�н���
		ret = WD_AI_AsyncCheck(m_dev,&stopped,&accessCnt);//stopΪtrue�����첽ģ���������,ִ���첽����
		if (ret < 0)goto err;
		if (stopped == 1)//�첽�������,��������
		{

			//һ�βɼ���ɣ�֪ͨ��һ������
		}
		//��ָ����Ƶ���Խӽ�ָ�������ʣ�ִ���������ϵ�adת����˫����ģʽ���������ϵ�adת������֧��post��������ʱ����ģʽ
        //����1 ִ�иò����Ŀ�id
        //����2 ģ��Ƶ��id
        //����3 ��buffersetup�������ص�һ��������id�����Ļ������飬�����˲��������
        //����4 ɨ����ܸ�����Ӧ����8�ı���
        //����5 ɨ�����ĳ���/����ֵ 1-65535
        //����6 ��������ĳ���/����ֵ 1-65535
       //����7 ����ͬ�������첽ִ�С���pre-/middle triggerʱ���ú������첽ִ�е�
       //ͬ��ת��ʱ��������������ֱ��adת����ɡ��첽ת��ʱ��������������
		if( ret = WD_AI_ContReadChannel(m_dev, 0, buf_id, buffernum, scantlv, samptvl,ASYNCH_OP)!=0 )goto err;
		stopped = 0;//��0
	} while (true);
err:
	return ret;
}
int DataCollection::Register_function(DataCollection &dc)
{
    //ע����Ϣ������ɲɼ���ע�ᡢ���õ�����
	int ret = 0;
	ret = dc.register_Card();//ע��
	ret = dc.base_config();//Ĭ������
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
//c#���ýӿ�
extern "C" MYDLL_API CollectionSession proxy(CollectionSession *cs)
{
	static DataCollection *dc = DataCollection::GetSingleton();//����ģʽ
	dc->cs=cs;//����c#������CollectionSession
	proxy_for_cPlus(*dc);
	return *(dc->cs);//����CollectionSession
}
extern "C" MYDLL_API  test proxyx(test *cs)
{
	return *cs;
}

//��Ԫ��������Э����
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
