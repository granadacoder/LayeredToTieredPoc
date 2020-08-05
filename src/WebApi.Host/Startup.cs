namespace MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.WebApi.Host
{
    using System;
    using System.Web.Http;

    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.WebApi.BusinessServices.Managers;

    using Owin;

    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            Type departmentBusinessServiceControllerType = typeof(DepartmentBusinessServiceController);

            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                ////routeTemplate: "api/{controller}/{id}",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional });

            appBuilder.UseWebApi(config);
        }
    }
}