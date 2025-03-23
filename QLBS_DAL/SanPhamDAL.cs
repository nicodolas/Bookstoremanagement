using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBS_DTO;
using System.Data.SqlClient;
using System.Data;

namespace QLBS_DAL
{
   public class SanPhamDAL:DBConnect
    {
        public List<SanPhamDTO> getAllSP()
        {
            List<SanPhamDTO> lst = new List<SanPhamDTO>();
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "select * from sanpham where tonkho>0";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                SanPhamDTO sp = new SanPhamDTO();
                sp.MASP = rd[0].ToString();
                sp.TENSP = rd[1].ToString();
                sp.TENTG = rd[2].ToString();
                sp.NAMPH = (int)rd[3];
                sp.GIABAN = (decimal)rd[4];
                sp.TONKHO = (int)rd[5];
                sp.MALOAI = rd[6].ToString();
                sp.MANXB = rd[7].ToString();
                lst.Add(sp);
            }
            con.Close();
            return lst;

        }
        public List<SanPhamDTO> getAllSP_DatHang()
        {
            List<SanPhamDTO> lst = new List<SanPhamDTO>();
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "select * from sanpham";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                SanPhamDTO sp = new SanPhamDTO();
                sp.MASP = rd[0].ToString();
                sp.TENSP = rd[1].ToString();
                sp.TENTG = rd[2].ToString();
                sp.NAMPH = (int)rd[3];
                sp.GIABAN = (decimal)rd[4];
                sp.TONKHO = (int)rd[5];
                sp.MALOAI = rd[6].ToString();
                sp.MANXB = rd[7].ToString();
                lst.Add(sp);
            }
            con.Close();
            return lst;

        }
        public DataTable getSPByID(string masp)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "SELECT MASP,TENSP,NAMPH,TONKHO,GIABAN,TENTG,TENNXB,TENLOAI FROM SANPHAM,NXB,LOAI where " +
                " SANPHAM.MANXB=NXB.MANXB and SANPHAM.MALOAI=LOAI.MALOAI and MASP = @masp";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@masp", masp);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            con.Close();

            return dt;

        }

        public List<LOAIDTO> getDSLoai()
        {
            List<LOAIDTO> lst = new List<LOAIDTO>();
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "select * from loai order by tenloai asc";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                string maloai = rd[0].ToString();
                string tenloai = rd[1].ToString();
                string mapl = rd[2].ToString();
                LOAIDTO loai = new LOAIDTO(maloai,tenloai,mapl);
                lst.Add(loai);
            }
            con.Close();
            return lst;

        }

        public List<NXBDTO> getDSNXB()
        {
            List<NXBDTO> lst = new List<NXBDTO>();
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "select * from nxb order by TENNXB asc";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                string manxb = rd[0].ToString();
                string tennxb = rd[1].ToString();
                string dc = rd[2].ToString();
                NXBDTO nxb = new NXBDTO(manxb, tennxb, dc);
                lst.Add(nxb);
            }
            con.Close();
            return lst;

        }
        public bool ktTrungMaSp(string masp)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "select count(*) from sanpham where masp =@masp";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@masp", masp);
            int rs = (int)cmd.ExecuteScalar();
            con.Close();
            return !(rs > 0);

        }
        public bool insertSP(SanPhamDTO sp)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "insert into sanpham values(@masp,@tensp,@tentg,@namph,@giaban,@sl,@maloai,@manxb)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@masp", sp.MASP);
            cmd.Parameters.AddWithValue("@tensp", sp.TENSP);
            cmd.Parameters.AddWithValue("@tentg", sp.TENTG);
            cmd.Parameters.AddWithValue("@namph", sp.NAMPH);
            cmd.Parameters.AddWithValue("@giaban", sp.GIABAN);
            cmd.Parameters.AddWithValue("@sl", sp.TONKHO);
            cmd.Parameters.AddWithValue("@maloai", sp.MALOAI);
            cmd.Parameters.AddWithValue("@manxb", sp.MANXB);
            int rs = cmd.ExecuteNonQuery();
            con.Close();
            return rs > 0;
        }
        public int getSLTonKho_SanPham(string masp)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string sql = "select tonkho from sanpham where masp='" + masp + "'";
                using (SqlCommand cmd = new SqlCommand(sql,con))
                {
                    int rs = (int)cmd.ExecuteScalar();
                    return rs;
                }

            }
        }

        public DataTable TimKiemSanPhamTheoTen(string tenSP)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM FN_TIMKIEM_THEOTEN(@TenSP)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenSP", tenSP);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }







    }
}
