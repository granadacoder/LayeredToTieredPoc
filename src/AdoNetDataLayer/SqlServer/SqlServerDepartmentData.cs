namespace MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Data.AdoNetDataLayer.SqlServer
{
    using System;
    using System.Data;
    using System.Data.Common;

    using Microsoft.Practices.EnterpriseLibrary.Data;

    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Data.AdoNetDataLayer.Interfaces;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.Args.DepartmentCentric;

    public class SqlServerDepartmentData : SqlServerDataLayerBase, IAdoNetDepartmentData
    {
        #region "Constants"

        ////Parameter Names
        private static readonly string ParameterNameDepartmentUuid = "@DepartmentUUID";
        private static readonly string ParameterNameDepartmentName = "@DepartmentName";
        private static readonly string ParameterNameDepartmentCreateDate = "@CreateDate";

        private static readonly string ParameterNameNumberRowsAffected = "@numberRowsAffected";
        private static readonly string ParameterNameMillisecondsReturnValue = "@msExecutionCount";
        private static readonly string ParameterNameXmlDoc = "@xml_doc";

        ////Procedures
        private static readonly string ProcedureNameZebraUpdate = "dbo.uspZebraUpdate";
        ////private static readonly string PROC_ZEBRA_GET_ALL = "[dbo].[uspZebraGetAll]";
        private static readonly string SqlStringDepartmentGetAll = "SELECT [DepartmentUUID] , [TheVersionProperty] , [DepartmentName] , [CreateDate]  FROM [dbo].[Department] dept";
        private static readonly string SqlStringDepartmentGetSingle = string.Format("{0} where dept.[DepartmentUUID]={1}", SqlStringDepartmentGetAll, ParameterNameDepartmentUuid);
        private static readonly string SqlStringDepartmentInsertSingle = string.Format("Insert into [dbo].[Department] ( [DepartmentUUID] , [DepartmentName] , [CreateDate] ) Values ( {0} , {1} , {2} );", ParameterNameDepartmentUuid, ParameterNameDepartmentName, ParameterNameDepartmentCreateDate);
        private static readonly string SqlStringDepartmentUpdateSingle = string.Format("Update [dbo].[Department] Set [DepartmentName] = {1} , [CreateDate] = {2} WHERE [DepartmentUUID] = {0};", ParameterNameDepartmentUuid, ParameterNameDepartmentName, ParameterNameDepartmentCreateDate);

        #endregion

        public SqlServerDepartmentData() : base()
        {
        }

        public SqlServerDepartmentData(string instanceName)
            : base(instanceName)
        {
        }

        public IDataReader GetAllDepartmentsDataReader()
        {
            IDataReader idr = null;

            Database db = this.GetDatabase();
            ////DatabaseCommand dbc = db.GetStoredProcedureCommand(this.ProcedureNameZebraUpdate);
            DbCommand dbc = db.GetSqlStringCommand(SqlStringDepartmentGetAll);
            idr = db.ExecuteReader(dbc);
            return idr;
        }

        public IDataReader GetDepartmentSingleDataReader(DepartmentGetSingleArgs args)
        {
            IDataReader idr = null;
            Database db = this.GetDatabase();
            ////DatabaseCommand dbc = db.GetStoredProcedureCommand(this.ProcedureNameZebraUpdate);
            DbCommand dbc = db.GetSqlStringCommand(SqlStringDepartmentGetSingle);
            db.AddInParameter(dbc, ParameterNameDepartmentUuid, DbType.Guid, args.DepartmentSurrogateKey);
            idr = db.ExecuteReader(dbc);
            return idr;
        }

        public IDataReader AddDepartment(DepartmentAddEditArgs args)
        {
            Database db = this.GetDatabase();
            ////DatabaseCommand dbc = db.GetStoredProcedureCommand(this.PROC_ZEBRA_INSERT);
            DbCommand dbc = db.GetSqlStringCommand(SqlStringDepartmentInsertSingle);

            db.AddInParameter(dbc, ParameterNameDepartmentUuid, DbType.Guid, args.DepartmentSurrogateKey);
            db.AddInParameter(dbc, ParameterNameDepartmentName, DbType.String, args.DepartmentName);
            db.AddInParameter(dbc, ParameterNameDepartmentCreateDate, DbType.DateTime, args.CreateDate);
            db.ExecuteNonQuery(dbc);

            DepartmentGetSingleArgs getArgs = new DepartmentGetSingleArgs() { DepartmentSurrogateKey = args.DepartmentSurrogateKey };

            return this.GetDepartmentSingleDataReader(getArgs);
        }

        public IDataReader UpdateDepartment(DepartmentAddEditArgs args)
        {
            try
            {
                Database db = this.GetDatabase();
                ////DatabaseCommand dbc = db.GetStoredProcedureCommand(this.ProcedureNameZebraUpdate);
                DbCommand dbc = db.GetSqlStringCommand(SqlStringDepartmentUpdateSingle);

                db.AddInParameter(dbc, ParameterNameDepartmentUuid, DbType.Guid, args.DepartmentSurrogateKey);
                db.AddInParameter(dbc, ParameterNameDepartmentName, DbType.String, args.DepartmentName);
                db.AddInParameter(dbc, ParameterNameDepartmentCreateDate, DbType.DateTime, args.CreateDate);
                int rowCount = db.ExecuteNonQuery(dbc);
                if (rowCount < 1)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Rowcount was not equal to one (No row was updated).  (DepartmentUUID='{0})", args.DepartmentSurrogateKey));
                }

                DepartmentGetSingleArgs getArgs = new DepartmentGetSingleArgs() { DepartmentSurrogateKey = args.DepartmentSurrogateKey };

                return this.GetDepartmentSingleDataReader(getArgs);
            }
            finally
            {
                System.Console.WriteLine(string.Empty);
            }
        }

        public int UpdateZebras(DataSet inputDS)
        {
            Database db = this.GetDatabase();
            ////DatabaseCommand dbc = db.GetStoredProcedureCommand(this.ProcedureNameZebraUpdate);
            DbCommand dbc = db.GetStoredProcCommand(ProcedureNameZebraUpdate);

            //// Input parameters can specify the input value 
            db.AddInParameter(dbc, ParameterNameXmlDoc, DbType.String, inputDS.GetXml());
            //// Output parameters specify the size of the return data 
            db.AddOutParameter(dbc, ParameterNameNumberRowsAffected, DbType.Int32, 0);
            db.AddOutParameter(dbc, ParameterNameMillisecondsReturnValue, DbType.Int32, 0);

            int rowsAffected = 0;

            rowsAffected = db.ExecuteNonQuery(dbc);

            int millisecondCount = Convert.ToInt32(db.GetParameterValue(dbc, ParameterNameMillisecondsReturnValue));

            return millisecondCount;
        }
    }
}