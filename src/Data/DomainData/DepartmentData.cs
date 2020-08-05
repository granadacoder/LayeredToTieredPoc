namespace MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Data.DomainDataViaAdoNet.DomainData
{
    using System.Collections.Generic;
    using System.Data;

    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Data.AdoNetDataLayer.Interfaces;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Data.DomainDataLayerInterfaces.DomainData;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Data.DomainDataViaAdoNet.Serializers.DepartmentCentric;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.Args.DepartmentCentric;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.BusinessObjects;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.Collections;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.Compositions.DepartmentCentric;

    public class DepartmentData : IDepartmentData
    {
        public DepartmentData(IAdoNetDepartmentData adoData)
        {
            this.SetDependencies(adoData);
        }

        private IAdoNetDepartmentData AdoDepartmentData { get; set; }

        public DepartmentCollection GetAllDepartments()
        {
            DepartmentCollection returnCollection = new DepartmentCollection();

            /* Start Temp Code */
            ////Department d1 = new Department() { DepartmentUUID = Guid.NewGuid(), DepartmentName = "Dept1", CreateDate = DateTime.Now, TheVersionProperty = new byte[8] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 } };
            ////Department d2 = new Department() { DepartmentUUID = Guid.NewGuid(), DepartmentName = "Dept2", CreateDate = DateTime.Now, TheVersionProperty = new byte[8] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 } };
            ////Department d3 = new Department() { DepartmentUUID = Guid.NewGuid(), DepartmentName = "Dept3", CreateDate = DateTime.Now, TheVersionProperty = new byte[8] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 } };
            ////returnCollection.Add(d1);
            ////returnCollection.Add(d2);
            ////returnCollection.Add(d3);
            /* End Temp Code */

            ////Below Code is Good Code...Comment out the "Temp Code" (above) and uncomment below to hit the database.
            IDataReader idr = this.AdoDepartmentData.GetAllDepartmentsDataReader();
            ICollection<Department> coll = new DepartmentDefaultSerializer().SerializeCollection(idr);
            returnCollection.AddRange(coll);

            return returnCollection;
        }

        public DepartmentAddEditSingleWrapper GetSingleDepartment(DepartmentGetSingleArgs args)
        {
            DepartmentAddEditSingleWrapper returnItem = new DepartmentAddEditSingleWrapper();

            /* Start Temp Code */
            //////Department d1 = new Department() { DepartmentUUID = args.DepartmentSurrogateKey, DepartmentName = "DeptGetSingle", CreateDate = DateTime.Now, TheVersionProperty = new byte[8] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 } };
            //////returnItem.PrimaryDepartment = d1;
            /* End Temp Code */

            ////Below Code is Good Code...Comment out the "Temp Code" (above) and uncomment below to hit the database.
            IDataReader idr = this.AdoDepartmentData.GetDepartmentSingleDataReader(args);
            returnItem.PrimaryDepartment = new DepartmentDefaultSerializer().SerializeSingle(idr);

            return returnItem;
        }

        public Department AddDepartment(DepartmentAddEditArgs args)
        {
            Department returnItem = null;

            /* Start Temp Code */
            ////returnItem = new Department() { DepartmentUUID = Guid.NewGuid(), DepartmentName = "DeptNew", CreateDate = DateTime.Now, TheVersionProperty = new byte[8] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 } };
            /* End Temp Code */

            ////Below Code is Good Code...Comment out the "Temp Code" (above) and uncomment below to hit the database.
            IDataReader idr = this.AdoDepartmentData.AddDepartment(args);
            returnItem = new DepartmentDefaultSerializer().SerializeSingle(idr);

            return returnItem;
        }

        public Department UpdateDepartment(DepartmentAddEditArgs args)
        {
            Department returnItem = null;

            /* Start Temp Code */
            ////returnItem = new Department() { DepartmentUUID = Guid.NewGuid(), DepartmentName = "DeptUpdate", CreateDate = DateTime.Now, TheVersionProperty = new byte[8] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 } };
            /* End Temp Code */

            ////Below Code is Good Code...Comment out the "Temp Code" (above) and uncomment below to hit the database.
            IDataReader idr = this.AdoDepartmentData.UpdateDepartment(args);
            returnItem = new DepartmentDefaultSerializer().SerializeSingle(idr);

            return returnItem;
        }

        private void SetDependencies(IAdoNetDepartmentData adoData)
        {
            this.AdoDepartmentData = adoData;
        }
    }
}
