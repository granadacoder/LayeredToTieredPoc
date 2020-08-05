namespace MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Data.DomainDataViaAdoNet.Serializers.DepartmentCentric
{
    using System.Collections.Generic;
    using System.Data;

    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Data.DomainDataViaAdoNet.Layouts.DepartmentCentric;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.BusinessObjects;

    /// <summary>
    /// Methods to convert IDataReader(s) to Department or ICollection{Department}.
    /// </summary>
    internal class DepartmentDefaultSerializer : DBSerializerBase<Department, ICollection<Department>>
    {
        internal override ICollection<Department> SerializeCollection(IDataReader dataReader)
        {
            Department item = new Department();
            ICollection<Department> returnCollection = new List<Department>();
            try
            {
                int fc = dataReader.FieldCount; /* just an FYI value */
                while (dataReader.Read())
                {
                    if (!dataReader.IsDBNull(DepartmentDefaultLayout.DepartmentUUID))
                    {
                        item = new Department() { DepartmentUUID = dataReader.GetGuid(DepartmentDefaultLayout.DepartmentUUID) };

                        if (!dataReader.IsDBNull(DepartmentDefaultLayout.TheVersionProperty))
                        {
                            byte[] timestamp = new byte[8];
                            dataReader.GetBytes(DepartmentDefaultLayout.TheVersionProperty, 0, timestamp, 0, 8);
                            item.TheVersionProperty = timestamp;
                        }

                        if (!dataReader.IsDBNull(DepartmentDefaultLayout.DepartmentName))
                        {
                            item.DepartmentName = dataReader.GetString(DepartmentDefaultLayout.DepartmentName);
                        }

                        if (!dataReader.IsDBNull(DepartmentDefaultLayout.CreateDate))
                        {
                            item.CreateDate = dataReader.GetDateTime(DepartmentDefaultLayout.CreateDate);
                        }

                        returnCollection.Add(item);
                    }
                }

                return returnCollection;

                ////no catch here... see  http://blogs.msdn.com/brada/archive/2004/12/03/274718.aspx
            }
            finally
            {
                System.Console.WriteLine(string.Empty);

                /*
                if (!((dataReader == null)))
                {
                    try
                    {
                        dataReader.Close();
                    }
                    catch {}
                }
                */
            }
        }
    }
}
