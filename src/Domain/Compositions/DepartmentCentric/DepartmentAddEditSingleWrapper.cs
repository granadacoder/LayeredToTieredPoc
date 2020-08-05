namespace MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.Compositions.DepartmentCentric
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.BusinessObjects;

    [Serializable]
    [DataContract]
    public class DepartmentAddEditSingleWrapper
    {
        [DataMember]
        public Department PrimaryDepartment { get; set; }
    }
}
