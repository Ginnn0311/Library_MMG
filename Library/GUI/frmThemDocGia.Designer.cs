
namespace Library
{
    partial class frmThemDocGia
    {
        private System.ComponentModel.IContainer components = null;

        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTieuDe;
        private Guna.UI2.WinForms.Guna2TextBox txtMaDocGia;
        private Guna.UI2.WinForms.Guna2TextBox txtHoTen;
        private Guna.UI2.WinForms.Guna2TextBox txtSoDienThoai;
        private Guna.UI2.WinForms.Guna2TextBox txtDiaChi;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgaySinh;
        private Guna.UI2.WinForms.Guna2ComboBox cboGioiTinh;
        private Guna.UI2.WinForms.Guna2Button btnLuu;
        private Guna.UI2.WinForms.Guna2Button btnHuy;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            lblTieuDe = new Guna.UI2.WinForms.Guna2HtmlLabel();

            txtMaDocGia = new Guna.UI2.WinForms.Guna2TextBox();
            txtHoTen = new Guna.UI2.WinForms.Guna2TextBox();
            txtSoDienThoai = new Guna.UI2.WinForms.Guna2TextBox();
            txtDiaChi = new Guna.UI2.WinForms.Guna2TextBox();
            txtEmail = new Guna.UI2.WinForms.Guna2TextBox();

            dtpNgaySinh = new Guna.UI2.WinForms.Guna2DateTimePicker();
            cboGioiTinh = new Guna.UI2.WinForms.Guna2ComboBox();

            btnLuu = new Guna.UI2.WinForms.Guna2Button();
            btnHuy = new Guna.UI2.WinForms.Guna2Button();

            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();

            pnlHeader.SuspendLayout();
            SuspendLayout();

            System.Drawing.Color mauChu =
                System.Drawing.Color.FromArgb(45, 55, 72);

            System.Drawing.Color mauVien =
                System.Drawing.Color.FromArgb(210, 220, 235);

            System.Drawing.Font fontNhap =
                new System.Drawing.Font("Segoe UI", 10F);

            System.Drawing.Font fontNhan =
                new System.Drawing.Font(
                    "Segoe UI", 9F,
                    System.Drawing.FontStyle.Bold);

            pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            pnlHeader.Height = 80;
            pnlHeader.FillColor =
                System.Drawing.Color.FromArgb(40, 120, 208);
            pnlHeader.Controls.Add(lblTieuDe);

            lblTieuDe.BackColor =
                System.Drawing.Color.Transparent;
            lblTieuDe.Text = "THÔNG TIN ĐỘC GIẢ";
            lblTieuDe.Font =
                new System.Drawing.Font(
                    "Segoe UI", 17F,
                    System.Drawing.FontStyle.Bold);
            lblTieuDe.ForeColor = System.Drawing.Color.White;
            lblTieuDe.Location =
                new System.Drawing.Point(24, 23);

            label1.Text = "Mã độc giả";
            label1.Location = new System.Drawing.Point(30, 105);

            label2.Text = "Họ và tên";
            label2.Location = new System.Drawing.Point(285, 105);

            label3.Text = "Ngày sinh";
            label3.Location = new System.Drawing.Point(30, 195);

            label4.Text = "Số điện thoại";
            label4.Location = new System.Drawing.Point(285, 195);

            label5.Text = "Địa chỉ";
            label5.Location = new System.Drawing.Point(30, 285);

            label6.Text = "Giới tính";
            label6.Location = new System.Drawing.Point(285, 285);

            label7.Text = "Email";
            label7.Location = new System.Drawing.Point(30, 375);

            foreach (System.Windows.Forms.Label lbl in
                new System.Windows.Forms.Label[]
                {
                    label1, label2, label3, label4,
                    label5, label6, label7
                })
            {
                lbl.AutoSize = true;
                lbl.Font = fontNhan;
                lbl.ForeColor = mauChu;
            }

            txtMaDocGia.Name = "txtMaDocGia";
            txtMaDocGia.Location =
                new System.Drawing.Point(30, 130);
            txtMaDocGia.Size =
                new System.Drawing.Size(225, 42);
            txtMaDocGia.PlaceholderText = "Nhập mã độc giả";

