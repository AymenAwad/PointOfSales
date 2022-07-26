using Core.Helpers;
using Dapper;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence
{
    public class DBContext
    {
        static IConfiguration configuration;
        public DBContext(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public static object ExcuteProcedure(List<ProcedureParameters> procedureParameters, string procedureName)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                foreach (var item in procedureParameters)
                {
                    if (item.ParameterDirection == ParameterDirection.Input)
                        dyParam.Add(item.ParameterName, item.OracleDbType, item.ParameterDirection, item.paramerterValue);
                    else
                        dyParam.Add(item.ParameterName, item.OracleDbType, item.ParameterDirection);
                }


                var connectionString = " Data Source= DESKTOP-MLAEPOO;Initial Catalog = SalesOfPoint; Integrated Security = true";

                var conn = new OracleConnection(connectionString);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SpGenerateId";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

    }
}
