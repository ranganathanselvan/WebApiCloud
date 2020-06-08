using StructureMap;
using WebApiCloud.Services;

namespace WebApiCloud.App_Start
{ 
    /// <summary>
    /// Default Registry
    /// </summary>
    public class DefaultRegistry : Registry
    {
        /// <summary>
        /// IContainer property
        /// </summary>
        public IContainer Container { get; protected set; }

        /// <summary>
        /// Constructor 
        /// </summary>
        public DefaultRegistry()
        {
            Container = new Container(_ =>
            {
                _.For<IUserService>().Use<UserService>();
            });
        }
    }
}