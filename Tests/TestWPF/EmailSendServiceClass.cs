using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Security;

namespace TestWPF
{
    class EmailSendServiceClass
    {

        public string message_Subject;
        public string message_Body;
        public string from;
        public string to;
        public string server_address;
        public int server_port;
        public EmailSendServiceClass(string user_name, SecureString user_password)
        {
            message_Subject = WpfTestMailSender.message_subject;
            message_Body = WpfTestMailSender.message_body;
            from = WpfTestMailSender.from;
            to = WpfTestMailSender.to;
            server_address = WpfTestMailSender.server_address;
            server_port = WpfTestMailSender.server_port;
        }
        public void MsgSend(string user_name, SecureString user_password)
        {
            using (var message = new MailMessage(from, to))
            {
                message.Subject = message_Subject;
                message.Body = message_Body;

                using var client = new SmtpClient(server_address, server_port);
                client.EnableSsl = true;               

                client.Credentials = new NetworkCredential(user_name, user_password);
                client.Send(message);
            }
        }
    }
}
