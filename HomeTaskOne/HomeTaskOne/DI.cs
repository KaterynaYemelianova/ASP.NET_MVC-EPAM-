using Autofac;

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

            Services = builder.Build();
        }
    }
}