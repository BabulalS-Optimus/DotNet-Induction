using MvcPattern.App_Start;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcPattern
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();

            Router.RegisterRoutes(RouteTable.Routes);
            WebApiConfig.Register(System.Web.Http.GlobalConfiguration.Configuration);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}