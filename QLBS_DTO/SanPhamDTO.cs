using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBS_DTO
{
   public class SanPhamDTO
    {
        public string MASP { get; set; }
        public string TENSP { get; set; }
        public string TENTG { get; set; }
        public int NAMPH { get; set; }
        public decimal GIABAN { get; set; }
        public int TONKHO { get; set; }
        public string MALOAI { get; set; }
        public string MANXB { get; set; }

        public SanPhamDTO(string mASP, string tENSP, string tENTG, int nAMPH, decimal gIABAN, int tONKHO, string mALOAI, string mANXB)
        {
            MASP = mASP;
            TENSP = tENSP;
            TENTG = tENTG;
            NAMPH = nAMPH;
            GIABAN = gIABAN;
            TONKHO = tONKHO;
            MALOAI = mALOAI;
            MANXB = mANXB;
        }
        public SanPhamDTO()
        {

        }
    }
}
