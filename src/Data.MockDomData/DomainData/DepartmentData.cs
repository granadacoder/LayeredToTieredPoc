namespace MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Data.MockDomainData.DomainData
{
    using System;

    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Data.DomainDataLayerInterfaces.DomainData;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.Args.DepartmentCentric;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.BusinessObjects;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.Collections;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.Compositions.DepartmentCentric;

    public class DepartmentData : IDepartmentData
    {
        public DepartmentCollection GetAllDepartments()
        {
            DepartmentCollection returnCollection = new DepartmentCollection();

            Department d1 = new Department() { DepartmentUUID = Guid.NewGuid(), DepartmentName = "MockDept1", CreateDate = DateTime.Now, TheVersionProperty = new byte[8] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 } };
            Department d2 = new Department() { DepartmentUUID = Guid.NewGuid(), DepartmentName = "MockDept2", CreateDate = DateTime.Now, TheVersionProperty = new byte[8] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 } };
            Department d3 = new Department() { DepartmentUUID = Guid.NewGuid(), DepartmentName = "MockDept3", CreateDate = DateTime.Now, TheVersionProperty = new byte[8] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 } };
            returnCollection.Add(d1);
            returnCollection.Add(d2);
            returnCollection.Add(d3);

            return returnCollection;
        }

        public DepartmentAddEditSingleWrapper GetSingleDepartment(DepartmentGetSingleArgs args)
        {
            DepartmentAddEditSingleWrapper returnItem = new DepartmentAddEditSingleWrapper();
            Department d1 = new Department() { DepartmentUUID = args.DepartmentSurrogateKey, DepartmentName = "MockDeptGetSingle", CreateDate = DateTime.Now, TheVersionProperty = new byte[8] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 } };
            returnItem.PrimaryDepartment = d1;
            return returnItem;
        }

        public Department AddDepartment(DepartmentAddEditArgs args)
        {
            Department returnItem = null;
            returnItem = new Department() { DepartmentUUID = Guid.NewGuid(), DepartmentName = "MockDeptNew", CreateDate = DateTime.Now, TheVersionProperty = new byte[8] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 } };
            return returnItem;
        }

        public Department UpdateDepartment(DepartmentAddEditArgs args)
        {
            Department returnItem = null;
            returnItem = new Department() { DepartmentUUID = Guid.NewGuid(), DepartmentName = "MockDeptUpdate", CreateDate = DateTime.Now, TheVersionProperty = new byte[8] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 } };
            return returnItem;
        }
    }
}