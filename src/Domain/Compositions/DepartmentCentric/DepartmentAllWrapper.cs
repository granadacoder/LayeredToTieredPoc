namespace MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.Compositions.DepartmentCentric
{
    using System;
    using System.Runtime.Serialization;

    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.Collections;

    [Serializable]
    [DataContract]
    public class DepartmentAllWrapper
    {
        [DataMember]
        public DepartmentCollection Departments { get; set; }
    }
}
