using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string emailCode = System.Guid.NewGuid().ToString();

            string link = "http://www.baidu.com";

            string emailContent = "尊敬的灌篮App用户，您好:<br/><br/>感谢您注册成为灌篮的用户<br/>您的帐号名称为:" + user.UserName + "<br/>我们需要对您的邮箱地址有效性进行验证，以免地址被滥用。<br/>点击以下链接进行认证<br/><a href='" + link + "'>验证地址</a><br/>如果无法正常跳转，请直接复制url完整信息到浏览器里打开，完成邮箱认证。<br/>" + link + "<br/><br/> -- 灌篮App开发团队";

            try
            {
                //WXSSK.Common.SendEmail.SendMails(config.EmailHost, config.EmailFromName, config.EmailFromAccount, config.EmailFromAccountPassword,
                //    config.EmailFromNickName, user.Email, "请确认您的邮箱", emailContent, new Action(EmailError));
                Common.SendEmail.SendMails("smtp.126.com", "guanlanapp@126.com", "guanlanapp", "guanlanapp2014",
                    "灌篮APP", user.Email, "请确认您的邮箱", emailContent, new Action(EmailError));

            }

        }
    }
}
