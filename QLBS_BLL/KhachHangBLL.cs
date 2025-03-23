using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBS_DTO;
using QLBS_DAL;

namespace QLBS_BLL
{
    public class KhachHangBLL
    {
        private KhachHangDAL khachhangDAL;

        public KhachHangBLL()
        {
            khachhangDAL = new KhachHangDAL();
        }
        public List<KhachHangDTO> GetAllKH()
        {
            return khachhangDAL.getAll();
        }
        public KhachHangDTO getKHByID(string makh)
        {
            return khachhangDAL.getKHByID(makh);
        }
        public string taoMaKh()
        {
            return khachhangDAL.taoMaKh();
        }
        public bool insertKH(KhachHangDTO kh)
        {
            return khachhangDAL.insertKH(kh);
        }
        public bool updateKH(KhachHangDTO kh)
        {
            return khachhangDAL.updateKH(kh);
        }
        public List<KhachHangDTO> getAllKH_Include_VangLai()
        {
            return khachhangDAL.getAllKH_Include_VangLai();
        }
    }
}
