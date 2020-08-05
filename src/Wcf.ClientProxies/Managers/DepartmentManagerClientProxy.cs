namespace MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Wcf.ClientProxies.Managers
{
    using System;
    using System.ServiceModel;

    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.Args.DepartmentCentric;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.BusinessObjects;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.Compositions.DepartmentCentric;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.ServiceInterfaces.Managers;

    public class DepartmentManagerClientProxy : IDepartmentManager
    {
        #region IDepartmentManager Members

        public DepartmentAllWrapper GetDepartmentAllWrapper()
        {
            DepartmentAllWrapper returnItem = null;

            IDepartmentManager proxy1 = this.GetTheProxy();

            using (proxy1 as IDisposable)
            {
                returnItem = proxy1.GetDepartmentAllWrapper();
                return returnItem;
            }
        }

        public DepartmentAddEditSingleWrapper GetDepartmentAddEditSingleWrapper(DepartmentGetSingleArgs args)
        {
            DepartmentAddEditSingleWrapper returnItem = null;

            IDepartmentManager proxy1 = this.GetTheProxy();

            using (proxy1 as IDisposable)
            {
                returnItem = proxy1.GetDepartmentAddEditSingleWrapper(args);
                return returnItem;
            }
        }

        public Department AddDepartment(DepartmentAddEditArgs args)
        {
            Department returnItem = null;

            IDepartmentManager proxy1 = this.GetTheProxy();

            using (proxy1 as IDisposable)
            {
                returnItem = proxy1.AddDepartment(args);
                return returnItem;
            }
        }

        public Department UpdateDepartment(DepartmentAddEditArgs args)
        {
            Department returnItem = null;

            IDepartmentManager proxy1 = this.GetTheProxy();

            using (proxy1 as IDisposable)
            {
                returnItem = proxy1.UpdateDepartment(args);
                return returnItem;
            }
        }

        #endregion

        private IDepartmentManager GetTheProxy()
        {
            string endPointName = System.Configuration.ConfigurationManager.AppSettings["DefaultEndPointName"];
            ChannelFactory<IDepartmentManager> factory;
            ////Use default endpoint
            Console.WriteLine("endPointName='{0}'", endPointName);

            factory = new ChannelFactory<IDepartmentManager>(endPointName);
            IDepartmentManager proxy1 = factory.CreateChannel();
            return proxy1;
        }
    }
}
