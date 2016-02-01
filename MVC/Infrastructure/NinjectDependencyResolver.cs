using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ModelEmployees.Abstract;
using ModelEmployees.Data;
using ModelEmployees.Entities;

namespace MVC.Infrastructure
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
            kernel.Bind<IEmployeeRepository>().To<EFEmployeeRepository>();
            kernel.Bind<ITax>().To<TaxSalary>();
        }
    }
}