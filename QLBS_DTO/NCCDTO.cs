using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBS_DTO
{
    public class NCCDTO
    {
        public string MANCC { get; set; }
        public string TENNCC { get; set; }
        public string DCNCC { get; set; }

        public NCCDTO(string mANCC, string tENNCC, string dCNCC)
        {
            MANCC = mANCC;
            TENNCC = tENNCC;
            DCNCC = dCNCC;
        }
    }
}
