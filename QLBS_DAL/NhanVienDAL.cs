using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//==
using QLBS_DTO;
using System.Data.SqlClient;
using System.Data;

namespace QLBS_DAL
{
    public class NhanVienDAL : DBConnect
    {
        public List<NhanVienDTO> getAll()
        {
            List<NhanVienDTO> lst = new List<NhanVienDTO>();
            if (ConnectionState.Closed == con.State)
                con.Open();
            string getAllSql = "Select * from nhanvien";
            SqlCommand cmd = new SqlCommand(getAllSql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                NhanVienDTO nv = new NhanVienDTO()
                {
                    MANV = rd[0].ToString(),
                    HOTENNV = rd[1].ToString(),
                    SDTNV = rd[2].ToString(),
                    DCHINV = rd[3].ToString(),
                    GTINHNV = rd[4].ToString(),
                    NGAYSINHNV = rd.GetDateTime(5),
                    TENDN = rd[6].ToString(),
                    TINHTRANG = rd[7].ToString()

                };
                lst.Add(nv);
            }
            con.Close();
            return lst;
        }



        public NhanVienDTO getNhanVienById(string MANV)
        {
            NhanVienDTO nv = null;

            if (ConnectionState.Closed == con.State)
                con.Open();
            string getNVSql = "Select * from nhanvien where manv=@manv";
            SqlCommand cmd = new SqlCommand(getNVSql, con);
            cmd.Parameters.AddWithValue("@manv", MANV);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                nv = new NhanVienDTO()
                {
                    MANV = rd[0].ToString(),
                    HOTENNV = rd[1].ToString(),
                    SDTNV = rd[2].ToString(),
                    DCHINV = rd[3].ToString(),
                    GTINHNV = rd[4].ToString(),
                    NGAYSINHNV = rd.GetDateTime(5),
                    TENDN = rd[6].ToString(),
                    TINHTRANG = rd[7].ToString()

                };

            }
            con.Close();
            return nv;
        }



        public NhanVienDTO getNhanVienByTenDN(string tendn)
        {
            NhanVienDTO nv = null;
            List<NhanVienDTO> lst = new List<NhanVienDTO>();
            if (ConnectionState.Closed == con.State)
                con.Open();
            string getNVSql = "Select * from nhanvien where tendn=@tendn";
            SqlCommand cmd = new SqlCommand(getNVSql, con);
            cmd.Parameters.AddWithValue("@tendn", tendn);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                nv = new NhanVienDTO()
                {
                    MANV = rd[0].ToString(),
                    HOTENNV = rd[1].ToString(),
                    SDTNV = rd[2].ToString(),
                    DCHINV = rd[3].ToString(),
                    GTINHNV = rd[4].ToString(),
                    NGAYSINHNV = rd.GetDateTime(5),
                    TENDN = rd[6].ToString(),
                    TINHTRANG = rd[7].ToString()

                };

            }
            con.Close();
            return nv;
        }


        public bool insertNhanVien(NhanVienDTO nhanvien)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string insertSql = "insert into nhanvien(manv,hotennv,sdtnv,dchinv,gtinhnv,ngaysinhnv,tendn) values(@manv,@hotennv,@sdtnv,@dchinv,@gtinhnv,@ngaysinhnv,@tendangnhap)";
            SqlCommand cmd = new SqlCommand(insertSql, con);
            cmd.Parameters.AddWithValue("@manv", nhanvien.MANV);
            cmd.Parameters.AddWithValue("@hotennv", nhanvien.HOTENNV);
            cmd.Parameters.AddWithValue("@sdtnv", nhanvien.SDTNV);
            cmd.Parameters.AddWithValue("@dchinv", nhanvien.DCHINV);
            cmd.Parameters.AddWithValue("@gtinhnv", nhanvien.GTINHNV);
            cmd.Parameters.AddWithValue("@ngaysinhnv", nhanvien.NGAYSINHNV);
            cmd.Parameters.AddWithValue("@tendangnhap", nhanvien.TENDN);
            int rs = cmd.ExecuteNonQuery();
            con.Close();
            return rs > 0;
        }

        public bool DeleteNhanVien(string maNV)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();

            string updateSql = "Update nhanvien set tinhtrang =N'Đã nghỉ' WHERE manv = @manv";
            SqlCommand cmd = new SqlCommand(updateSql, con);
            cmd.Parameters.AddWithValue("@manv", maNV);

            int rs = cmd.ExecuteNonQuery();


            return rs > 0;
        }

        public bool updateNhanVien(string manv, string hotennv, string sdtnv, string dchinv, string gtinhnv, DateTime ngaysinhnv)
        {

            if (ConnectionState.Closed == con.State)
                con.Open();


            string updateSql = "UPDATE nhanvien SET hotennv=@hotennv, sdtnv=@sdtnv, dchinv=@dchinv, gtinhnv=@gtinhnv, ngaysinhnv=@ngaysinhnv WHERE manv=@manv";


            SqlCommand cmd = new SqlCommand(updateSql, con);

            // Thêm tham số vào câu lệnh
            cmd.Parameters.AddWithValue("@manv", manv);
            cmd.Parameters.AddWithValue("@hotennv", hotennv);
            cmd.Parameters.AddWithValue("@sdtnv", sdtnv);
            cmd.Parameters.AddWithValue("@dchinv", dchinv);
            cmd.Parameters.AddWithValue("@gtinhnv", gtinhnv);
            cmd.Parameters.AddWithValue("@ngaysinhnv", ngaysinhnv);
            int rs = cmd.ExecuteNonQuery();
            return rs > 0;
        }

        public string getMaNVByUserName(string username)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string sql = "select manv from nhanvien where tendn=@tendn";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@tendn", username);
                    string rs = (string)cmd.ExecuteScalar();
                    return rs;
                }

            }
        }


        public string getMKByMaNV(string manv)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string sql = "select matkhau from TAIKHOAN where TENDN=(select TENDN from NHANVIEN where MANV='" + manv + "')";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        string result = (string)cmd.ExecuteScalar();
                        return result;
                    }

                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public bool doiMatKhau(string manv, string mkmoi)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string sql = "update TAIKHOAN set MATKHAU = '" + mkmoi + "' where TENDN = (select TENDN from NHANVIEN where MANV = '" + manv + "')";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        int result = (int)cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }


    }
}
