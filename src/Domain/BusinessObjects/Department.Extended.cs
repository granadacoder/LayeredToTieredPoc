namespace MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.BusinessObjects
{
    using System;
    using System.Collections.Generic;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.Collections;

    /// <summary>
    /// Navigation/Other properties of Department
    /// </summary>
    public partial class Department
    {
        public Department()
        {
            this.Employees = new EmployeeCollection();
        }

        public EmployeeCollection Employees { get; set; }
    }
}
