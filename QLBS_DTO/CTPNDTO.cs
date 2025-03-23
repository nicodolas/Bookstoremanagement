using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBS_DTO
{
   public class CTPNDTO
    {
        public string MAPN { get; set; }
        public string MASP { get; set; }
        public int SLDAT { get; set; }
        public decimal GIADAT { get; set; }

        public CTPNDTO(string mAPN, string mASP, int sLDAT, decimal gIADAT)
        {
            MAPN = mAPN;
            MASP = mASP;
            SLDAT = sLDAT;
            GIADAT = gIADAT;
        }

        public CTPNDTO()
        {
        }
    }

}
