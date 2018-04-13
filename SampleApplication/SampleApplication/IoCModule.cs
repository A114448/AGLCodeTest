using Autofac;
using Autofac.Integration.Mvc;
using SampleApplicationServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleApplication
{
    public class IoCModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<HomeController>().UsingConstructor(typeof(ISampleService));
            builder.RegisterType<SampleService>().As<ISampleService>().InstancePerHttpRequest();
            base.Load(builder);
        }
    }
}
