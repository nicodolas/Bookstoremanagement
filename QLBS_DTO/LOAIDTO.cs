using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBS_DTO
{
    public class LOAIDTO
    {
        public string MALOAI { get; set; }
        public string TENLOAI { get; set; }
        public string MAPL { get; set; }
        public LOAIDTO()
        {

        }
        public LOAIDTO(string mALOAI, string tENLOAI, string mAPL)
        {
            MALOAI = mALOAI;
            TENLOAI = tENLOAI;
            MAPL = mAPL;
        }
    }
}
