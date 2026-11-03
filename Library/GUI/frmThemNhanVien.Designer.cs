namespace Library
{
    partial class frmThemNhanVien
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblSoDienThoai;
        private System.Windows.Forms.Label lblTaiKhoan;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.Label lblVaiTro;
        private System.Windows.Forms.Label lblHinhAnh;

        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.TextBox txtMatKhau;

        private System.Windows.Forms.ComboBox cboVaiTro;
        private System.Windows.Forms.PictureBox picHinhAnh;

        private System.Windows.Forms.Button btnChonAnh;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblSoDienThoai = new System.Windows.Forms.Label();
            this.lblTaiKhoan = new System.Windows.Forms.Label();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.lblVaiTro = new System.Windows.Forms.Label();
            this.lblHinhAnh = new System.Windows.Forms.Label();

            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.txtMatKhau = new System.Windows.Forms.TextBox();

            this.cboVaiTro = new System.Windows.Forms.ComboBox();
            this.picHinhAnh = new System.Windows.Forms.PictureBox();

            this.btnChonAnh = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnChonAnh.Click += new System.EventHandler(this.btnChonAnh_Click);

            ((System.ComponentModel.ISupportInitialize)(this.picHinhAnh)).BeginInit();
            this.SuspendLayout();

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(243, 246, 251);
            this.ClientSize = new System.Drawing.Size(650, 650);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông tin nhân viên";

            // Tiêu đề
            this.lblTieuDe.AutoSize = false;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(31, 58, 95);
            this.lblTieuDe.Location = new System.Drawing.Point(30, 20);
            this.lblTieuDe.Size = new System.Drawing.Size(590, 45);
            this.lblTieuDe.Text = "THÊM NHÂN VIÊN";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Họ tên
            this.lblHoTen.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHoTen.Location = new System.Drawing.Point(35, 90);
            this.lblHoTen.Size = new System.Drawing.Size(145, 30);
            this.lblHoTen.Text = "Họ tên:";

            this.txtHoTen.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtHoTen.Location = new System.Drawing.Point(190, 85);
            this.txtHoTen.Size = new System.Drawing.Size(400, 30);

            // Số điện thoại
            this.lblSoDienThoai.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSoDienThoai.Location = new System.Drawing.Point(35, 155);
            this.lblSoDienThoai.Size = new System.Drawing.Size(145, 30);
            this.lblSoDienThoai.Text = "Số điện thoại:";

            this.txtSoDienThoai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSoDienThoai.Location = new System.Drawing.Point(190, 150);
            this.txtSoDienThoai.Size = new System.Drawing.Size(400, 30);

            // Tài khoản
            this.lblTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTaiKhoan.Location = new System.Drawing.Point(35, 220);
            this.lblTaiKhoan.Size = new System.Drawing.Size(145, 30);
            this.lblTaiKhoan.Text = "Tài khoản:";

            this.txtTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTaiKhoan.Location = new System.Drawing.Point(190, 215);
            this.txtTaiKhoan.Size = new System.Drawing.Size(400, 30);

            // Mật khẩu
            this.lblMatKhau.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMatKhau.Location = new System.Drawing.Point(35, 285);
            this.lblMatKhau.Size = new System.Drawing.Size(145, 30);
            this.lblMatKhau.Text = "Mật khẩu:";

            this.txtMatKhau.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMatKhau.Location = new System.Drawing.Point(190, 280);
            this.txtMatKhau.Size = new System.Drawing.Size(400, 30);
            this.txtMatKhau.UseSystemPasswordChar = true;

            // Vai trò
            this.lblVaiTro.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblVaiTro.Location = new System.Drawing.Point(35, 350);
            this.lblVaiTro.Size = new System.Drawing.Size(145, 30);
            this.lblVaiTro.Text = "Vai trò:";

            this.cboVaiTro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVaiTro.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboVaiTro.Location = new System.Drawing.Point(190, 345);
            this.cboVaiTro.Size = new System.Drawing.Size(400, 30);

            this.cboVaiTro.Items.AddRange(new object[]
            {
                "Quản trị viên",
                "Nhân viên"
            });

            this.cboVaiTro.SelectedIndex = 1;

            // Hình ảnh
            this.lblHinhAnh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHinhAnh.Location = new System.Drawing.Point(35, 415);
            this.lblHinhAnh.Size = new System.Drawing.Size(145, 30);
            this.lblHinhAnh.Text = "Hình ảnh:";

            this.picHinhAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picHinhAnh.Location = new System.Drawing.Point(190, 410);
            this.picHinhAnh.Size = new System.Drawing.Size(150, 150);
            this.picHinhAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHinhAnh.BackColor = System.Drawing.Color.White;

            // Chọn ảnh
            this.btnChonAnh.BackColor = System.Drawing.Color.FromArgb(35, 120, 210);
            this.btnChonAnh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChonAnh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnChonAnh.ForeColor = System.Drawing.Color.White;
            this.btnChonAnh.Location = new System.Drawing.Point(365, 465);
            this.btnChonAnh.Size = new System.Drawing.Size(120, 40);
            this.btnChonAnh.Text = "Chọn ảnh";
            this.btnChonAnh.UseVisualStyleBackColor = false;
            this.btnChonAnh.Click += new System.EventHandler(this.btnChonAnh_Click);

            // Lưu
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(35, 160, 100);
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(190, 575);
            this.btnLuu.Size = new System.Drawing.Size(150, 42);
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);

            // Hủy
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(220, 65, 75);
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(365, 575);
            this.btnHuy.Size = new System.Drawing.Size(150, 42);
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);

            // Add controls
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.lblSoDienThoai);
            this.Controls.Add(this.lblTaiKhoan);
            this.Controls.Add(this.lblMatKhau);
            this.Controls.Add(this.lblVaiTro);
            this.Controls.Add(this.lblHinhAnh);

            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.txtSoDienThoai);
            this.Controls.Add(this.txtTaiKhoan);
            this.Controls.Add(this.txtMatKhau);

            this.Controls.Add(this.cboVaiTro);
            this.Controls.Add(this.picHinhAnh);

            this.Controls.Add(this.btnChonAnh);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnHuy);

            ((System.ComponentModel.ISupportInitialize)(this.picHinhAnh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}