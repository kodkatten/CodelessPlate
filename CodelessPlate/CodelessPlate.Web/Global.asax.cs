using System.Web.Mvc;
using System.Web.Routing;
using CodelessPlate.Data;
using LightInject;

namespace CodelessPlate
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var container = new ServiceContainer();

            container.RegisterControllers();
            container.RegisterInstance<IRavenInstance>(RavenInstance.Current);

            container.EnableMvc();
        }
    }
}
