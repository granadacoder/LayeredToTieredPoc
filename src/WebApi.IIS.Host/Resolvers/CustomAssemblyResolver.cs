namespace MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.WebApi.IIS.Host.Resolvers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Web;
    using System.Web.Http.Dispatcher;

    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.WebApi.BusinessServices.Managers;
    
    public class CustomAssemblyResolver : DefaultAssembliesResolver
    {
        public override ICollection<Assembly> GetAssemblies()
        {
            ICollection<Assembly> baseAssemblies = base.GetAssemblies();
            List<Assembly> assemblies = new List<Assembly>(baseAssemblies);
            Type departmentBusinessServiceControllerType = typeof(DepartmentBusinessServiceController);
            var controllersAssembly = Assembly.GetAssembly(departmentBusinessServiceControllerType);
            baseAssemblies.Add(controllersAssembly);
            return assemblies;
        }
    }
}