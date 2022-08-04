using Autofac;
using UserProject.Core.Models;
using UserProject.Core.Repositories;
using UserProject.Core.Services;
using UserProject.Core.UnitOfWorks;
using UserProject.Repository;
using UserProject.Repository.Repositories;
using UserProject.Repository.UnitOfWorks;
using UserProject.Service.Services;
using System.Reflection;
using Module = Autofac.Module;
using UserProject.Service.Validations;

namespace UserProject.API.Modules
{
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(UserValidator));
            var coreAssembly = Assembly.GetAssembly(typeof(User));

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly, coreAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly, coreAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();


            //InstancePerLifetimeScope => scope
            //InstancePerDependency => transient
        }
    }
}
