using Autofac;

namespace NTTS.UI.WPF.ViewModels
{
    public class ViewModelLocator
    {
        private readonly IContainer container;
        public ViewModelLocator()
        {
            // Autofac dependecy injection

            var builder = new ContainerBuilder();
            builder.RegisterType<MainViewModel>().SingleInstance();
            builder.RegisterType<StartViewModel>().SingleInstance();

            container = builder.Build();
        }

        public MainViewModel Main => container.Resolve<MainViewModel>();
        public StartViewModel Start => container.Resolve<StartViewModel>();
    }
}
