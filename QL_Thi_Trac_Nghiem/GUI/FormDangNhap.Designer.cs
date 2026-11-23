namespace QL_Thi_Trac_Nghiem.GUI
{
    partial class FormDangNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtTaiKhoan = new TextBox();
            txtMatKhau = new TextBox();
            btnDangNhap = new Button();
            label2 = new Label();
            label3 = new Label();
            pnlDoiMatKhau = new Panel();
            txtMatKhauHienTai = new TextBox();
            txtTaiKhoanDoiMK = new TextBox();
            btnDoiMatKhau = new Button();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtMatKhauMoi = new TextBox();
            txtXacNhanMatKhau = new TextBox();
            btnXacNhanDoiMK = new Button();
            btnHuyDoiMK = new Button();
            label8 = new Label();
            pnlDoiMatKhau.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(330, 67);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 0;
            label1.Text = "ĐĂNG NHẬP";
            // 
            // txtTaiKhoan
            // 
            txtTaiKhoan.Location = new Point(330, 117);
            txtTaiKhoan.Name = "txtTaiKhoan";
            txtTaiKhoan.Size = new Size(217, 23);
            txtTaiKhoan.TabIndex = 1;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(330, 172);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '*';
            txtMatKhau.Size = new Size(217, 23);
            txtMatKhau.TabIndex = 2;
            // 
            // btnDangNhap
            // 
            btnDangNhap.Location = new Point(330, 235);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(75, 23);
            btnDangNhap.TabIndex = 3;
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.UseVisualStyleBackColor = true;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(263, 120);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 4;
            label2.Text = "Tài khoản:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(263, 175);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 5;
            label3.Text = "Mật khẩu:";
            // 
            // pnlDoiMatKhau
            // 
            pnlDoiMatKhau.Controls.Add(label8);
            pnlDoiMatKhau.Controls.Add(btnHuyDoiMK);
            pnlDoiMatKhau.Controls.Add(btnXacNhanDoiMK);
            pnlDoiMatKhau.Controls.Add(txtXacNhanMatKhau);
            pnlDoiMatKhau.Controls.Add(txtMatKhauMoi);
            pnlDoiMatKhau.Controls.Add(label7);
            pnlDoiMatKhau.Controls.Add(label6);
            pnlDoiMatKhau.Controls.Add(label5);
            pnlDoiMatKhau.Controls.Add(label4);
            pnlDoiMatKhau.Controls.Add(txtMatKhauHienTai);
            pnlDoiMatKhau.Controls.Add(txtTaiKhoanDoiMK);
            pnlDoiMatKhau.Location = new Point(571, 39);
            pnlDoiMatKhau.Name = "pnlDoiMatKhau";
            pnlDoiMatKhau.Size = new Size(492, 381);
            pnlDoiMatKhau.TabIndex = 6;
            pnlDoiMatKhau.Visible = false;
            // 
            // txtMatKhauHienTai
            // 
            txtMatKhauHienTai.Location = new Point(156, 133);
            txtMatKhauHienTai.Name = "txtMatKhauHienTai";
            txtMatKhauHienTai.PasswordChar = '*';
            txtMatKhauHienTai.Size = new Size(223, 23);
            txtMatKhauHienTai.TabIndex = 1;
            
            // 
            // txtTaiKhoanDoiMK
            // 
            txtTaiKhoanDoiMK.Location = new Point(156, 78);
            txtTaiKhoanDoiMK.Name = "txtTaiKhoanDoiMK";
            txtTaiKhoanDoiMK.Size = new Size(223, 23);
            txtTaiKhoanDoiMK.TabIndex = 0;
            
            // 
            // btnDoiMatKhau
            // 
            btnDoiMatKhau.Location = new Point(455, 235);
            btnDoiMatKhau.Name = "btnDoiMatKhau";
            btnDoiMatKhau.Size = new Size(92, 23);
            btnDoiMatKhau.TabIndex = 7;
            btnDoiMatKhau.Text = "Đổi mật khẩu";
            btnDoiMatKhau.UseVisualStyleBackColor = true;
            btnDoiMatKhau.Click += btnDoiMatKhau_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 81);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 2;
            label4.Text = "Tài khoản:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 136);
            label5.Name = "label5";
            label5.Size = new Size(134, 15);
            label5.TabIndex = 3;
            label5.Text = "Nhập mật khẩu hiện tại:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(16, 200);
            label6.Name = "label6";
            label6.Size = new Size(116, 15);
            label6.TabIndex = 4;
            label6.Text = "Nhập mật khẩu mới:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(16, 236);
            label7.Name = "label7";
            label7.Size = new Size(131, 15);
            label7.TabIndex = 5;
            label7.Text = "Nhập lại mật khẩu mới:";
            // 
            // txtMatKhauMoi
            // 
            txtMatKhauMoi.Location = new Point(156, 196);
            txtMatKhauMoi.Name = "txtMatKhauMoi";
            txtMatKhauMoi.PasswordChar = '*';
            txtMatKhauMoi.Size = new Size(223, 23);
            txtMatKhauMoi.TabIndex = 6;
            
            // 
            // txtXacNhanMatKhau
            // 
            txtXacNhanMatKhau.Location = new Point(156, 233);
            txtXacNhanMatKhau.Name = "txtXacNhanMatKhau";
            txtXacNhanMatKhau.PasswordChar = '*';
            txtXacNhanMatKhau.Size = new Size(223, 23);
            txtXacNhanMatKhau.TabIndex = 7;
            // 
            // btnXacNhanDoiMK
            // 
            btnXacNhanDoiMK.Location = new Point(156, 289);
            btnXacNhanDoiMK.Name = "btnXacNhanDoiMK";
            btnXacNhanDoiMK.Size = new Size(75, 23);
            btnXacNhanDoiMK.TabIndex = 8;
            btnXacNhanDoiMK.Text = "Xác nhận";
            btnXacNhanDoiMK.UseVisualStyleBackColor = true;
            btnXacNhanDoiMK.Click += btnXacNhanDoiMK_Click;
            // 
            // btnHuyDoiMK
            // 
            btnHuyDoiMK.Location = new Point(237, 289);
            btnHuyDoiMK.Name = "btnHuyDoiMK";
            btnHuyDoiMK.Size = new Size(75, 23);
            btnHuyDoiMK.TabIndex = 9;
            btnHuyDoiMK.Text = "Hủy";
            btnHuyDoiMK.UseVisualStyleBackColor = true;
            btnHuyDoiMK.Click += btnHuyDoiMK_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(156, 28);
            label8.Name = "label8";
            label8.Size = new Size(91, 15);
            label8.TabIndex = 10;
            label8.Text = "ĐỔI MẬT KHẨU";
            // 
            // FormDangNhap
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1075, 450);
            Controls.Add(btnDoiMatKhau);
            Controls.Add(pnlDoiMatKhau);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnDangNhap);
            Controls.Add(txtMatKhau);
            Controls.Add(txtTaiKhoan);
            Controls.Add(label1);
            Name = "FormDangNhap";
            Text = "Form1";
            pnlDoiMatKhau.ResumeLayout(false);
            pnlDoiMatKhau.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtTaiKhoan;
        private TextBox txtMatKhau;
        private Button btnDangNhap;
        private Label label2;
        private Label label3;
        private Panel pnlDoiMatKhau;
        private TextBox txtMatKhauHienTai;
        private TextBox txtTaiKhoanDoiMK;
        private Button btnDoiMatKhau;
        private TextBox txtXacNhanMatKhau;
        private TextBox txtMatKhauMoi;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Button btnHuyDoiMK;
        private Button btnXacNhanDoiMK;
        private Label label8;
    }
}