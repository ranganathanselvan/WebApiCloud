using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;

namespace WebApiCloud.App_Start
{

    /// <summary>
    /// DependencyScope
    /// </summary>
    public class DependencyScope : IDependencyScope
    {
        /// <summary>
        /// readonly IContainer
        /// </summary>
        public readonly IContainer container;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="container"></param>
        public DependencyScope(IContainer container)
        {
            this.container = container;
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            if(container != null)
            {
                container.Dispose();
            }
        }

        /// <summary>
        /// Get Service
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            return serviceType.IsAbstract || serviceType.IsInterface
                ? container.TryGetInstance(serviceType)
                : container.GetInstance(serviceType);
        }

        /// <summary>
        /// Get Services
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return container.GetAllInstances(serviceType).Cast<object>();
        }
    }

    /// <summary>
    /// DependencyResolver
    /// </summary>
    public class DependencyResolver : DependencyScope, IDependencyResolver
    {
        /// <summary>
        /// readonly IContainer
        /// </summary>
        private readonly IContainer container;

        /// <summary>
        /// Dependency Resolver
        /// </summary>
        /// <param name="container"></param>
        public DependencyResolver(IContainer container) : base(container.GetNestedContainer())
        {
            this.container = container;
        }

        /// <summary>
        /// Begin Scope
        /// </summary>
        /// <returns></returns>
        public IDependencyScope BeginScope()
        {
            var nestedContainer = this.container.GetNestedContainer();
            return new DependencyScope(nestedContainer);
        }
    }
}