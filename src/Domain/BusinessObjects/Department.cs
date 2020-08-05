namespace MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.BusinessObjects
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Scalar properties of Department
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class Department
    {
        [DataMember]
        public Guid DepartmentUUID { get; set; }

        [DataMember]
        public string DepartmentName { get; set; }

        [DataMember]
        public DateTime CreateDate { get; set; }

        [DataMember]
        public virtual byte[] TheVersionProperty { get; set; }
    }
}
