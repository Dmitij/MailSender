using System;
using System.Collections.Generic;
using System.Text;

namespace TestWPF
{
    class WpfTestMailSender
    {

        public static string message_subject = $"Тестовое сообщение от {DateTime.Now}";
        public static string message_body = $"Тело сообщения - {DateTime.Now}";

        public static string from = "gorbunokya@yandex.ru";
        public static string to = "gorbunok2@gmail.com";

        public static string server_address = "smtp.yandex.ru";
        public static int server_port = 25; //25


    }
}
