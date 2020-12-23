[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ClothesStore.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ClothesStore.Web.App_Start.NinjectWebCommon), "Stop")]

namespace ClothesStore.Web.App_Start
{
    using System;
    using System.Web;
    using ClothesStore.Data.Repositories;
    using ClothesStore.Domain;
    using ClothesStore.EF.Repositories;
    using ClothesStore.Domain.Interfaces;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using TestChecker;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using System.Web.ModelBinding;
    using ClothesStore.Domain.Implementations;
    using ClothesStore.Web.Provider;
    using ClothesStore.Data.Entities.OrderAggrigate;
    using FluentValidation;
    using FluentValidation.Mvc;
    using System.Reflection;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application.
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));

            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

 


                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //Validation factory that uses ninject to create validators
            NinjectValidatorFactory ninjectValidatorFactory = new NinjectValidatorFactory(kernel);

            var fluentValidationModelValidatorProvider = new FluentValidationModelValidatorProvider(ninjectValidatorFactory);
            fluentValidationModelValidatorProvider.AddImplicitRequiredValidator = false;

            FluentValidationModelValidatorProvider
              .Configure(x => x.ValidatorFactory = ninjectValidatorFactory);

            DataAnnotationsModelValidatorProvider
              .AddImplicitRequiredAttributeForValueTypes = false;

            AssemblyScanner.FindValidatorsInAssembly(Assembly.GetExecutingAssembly())
                .ForEach(match => kernel.Bind(match.InterfaceType).To(match.ValidatorType));
        


                
            kernel.Bind<IProductRepository>().To<ProductRepository>();
            kernel.Bind<ICartService>().To<CartService>();
            kernel.Bind<IOrderRepository>().To<OrderRepository>();
            kernel.Bind<IOrderService>().To<OrderService>();
            kernel.Bind<IReservationRepository>().To<ReservationRepository>();
            kernel.Bind<IReservationService>().To<ReservationService>();
            kernel.Bind<ICartProvider>().To<CartProvider>();

            // kernel.Bind<Checker>().ToConstant(new Checker(kernel.Get<IReservationRepository>(), kernel.Get<IReservationService>()));
            //kernel.Bind<IValidator<OrderDetails>>().To<OrderDetailsValidator>();



        }
    }
}