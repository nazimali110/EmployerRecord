using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployerRecord.Common
{
    public class Helper
    {
        #region Sql

        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            }
        }

        public static SqlConnection Connection
        {
            get
            {
                return new SqlConnection(ConnectionString);
            }
        }

        #endregion

    }
}
