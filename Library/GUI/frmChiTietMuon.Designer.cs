
namespace Library
{
    partial class frmChiTietMuon
    {
        private System.ComponentModel.IContainer components = null;

        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2Panel pnlTimKiem;
        private Guna.UI2.WinForms.Guna2Panel pnlNoiDung;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTieuDe;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTimTheo;

        private Guna.UI2.WinForms.Guna2ComboBox cboTimTheo;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
        private Guna.UI2.WinForms.Guna2Button btnTimKiem;
        private Guna.UI2.WinForms.Guna2Button btnLamMoi;
        private Guna.UI2.WinForms.Guna2Button btnTraSach;
        private Guna.UI2.WinForms.Guna2Button btnSachQuaHan;
        private Guna.UI2.WinForms.Guna2DataGridView dgvChiTietMuon;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            pnlTimKiem = new Guna.UI2.WinForms.Guna2Panel();
            pnlNoiDung = new Guna.UI2.WinForms.Guna2Panel();

            lblTieuDe = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblTimTheo = new Guna.UI2.WinForms.Guna2HtmlLabel();

            cboTimTheo = new Guna.UI2.WinForms.Guna2ComboBox();
            txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();

            btnTimKiem = new Guna.UI2.WinForms.Guna2Button();
            btnLamMoi = new Guna.UI2.WinForms.Guna2Button();
            btnTraSach = new Guna.UI2.WinForms.Guna2Button();
            btnSachQuaHan = new Guna.UI2.WinForms.Guna2Button();

            dgvChiTietMuon =
                new Guna.UI2.WinForms.Guna2DataGridView();

