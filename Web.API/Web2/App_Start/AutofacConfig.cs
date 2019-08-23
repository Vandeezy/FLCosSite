using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using Entities;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace Web2.App_Start
{
    public class AutofacConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder(), config));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder, HttpConfiguration config)
        {
            // Reference the executing assembly
            var assembly = Assembly.GetExecutingAssembly();

            // Get referenced assemblies
            var referencedAssemblies = AppDomain.CurrentDomain.GetAssemblies();

            //Register Web API controllers.  
            builder.RegisterApiControllers(assembly);

            // Need to resolve D.I into filter attributes
            builder.RegisterWebApiFilterProvider(config);

            //Automapper module
            builder.RegisterModule(new AutoMapperModule());
            builder.Register<FLCosContext>(c => new FLCosContext()).AsSelf().InstancePerLifetimeScope();

            // Register identity related types
            //builder.RegisterType<ApplicationUserManager>().As<IApplicationUserManager>().InstancePerLifetimeScope();
            //builder.RegisterType<ApplicationRoleManager>().As<IApplicationRoleManager>().InstancePerLifetimeScope();
            //builder.RegisterType<ApplicationPermissionManager>().As<IApplicationPermissionManager>().InstancePerLifetimeScope();
            //builder.RegisterType<IdentityContext>().As<IdentityContext>().InstancePerLifetimeScope();
            //builder.RegisterType<IdentityContext>().As<IIdentityContext>().InstancePerLifetimeScope();
            //builder.RegisterType<IdentityRepository>().As<IIdentityRepository>().InstancePerLifetimeScope();
            //builder.RegisterType<ApplicationUserStore>().As<IApplicationUserStore>().InstancePerLifetimeScope();
            //builder.RegisterType<ApplicationRoleStore>().As<IApplicationRoleStore>().InstancePerLifetimeScope();
            //builder.RegisterType<ApplicationPermissionStore>().As<IApplicationPermissionStore>().InstancePerLifetimeScope();

            //builder.RegisterType<ADAuthorizationServerProvider>().As<IOAuthAuthorizationServerProvider>().InstancePerLifetimeScope();

            builder.RegisterType<SportService>().As<ISportService>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            //builder.RegisterType<UserManagementService>().As<IUserManagementService>().InstancePerLifetimeScope();
            //builder.RegisterType<CodeCalculationService>().As<ICodeCalculationService>().InstancePerLifetimeScope();
            //builder.RegisterType<TaxonomyService>().As<ITaxonomyService>().InstancePerLifetimeScope();
            //builder.RegisterType<ManufacturingService>().As<IManufacturingService>().InstancePerLifetimeScope();
            //builder.RegisterType<PathfinderService>().As<IPathfinderService>().InstancePerLifetimeScope();
            //builder.RegisterType<EomService>().As<IEomService>().InstancePerLifetimeScope();
            //builder.RegisterType<PricingService>().As<IPricingService>().InstancePerLifetimeScope();
            //builder.RegisterType<EcnService>().As<IEcnService>().InstancePerLifetimeScope();
            //builder.RegisterType<ProductFeatureListService>().As<IProductFeatureListService>().InstancePerLifetimeScope();
            //builder.RegisterType<ProductRuleSetService>().As<IProductRuleSetService>().InstancePerLifetimeScope();
            //builder.RegisterType<ELogiaService>().As<IELogiaService>().InstancePerLifetimeScope();
            //builder.RegisterType<SapService>().As<ISapService>().InstancePerLifetimeScope();
            //builder.RegisterType<CspsOneService>().As<ICspsOneService>().InstancePerLifetimeScope();
            //builder.RegisterType<CspsTwoService>().As<ICspsTwoService>().InstancePerLifetimeScope();
            //builder.RegisterType<UomService>().As<IUomService>().InstancePerLifetimeScope();

            // Auto apply filter to all controllers
            //builder.Register(c => new AuthorizePermissionFilterAttribute(c.Resolve<IUserManagementService>()))
            //        .AsWebApiAuthorizationFilterFor<ApiController>().InstancePerRequest();

            // Configure Mongo Repository
            //builder.RegisterType<MongoRepository>().As<IProjectionReader>().InstancePerLifetimeScope().WithParameters(new[] {
            //    //new NamedParameter("connectionString", "mongodb://c700m779.go.johnsoncontrols.com:27017"),
            //    new NamedParameter("connectionString", Settings.Default.MongoDBConnection), // "mongodb://localhost:27017"
            //    new NamedParameter("databaseName",  Settings.Default.MongoDBName) // "CSPS2"
            //});

            //// Configure Email Messenger
            //builder.RegisterType<EmailMessenger>().As<INotificationMessenger>().InstancePerLifetimeScope().WithParameters(new[] {
            //    new NamedParameter("mailHub", "mhub1.eu.jci.com"),
            //    new NamedParameter("from", "CSPS@jci.com")
            //});

            //// Configure the ECN Repository
            //builder.RegisterType<EcnRepository>().As<IEcnReader>().InstancePerLifetimeScope().WithParameters(new[] {
            //    new NamedParameter("server", "yorkengmysql00.eng.york.york.com"),
            //    new NamedParameter("database", "ec_report_database"),
            //    new NamedParameter("user", "ecrptadmin"),
            //    new NamedParameter("password", "Disney USA Report T00l")
            //    // new NamedParameter("server", "yorkengmysql01.eng.york.york.com"),
            //    //new NamedParameter("database", "ecn"),
            //    //new NamedParameter("user", "cspsadmin"),
            //    //new NamedParameter("password", "NASA_mission01")
            //});

            //// Configure the eLogia Repository
            //builder.RegisterType<ELogiaRepository>().As<IELogiaReader>().InstancePerLifetimeScope().WithParameters(new[] {
            //    new NamedParameter("server", "J201MI19"),
            //    new NamedParameter("database", "PCUser40"),
            //    new NamedParameter("user", "CSEreports"),
            //    new NamedParameter("password", "prod_report07")
            //});

            //// Configure the CSPS 1.0 reader
            //builder.RegisterType<CSPSOneRepository>().As<ICSPSOneReader>().InstancePerLifetimeScope().WithParameters(new[] {
            //    new NamedParameter("server", Settings.Default.CSPSDBServer),
            //    new NamedParameter("database", Settings.Default.CSPSDBName)
            //});

            // Configure the CSPS 2.0 reader
            builder.RegisterType<FLCosRepository>().As<IFLCosReaderWriter>().InstancePerLifetimeScope().WithParameters(new[] {
                new NamedParameter("server", "M5290656\\SQLEXPRESS"),
                new NamedParameter("database", "FLCos")
            });

            // Configure the SAP reader
            //builder.RegisterType<SAPRepository>().As<ISAPRepository>().InstancePerLifetimeScope();

            //// Configure the SAP reader
            //builder.RegisterType<MapicsService>().As<IMapicsService>().InstancePerLifetimeScope();

            //.WithParameters(new[] {
            //    new NamedParameter("server", Settings.Default.CSPSDBServer),
            //    new NamedParameter("database", Settings.Default.CSPSDBName)
            //});

            // Configure Event Store
            //builder.RegisterType<EventStoreRepository>().As<IRepository>().SingleInstance().WithParameters(new[] {
            //    new NamedParameter("eventStorePort", Settings.Default.EventStorePort),
            //});

            //// Configure message bus
            //builder.RegisterType<MessageDispatcher>().As<IMessageBus>().SingleInstance();

            // Configuring command / event handlers
            //foreach (var a in referencedAssemblies)
            //{
            //    builder.RegisterAssemblyTypes(a).AsClosedTypesOf(typeof(IHandleCommand<>)).AsImplementedInterfaces();
            //    builder.RegisterAssemblyTypes(a).AsClosedTypesOf(typeof(IHandleEvent<>)).AsImplementedInterfaces();

            //    //builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces(typeof(IHandleCommand<>));
            //}

            //builder.RegisterType<DefaultCommandBus>().As<ICommandBus>().InstancePerHttpRequest();
            //builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerHttpRequest();
            //builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerHttpRequest();
            //builder.RegisterAssemblyTypes(typeof(CategoryRepository).Assembly).Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerHttpRequest();
            //var services = Assembly.Load("EFMVC.Domain");
            //builder.RegisterAssemblyTypes(services).AsClosedTypesOf(typeof(ICommandHandler<>)).InstancePerHttpRequest();
            //builder.RegisterAssemblyTypes(services).AsClosedTypesOf(typeof(IValidationHandler<>)).InstancePerHttpRequest();
            //builder.RegisterType<DefaultFormsAuthentication>().As<IFormsAuthentication>().InstancePerHttpRequest();
            //builder.RegisterFilterProvider();


            //Set the dependency resolver to be Autofac.  
            Container = builder.Build();

            return Container;
        }
    }
}