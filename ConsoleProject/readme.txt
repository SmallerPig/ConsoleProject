���Ӽ�¼

2015��10��19��17:16:28 �� ���Ӻ�̨�ı༭��Ԫ
2014��11��26��14:40:30 �� �޸�admin��½ҳĬ�ϵ�½��ť�޵�½�¼���bug
2014��11��26��14:39:39 �� �޸������ļ�Ĭ��Ϊ����״̬


5�����ӻ����������ࡣ
4�����Admin Area��
3�������ϴ��ؼ���
2������CMSģ�����ݡ�
1��������ʽ�������ʾ��Ϣoldbrowser.html��


��֪���⣺
2014��11��17��11:09:32 ��������Ŀʱ��ý����Զ˿ڸ��ģ�

--SQL
--Admin
CREATE TABLE [dbo].[Admin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreateTime] [datetime] NOT NULL DEFAULT getdate(),
	[UserName] [nvarchar](250) NOT NULL,
	[Password] [nvarchar](250) NOT NULL,
	[Status] [int] NOT NULL DEFAULT 1,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

INSERT INTO [dbo].[Admin]("UserName","Password") values("admin","cbWwnCsPNX2HCXnBSsCZKw==")

-- LoginLog

CREATE TABLE [dbo].[LoginLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreateTime] [datetime] NOT NULL DEFAULT getdate(),
	[UserName] [nvarchar](50) NOT NULL,
	[IpAddress] [nvarchar](50) NOT NULL,
	[Status] [int] NOT NULL DEFAULT 1,
 CONSTRAINT [PK_LoginLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