            pnlHeader.SuspendLayout();
            pnlTimKiem.SuspendLayout();
            pnlNoiDung.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)
                dgvChiTietMuon).BeginInit();

            SuspendLayout();

            System.Drawing.Color mauChinh =
                System.Drawing.Color.FromArgb(100, 88, 255);

            System.Drawing.Color mauNen =
                System.Drawing.Color.FromArgb(245, 247, 252);

            System.Drawing.Font fontChu =
                new System.Drawing.Font("Segoe UI", 10F);

            pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            pnlHeader.Height = 35;
            pnlHeader.FillColor = mauChinh;
            pnlHeader.Controls.Add(lblTieuDe);


            pnlTimKiem.Dock = System.Windows.Forms.DockStyle.Top;
            pnlTimKiem.Height = 145;
            pnlTimKiem.FillColor = System.Drawing.Color.White;

            lblTimTheo.Text = "Tìm kiếm theo";
            lblTimTheo.Font = fontChu;
            lblTimTheo.Location =
                new System.Drawing.Point(25, 17);

            cboTimTheo.Name = "cboTimTheo";
            cboTimTheo.Location =
                new System.Drawing.Point(25, 45);
            cboTimTheo.Size =
                new System.Drawing.Size(190, 40);
            cboTimTheo.BorderRadius = 8;
            cboTimTheo.Font = fontChu;
            cboTimTheo.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Location =
                new System.Drawing.Point(230, 45);
            txtTimKiem.Size =
                new System.Drawing.Size(300, 40);
            txtTimKiem.BorderRadius = 8;
            txtTimKiem.Font = fontChu;
            txtTimKiem.PlaceholderText =
                "Nhập nội dung cần tìm...";

            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.Location =
                new System.Drawing.Point(545, 45);
            btnTimKiem.Size =
                new System.Drawing.Size(115, 40);
            btnTimKiem.BorderRadius = 8;
            btnTimKiem.FillColor = mauChinh;
            btnTimKiem.Font = fontChu;
            btnTimKiem.ForeColor = System.Drawing.Color.White;
            btnTimKiem.Click += btnTimKiem_Click;

            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Location =
                new System.Drawing.Point(675, 45);
            btnLamMoi.Size =
                new System.Drawing.Size(115, 40);
            btnLamMoi.BorderRadius = 8;
            btnLamMoi.FillColor =
                System.Drawing.Color.FromArgb(90, 100, 120);
            btnLamMoi.Font = fontChu;
            btnLamMoi.ForeColor = System.Drawing.Color.White;
            btnLamMoi.Click += btnLamMoi_Click;

            btnTraSach.Name = "btnTraSach";
            btnTraSach.Text = "Trả sách";
            btnTraSach.Location =
                new System.Drawing.Point(25, 99);
            btnTraSach.Size =
                new System.Drawing.Size(145, 38);
            btnTraSach.BorderRadius = 8;
            btnTraSach.FillColor =
                System.Drawing.Color.FromArgb(34, 160, 107);
            btnTraSach.Font = fontChu;
            btnTraSach.ForeColor = System.Drawing.Color.White;
            btnTraSach.Click += btnTraSach_Click;

            btnSachQuaHan.Name = "btnSachQuaHan";
            btnSachQuaHan.Text = "Sách quá hạn";
            btnSachQuaHan.Location =
                new System.Drawing.Point(185, 99);
            btnSachQuaHan.Size =
                new System.Drawing.Size(160, 38);
            btnSachQuaHan.BorderRadius = 8;
            btnSachQuaHan.FillColor =
                System.Drawing.Color.FromArgb(230, 126, 34);
            btnSachQuaHan.Font = fontChu;
            btnSachQuaHan.ForeColor = System.Drawing.Color.White;
            btnSachQuaHan.Click += btnSachQuaHan_Click;

            pnlTimKiem.Controls.Add(lblTimTheo);
            pnlTimKiem.Controls.Add(cboTimTheo);
            pnlTimKiem.Controls.Add(txtTimKiem);
            pnlTimKiem.Controls.Add(btnTimKiem);
            pnlTimKiem.Controls.Add(btnLamMoi);
            pnlTimKiem.Controls.Add(btnTraSach);
            pnlTimKiem.Controls.Add(btnSachQuaHan);

            pnlNoiDung.Dock =
                System.Windows.Forms.DockStyle.Fill;
            pnlNoiDung.Padding =
                new System.Windows.Forms.Padding(20);
            pnlNoiDung.FillColor = mauNen;

            dgvChiTietMuon.Name = "dgvChiTietMuon";
            dgvChiTietMuon.Dock =
                System.Windows.Forms.DockStyle.Fill;

            dgvChiTietMuon.BackgroundColor =
                System.Drawing.Color.White;

            dgvChiTietMuon.BorderStyle =
                System.Windows.Forms.BorderStyle.None;

            dgvChiTietMuon.AllowUserToAddRows = false;
            dgvChiTietMuon.AllowUserToDeleteRows = false;
            dgvChiTietMuon.ReadOnly = true;
            dgvChiTietMuon.MultiSelect = false;
            dgvChiTietMuon.RowHeadersVisible = false;

            dgvChiTietMuon.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            dgvChiTietMuon.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            dgvChiTietMuon.ColumnHeadersHeight = 42;
            dgvChiTietMuon.RowTemplate.Height = 34;

            dgvChiTietMuon.CellClick +=
                dgvChiTietMuon_CellClick;

            pnlNoiDung.Controls.Add(dgvChiTietMuon);

            AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            BackColor = mauNen;
            ClientSize = new System.Drawing.Size(1050, 650);

            Controls.Add(pnlNoiDung);
            Controls.Add(pnlTimKiem);
            Controls.Add(pnlHeader);

            Name = "frmChiTietMuon";
            Text = "Quản lý chi tiết mượn sách";
            StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            Load += frmChiTietMuon_Load;

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();

            pnlTimKiem.ResumeLayout(false);
            pnlTimKiem.PerformLayout();

            pnlNoiDung.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)
                dgvChiTietMuon).EndInit();

            ResumeLayout(false);
        }
    }
}
