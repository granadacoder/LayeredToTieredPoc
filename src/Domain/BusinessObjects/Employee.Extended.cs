namespace MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.BusinessObjects
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.Serialization;
    
    /*
       see http://iainjmitchell.com/blog/?p=395 about EmitDefaultValue and JSON
   */

    /// <summary>
    /// Navigation/Other properties of Employee
    /// </summary>
    [DebuggerDisplay("{FullName}, {SSN}")]
    public partial class Employee
    {
        public Employee()
        {
        }

        public Department ParentDepartment { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string FullName
        {
            get
            {
                return (string.IsNullOrEmpty(this.LastName) ? string.Empty : this.LastName) + ", " + (string.IsNullOrEmpty(this.FirstName) ? string.Empty : this.FirstName);
            }

            set
            {
                ////throw new NotImplementedException();
            }
        }
    }
}