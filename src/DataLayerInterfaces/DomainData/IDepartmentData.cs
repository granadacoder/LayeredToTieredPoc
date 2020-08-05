namespace MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Data.DomainDataLayerInterfaces.DomainData
{
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.Args.DepartmentCentric;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.BusinessObjects;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.Collections;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.Compositions.DepartmentCentric;

    public interface IDepartmentData
    {
        DepartmentCollection GetAllDepartments();

        DepartmentAddEditSingleWrapper GetSingleDepartment(DepartmentGetSingleArgs args);

        Department AddDepartment(DepartmentAddEditArgs args);

        Department UpdateDepartment(DepartmentAddEditArgs args);
    }
}
