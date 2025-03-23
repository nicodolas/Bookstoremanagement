using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBS_DTO
{
    public class HoaDonDTO
    {
        public string MAHD { get; set; }
        public DateTime NGAYLAPHD { get; set; }
        public decimal TONGTIEN { get; set; }
        public string MAKH { get; set; }
        public string MANV { get; set; }
        public HoaDonDTO()
        {

        }
        public HoaDonDTO(string mAHD, DateTime nGAYLAPHD, Decimal tONGTIEN, string mAKH, string mANV)
        {
            MAHD = mAHD;
            NGAYLAPHD = nGAYLAPHD;
            TONGTIEN = tONGTIEN;
            MAKH = mAKH;
            MANV = mANV;
        }
    }
}
