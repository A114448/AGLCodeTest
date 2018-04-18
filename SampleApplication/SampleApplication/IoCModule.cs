using Autofac;
using Autofac.Integration.Mvc;
using SampleApplicationServiceModel;

namespace SampleApplication
{
    public class IoCModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SampleService>().As<ISampleService>().InstancePerHttpRequest();
            builder.RegisterType<LogError>().As<ILogError>().InstancePerHttpRequest();
            base.Load(builder);
        }
    }
}
