using System.Reflection;
using Autofac;

namespace RepositoryAndUnitOfWorkTechBrij.Web.Modules
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("Demo.Repository"))
                  .Where(t => t.Name.EndsWith("Repository"))
                  .AsImplementedInterfaces()
                 .InstancePerLifetimeScope();
        }
    }
}