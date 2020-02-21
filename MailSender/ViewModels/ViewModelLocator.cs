using System;
using System.Collections.Generic;
using System.Text;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using MailSender.lib.Services;
using MailSender.lib.Services.InMemory;
using MailSender.lib.Services.Interfaces;

namespace MailSender.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {

            //механизм инверсии управления внедрения зависимостей, для связывания логики различных кусков приложения
            
            
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default); //контейнер сервисов

        

            var services = SimpleIoc.Default;

            services.Register<MainWindowViewModel>();
            //регистрируем интерфейсы
            services.Register<IRecipientsManager, RecipientsManager>();  //IRecipientsManager  -интерфейс и его реализация RecipientsManager
            services.Register<IRecipientsStore, RecipientsStoreInMemory>();
        }


        //связь моделей с визуальными элементами
        public MainWindowViewModel MainWindowModel => ServiceLocator.Current.GetInstance<MainWindowViewModel>();


        //для реализации какой либо функциональности 
        // 1. создаем это интерфейс для сервиса
        // 2. реализация интерфейса
        // 3. регистрируем ее в контейнере и используем в программе
    }
}

