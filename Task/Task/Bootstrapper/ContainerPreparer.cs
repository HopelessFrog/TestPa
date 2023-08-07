using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Task.Services;
using Task.Services.Interfaces;
using Task.ViewModels;
using Task.ViewModels.Interface;

namespace Task.Bootstrapper
{
    public static class ContainerPreparer
    {
        private static void Prepare(ContainerBuilder builder)
        {
            builder.RegisterType<MainViewModel>().As<IMainViewModel>();
            builder.RegisterType<OfferParser>().As<IOfferParser>();
            builder.RegisterType<DialogService>().As<IDialogService>();


        }
        public static IContainer PrepareContainer()
        {
            var builder = new ContainerBuilder();
            Prepare(builder);
            return builder.Build();
        }
    }
}
