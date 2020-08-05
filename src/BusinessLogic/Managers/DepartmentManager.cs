namespace MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.BusinessLogic.Managers
{
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Data.DomainDataLayerInterfaces.DomainData;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.Args.DepartmentCentric;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.BusinessObjects;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.Collections;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.Compositions.DepartmentCentric;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.ServiceInterfaces.Managers;

    public class DepartmentManager : IDepartmentManager
    {
        public DepartmentManager(IDepartmentData deptData)
        {
            this.SetDependencies(deptData);
        }

        private IDepartmentData DepartmentData { get; set; }

        public DepartmentAllWrapper GetDepartmentAllWrapper()
        {
            DepartmentAllWrapper returnItem = new DepartmentAllWrapper();
            DepartmentCollection dcoll = this.DepartmentData.GetAllDepartments();
            returnItem.Departments = dcoll;
            return returnItem;
        }

        public DepartmentAddEditSingleWrapper GetDepartmentAddEditSingleWrapper(DepartmentGetSingleArgs args)
        {
            DepartmentAddEditSingleWrapper returnItem = new DepartmentAddEditSingleWrapper();
            returnItem = this.DepartmentData.GetSingleDepartment(args);
            return returnItem;
        }

        public Department AddDepartment(DepartmentAddEditArgs args)
        {
            Department returnItem = null;
            returnItem = this.DepartmentData.AddDepartment(args);
            return returnItem;
        }

        public Department UpdateDepartment(DepartmentAddEditArgs args)
        {
            Department returnItem = null;
            returnItem = this.DepartmentData.UpdateDepartment(args);
            return returnItem;
        }

        private void SetDependencies(IDepartmentData deptData)
        {
            this.DepartmentData = deptData;
        }
    }
}
