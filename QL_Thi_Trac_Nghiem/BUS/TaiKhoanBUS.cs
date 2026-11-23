using QL_Thi_Trac_Nghiem.DAO;

namespace QL_Thi_Trac_Nghiem.BUS
{
    public class TaiKhoanBUS
    {
        public string KiemTraDangNhap(string taiKhoan, string matKhau)
        {
            return TaiKhoanDAO.Instance.KiemTraDangNhap(taiKhoan, matKhau);
        }

        public bool DoiMatKhau(string tenDangNhap, string matKhauCu, string matKhauMoi, out string thongBao)
        {
            tenDangNhap = tenDangNhap?.Trim() ?? "";
            matKhauCu = matKhauCu?.Trim() ?? "";
            matKhauMoi = matKhauMoi?.Trim() ?? "";

            if (string.IsNullOrEmpty(tenDangNhap))
            {
                thongBao = "Chưa xác định tài khoản đang đăng nhập.";
                return false;
            }

            if (string.IsNullOrEmpty(matKhauCu) || string.IsNullOrEmpty(matKhauMoi))
            {
                thongBao = "Vui lòng nhập đầy đủ mật khẩu hiện tại và mật khẩu mới.";
                return false;
            }

            if (matKhauMoi.Length < 6)
            {
                thongBao = "Mật khẩu mới phải có ít nhất 6 ký tự.";
                return false;
            }

            if (matKhauCu == matKhauMoi)
            {
                thongBao = "Mật khẩu mới phải khác mật khẩu hiện tại.";
                return false;
            }

            return TaiKhoanDAO.Instance.DoiMatKhau(tenDangNhap, matKhauCu, matKhauMoi, out thongBao);
        }
    }
}