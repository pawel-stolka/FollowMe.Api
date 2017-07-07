using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using FollowMe.Infrastructure.Commands;

namespace FollowMe.Infrastructure.IoC.Modules
{
    public class CommandModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // gets THIS assembly, so one of its method (this CommandModule)
            var assembly = typeof (CommandModule)
                .GetTypeInfo()
                .Assembly;

            // Autofac scans all classes in assembly and matches them 
            // with its implementation - losedType (closure)
            builder.RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof (ICommandHandler<>))
                .InstancePerLifetimeScope();

            builder.RegisterType<CommandDispatcher>()
                .As<ICommandDispatcher>()
                .InstancePerLifetimeScope();
        }
    }
}