            txtHoTen.Name = "txtHoTen";
            txtHoTen.Location =
                new System.Drawing.Point(285, 130);
            txtHoTen.Size =
                new System.Drawing.Size(225, 42);
            txtHoTen.PlaceholderText = "Nhập họ và tên";

            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Location =
                new System.Drawing.Point(30, 220);
            dtpNgaySinh.Size =
                new System.Drawing.Size(225, 42);
            dtpNgaySinh.Format =
                System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.Value = System.DateTime.Today;

            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Location =
                new System.Drawing.Point(285, 220);
            txtSoDienThoai.Size =
                new System.Drawing.Size(225, 42);
            txtSoDienThoai.PlaceholderText = "Nhập số điện thoại";

            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Location =
                new System.Drawing.Point(30, 310);
            txtDiaChi.Size =
                new System.Drawing.Size(225, 42);
            txtDiaChi.PlaceholderText = "Nhập địa chỉ";

            cboGioiTinh.Name = "cboGioiTinh";
            cboGioiTinh.Location =
                new System.Drawing.Point(285, 310);
            cboGioiTinh.Size =
                new System.Drawing.Size(225, 42);
            cboGioiTinh.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboGioiTinh.Items.AddRange(
                new object[] { "Nam", "Nữ" });
            cboGioiTinh.SelectedIndexChanged +=
                cboGioiTinh_SelectedIndexChanged;

            txtEmail.Name = "txtEmail";
            txtEmail.Location =
                new System.Drawing.Point(30, 400);
            txtEmail.Size =
                new System.Drawing.Size(480, 42);
            txtEmail.PlaceholderText = "example@gmail.com";

            foreach (Guna.UI2.WinForms.Guna2TextBox txt in
                new Guna.UI2.WinForms.Guna2TextBox[]
                {
                    txtMaDocGia, txtHoTen, txtSoDienThoai,
                    txtDiaChi, txtEmail
                })
            {
                txt.BorderRadius = 8;
                txt.BorderColor = mauVien;
                txt.FocusedState.BorderColor =
                    System.Drawing.Color.FromArgb(40, 120, 208);
                txt.Font = fontNhap;
                txt.ForeColor = mauChu;
            }

            dtpNgaySinh.BorderRadius = 8;
            dtpNgaySinh.FillColor = System.Drawing.Color.White;
            dtpNgaySinh.ForeColor = mauChu;
            dtpNgaySinh.Font = fontNhap;

            cboGioiTinh.BorderRadius = 8;
            cboGioiTinh.FillColor = System.Drawing.Color.White;
            cboGioiTinh.Font = fontNhap;
            cboGioiTinh.ForeColor = mauChu;

            btnLuu.Name = "btnLuu";
            btnLuu.Text = "Lưu độc giả";
            btnLuu.Location =
                new System.Drawing.Point(285, 475);
            btnLuu.Size =
                new System.Drawing.Size(140, 43);
            btnLuu.BorderRadius = 9;
            btnLuu.FillColor =
                System.Drawing.Color.FromArgb(40, 120, 208);
            btnLuu.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F,
                    System.Drawing.FontStyle.Bold);
            btnLuu.ForeColor = System.Drawing.Color.White;

            btnHuy.Name = "btnHuy";
            btnHuy.Text = "Hủy";
            btnHuy.Location =
                new System.Drawing.Point(435, 475);
            btnHuy.Size =
                new System.Drawing.Size(75, 43);
            btnHuy.BorderRadius = 9;
            btnHuy.FillColor =
                System.Drawing.Color.FromArgb(225, 230, 238);
            btnHuy.ForeColor = mauChu;
            btnHuy.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F,
                    System.Drawing.FontStyle.Bold);

            AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            BackColor =
                System.Drawing.Color.FromArgb(248, 250, 253);
            ClientSize = new System.Drawing.Size(540, 550);

            Controls.Add(pnlHeader);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label7);

            Controls.Add(txtMaDocGia);
            Controls.Add(txtHoTen);
            Controls.Add(dtpNgaySinh);
            Controls.Add(txtSoDienThoai);
            Controls.Add(txtDiaChi);
            Controls.Add(cboGioiTinh);
            Controls.Add(txtEmail);

            Controls.Add(btnLuu);
            Controls.Add(btnHuy);

            FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition =
                System.Windows.Forms.FormStartPosition.CenterParent;

            Name = "frmThemDocGia";
            Text = "Thông tin độc giả";

            Load += frmThemDocGia_Load;

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
