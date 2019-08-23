using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Web2.App_Start
{
    public class AutoMapperModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
           
            // With ugly hack to avoid problem with ILMarge
            builder.RegisterAssemblyTypes(typeof(AutoMapperModule).Assembly)
                .Where(x => !x.IsAbstract)      // to avoid abstract Profile class
                .Where(t => !t.IsNestedPrivate) // to avoid private nested MapperConfiguration+NamedProfile class
                .AssignableTo(typeof(Profile)).As<Profile>();

            //builder.RegisterInstance(new EvaluationProfile ()).As<Profile>();


            builder.Register(context => new MapperConfiguration(cfg =>
            {
                foreach (var profile in context.Resolve<IEnumerable<Profile>>())
                {
                    cfg.AddProfile(profile);
                }
            })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve))
                .As<IMapper>()
                .InstancePerLifetimeScope();
        }
    }
}