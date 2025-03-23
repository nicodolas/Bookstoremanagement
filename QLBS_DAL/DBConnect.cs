using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//===
using System.Data.SqlClient;
using QLBS_DTO;
 namespace QLBS_DAL
{
    public class DBConnect
    {
        public static string connectionString = @"Data Source = HyunWeeh; Initial Catalog = _BookStore_; Integrated Security = True";
        protected SqlConnection con = new SqlConnection(connectionString);
    }
}