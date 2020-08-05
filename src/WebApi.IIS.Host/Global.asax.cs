namespace MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.WebApi.IIS.Host
{
    using System;
    using System.Web.Http;
    using System.Web.Http.Dispatcher;

    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.WebApi.IIS.Host.ApiConfigs;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.WebApi.IIS.Host.Resolvers;

    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            WebApiConfig.Register(GlobalConfiguration.Configuration);    
            GlobalConfiguration.Configuration.Services.Replace(typeof(IAssembliesResolver), new CustomAssemblyResolver());
        }

        protected void Session_Start(object sender, EventArgs e)
        {
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