namespace MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Data.AdoNetDataLayer.SqlServer
{
    using Microsoft.Practices.EnterpriseLibrary.Data;

    public abstract class SqlServerDataLayerBase
    {
        private readonly string applicationName = typeof(SqlServerDataLayerBase).Assembly.FullName;

        public SqlServerDataLayerBase()
        {
            this.InstanceName = string.Empty;
        }

        public SqlServerDataLayerBase(string instanceName)
        {
            this.InstanceName = instanceName;
        }

        private string InstanceName { get; set; }

        protected Database GetDatabase()
        {
            // Create the Database object, using the default database service. The
            // default database service is determined through configuration.
            Database returnDb = null;
            if (this.InstanceName.Length > 0)
            {
                returnDb = DatabaseFactory.CreateDatabase(this.InstanceName);
            }
            else
            {
                returnDb = DatabaseFactory.CreateDatabase();
            }

            return returnDb;
        }
    }
}
