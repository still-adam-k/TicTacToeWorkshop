using System.Web;
using System.Web.Http;
using WebFrontEnd.App_Start;

namespace WebFrontEnd
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            WebApiConfig.Register(GlobalConfiguration.Configuration);
        }
    }
}