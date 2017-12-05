using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataLayer
{
    public class GetData
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetGridData()
        {
            DataTable result = new DataTable();
            string connString = string.Empty;
            try
            {
                connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString().Trim();
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT [ORD_NUM], [ORD_AMOUNT], [ORD_DATE], [CUST_NAME], [ORD_DESCRIPTION], ISNULL([APPROVAL_ID],'') AS [APPROVAL_ID] FROM [ORDERS] ORDER BY [ORD_DATE] DESC", connection);
                    adapter.Fill(result);
                }             
            }
            catch
            {
                throw;
            }
            return result;
        }
    }
}
