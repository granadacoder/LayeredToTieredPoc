namespace MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Data.AdoNetDataLayer.Interfaces
{
    using System;
    using System.Data;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.Args.DepartmentCentric;

    public interface IAdoNetDepartmentData
    {
        IDataReader GetAllDepartmentsDataReader();

        IDataReader GetDepartmentSingleDataReader(DepartmentGetSingleArgs args);

        IDataReader AddDepartment(DepartmentAddEditArgs args);

        IDataReader UpdateDepartment(DepartmentAddEditArgs args);
    }
}
