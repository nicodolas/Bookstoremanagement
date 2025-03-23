using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//==
using System.Data.SqlClient;
using System.Data;
using QLBS_DTO;

namespace QLBS_DAL
{
    public class QuanHuyenDAL:DBConnect
    {
        public List<QuanHuyenDTO> getAllQuanHuyen()
        {
            List<QuanHuyenDTO> lst = new List<QuanHuyenDTO>();
            if (ConnectionState.Closed == con.State)
                con.Open();
            string getAllSql = "Select * from quanhuyen";
            SqlCommand cmd = new SqlCommand(getAllSql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                QuanHuyenDTO qh = new QuanHuyenDTO()
                {
                    MA = (int)rd[0],
                    TENQUANHUYEN = rd[1].ToString()
                   
                };
                lst.Add(qh);
            }
            con.Close();
            return lst;
        }
    }
}
