using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QLBS_DTO;
using QLBS_DAL;

namespace QLBS_BLL
{
    public class QuanHuyenBLL
    {
        QuanHuyenDAL quanHuyenDAL = new QuanHuyenDAL();
        public List<QuanHuyenDTO> getAllQuanHuyen()
        {
            return quanHuyenDAL.getAllQuanHuyen();
        }
    }
}
