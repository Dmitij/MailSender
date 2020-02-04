﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Mail;
using System.Security;


namespace TestWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void OnSendButtonClick(object sender, RoutedEventArgs e)
        {
            string message_subject = WpfTestMailSender.message_subject;
            string message_body = WpfTestMailSender.message_body;

            string from = WpfTestMailSender.from;
            string to = WpfTestMailSender.to;
            
            try
            {   
                EmailSendServiceClass mail = new EmailSendServiceClass(UserNameEdit.Text, PasswordEdit.SecurePassword);
                mail.MsgSend(UserNameEdit.Text, PasswordEdit.SecurePassword);
                //MessageBox.Show("Почта отправлена!", "Ура!!!", MessageBoxButton.OK, MessageBoxImage.Information);
                MsgShow("Почта отправлена! Ура!!!", Brushes.Green);
                

            }
            catch (Exception error)
            {
                //MessageBox.Show(error.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                MsgShow(error.Message, Brushes.Red);
            }
        }

        private void MsgShow(string msg, Brush msgcolor)
        {
            MsgWindow MsgWindow = new MsgWindow();
            //Теперь MainWindow главное окно для taskWindow
            MsgWindow.Owner = this;
            MsgWindow.tbMsg.Text = msg;
            MsgWindow.tbMsg.Foreground = msgcolor; 
            MsgWindow.Show();
        }
       
    }
}
