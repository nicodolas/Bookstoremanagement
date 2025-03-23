using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBS_DTO
{
    public class NhanVienDTO
    {
        public string MANV { get; set; }
        public string HOTENNV { get; set; }
        public string SDTNV { get; set; }
        public string DCHINV { get; set; }
        public string GTINHNV { get; set; }
        public DateTime NGAYSINHNV { get; set; }
        public string TENDN { get; set; }
        public string TINHTRANG { get; set; }
        public NhanVienDTO()
        {
                
        }
        public NhanVienDTO(string mANV, string hOTENNV, string sDTNV, string dCHINV, string gTINHNV, DateTime nGAYSINHNV, string tENDN, string tINHTRANG)
        {
            MANV = mANV;
            HOTENNV = hOTENNV;
            SDTNV = sDTNV;
            DCHINV = dCHINV;
            GTINHNV = gTINHNV;
            NGAYSINHNV = nGAYSINHNV;
            TENDN = tENDN;
            TINHTRANG = tINHTRANG;
        }

        public NhanVienDTO(string mANV, string hOTENNV, string sDTNV, string dCHINV, string gTINHNV, DateTime nGAYSINHNV, string tENDN)
        {
            MANV = mANV;
            HOTENNV = hOTENNV;
            SDTNV = sDTNV;
            DCHINV = dCHINV;
            GTINHNV = gTINHNV;
            NGAYSINHNV = nGAYSINHNV;
            TENDN = tENDN;
        }
    }
}
