using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBS_DAL;
using QLBS_DTO;

namespace QLBS_BLL
{
    public class TaiKhoanBLL
    {
        TaiKhoanDAL taiKhoanDAL = new TaiKhoanDAL();

        // Đăng nhập với mật khẩu đã được mã hóa MD5
        public TaiKhoanDTO DangNhap(string tenDN, string matKhau)
        {
            // Mã hóa mật khẩu bằng MD5
            string matKhauMaHoa = MD5Hash.Hash(matKhau);

            // Kiểm tra tài khoản với mật khẩu đã mã hóa
            TaiKhoanDTO taiKhoan = taiKhoanDAL.GetTaiKhoan(tenDN, matKhauMaHoa);
            if (taiKhoan != null)
            {
                return taiKhoan;
            }
            return null;
        }

        // Lấy số lượng tài khoản tối đa
        public int getNumberAccMax()
        {
            return taiKhoanDAL.getNumberAccMax();
        }
        public string GenerateUsername()
        {
            // Lấy số tài khoản lớn nhất hiện có
            int maxNumber = getNumberAccMax();

            // Tạo tên đăng nhập mới bằng cách tăng maxNumber lên 1
            int newNumber = maxNumber + 1;

            // Tạo tên đăng nhập mới với định dạng "nhanvien" + số
            string newUsername = "nhanvien" + newNumber.ToString();

            return newUsername;
        }

        // Tạo tài khoản mới với mật khẩu đã được mã hóa MD5
        public bool createAccount(TaiKhoanDTO tk)
        {
            // Mã hóa mật khẩu trước khi lưu vào cơ sở dữ liệu
            tk.MatKhau = MD5Hash.Hash(tk.MatKhau);
            return taiKhoanDAL.createAccount(tk);
        }

        // Xóa tài khoản
        public bool deleteAccount(string tendn)
        {
            return taiKhoanDAL.deleteAccount(tendn);
        }

        // Cập nhật mật khẩu tài khoản, áp dụng mã hóa MD5 cho mật khẩu mới
        public bool updateAccount(string tendn, string mk)
        {
            // Mã hóa mật khẩu mới bằng MD5
            string matKhauMaHoa = MD5Hash.Hash(mk);
            return taiKhoanDAL.updateAccount(tendn, matKhauMaHoa);
        }
    }
}
