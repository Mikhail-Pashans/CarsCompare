using CarsCompare.Database;
using CarsCompare.UI.Cache;
using Ninject;
using System;
using System.Web.Mvc;

namespace CarsCompare.UI
{
    public class NinjectControllerFactory : DefaultControllerFactory, IDisposable
    {
        private readonly IKernel _ninjectKernel;

        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)_ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            _ninjectKernel.Bind<IUnitOfWork>().To<EfUnitOfWork>();
            _ninjectKernel.Bind<ICacheService>().To<InMemoryCache>();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                _ninjectKernel.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}