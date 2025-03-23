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
  public  class PhieuNhapDAL:DBConnect
    {
        public List<PhieuNhapDTO> getAllPN()
        {
            List<PhieuNhapDTO> lst = new List<PhieuNhapDTO>();
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "select * from phieunhap where trangthai=N'Đã nhận'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                string mapn = rd[0].ToString();
                DateTime ngaydat =DateTime.Parse(rd[1].ToString());
                decimal tongdat = decimal.Parse(rd[2].ToString());
                string mancc = rd[3].ToString();
                PhieuNhapDTO pn = new PhieuNhapDTO(mapn, ngaydat, tongdat, mancc);
                lst.Add(pn);
            }
            con.Close();
            return lst;
        }

        public List<PhieuNhapDTO> getAllPNChoXacNhan()
        {
            List<PhieuNhapDTO> lst = new List<PhieuNhapDTO>();
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "select * from phieunhap where trangthai=N'Chưa xác nhận'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                string mapn = rd[0].ToString();
                DateTime ngaydat = DateTime.Parse(rd[1].ToString());
                decimal tongdat = decimal.Parse(rd[2].ToString());
                string mancc = rd[3].ToString();
                PhieuNhapDTO pn = new PhieuNhapDTO(mapn, ngaydat, tongdat, mancc);
                lst.Add(pn);
            }
            con.Close();
            return lst;
        }


        public List<NCCDTO> getAllNCC()
        {
            List<NCCDTO> lst = new List<NCCDTO>();
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "select * from ncc";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                string mancc = rd[0].ToString();
                string tencc = rd[1].ToString();
                string dcncc = rd[2].ToString();

                NCCDTO ncc = new NCCDTO(mancc, tencc, dcncc);
                lst.Add(ncc);
            }
            con.Close();
            return lst;
        }
       
        public DataTable getPNByID(string mapn)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            DataTable dt = new DataTable();
            string sql = "select mapn,ngaydat,tongdat,tenncc from phieunhap,NCC" +
                " where PHIEUNHAP.MANCC=NCC.MANCC and MAPN=@mapn";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@mapn", mapn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;

        }
        public DataTable getCTHDByID(string mapn)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "select TENSP,SLDAT,GIADAT from CHITIETPN,SANPHAM where" +
                " SANPHAM.MASP=CHITIETpn.MASP and MAPN=@mapn";
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@mapn", mapn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public string getNumPNMax()
        {

            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "select MAPN from PHIEUNHAP order by mapn desc";
            SqlCommand cmd = new SqlCommand(sql, con);
            string rs = cmd.ExecuteScalar().ToString();
            con.Close();
            return rs;

        }
        public bool createPN(PhieuNhapDTO pn)
        {
            try
            {
                if (ConnectionState.Closed == con.State)
                    con.Open();

                string sql = "INSERT INTO PHIEUNHAP (MAPN, NGAYDAT, TONGDAT, MANCC) " +
                             "VALUES (@mapn, @ngaydat, @tongdat, @mancc)";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@mapn", pn.MAPN);
                cmd.Parameters.AddWithValue("@ngaydat", pn.NGAYDAT);
                cmd.Parameters.AddWithValue("@tongdat", pn.TONGDAT);
                cmd.Parameters.AddWithValue("@mancc", pn.MANCC);

                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                con.Close();
                return false;
            }
        }
        public bool createCTPN(CTPNDTO ctpn)
        {
            try
            {
                if (ConnectionState.Closed == con.State)
                    con.Open();

                string sql = "INSERT INTO CHITIETPN (MAPN, MASP, SLDAT, GIADAT) " +
                             "VALUES (@mapn, @masp, @sldat, @giadat)";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@mapn", ctpn.MAPN);
                cmd.Parameters.AddWithValue("@masp", ctpn.MASP);
                cmd.Parameters.AddWithValue("@sldat", ctpn.SLDAT);
                cmd.Parameters.AddWithValue("@giadat", ctpn.GIADAT);

                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                con.Close();
                return false;
            }
        }

        public bool deleteCTPN(string mapn,string masp)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string query = "DELETE FROM CHITIETPN WHERE MaPN = @mapn AND masp = @masp";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@mapn", mapn);
            cmd.Parameters.AddWithValue("@masp", masp);
            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected > 0;

        }


        public bool xacNhanPN(string mapn)
        {

            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "update phieunhap set trangthai=N'Đã nhận' where mapn=@mapn";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@mapn", mapn);
            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected > 0;
        }

        public bool huyXacNhanPN(string mapn)
        {

            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "update phieunhap set trangthai=N'Đã hủy' where mapn=@mapn";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@mapn", mapn);
            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected > 0;
        }




        public void CapNhatSoLuongTonKho_SauKhiDatHang(string mapn)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Mở kết nối
                    conn.Open();

                    // Tạo SqlCommand
                    using (SqlCommand cmd = new SqlCommand("dbo.SP_CAPNHATSOLUONG_SAUNHAPKHO_CURSOR", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số đầu vào
                        cmd.Parameters.AddWithValue("@MAPN", mapn);
                       
                        // Thực thi Stored Procedure
                        cmd.ExecuteNonQuery();


                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PhieuNhapDTO> TimKiemPhieuNhapTheoNgay(DateTime ngaybd,DateTime ngaykt)
        {
            List<PhieuNhapDTO> lst = new List<PhieuNhapDTO>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string sql = "select * from FN_TIMKIEM_PN_THEONGAY(@ngaybd,@ngaykt)";
                using (SqlCommand cmd = new SqlCommand(sql,con))
                {
                    cmd.Parameters.AddWithValue("@ngaybd", ngaybd);
                    cmd.Parameters.AddWithValue("@ngaykt", ngaykt);
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        string mapn = rd[0].ToString();
                        DateTime ngaydat = DateTime.Parse(rd[1].ToString());
                        decimal tongdat = decimal.Parse(rd[2].ToString());
                        string mancc = rd[3].ToString();
                        PhieuNhapDTO pn = new PhieuNhapDTO(mapn, ngaydat, tongdat, mancc);
                        lst.Add(pn);
                    }
                    con.Close();
                    return lst;
                }
            }

        }








    }
}
