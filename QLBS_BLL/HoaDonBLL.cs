using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBS_DTO;
using QLBS_DAL;

namespace QLBS_BLL
{
    public class HoaDonBLL
    {
        private HoaDonDAL hoaDonDAL;
        public HoaDonBLL()
        {
            hoaDonDAL = new HoaDonDAL();
        }
        public HoaDonDTO getHoaDonByMaHD(string maHD)
        {
            return hoaDonDAL.getHoaDonByMaHD(maHD);
        }
        public List<HoaDonDTO> GetAllHoaDon()
        {
            return hoaDonDAL.getAll();
        }
        public string getKhachHangByMaKH(string maKH)
        {
            return hoaDonDAL.getKhachHangByMaKH(maKH);
        }
        public string getNhanVienByMaNV(string maNV)
        {
            return hoaDonDAL.getNhanVienByMaNV(maNV);
        }
        public List<CTHDDTO> getSanPhamByMaHD(string maHD)
        {
            return hoaDonDAL.getSanPhamByMaHD(maHD);
        }

        public bool insertHoaDon(HoaDonDTO hoadon)
        {
            return hoaDonDAL.insertHoaDon(hoadon);
        }
        public bool DeleteHoaDon(string mAHD)
        {
            return hoaDonDAL.DeleteHoaDon(mAHD);
        }
        public bool updateHoaDon(string mahd, DateTime ngaylaphd, decimal tongtien,string makh,string manv)
        {
            return hoaDonDAL.updateHoaDon(mahd, ngaylaphd, tongtien, makh, manv);
        }
        public bool insertCTHD(CTHDDTO CTHD)
        {
            return hoaDonDAL.insertCTHD(CTHD);
        }

        public decimal getGiaByMaSP(string maSP)
        {
            return hoaDonDAL.getGiaByMaSP(maSP);
        }
        public void updateTongTien(string mahd)
        {
            hoaDonDAL.updateTongTien(mahd);
        }
        public decimal getTongTien(string mahd)
        {
            return hoaDonDAL.tinhTongTien(mahd);
        }
        public string taoMaHD()
        {
            return hoaDonDAL.taoMaHD();
        }
        public bool XacNhanThanhToan(string mahd)
        {
            return hoaDonDAL.XacNhanThanhToan(mahd);
        }
        public void TinhDiemTichLuy(string mahd)
        {
             hoaDonDAL.TinhDiemTichLuy(mahd);
        }
        public void CapNhatSoLuongTonKho_SauKhiMua(string masp, int slmua)
        {
            hoaDonDAL.CapNhatSoLuongTonKho_SauKhiMua(masp, slmua);
        }
        public List<HoaDonDTO> TimKiemHDTheoNgay(DateTime ngaybd, DateTime ngaykt)
        {
            return hoaDonDAL.TimKiemHDTheoNgay(ngaybd,ngaykt);
        }
    }
}
