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
    public class UpdateData
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="approverid"></param>
        /// <param name="orderid"></param>
        public void UpdateApproverId(string orderid,string approverid)
        {
            SqlConnection sqlconnection = null;
            SqlCommand command = null;
            string connString = string.Empty;
            try
            {
                connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString().Trim();
                sqlconnection = new SqlConnection(connString);
                sqlconnection.Open();
                command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.Connection = sqlconnection;
                command.CommandText = "UPDATE ORDERS SET APPROVAL_ID='" + approverid + "' WHERE ORD_NUM='" + orderid+"'";
                command.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (sqlconnection!=null)
                {
                    sqlconnection.Close();
                    sqlconnection.Dispose();
                }
                if (command!=null)
                {
                    command.Dispose();
                }
            }
        }
    }
}
