using Autofac;
using NTTS.Services.Infrastructure;

namespace NTTS.UI.WPF.ViewModels
{
    public class ViewModelLocator
    {
        private readonly IContainer container;
        public ViewModelLocator()
        {
            // Autofac dependecy injection

            var builder = new ContainerBuilder();
            builder.RegisterModule<ServicesModule>();
            builder.RegisterType<MainViewModel>().SingleInstance();
            builder.RegisterType<StartViewModel>().SingleInstance();
            builder.RegisterType<TicketInformationViewModel>().SingleInstance();
            builder.RegisterType<SeatingViewModel>().SingleInstance();

            container = builder.Build();
            container.Resolve<MainViewModel>();
            container.Resolve<StartViewModel>();
            container.Resolve<TicketInformationViewModel>();
            container.Resolve<SeatingViewModel>();
        }

        public MainViewModel Main => container.Resolve<MainViewModel>();
        public StartViewModel Start => container.Resolve<StartViewModel>();
        public TicketInformationViewModel TicketInformation => container.Resolve<TicketInformationViewModel>();
        public SeatingViewModel Seating => container.Resolve<SeatingViewModel>();
    }
}
