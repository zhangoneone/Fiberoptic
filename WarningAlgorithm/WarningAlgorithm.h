// ���� ifdef ���Ǵ���ʹ�� DLL �������򵥵�
// ��ı�׼�������� DLL �е������ļ��������������϶���� WARNINGALGORITHM_EXPORTS
// ���ű���ġ���ʹ�ô� DLL ��
// �κ�������Ŀ�ϲ�Ӧ����˷��š�������Դ�ļ��а������ļ����κ�������Ŀ���Ὣ
// WARNINGALGORITHM_API ������Ϊ�Ǵ� DLL ����ģ����� DLL ���ô˺궨���
// ������Ϊ�Ǳ������ġ�
#ifdef WARNINGALGORITHM_EXPORTS
#define WARNINGALGORITHM_API __declspec(dllexport)
#else
#define WARNINGALGORITHM_API __declspec(dllimport)
#endif

// �����Ǵ� WarningAlgorithm.dll ������
class WARNINGALGORITHM_API CWarningAlgorithm {
public:
	CWarningAlgorithm(void);
	// TODO: �ڴ�������ķ�����
};

extern WARNINGALGORITHM_API int nWarningAlgorithm;

WARNINGALGORITHM_API int fnWarningAlgorithm(void);
