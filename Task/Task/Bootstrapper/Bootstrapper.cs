using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Task.Services;
using Task.ViewModels.Interface;

namespace Task.Bootstrapper
{
    public static class Bootstrapper
    {
        private static ILifetimeScope rootScope;

        public static IMainViewModel RootVisual
        {
            get
            {
                if (rootScope == null)
                    Run();
               
                    return rootScope.Resolve<IMainViewModel>();

            }
        }
        public static void Run()
        {
            if (rootScope != null)
                return;
            rootScope = ContainerPreparer.PrepareContainer();


        }

    
    }
}
