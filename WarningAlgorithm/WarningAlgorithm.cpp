// WarningAlgorithm.cpp : ���� DLL Ӧ�ó���ĵ���������
//

#include "stdafx.h"
#include "WarningAlgorithm.h"


// ���ǵ���������һ��ʾ��
WARNINGALGORITHM_API int nWarningAlgorithm=0;

// ���ǵ���������һ��ʾ����
WARNINGALGORITHM_API int fnWarningAlgorithm(void)
{
	return 42;
}

// �����ѵ�����Ĺ��캯����
// �й��ඨ�����Ϣ������� WarningAlgorithm.h
CWarningAlgorithm::CWarningAlgorithm()
{
	return;
}
