// ���� ifdef ���Ǵ���ʹ�� DLL �������򵥵�
// ��ı�׼�������� DLL �е������ļ��������������϶���� DATAHANDLE_EXPORTS
// ���ű���ġ���ʹ�ô� DLL ��
// �κ�������Ŀ�ϲ�Ӧ����˷��š�������Դ�ļ��а������ļ����κ�������Ŀ���Ὣ
// DATAHANDLE_API ������Ϊ�Ǵ� DLL ����ģ����� DLL ���ô˺궨���
// ������Ϊ�Ǳ������ġ�
#ifdef DATAHANDLE_EXPORTS
#define DATAHANDLE_API __declspec(dllexport)
#else
#define DATAHANDLE_API __declspec(dllimport)
#endif

// �����Ǵ� DataHandle.dll ������
class DATAHANDLE_API CDataHandle {
public:
	CDataHandle(void);
	// TODO: �ڴ�������ķ�����
};

extern DATAHANDLE_API int nDataHandle;

DATAHANDLE_API int fnDataHandle(void);
