using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBS_DTO;
using QLBS_DAL;
using System.Data;

namespace QLBS_BLL
{
    public class PhieuNhapBLL
    {
        PhieuNhapDAL phieuNhapDAL = new PhieuNhapDAL();

        public List<PhieuNhapDTO> getAllPN()
        {
            return phieuNhapDAL.getAllPN();
        }
        public List<PhieuNhapDTO> getAllPNChoXacNhan()
        {
            return phieuNhapDAL.getAllPNChoXacNhan();
        }
        public DataTable getPNByID(string mapn)
        {
            return phieuNhapDAL.getPNByID(mapn);
        }
        public List<NCCDTO> getAllNCC()
        {
            return phieuNhapDAL.getAllNCC();
        }

        public DataTable getCTHDByID(string mapn)
        {
            return phieuNhapDAL.getCTHDByID(mapn);
        }

        public string getNumPNMax()
        {
            string numPNMax = phieuNhapDAL.getNumPNMax();
            if (numPNMax.StartsWith("PN"))
            {
                return numPNMax.Substring(2);
            }
            return "0";
        }

        public string generateNewPN()
        {
            string maxPNString = getNumPNMax();
            int maxPN = int.Parse(maxPNString);
            int newPNNumber = maxPN + 1;
            string newPN = "PN" + newPNNumber.ToString("D3"); // D3 để luôn có 3 chữ số, ví dụ: PN001
            return newPN;
        }

        public bool createPN(PhieuNhapDTO pn)
        {
            return phieuNhapDAL.createPN(pn);
        }

        public bool createCTPN(CTPNDTO ctpn)
        {
            return phieuNhapDAL.createCTPN(ctpn);
        }




        public bool deleteCTPN(string mapn, string masp)
        {
            return phieuNhapDAL.deleteCTPN(mapn, masp);
        }
        public bool xacNhanPN(string mapn)
        {
            return phieuNhapDAL.xacNhanPN(mapn);
        }
        public bool huyXacNhanPN(string mapn)
        {
            return phieuNhapDAL.huyXacNhanPN(mapn);
        }

        public void CapNhatSoLuongTonKho_SauKhiDatHang(string mapn)
        {
            phieuNhapDAL.CapNhatSoLuongTonKho_SauKhiDatHang(mapn);
        }

        public List<PhieuNhapDTO> TimKiemPhieuNhapTheoNgay(DateTime ngaybd, DateTime ngaykt)
        {
            return phieuNhapDAL.TimKiemPhieuNhapTheoNgay(ngaybd, ngaykt);
        }



    }
}
