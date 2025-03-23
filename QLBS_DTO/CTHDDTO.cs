using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBS_DTO
{
    public class CTHDDTO
    {
        public string MAHD { get; set; }
        public string MASP { get; set; }
        public int SLMUA { get; set; }
        public decimal GIABAN { get; set; }
        public CTHDDTO()
        {

        }
        public CTHDDTO(string mAHD, string mASP, int sLMUA, decimal gIABAN)
        {
            MAHD = mAHD;
            MASP = mASP;
            SLMUA = sLMUA;
            GIABAN = gIABAN;
        }
    }
}
