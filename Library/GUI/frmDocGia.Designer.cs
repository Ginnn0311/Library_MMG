
using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Library
{
    partial class frmDocGia
    {
        private System.ComponentModel.IContainer components = null;

        private Guna2Panel pnlMain;
        private Guna2Panel pnlContent;
        private Guna2Panel pnlSearch;
        private Guna2Panel pnlActions;

        private TableLayoutPanel layoutMain;
        private TableLayoutPanel tableLayoutButtons;

        private Label lblDanhSach;
        private Label toolStripLabel4;

        private Guna2Button btnThemDocGia;
        private Guna2Button btnSuaDocGia;
        private Guna2Button btnXoaDocGia;
        private Guna2Button btnGiaHan;
        private Guna2Button toolStripButton1;

        private Guna2ComboBox cbTimTheo;
        private Guna2TextBox toolStripTextBox1;

        private Guna2DataGridView dgvDocGia;

        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn dgvNhaXuatBan;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;

        private DataGridViewTextBoxColumn colNgayDangKy;
        private DataGridViewTextBoxColumn colNgayHetHan;
        private DataGridViewTextBoxColumn colTrangThaiThe;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 =
                new DataGridViewCellStyle();

            DataGridViewCellStyle dataGridViewCellStyle2 =
                new DataGridViewCellStyle();

            DataGridViewCellStyle dataGridViewCellStyle3 =
                new DataGridViewCellStyle();

            pnlMain = new Guna2Panel();
            pnlContent = new Guna2Panel();

            layoutMain = new TableLayoutPanel();

            lblDanhSach = new Label();

            pnlSearch = new Guna2Panel();
            toolStripLabel4 = new Label();

            cbTimTheo = new Guna2ComboBox();
            toolStripTextBox1 = new Guna2TextBox();
            toolStripButton1 = new Guna2Button();

            dgvDocGia = new Guna2DataGridView();

            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            dgvNhaXuatBan = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();

            colNgayDangKy = new DataGridViewTextBoxColumn();
            colNgayHetHan = new DataGridViewTextBoxColumn();
            colTrangThaiThe = new DataGridViewTextBoxColumn();

            pnlActions = new Guna2Panel();
            tableLayoutButtons = new TableLayoutPanel();

            btnThemDocGia = new Guna2Button();
            btnSuaDocGia = new Guna2Button();
            btnXoaDocGia = new Guna2Button();
            btnGiaHan = new Guna2Button();

            pnlMain.SuspendLayout();
            pnlContent.SuspendLayout();
            layoutMain.SuspendLayout();
            pnlSearch.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)
                dgvDocGia).BeginInit();

            pnlActions.SuspendLayout();
            tableLayoutButtons.SuspendLayout();

            SuspendLayout();

            Color mauNen = Color.FromArgb(243, 246, 251);
            Color mauChu = Color.FromArgb(50, 65, 85);
            Color mauTieuDe = Color.FromArgb(31, 58, 95);
            Color mauXanh = Color.FromArgb(35, 120, 210);
            Color mauVang = Color.FromArgb(235, 160, 45);
            Color mauDo = Color.FromArgb(220, 65, 75);
            Color mauXanhLa = Color.FromArgb(22, 163, 74);

            Font fontThuong = new Font("Segoe UI", 9.5F);
            Font fontDam = new Font(
                "Segoe UI", 10F, FontStyle.Bold);

            pnlMain.Name = "pnlMain";
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.FillColor = mauNen;
            pnlMain.Padding = new Padding(20);
            pnlMain.Controls.Add(pnlContent);

            pnlContent.Name = "pnlContent";
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.BorderRadius = 12;
            pnlContent.FillColor = Color.White;
            pnlContent.Padding = new Padding(20);
            pnlContent.Controls.Add(layoutMain);

            layoutMain.Name = "layoutMain";
            layoutMain.Dock = DockStyle.Fill;
            layoutMain.BackColor = Color.White;
            layoutMain.Margin = new Padding(0);
            layoutMain.ColumnCount = 1;
            layoutMain.RowCount = 4;

            layoutMain.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100F));

            layoutMain.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 55F));

            layoutMain.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 95F));

            layoutMain.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100F));

            layoutMain.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 85F));

            layoutMain.Controls.Add(lblDanhSach, 0, 0);
            layoutMain.Controls.Add(pnlSearch, 0, 1);
            layoutMain.Controls.Add(dgvDocGia, 0, 2);
            layoutMain.Controls.Add(pnlActions, 0, 3);

            lblDanhSach.Name = "lblDanhSach";
            lblDanhSach.Text = "DANH SÁCH ĐỘC GIẢ";
            lblDanhSach.Dock = DockStyle.Fill;
            lblDanhSach.BackColor =
                Color.FromArgb(220, 245, 255);
            lblDanhSach.ForeColor = mauTieuDe;
            lblDanhSach.Font = new Font(
                "Segoe UI", 16F, FontStyle.Bold);
            lblDanhSach.TextAlign =
                ContentAlignment.MiddleLeft;
            lblDanhSach.Padding = new Padding(15, 0, 0, 0);
            lblDanhSach.Click += lblDanhSach_Click;

            pnlSearch.Name = "pnlSearch";
            pnlSearch.Dock = DockStyle.Fill;
            pnlSearch.FillColor = Color.White;
            pnlSearch.Controls.Add(toolStripLabel4);
            pnlSearch.Controls.Add(cbTimTheo);
            pnlSearch.Controls.Add(toolStripTextBox1);
            pnlSearch.Controls.Add(toolStripButton1);

            toolStripLabel4.Name = "toolStripLabel4";
            toolStripLabel4.Text = "Tìm kiếm độc giả";
            toolStripLabel4.BackColor = Color.White;
            toolStripLabel4.Font = new Font(
                "Segoe UI", 9.5F, FontStyle.Bold);
            toolStripLabel4.ForeColor = mauChu;
            toolStripLabel4.Location = new Point(5, 5);
            toolStripLabel4.Size = new Size(200, 25);
            toolStripLabel4.TextAlign =
                ContentAlignment.MiddleLeft;

            cbTimTheo.Name = "cbTimTheo";
            cbTimTheo.Location = new Point(5, 35);
            cbTimTheo.Size = new Size(185, 38);
            cbTimTheo.BorderRadius = 7;
            cbTimTheo.Font = fontThuong;
            cbTimTheo.ForeColor = mauChu;
            cbTimTheo.DrawMode = DrawMode.OwnerDrawFixed;
            cbTimTheo.DropDownStyle =
                ComboBoxStyle.DropDownList;
            cbTimTheo.ItemHeight = 30;
            cbTimTheo.BackColor = Color.Transparent;

            toolStripTextBox1.Name = "toolStripTextBox1";
            toolStripTextBox1.Location =
                new Point(200, 35);
            toolStripTextBox1.Size =
                new Size(330, 38);
            toolStripTextBox1.BorderRadius = 7;
            toolStripTextBox1.Font = fontThuong;
            toolStripTextBox1.ForeColor = mauChu;
            toolStripTextBox1.PlaceholderText =
                "Nhập từ khóa tìm kiếm...";

            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Text = "Tìm kiếm";
            toolStripButton1.Location =
                new Point(540, 35);
            toolStripButton1.Size =
                new Size(125, 38);
            toolStripButton1.BorderRadius = 7;
            toolStripButton1.FillColor = mauXanh;
            toolStripButton1.ForeColor = Color.White;
            toolStripButton1.Font = fontDam;

            dgvDocGia.Name = "dgvDocGia";
            dgvDocGia.Dock = DockStyle.Fill;
            dgvDocGia.Margin = new Padding(3, 5, 3, 5);
            dgvDocGia.BackgroundColor = Color.White;
            dgvDocGia.BorderStyle = BorderStyle.None;

            dgvDocGia.AllowUserToAddRows = false;
            dgvDocGia.AllowUserToDeleteRows = false;
            dgvDocGia.AllowUserToResizeRows = false;

            dgvDocGia.ReadOnly = true;
            dgvDocGia.MultiSelect = false;
            dgvDocGia.RowHeadersVisible = false;

            dgvDocGia.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvDocGia.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.None;

            dgvDocGia.ScrollBars = ScrollBars.Both;

            dgvDocGia.ColumnHeadersHeight = 48;
            dgvDocGia.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

            dgvDocGia.RowTemplate.Height = 40;

            dgvDocGia.GridColor =
                Color.FromArgb(225, 232, 240);

            dataGridViewCellStyle1.BackColor =
                Color.FromArgb(246, 249, 253);
            dataGridViewCellStyle1.ForeColor = mauChu;
            dataGridViewCellStyle1.Font = fontThuong;
            dataGridViewCellStyle1.SelectionBackColor =
                Color.FromArgb(220, 235, 250);
            dataGridViewCellStyle1.SelectionForeColor =
                mauTieuDe;

            dgvDocGia.AlternatingRowsDefaultCellStyle =
                dataGridViewCellStyle1;

            dataGridViewCellStyle2.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor =
                Color.FromArgb(38, 88, 145);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Font = fontDam;
            dataGridViewCellStyle2.SelectionBackColor =
                Color.FromArgb(38, 88, 145);
            dataGridViewCellStyle2.SelectionForeColor =
                Color.White;
            dataGridViewCellStyle2.WrapMode =
                DataGridViewTriState.True;

            dgvDocGia.ColumnHeadersDefaultCellStyle =
                dataGridViewCellStyle2;

            dataGridViewCellStyle3.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.ForeColor = mauChu;
            dataGridViewCellStyle3.Font = fontThuong;
            dataGridViewCellStyle3.SelectionBackColor =
                Color.FromArgb(220, 235, 250);
            dataGridViewCellStyle3.SelectionForeColor =
                mauTieuDe;
            dataGridViewCellStyle3.WrapMode =
                DataGridViewTriState.False;

            dgvDocGia.DefaultCellStyle =
                dataGridViewCellStyle3;

            Column1.Name = "Column1";
            Column1.HeaderText = "Mã độc giả";
            Column1.Width = 105;
            Column1.ReadOnly = true;

            Column2.Name = "Column2";
            Column2.HeaderText = "Họ và tên";
            Column2.Width = 175;
            Column2.ReadOnly = true;

            Column3.Name = "Column3";
            Column3.HeaderText = "Ngày sinh";
            Column3.Width = 115;
            Column3.ReadOnly = true;
            Column3.DefaultCellStyle.Format = "dd/MM/yyyy";

            Column4.Name = "Column4";
            Column4.HeaderText = "Số điện thoại";
            Column4.Width = 135;
            Column4.ReadOnly = true;

            dgvNhaXuatBan.Name = "dgvNhaXuatBan";
            dgvNhaXuatBan.HeaderText = "Địa chỉ";
            dgvNhaXuatBan.Width = 185;
            dgvNhaXuatBan.ReadOnly = true;

            Column5.Name = "Column5";
            Column5.HeaderText = "Giới tính";
            Column5.Width = 100;
            Column5.ReadOnly = true;

            Column6.Name = "Column6";
            Column6.HeaderText = "Email";
            Column6.Width = 205;
            Column6.ReadOnly = true;

            colNgayDangKy.Name = "colNgayDangKy";
            colNgayDangKy.HeaderText = "Ngày đăng ký";
            colNgayDangKy.Width = 135;
            colNgayDangKy.ReadOnly = true;
            colNgayDangKy.DefaultCellStyle.Format =
                "dd/MM/yyyy";

            colNgayHetHan.Name = "colNgayHetHan";
            colNgayHetHan.HeaderText = "Ngày hết hạn";
            colNgayHetHan.Width = 135;
            colNgayHetHan.ReadOnly = true;
            colNgayHetHan.DefaultCellStyle.Format =
                "dd/MM/yyyy";

            colTrangThaiThe.Name = "colTrangThaiThe";
            colTrangThaiThe.HeaderText = "Trạng thái thẻ";
            colTrangThaiThe.Width = 155;
            colTrangThaiThe.ReadOnly = true;

            dgvDocGia.Columns.AddRange(
                new DataGridViewColumn[]
                {
                    Column1,
                    Column2,
                    Column3,
                    Column4,
                    dgvNhaXuatBan,
                    Column5,
                    Column6,
                    colNgayDangKy,
                    colNgayHetHan,
                    colTrangThaiThe
                });

            dgvDocGia.EnableHeadersVisualStyles = false;

            dgvDocGia.CellContentClick +=
                dgvDocGia_CellContentClick;

            pnlActions.Name = "pnlActions";
            pnlActions.Dock = DockStyle.Fill;
            pnlActions.FillColor = Color.White;
            pnlActions.Padding = new Padding(0, 12, 0, 5);
            pnlActions.Controls.Add(tableLayoutButtons);

            tableLayoutButtons.Name = "tableLayoutButtons";
            tableLayoutButtons.Dock = DockStyle.Left;
            tableLayoutButtons.Size = new Size(900, 60);
            tableLayoutButtons.Margin = new Padding(0);
            tableLayoutButtons.BackColor = Color.White;

            tableLayoutButtons.ColumnCount = 4;
            tableLayoutButtons.RowCount = 1;

            tableLayoutButtons.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutButtons.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutButtons.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutButtons.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 25F));

            tableLayoutButtons.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100F));

            btnThemDocGia.Name = "btnThemDocGia";
            btnThemDocGia.Text = "＋  Thêm độc giả";
            btnThemDocGia.Dock = DockStyle.Fill;
            btnThemDocGia.BorderRadius = 8;
            btnThemDocGia.FillColor = mauXanh;
            btnThemDocGia.ForeColor = Color.White;
            btnThemDocGia.Font = fontDam;
            btnThemDocGia.Margin =
                new Padding(0, 0, 6, 0);
            btnThemDocGia.Click += btnThemDocGia_Click;

            btnSuaDocGia.Name = "btnSuaDocGia";
            btnSuaDocGia.Text = "✎  Sửa độc giả";
            btnSuaDocGia.Dock = DockStyle.Fill;
            btnSuaDocGia.BorderRadius = 8;
            btnSuaDocGia.FillColor = mauVang;
            btnSuaDocGia.ForeColor = Color.White;
            btnSuaDocGia.Font = fontDam;
            btnSuaDocGia.Margin =
                new Padding(6, 0, 6, 0);
            btnSuaDocGia.Click += btnSuaDocGia_Click;

            btnXoaDocGia.Name = "btnXoaDocGia";
            btnXoaDocGia.Text = "✕  Xóa độc giả";
            btnXoaDocGia.Dock = DockStyle.Fill;
            btnXoaDocGia.BorderRadius = 8;
            btnXoaDocGia.FillColor = mauDo;
            btnXoaDocGia.ForeColor = Color.White;
            btnXoaDocGia.Font = fontDam;
            btnXoaDocGia.Margin =
                new Padding(6, 0, 6, 0);
            btnXoaDocGia.Click += btnXoaDocGia_Click;

            btnGiaHan.Name = "btnGiaHan";
            btnGiaHan.Text = "Gia hạn 3 tháng";
            btnGiaHan.Dock = DockStyle.Fill;
            btnGiaHan.BorderRadius = 8;
            btnGiaHan.FillColor = mauXanhLa;
            btnGiaHan.ForeColor = Color.White;
            btnGiaHan.Font = fontDam;
            btnGiaHan.Margin =
                new Padding(6, 0, 0, 0);

            tableLayoutButtons.Controls.Add(
                btnThemDocGia, 0, 0);

            tableLayoutButtons.Controls.Add(
                btnSuaDocGia, 1, 0);

            tableLayoutButtons.Controls.Add(
                btnXoaDocGia, 2, 0);

            tableLayoutButtons.Controls.Add(
                btnGiaHan, 3, 0);

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;

            BackColor = mauNen;
            ClientSize = new Size(1245, 869);

            Controls.Add(pnlMain);

            FormBorderStyle = FormBorderStyle.None;
            Name = "frmDocGia";
            StartPosition = FormStartPosition.Manual;
            Text = "Quản lý độc giả";

            pnlMain.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            layoutMain.ResumeLayout(false);
            pnlSearch.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)
                dgvDocGia).EndInit();

            pnlActions.ResumeLayout(false);
            tableLayoutButtons.ResumeLayout(false);

            ResumeLayout(false);
        }
    }
}
