using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//=
using System.Data.SqlClient;
using System.Data;
using QLBS_DTO;
namespace QLBS_DAL
{
    public class TaiKhoanDAL : DBConnect
    {
        public TaiKhoanDTO GetTaiKhoan(string tenDN, string matKhau)
        {
            TaiKhoanDTO taiKhoan = null;
            if (ConnectionState.Closed == con.State)
                con.Open();
            string query = "SELECT TENDN, MATKHAU, VAITRO FROM TAIKHOAN WHERE TENDN = @TENDN AND MATKHAU = @MATKHAU";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@TENDN", tenDN);
            cmd.Parameters.AddWithValue("@MATKHAU", matKhau);
            try
            {

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    taiKhoan = new TaiKhoanDTO()
                    {
                        TenDN = reader["TENDN"].ToString(),
                        MatKhau = reader["MATKHAU"].ToString(),
                        VaiTro = reader["VAITRO"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy tài khoản: " + ex.Message);
            }
            con.Close();
            return taiKhoan;
        }

        public int getNumberAccMax()
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string getNumSql = @"SELECT MAX(CAST(SUBSTRING(tendn, LEN('nhanvien') + 1, LEN(tendn)) AS INT)) AS MaxNumber FROM TAIKHOAN WHERE VAITRO = 'NV' AND tendn LIKE 'nhanvien%'";
            SqlCommand cmd = new SqlCommand(getNumSql, con);
            int  num = (int)cmd.ExecuteScalar();

            return num;
        }
        public bool createAccount(TaiKhoanDTO tk)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
           
                string insertSql = "INSERT INTO taikhoan VALUES (@tendn, @matkhau, @role)";

                using (SqlCommand cmd = new SqlCommand(insertSql, con))
                {
                    cmd.Parameters.AddWithValue("@tendn", tk.TenDN);
                    cmd.Parameters.AddWithValue("@matkhau", tk.MatKhau);
                    cmd.Parameters.AddWithValue("@role", tk.VaiTro);

                    int result = cmd.ExecuteNonQuery();
                con.Close();
                    return result > 0; // Trả về true nếu có ít nhất 1 bản ghi được thêm
                }
            
        }


        public bool deleteAccount(string tendn)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string deletetSql = "delete from taikhoan where tendn =@tendn";
            SqlCommand cmd = new SqlCommand(deletetSql, con);
            cmd.Parameters.AddWithValue("@tendn", tendn);
            int rs = cmd.ExecuteNonQuery();
            
            return rs > 0;
        }

        public bool updateAccount(string tendn,string mk)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string deletetSql = "update taikhoan set matkhau=@matkhau where tendn =@tendn";
            SqlCommand cmd = new SqlCommand(deletetSql, con);
            cmd.Parameters.AddWithValue("@tendn", tendn);
            cmd.Parameters.AddWithValue("@matkhau", mk);
            int rs = cmd.ExecuteNonQuery();
            con.Close();

            return rs > 0;
        }








    }
}
