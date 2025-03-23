using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBS_DTO
{
    public class KhachHangDTO
    {
        public string MAKH { get; set; }    
        public string TENKH { get; set; }
        public string SDT { get; set; }

        public string DCHIKH { get; set; }

        public string GTINHKH { get; set; }

        public DateTime NGAYSINH { get; set; }

        public int DIEMTICHLUY { get; set; }

        public float GIAMGIA { get; set; }

        public KhachHangDTO(string mAKH, string tENKH, string sDT, string dCHIKH, string gTINHKH, DateTime nGAYSINH, int dIEMTICHLUY, float gIAMGIA)
        {
            MAKH = mAKH;
            TENKH = tENKH;
            SDT = sDT;
            DCHIKH = dCHIKH;
            GTINHKH = gTINHKH;
            NGAYSINH = nGAYSINH;
            DIEMTICHLUY = dIEMTICHLUY;
            GIAMGIA = gIAMGIA;
        }

        public KhachHangDTO(string mAKH, string tENKH, string sDT, string dCHIKH, string gTINHKH, DateTime nGAYSINH)
        {
            MAKH = mAKH;
            TENKH = tENKH;
            SDT = sDT;
            DCHIKH = dCHIKH;
            GTINHKH = gTINHKH;
            NGAYSINH = nGAYSINH;
        }

        public KhachHangDTO()
        {
            
        }
    }
}
