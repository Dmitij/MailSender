using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MailSender
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //тут можно переопределить методы OnStarup OnExit
        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    base.OnStartup(e); //e - массив аргументов командной строки с которыми было запущено приложение
        //    Environment.GetCommandLineArgs...; // - аргументы командной строки 
        //}
        //protected override void OnExit(ExitEventArgs e)
        //{
        //    base.OnExit(e);
        //    e.ApplicationExitCode = 42;  //код выхода из приложения
        //}
    }
}
