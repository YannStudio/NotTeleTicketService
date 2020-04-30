using Autofac;

namespace NTTS.Services.Infrastructure
{
    public class ServicesModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {           
            builder.RegisterType<EventService>().AsImplementedInterfaces();
            builder.RegisterType<SeatingService>().AsImplementedInterfaces();
        }
    }
}
