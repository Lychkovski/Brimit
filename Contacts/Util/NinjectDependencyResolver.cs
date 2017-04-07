using Ninject;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Contacts.Domain;
using Contacts.Domain.Interfaces;
using Contacts.Infrastructure.Data;
using Contacts.Services.Interfaces;
using Contacts.Infrastructure.Business;

namespace Contacts.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IContactRepository>().To<ContactRepository>();
            kernel.Bind<IBusinessInterface>().To<BusinessLogic>();
        }
    }
}