using System;
using System.Data.SqlClient;

namespace QL_Thi_Trac_Nghiem.DAO
{
    public class TaiKhoanDAO
    {
        private static TaiKhoanDAO instance;
        public static TaiKhoanDAO Instance
        {
            get { if (instance == null) instance = new TaiKhoanDAO(); return instance; }
            private set { instance = value; }
        }
        private TaiKhoanDAO() { }

        public string KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            string loaiTaiKhoan = "";
            using (SqlConnection conn = MyConnection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT LoaiTaiKhoan
                                 FROM TaiKhoan
                                 WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                    cmd.Parameters.AddWithValue("@MatKhau", matKhau);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            loaiTaiKhoan = reader.GetString(0);
                        }
                    }
                }
            }
            return loaiTaiKhoan;
        }

        public bool DoiMatKhau(string tenDangNhap, string matKhauCu, string matKhauMoi, out string thongBao)
        {
            thongBao = "";

            using (SqlConnection conn = MyConnection.GetConnection())
            {
                conn.Open();

                string checkQuery = @"SELECT COUNT(1)
                                      FROM TaiKhoan
                                      WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhauCu";

                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                    checkCmd.Parameters.AddWithValue("@MatKhauCu", matKhauCu);

                    int hopLe = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (hopLe == 0)
                    {
                        thongBao = "Mật khẩu hiện tại không chính xác!";
                        return false;
                    }
                }

                string updateQuery = @"UPDATE TaiKhoan
                                       SET MatKhau = @MatKhauMoi,
                                           PhaiDoiMatKhau = 0,
                                           NgayCapNhatMatKhau = GETDATE()
                                       WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhauCu";

                using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                {
                    updateCmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                    updateCmd.Parameters.AddWithValue("@MatKhauCu", matKhauCu);
                    updateCmd.Parameters.AddWithValue("@MatKhauMoi", matKhauMoi);

                    int rows = updateCmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        thongBao = "Đổi mật khẩu thành công! Lần đăng nhập sau hãy dùng mật khẩu mới.";
                        return true;
                    }
                }
            }

            thongBao = "Không thể cập nhật mật khẩu. Vui lòng thử lại!";
            return false;
        }
    }
}