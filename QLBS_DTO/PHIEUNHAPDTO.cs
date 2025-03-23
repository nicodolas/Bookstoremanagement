using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBS_DTO
{
    public class PhieuNhapDTO
    {
        public string MAPN { get; set; }
        public DateTime NGAYDAT { get; set; }
        public decimal TONGDAT { get; set; }
        public string MANCC { get; set; }

        public PhieuNhapDTO(string mAPN, DateTime nGAYDAT, decimal tONGDAT, string mANCC)
        {
            MAPN = mAPN;
            NGAYDAT = nGAYDAT;
            TONGDAT = tONGDAT;
            MANCC = mANCC;
        }

        public PhieuNhapDTO()
        {
        }
    }
}
