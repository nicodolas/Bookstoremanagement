using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using QLBS_DTO;

namespace QLBS_DAL
{
    public class KhachHangDAL : DBConnect
    {
        public List<KhachHangDTO> getAll()
        {
            List<KhachHangDTO> lst = new List<KhachHangDTO>();
            if (ConnectionState.Closed == con.State)
                con.Open();
            string getAllSql = "Select * from khachhang where makh <> 'KH000'";
            SqlCommand cmd = new SqlCommand(getAllSql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                KhachHangDTO kh = new KhachHangDTO()
                {
                    MAKH = rd[0].ToString(),
                    TENKH = rd[1].ToString()
                };
                lst.Add(kh);
            }
            con.Close();
            return lst;
        }
        public List<KhachHangDTO> getAllKH_Include_VangLai()
        {
            List<KhachHangDTO> lst = new List<KhachHangDTO>();
            if (ConnectionState.Closed == con.State)
                con.Open();
            string getAllSql = "Select * from khachhang";
            SqlCommand cmd = new SqlCommand(getAllSql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                KhachHangDTO kh = new KhachHangDTO()
                {
                    MAKH = rd[0].ToString(),
                    TENKH = rd[1].ToString()
                };
                lst.Add(kh);
            }
            con.Close();
            return lst;
        }
        public KhachHangDTO getKHByID(string makh)
        {
           

            if (ConnectionState.Closed == con.State)
                con.Open();
            string getKHSql = "Select * from KHACHHANG where makh='"+makh+"'";
            SqlCommand cmd = new SqlCommand(getKHSql, con);
            //cmd.Parameters.AddWithValue("@makh", makh);
            SqlDataReader rd = cmd.ExecuteReader();
            KhachHangDTO kh = new KhachHangDTO();
            while (rd.Read())
            {
             
                kh.MAKH = rd[0].ToString();
                kh.TENKH = rd[1].ToString();
                kh.SDT = rd[2].ToString();
                kh.DCHIKH = rd[3].ToString();
                kh.GTINHKH = rd[4].ToString();
                kh.NGAYSINH = rd.GetDateTime(5);
                kh.DIEMTICHLUY = (int)rd[6];
                kh.GIAMGIA = rd.IsDBNull(7) ? 0.0f : Convert.ToSingle(rd[7]);
            }
            con.Close();
            return kh;
        }

        public string taoMaKh()
        {
            if (ConnectionState.Closed == con.State)
                con.Open();

            string sql = "SELECT MAX(CAST(SUBSTRING(MAKH, 3, LEN(MAKH)) AS INT)) FROM KHACHHANG";
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                var result = cmd.ExecuteScalar();

                // Kiểm tra giá trị trả về
                if (result != DBNull.Value)
                {
                    int stt = (int)result;
                    return "KH" + (stt + 1).ToString("D3");
                }
                else
                {
                    return "KH001"; // Nếu không có mã nào, trả về "KH001"
                }
            }
        }

        public bool insertKH(KhachHangDTO kh)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "insert into khachhang values(@makh,@tenkh,@sdtkh,@dchikh,@gtinhkh,@ngaysinhkh,@diemtichluy,@giamgia)";
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@makh", kh.MAKH);
                cmd.Parameters.AddWithValue("@tenkh", kh.TENKH);
                cmd.Parameters.AddWithValue("@sdtkh", kh.SDT);
                cmd.Parameters.AddWithValue("@dchikh", kh.DCHIKH);
                cmd.Parameters.AddWithValue("@gtinhkh", kh.GTINHKH);
                cmd.Parameters.AddWithValue("@ngaysinhkh", kh.NGAYSINH);
                cmd.Parameters.AddWithValue("@diemtichluy", kh.DIEMTICHLUY );
                cmd.Parameters.AddWithValue("@giamgia", kh.GIAMGIA);
                int rs = (int)cmd.ExecuteNonQuery();
                con.Close();
                return rs > 0;
            }
           
        }
        public bool updateKH(KhachHangDTO kh)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "update  khachhang set makh=@makh,hotenkh=@tenkh,sdtkh=@sdtkh,dchikh=@dchikh,gtinhkh=@gtinhkh,ngaysinhkh=@ngaysinhkh where makh=@makh";
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@makh", kh.MAKH);
                cmd.Parameters.AddWithValue("@tenkh", kh.TENKH);
                cmd.Parameters.AddWithValue("@sdtkh", kh.SDT);
                cmd.Parameters.AddWithValue("@dchikh", kh.DCHIKH);
                cmd.Parameters.AddWithValue("@gtinhkh", kh.GTINHKH);
                cmd.Parameters.AddWithValue("@ngaysinhkh", kh.NGAYSINH);
                int rs = (int)cmd.ExecuteNonQuery();
                con.Close();
                return rs > 0;
            }

        }






    }


}




