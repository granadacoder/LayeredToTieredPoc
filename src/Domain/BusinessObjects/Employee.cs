namespace MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.BusinessObjects
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Scalar properties of Department
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class Employee
    {
        public Guid? EmployeeUUID { get; set; }

        public byte[] TheVersionProperty { get; set; }

        public string SSN { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime HireDate { get; set; }
    }
}
