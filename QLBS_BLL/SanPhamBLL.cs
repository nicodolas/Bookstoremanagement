using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLBS_DAL;
using QLBS_DTO;
namespace QLBS_BLL
{
    public class SanPhamBLL
    {
        SanPhamDAL sanPhamDAL = new SanPhamDAL();
        public List<SanPhamDTO> getAllSP()
        {
            return sanPhamDAL.getAllSP();
        }
        public List<SanPhamDTO> getAllSP_DatHang()
        {
            return sanPhamDAL.getAllSP_DatHang();
        }

        public DataTable getSPByID(string masp)
        {
            return sanPhamDAL.getSPByID(masp);
        }

        public List<LOAIDTO> getDSLoai()
        {
            return sanPhamDAL.getDSLoai();
        }
        public List<NXBDTO> getDSNXB()
        {
            return sanPhamDAL.getDSNXB();
        }

        public bool insertSP(SanPhamDTO sp)
        {
            if (sanPhamDAL.ktTrungMaSp(sp.MASP))
                return sanPhamDAL.insertSP(sp);
            return false;
        }
        public int getSLTonKho_SanPham(string masp)
        {
            return sanPhamDAL.getSLTonKho_SanPham(masp);
        }

        public DataTable TimKiemSanPhamTheoTen(string tenSP)
        {
            return sanPhamDAL.TimKiemSanPhamTheoTen(tenSP);
        }
    }
}
