using System;
using System.Data.Entity;

using Autofac;

using HomeTaskOne.Data;
using HomeTaskOne.Models.PageModels;

namespace HomeTaskOne
{
    public class DI
    {
        public static IContainer Services { get; private set; }

        public static void Init()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<DefaultNavigationMenuModel>().SingleInstance().As<NavigationMenuModel>();
            //builder.RegisterType<BlogContext>().SingleInstance().As<DbContext>().UsingConstructor(new Type[] { });

            Services = builder.Build();
        }
    }
}