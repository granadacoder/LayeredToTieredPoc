namespace MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.Args.DepartmentCentric
{
    using System;
    
    /// <summary>
    /// Encapsulates values for an Course Update in smallest possible manner.
    /// </summary>
    [Serializable]
    public class DepartmentAddEditArgs
    {
        public DepartmentAddEditArgs()
        {
            this.CreateDate = DateTime.Now;
        }

        public DepartmentAddEditArgs(DateTime createDate)
        {
            this.CreateDate = createDate;
        }

        public Guid DepartmentSurrogateKey { get; set; }

        public string DepartmentName { get; set; }

        public DateTime CreateDate { get; set; }

        public virtual byte[] TheVersionProperty { get; set; }
    }
}
