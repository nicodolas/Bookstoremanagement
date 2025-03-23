using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBS_DAL;
using QLBS_DTO;

namespace QLBS_BLL
{
    public class NhanVienBLL
    {
        private NhanVienDAL nhanVienDAL;

        public NhanVienBLL()
        {
            nhanVienDAL = new NhanVienDAL();
        }
        public List<NhanVienDTO> GetAllNhanVien()
        {
            return nhanVienDAL.getAll();
        }
        public NhanVienDTO getNhanVienById(string MANV)
        {
            return nhanVienDAL.getNhanVienById(MANV);
        }
        public NhanVienDTO getNhanVienByTenDN(string tendn)
        {
            return nhanVienDAL.getNhanVienByTenDN(tendn);
        }
        public bool insertNhanVien(NhanVienDTO nhanvien)
        {
            return nhanVienDAL.insertNhanVien(nhanvien);
        }

        public bool DeleteNhanVien(string maNV)
        {
            return nhanVienDAL.DeleteNhanVien(maNV);
        }


        public bool updateNhanVien(string manv, string hotennv, string sdtnv, string dchinv, string gtinhnv, DateTime ngaysinhnv)
        {
            return nhanVienDAL.updateNhanVien(manv, hotennv, sdtnv, dchinv, gtinhnv, ngaysinhnv);
        }
        public string getMaNVByUserName(string username)
        {
            return nhanVienDAL.getMaNVByUserName(username);
        }

        public string getMKByMaNV(string manv)
        {
            return nhanVienDAL.getMKByMaNV(manv);
        }
        public bool kiemTraMKTrungNhau(string manv, string matkhauNhapVao)
        {
            string matKhauMaHoa = MD5Hash.Hash(matkhauNhapVao);    //chuyển mật khẩu nhập vào,                                           
            return matKhauMaHoa.ToLower() == getMKByMaNV(manv).ToLower(); //mã hóa rồi so sánh với mật khẩu trong db 
        }
        public bool doiMatKhau(string manv, string mkmoi)
        {
            string matKhauMaHoa = MD5Hash.Hash(mkmoi);
            return nhanVienDAL.doiMatKhau(manv, matKhauMaHoa);
        }
    }
}
