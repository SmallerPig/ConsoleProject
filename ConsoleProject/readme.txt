���Ӽ�¼

2014��11��26��14:40:30 �� �޸�admin��½ҳĬ�ϵ�½��ť�޵�½�¼���bug
2014��11��26��14:39:39 �� �޸������ļ�Ĭ��Ϊ����״̬


5�����ӻ����������ࡣ
4�����Admin Area��
3�������ϴ��ؼ���
2������CMSģ�����ݡ�
1��������ʽ�������ʾ��Ϣoldbrowser.html��


��֪���⣺
2014��11��17��11:09:32 ��������Ŀʱ��ý����Զ˿ڸ��ģ�

SQL
CREATE TABLE [dbo].[Admin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](250) NOT NULL,
	[Password] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

INSERT INTO [dbo].[Admin]("UserName","Password") values("admin","cbWwnCsPNX2HCXnBSsCZKw==")