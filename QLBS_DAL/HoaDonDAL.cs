using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using QLBS_DTO;
using System.Data;

namespace QLBS_DAL
{
    public class HoaDonDAL:DBConnect
    {
        public List<HoaDonDTO> getAll()
        {
            List<HoaDonDTO> lst = new List<HoaDonDTO>();
            if (ConnectionState.Closed == con.State)
                con.Open();
            string getAllSql = "Select * from hoadon";
            SqlCommand cmd = new SqlCommand(getAllSql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                HoaDonDTO hd = new HoaDonDTO()
                {
                    MAHD= rd[0].ToString(),
                    NGAYLAPHD = rd.GetDateTime(1),
                    TONGTIEN = decimal.Parse(rd[2].ToString()),
                    MAKH = rd[3].ToString(),
                    MANV = rd[4].ToString(),
                };
                lst.Add(hd);
            }
            con.Close();
            return lst;
        }

        public HoaDonDTO getHoaDonByMaHD(string maHD)
        {
            HoaDonDTO hd = null;
            List<HoaDonDTO> lst = new List<HoaDonDTO>();
            if (ConnectionState.Closed == con.State)
            {
                con.Open();
            }
            string getHDSql = "Select * from hoadon where mahd=@mahd";
            SqlCommand cmd = new SqlCommand(getHDSql, con);
            cmd.Parameters.AddWithValue("@mahd", maHD);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                hd = new HoaDonDTO()
                {
                    MAHD = rd[0].ToString(),
                    NGAYLAPHD = rd.GetDateTime(1),
                    TONGTIEN = decimal.Parse(rd[2].ToString()),
                    MAKH = rd[3].ToString(),
                    MANV = rd[4].ToString(),
                };

            }
            con.Close();
            return hd;
        }
        public string getKhachHangByMaKH(string maKH)
        {
            string kh = null;
            List<KhachHangDTO> lst = new List<KhachHangDTO>();
            if (ConnectionState.Closed == con.State)
            {
                con.Open();
            }
            string getKHSql = "Select HOTENKH from hoadon, khachhang where khachhang.makh=@makh and hoadon.makh=khachhang.makh";
            SqlCommand cmd = new SqlCommand(getKHSql, con);
            cmd.Parameters.AddWithValue("@makh", maKH);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                kh = rd[0].ToString();
            }
            con.Close();
            return kh;
        }
        public string getNhanVienByMaNV(string maNV)
        {
            string nv = null;
            List<NhanVienDTO> lst = new List<NhanVienDTO>();
            if (ConnectionState.Closed == con.State)
            {
                con.Open();
            }
            string getNVSql = "Select HOTENNV from hoadon, nhanvien where nhanvien.manv=@manv and hoadon.manv=nhanvien.manv";
            SqlCommand cmd = new SqlCommand(getNVSql, con);
            cmd.Parameters.AddWithValue("@manv", maNV);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                nv = rd[0].ToString();
            }
            con.Close();
            return nv;
        }
        public List<CTHDDTO> getSanPhamByMaHD(string maHD)
        {
            List<CTHDDTO> lst = new List<CTHDDTO>();
            if (ConnectionState.Closed == con.State)
                con.Open();
            string getSPSql = "Select Tensp,SLMUA from hoadon, CHITIETHD, sanpham where hoadon.mahd=CHITIETHD.MAHD and chitiethd.mahd=@mahd and chitiethd.masp=sanpham.masp";
            SqlCommand cmd = new SqlCommand(getSPSql, con);
            cmd.Parameters.AddWithValue("@mahd", maHD);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                CTHDDTO sp = new CTHDDTO()
                {
                    MASP=rd[0].ToString(),
                    SLMUA=int.Parse(rd[1].ToString())
                };
                lst.Add(sp);
            }
            con.Close();
            return lst;
        }
        public bool insertHoaDon(HoaDonDTO hoadon)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string insertSql = "insert into hoadon values(@mahd,@ngaylaphd,@tongtien,@makh,@manv)";
            SqlCommand cmd = new SqlCommand(insertSql, con);
            cmd.Parameters.AddWithValue("@mahd", hoadon.MAHD);
            cmd.Parameters.AddWithValue("@ngaylaphd", hoadon.NGAYLAPHD);
            cmd.Parameters.AddWithValue("@tongtien", hoadon.TONGTIEN);
            cmd.Parameters.AddWithValue("@makh", hoadon.MAKH);
            cmd.Parameters.AddWithValue("@manv", hoadon.MANV);
            int rs = cmd.ExecuteNonQuery();
            con.Close();
            return rs > 0;
        }
        public bool DeleteHoaDon(string mAHD)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();

            string deleteSql = "DELETE FROM hoadon WHERE mahd = @mahd";
            SqlCommand cmd = new SqlCommand(deleteSql, con);
            cmd.Parameters.AddWithValue("@mahd", mAHD);

            int rs = cmd.ExecuteNonQuery();


            return rs > 0;
        }
        public bool updateHoaDon(string mahd, DateTime ngaylaphd, decimal tongtien, string makh, string manv)
        {

            if (ConnectionState.Closed == con.State)
                con.Open();


            string updateSql = "UPDATE nhanvien SET ngaylaphd=@ngaylaphd, tongtien=@tongtien, makh=@makh, manv=@manv where mahd=@mahd";


            SqlCommand cmd = new SqlCommand(updateSql, con);

            // Thêm tham số vào câu lệnh
            cmd.Parameters.AddWithValue("@mahd", mahd);
            cmd.Parameters.AddWithValue("@ngaylaphd", ngaylaphd);
            cmd.Parameters.AddWithValue("@tongtien", tongtien);
            cmd.Parameters.AddWithValue("@makh", makh);
            cmd.Parameters.AddWithValue("@manv", manv);
            int rs = cmd.ExecuteNonQuery();
            return rs > 0;
        }

        public bool insertCTHD(CTHDDTO CTHD)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string insertSql = "insert into Chitiethd values(@mahd,@masp,@sl,@gia)";
            SqlCommand cmd = new SqlCommand(insertSql, con);
            cmd.Parameters.AddWithValue("@mahd", CTHD.MAHD);
            cmd.Parameters.AddWithValue("@masp", CTHD.MASP);
            cmd.Parameters.AddWithValue("@sl", CTHD.SLMUA);
            cmd.Parameters.AddWithValue("@gia", CTHD.GIABAN);
            int rs = cmd.ExecuteNonQuery();
            con.Close();
            return rs > 0;
        }

        public decimal getGiaByMaSP(string masp)
        {
            decimal gia = 0;
            List<SanPhamDTO> lst = new List<SanPhamDTO>();
            if (ConnectionState.Closed == con.State)
            {
                con.Open();
            }
            string getGiaSql = "Select giaban from sanpham where masp=@masp";
            SqlCommand cmd = new SqlCommand(getGiaSql, con);
            cmd.Parameters.AddWithValue("@masp", masp);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                gia = decimal.Parse(rd[0].ToString());
            }
            con.Close();
            return gia;
        }

        public decimal tinhTongTien(string mahd)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            decimal gia = 0;
            string getSql = "select SUM(slmua*giaban) from CHITIETHD where MAHD=@mahd";
            SqlCommand cmd = new SqlCommand(getSql, con);
            cmd.Parameters.AddWithValue("@mahd", mahd);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                gia = decimal.Parse(rd[0].ToString());
            }
            con.Close();
            return gia;
        }

        public void updateTongTien(string mahd)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();

            decimal tongtien = tinhTongTien(mahd);
            string updateSql = "UPDATE hoadon SET tongtien=@tongtien where mahd=@mahd";


            SqlCommand cmd = new SqlCommand(updateSql, con);

            // Thêm tham số vào câu lệnh
            cmd.Parameters.AddWithValue("@mahd", mahd);
            cmd.Parameters.AddWithValue("@tongtien", tongtien);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public string taoMaHD()
        {
            if (ConnectionState.Closed == con.State)
                con.Open();

            string sql = "SELECT MAX(CAST(SUBSTRING(MAHD, 3, LEN(MAHD)) AS INT)) FROM HOADON";
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                var result = cmd.ExecuteScalar();

                // Kiểm tra giá trị trả về
                if (result != DBNull.Value)
                {
                    int stt = (int)result;
                    return "HD" + (stt + 1).ToString("D3");
                }
                else
                {
                    return "HD001"; // Nếu không có mã nào, trả về "HD001"
                }
            }
        }
        public bool XacNhanThanhToan(string mahd)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Mở kết nối
                    conn.Open();

                    // Tạo SqlCommand
                    using (SqlCommand cmd = new SqlCommand("dbo.SP_CapNhatTongTienSauGiamGia", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số đầu vào
                        cmd.Parameters.AddWithValue("@MaHD", mahd);

                        // Thực thi Stored Procedure
                       cmd.ExecuteNonQuery();
                        return true;
                       
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public void TinhDiemTichLuy(string mahd)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Mở kết nối
                    conn.Open();

                    // Tạo SqlCommand
                    using (SqlCommand cmd = new SqlCommand("dbo.SP_CapNhatDiemTichLuy", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số đầu vào
                        cmd.Parameters.AddWithValue("@MaHD", mahd);

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

        public void CapNhatSoLuongTonKho_SauKhiMua(string masp,int slmua)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Mở kết nối
                    conn.Open();

                    // Tạo SqlCommand
                    using (SqlCommand cmd = new SqlCommand("dbo.SP_CAPNHATSOLUONG_SAUTT", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số đầu vào
                        cmd.Parameters.AddWithValue("@MASP", masp);
                        cmd.Parameters.AddWithValue("@SLMUA", slmua);

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
        public List<HoaDonDTO> TimKiemHDTheoNgay(DateTime ngaybd, DateTime ngaykt)
        {
            List<HoaDonDTO> lst = new List<HoaDonDTO>();

            try
            {
                if (ConnectionState.Closed == con.State)
                    con.Open();

                string query = "SELECT * FROM FN_TIMKIEM_HD_THEONGAY(@NgayBatDau, @NgayKetThuc)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@NgayBatDau", ngaybd);
                    cmd.Parameters.AddWithValue("@NgayKetThuc", ngaykt);

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            HoaDonDTO hd = new HoaDonDTO()
                            {
                                MAHD = rd["MAHD"].ToString(),
                                NGAYLAPHD = rd["NGAYLAPHD"] == DBNull.Value ? DateTime.MinValue : rd.GetDateTime(rd.GetOrdinal("NGAYLAPHD")),
                                TONGTIEN = rd["TONGTIEN"] == DBNull.Value ? 0 : Convert.ToDecimal(rd["TONGTIEN"]),
                                MAKH = rd["MAKH"].ToString(),
                                MANV = rd["MANV"].ToString()
                            };
                            lst.Add(hd);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi (ghi log hoặc thông báo)
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                if (ConnectionState.Open == con.State)
                    con.Close();
            }

            return lst;
        }




    }
}
