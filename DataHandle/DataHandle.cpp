// DataHandle.cpp : ���� DLL Ӧ�ó���ĵ���������
//

#include "stdafx.h"
#include "DataHandle.h"


// ���ǵ���������һ��ʾ��
DATAHANDLE_API int nDataHandle=0;

// ���ǵ���������һ��ʾ����
DATAHANDLE_API int fnDataHandle(void)
{
	return 42;
}

// �����ѵ�����Ĺ��캯����
// �й��ඨ�����Ϣ������� DataHandle.h
CDataHandle::CDataHandle()
{
	return;
}
