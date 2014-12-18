增加记录

2014年11月26日14:40:30 ： 修复admin登陆页默认登陆按钮无登陆事件的bug
2014年11月26日14:39:39 ： 修改配置文件默认为调试状态


5，增加基础控制器类。
4，添加Admin Area。
3，增加上传控件。
2，增加CMS模板内容。
1，增加老式浏览器提示信息oldbrowser.html。


已知问题：
2014年11月17日11:09:32 创建新项目时最好将调试端口更改！

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