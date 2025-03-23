using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBS_DTO
{
    public class NXBDTO
    {
        public string MANXB { get; set; }
        public string TENNXB { get; set; }
        public string DCNXB { get; set; }

        public NXBDTO(string mANXB, string tENNXB, string dCNXB)
        {
            MANXB = mANXB;
            TENNXB = tENNXB;
            DCNXB = dCNXB;
        }
        public NXBDTO()
        {

        }
    }
}
