namespace MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.WebApi.BusinessServices.Managers
{
    using System;
    using System.Web.Http;

    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;

    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.Args.DepartmentCentric;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.BusinessObjects;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.Compositions.DepartmentCentric;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.ServiceInterfaces.Managers;

    public class DepartmentBusinessServiceController : ApiController, IDepartmentManager
    {
        public DepartmentBusinessServiceController()
        {
            UnityContainer container = new UnityContainer();
            container.LoadConfiguration();

            IDepartmentManager deptManager = container.Resolve<IDepartmentManager>();

            this.SetDependencies(deptManager);
        }

        #region "Dependencies"
        private IDepartmentManager ForwardRequestToDepartmentManager { get; set; }
        #endregion

        public DepartmentAllWrapper GetDepartmentAllWrapper()
        {
            try
            {
                DepartmentAllWrapper returnWrapper = null;
                IDepartmentManager con = this.ForwardRequestToDepartmentManager;
                returnWrapper = con.GetDepartmentAllWrapper();

                /* start temp code */
                if (null != returnWrapper)
                {
                    if (null != returnWrapper.Departments)
                    {
                        returnWrapper.Departments.Add(new Department() { DepartmentUUID = Guid.NewGuid(), DepartmentName = "DepartmentCreatedViaDepartmentWebApiBusinessServiceControllerTemp", CreateDate = new DateTime(2001, 1, 1), TheVersionProperty = new byte[8] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 } });
                    }
                }

                /* end temp code */

                return returnWrapper;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [System.Web.Http.HttpPost]
        public DepartmentAddEditSingleWrapper GetDepartmentAddEditSingleWrapper([FromBody] DepartmentGetSingleArgs args)
        {
            try
            {
                DepartmentAddEditSingleWrapper returnItem = null;
                IDepartmentManager con = this.ForwardRequestToDepartmentManager;
                returnItem = con.GetDepartmentAddEditSingleWrapper(args);
                return returnItem;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [System.Web.Http.HttpPost]
        public Department AddDepartment([FromBody] DepartmentAddEditArgs args)
        {
            try
            {
                Department returnItem = null;
                IDepartmentManager con = this.ForwardRequestToDepartmentManager;
                returnItem = con.AddDepartment(args);
                return returnItem;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [System.Web.Http.HttpPost]
        public Department UpdateDepartment([FromBody] DepartmentAddEditArgs args)
        {
            try
            {
                Department returnItem = null;
                IDepartmentManager con = this.ForwardRequestToDepartmentManager;
                returnItem = con.UpdateDepartment(args);
                if (null == returnItem)
                {
                    ////return NotFound();
                }

                return returnItem;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void SetDependencies(IDepartmentManager deptManager)
        {
            this.ForwardRequestToDepartmentManager = deptManager;
        }
    }
}