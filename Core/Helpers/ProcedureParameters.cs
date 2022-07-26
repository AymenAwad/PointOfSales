using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers
{
    public class ProcedureParameters
    {
        public OracleDbType OracleDbType { get; set; }
        public ParameterDirection ParameterDirection { get; set; }
        public string ParameterName { get; set; }
        public dynamic paramerterValue { get; set; }
    }
}
