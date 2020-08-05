namespace MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Wcf.BusinessServices
{
    using System;
    using System.ServiceModel;
    ////using ServiceModelEx;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;

    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.Args.DepartmentCentric;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.BusinessObjects;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.Compositions.DepartmentCentric;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.ServiceInterfaces.ErrorHandlers;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.ServiceInterfaces.Managers;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.ServiceInterfaces.Wcf;

    ////Most Scalable option is InstanceContextMode.PerCall//
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [ErrorBehaviorAttribute(typeof(BusinessServicesGenericErrorHandler))]
    public class DepartmentBusinessService : IDepartmentManager
    {
        public DepartmentBusinessService()
        {
            UnityContainer container = new UnityContainer();
            container.LoadConfiguration();

            IDepartmentManager deptManager = container.Resolve<IDepartmentManager>();

            this.SetDependencies(deptManager);
        }

        private IDepartmentManager ForwardRequestToDepartmentManager { get; set; }

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
                        returnWrapper.Departments.Add(new Department() { DepartmentUUID = Guid.NewGuid(), DepartmentName = "DepartmentCreatedViaWcfBusinessServiceTemp", CreateDate = new DateTime(2002, 2, 2), TheVersionProperty = new byte[8] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 } });
                    }
                }

                /* end temp code */

                return returnWrapper;
            }
            catch (Exception ex)
            {
                ExceptionDetail detail = new ExceptionDetail(ex);
                throw new FaultException<ExceptionDetail>(detail, ex.Message);
            }
        }

        public DepartmentAddEditSingleWrapper GetDepartmentAddEditSingleWrapper(DepartmentGetSingleArgs args)
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
                ExceptionDetail detail = new ExceptionDetail(ex);
                throw new FaultException<ExceptionDetail>(detail, ex.Message);
            }
        }

        public Department AddDepartment(DepartmentAddEditArgs args)
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
                ExceptionDetail detail = new ExceptionDetail(ex);
                throw new FaultException<ExceptionDetail>(detail, ex.Message);
            }
        }

        public Department UpdateDepartment(DepartmentAddEditArgs args)
        {
            try
            {
                Department returnItem = null;
                IDepartmentManager con = this.ForwardRequestToDepartmentManager;
                returnItem = con.UpdateDepartment(args);
                return returnItem;
            }
            catch (Exception ex)
            {
                ExceptionDetail detail = new ExceptionDetail(ex);
                throw new FaultException<ExceptionDetail>(detail, ex.Message);
            }
        }

        private void SetDependencies(IDepartmentManager deptManager)
        {
            this.ForwardRequestToDepartmentManager = deptManager;
        }
    }
}