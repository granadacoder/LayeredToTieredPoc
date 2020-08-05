namespace MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.Args.DepartmentCentric
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    
    /// <summary>
    /// Encapsulates values for retrieving a single Department
    /// </summary>
    [Serializable]
    [DataContract]
    public class DepartmentGetSingleArgs
    {
        [DataMember(EmitDefaultValue = false)]
        public Guid DepartmentSurrogateKey { get; set; }
    }
}