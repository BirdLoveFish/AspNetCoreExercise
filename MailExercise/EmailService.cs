using MailExercise.Services;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailExercise
{
    public class EmailService : IEmailService
    {
        public void Send(string address, string code)
        {
            var messageToSend = new MimeMessage();

            messageToSend.From.Add(new MailboxAddress("飞鸟慕鱼", "531047332@qq.com"));
            messageToSend.To.Add(new MailboxAddress(address));

            messageToSend.Subject = string.Format("C#自动发送邮件测试");
            messageToSend.Body = new TextPart(TextFormat.Html)
            {
                Text = "<p>请点击下面的链接:</p><p>http://localhost:5000/home/validation?email=" + address + "&code=" + code +"</p>"
            };


            using (var smtp = new SmtpClient())
            {
                smtp.MessageSent += (sender, args) =>
                {
                    Console.WriteLine("success");
                };
                smtp.AuthenticationMechanisms.Remove("XOAUTH2");
                smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;
                smtp.Connect("smtp.qq.com", 465, true);
                smtp.Authenticate("531047332@qq.com", "pfoqhmypjratbhjc");
                smtp.Send(messageToSend);
                smtp.Disconnect(true);
            }
        }
    }
}
