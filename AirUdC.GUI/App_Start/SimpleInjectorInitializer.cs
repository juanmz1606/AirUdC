[assembly: WebActivator.PostApplicationStartMethod(typeof(AirUdC.GUI.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace AirUdC.GUI.App_Start
{
    using AirUdC.Application.Contracts.Contracts.Parameters;
    using AirUdC.Application.Implementation.Implementation.Parameters;
    using AirUdC.Infastructure.Contracts.Contracts.Parameters;
    using AirUdC.Infrastructure.Implementation.Implementation.Parameters;
    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    using System.Web.Mvc;

    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            InitializeContainer(container);
            
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
            //#error Register your services here (remove this line).

            // For instance:
            // container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Scoped);
            container.Register<ICityInfrastructure, CityImplementationInfrastructure>(Lifestyle.Scoped);
            container.Register<ICityApplication, CityImplementationApplication>(Lifestyle.Scoped);

            container.Register<ICountryInfrastructure, CountryImplementationInfrastructure>(Lifestyle.Scoped);
            container.Register<ICountryApplication, CountryImplementationApplication>(Lifestyle.Scoped);

            container.Register<IPropertyOwnerInfrastructure, PropertyOwnerImplementationInfrastructure>(Lifestyle.Scoped);
            container.Register<IPropertyOwnerApplication, PropertyOwnerImplementationApplication>(Lifestyle.Scoped);

            container.Register<IMultimediaTypeInfrastructure, MultimediaTypeImplementationInfrastructure>(Lifestyle.Scoped);
            container.Register<IMultimediaTypeApplication, MultimediaTypeImplementationApplication>(Lifestyle.Scoped);

            container.Register<ICustomerInfrastructure, CustomerImplementationInfrastructure>(Lifestyle.Scoped);
            container.Register<ICustomerApplication, CustomerImplementationApplication>(Lifestyle.Scoped);

            container.RegisterMvcControllers();
        }
    }
}