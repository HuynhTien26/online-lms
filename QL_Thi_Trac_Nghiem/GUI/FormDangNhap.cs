using System;
using System.Windows.Forms;
using QL_Thi_Trac_Nghiem.BUS;

namespace QL_Thi_Trac_Nghiem.GUI
{
    public partial class FormDangNhap : Form
    {
        TaiKhoanBUS taiKhoanBUS = new TaiKhoanBUS();

        public FormDangNhap()
        {
            InitializeComponent();
            if (pnlDoiMatKhau != null)
            {
                pnlDoiMatKhau.Visible = false;
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string taiKhoan = txtTaiKhoan.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(taiKhoan) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tài khoản và Mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string loaiTaiKhoan = taiKhoanBUS.KiemTraDangNhap(taiKhoan, matKhau);

            if (loaiTaiKhoan == "AD")
            {
                MessageBox.Show("Đăng nhập thành công! Chào mừng Quản trị viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormMainAdmin frmMain = new FormMainAdmin();
                this.Hide();
                frmMain.ShowDialog();
                this.Show();
            }
            else if (loaiTaiKhoan == "GV")
            {
                MessageBox.Show($"Đăng nhập thành công! Mã giảng viên: {taiKhoan}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormMainAdmin frmMainGV = new FormMainAdmin(taiKhoan, "Giáo viên");
                this.Hide();
                frmMainGV.ShowDialog();
                this.Show();
            }
            else if (loaiTaiKhoan == "TS" || loaiTaiKhoan == "SV")
            {
                MessageBox.Show($"Đăng nhập thành công! Mã thí sinh: {taiKhoan}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormSinhVien frmSV = new FormSinhVien();
                this.Hide();
                frmSV.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            txtTaiKhoanDoiMK.Text = txtTaiKhoan.Text.Trim();
            txtMatKhauHienTai.Clear();
            txtMatKhauMoi.Clear();
            txtXacNhanMatKhau.Clear();

            pnlDoiMatKhau.Visible = true;
            pnlDoiMatKhau.BringToFront();

            if (string.IsNullOrWhiteSpace(txtTaiKhoanDoiMK.Text))
                txtTaiKhoanDoiMK.Focus();
            else
                txtMatKhauHienTai.Focus();
        }

        private void btnXacNhanDoiMK_Click(object sender, EventArgs e)
        {
            string tk = txtTaiKhoanDoiMK.Text.Trim();
            string mkCu = txtMatKhauHienTai.Text.Trim();
            string mkMoi = txtMatKhauMoi.Text.Trim();
            string mkXacNhan = txtXacNhanMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(tk))
            {
                MessageBox.Show("Vui lòng nhập ID tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaiKhoanDoiMK.Focus();
                return;
            }

            if (mkMoi != mkXacNhan)
            {
                MessageBox.Show("Mật khẩu mới và Xác nhận mật khẩu không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtXacNhanMatKhau.Focus();
                return;
            }

            bool ok = taiKhoanBUS.DoiMatKhau(tk, mkCu, mkMoi, out string thongBao);
            MessageBox.Show(thongBao, ok ? "Thành công" : "Thông báo",
                MessageBoxButtons.OK, ok ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            if (ok)
            {
                txtTaiKhoan.Text = tk;
                txtMatKhau.Clear();
                DongKhungDoiMatKhau();
                txtMatKhau.Focus();
            }
        }

        private void btnHuyDoiMK_Click(object sender, EventArgs e)
        {
            DongKhungDoiMatKhau();
        }

        private void DongKhungDoiMatKhau()
        {
            txtMatKhauHienTai.Clear();
            txtMatKhauMoi.Clear();
            txtXacNhanMatKhau.Clear();
            pnlDoiMatKhau.Visible = false;
        }
    }
}