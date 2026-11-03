
using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace Library
{
    partial class frmNhanVien
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlMain = new Guna2Panel();
            pnlContent = new Guna2Panel();
            layoutMain = new TableLayoutPanel();
            lblTieuDe = new Label();
            pnlSearch = new Guna2Panel();
            lblTimKiem = new Label();
            cboTimTheo = new Guna2ComboBox();
            txtTimKiem = new Guna2TextBox();
            btnTimKiem = new Guna2Button();
            pnlThongTin = new Guna2Panel();
            picHinhAnh = new PictureBox();
            lblMaNhanVien = new Label();
            lblHoTen = new Label();
            lblSoDienThoai = new Label();
            lblTaiKhoan = new Label();
            lblVaiTro = new Label();
            dgvNhanVien = new Guna2DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            pnlActions = new Guna2Panel();
            tableLayoutButtons = new TableLayoutPanel();
            btnThem = new Guna2Button();
            btnSua = new Guna2Button();
            btnXoa = new Guna2Button();
            pnlMain.SuspendLayout();
            pnlContent.SuspendLayout();
            layoutMain.SuspendLayout();
            pnlSearch.SuspendLayout();
            pnlThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            pnlActions.SuspendLayout();
            tableLayoutButtons.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(pnlContent);
            pnlMain.CustomizableEdges = customizableEdges21;
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.FillColor = Color.FromArgb(243, 246, 251);
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(20);
            pnlMain.ShadowDecoration.CustomizableEdges = customizableEdges22;
            pnlMain.Size = new Size(1100, 680);
            pnlMain.TabIndex = 0;
            // 
            // pnlContent
            // 
            pnlContent.BorderRadius = 12;
            pnlContent.Controls.Add(layoutMain);
            pnlContent.CustomizableEdges = customizableEdges19;
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.FillColor = Color.White;
            pnlContent.Location = new Point(20, 20);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(20);
            pnlContent.ShadowDecoration.CustomizableEdges = customizableEdges20;
            pnlContent.Size = new Size(1060, 640);
            pnlContent.TabIndex = 0;
            // 
            // layoutMain
            // 
            layoutMain.BackColor = Color.White;
            layoutMain.ColumnCount = 1;
            layoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutMain.Controls.Add(lblTieuDe, 0, 0);
            layoutMain.Controls.Add(pnlSearch, 0, 1);
            layoutMain.Controls.Add(pnlThongTin, 0, 2);
            layoutMain.Controls.Add(dgvNhanVien, 0, 3);
            layoutMain.Controls.Add(pnlActions, 0, 4);
            layoutMain.Dock = DockStyle.Fill;
            layoutMain.Location = new Point(20, 20);
            layoutMain.Name = "layoutMain";
            layoutMain.RowCount = 5;
            layoutMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            layoutMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 65F));
            layoutMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
            layoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 75F));
            layoutMain.Size = new Size(1020, 600);
            layoutMain.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            lblTieuDe.Dock = DockStyle.Fill;
            lblTieuDe.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.FromArgb(31, 58, 95);
            lblTieuDe.Location = new Point(3, 0);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(1014, 50);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "DANH SÁCH NHÂN VIÊN";
            lblTieuDe.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlSearch
            // 
            pnlSearch.BorderRadius = 9;
            pnlSearch.Controls.Add(lblTimKiem);
            pnlSearch.Controls.Add(cboTimTheo);
            pnlSearch.Controls.Add(txtTimKiem);
            pnlSearch.Controls.Add(btnTimKiem);
            pnlSearch.CustomizableEdges = customizableEdges7;
            pnlSearch.Dock = DockStyle.Fill;
            pnlSearch.FillColor = Color.FromArgb(243, 246, 251);
            pnlSearch.Location = new Point(0, 55);
            pnlSearch.Margin = new Padding(0, 5, 0, 5);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.ShadowDecoration.CustomizableEdges = customizableEdges8;
            pnlSearch.Size = new Size(1020, 55);
            pnlSearch.TabIndex = 1;
            // 
            // lblTimKiem
            // 
            lblTimKiem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTimKiem.ForeColor = Color.FromArgb(50, 65, 85);
            lblTimKiem.Location = new Point(15, 15);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(85, 30);
            lblTimKiem.TabIndex = 0;
            lblTimKiem.Text = "Tìm kiếm:";
            lblTimKiem.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cboTimTheo
            // 
            cboTimTheo.BackColor = Color.Transparent;
            cboTimTheo.BorderRadius = 6;
            cboTimTheo.CustomizableEdges = customizableEdges1;
            cboTimTheo.DrawMode = DrawMode.OwnerDrawFixed;
            cboTimTheo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTimTheo.FocusedColor = Color.Empty;
            cboTimTheo.Font = new Font("Segoe UI", 9.5F);
            cboTimTheo.ForeColor = Color.FromArgb(45, 55, 72);
            cboTimTheo.ItemHeight = 30;
            cboTimTheo.Location = new Point(105, 13);
            cboTimTheo.Name = "cboTimTheo";
            cboTimTheo.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cboTimTheo.Size = new Size(160, 36);
            cboTimTheo.TabIndex = 1;
            // 
            // txtTimKiem
            // 
            txtTimKiem.BorderRadius = 6;
            txtTimKiem.CustomizableEdges = customizableEdges3;
            txtTimKiem.DefaultText = "";
            txtTimKiem.Font = new Font("Segoe UI", 9.5F);
            txtTimKiem.Location = new Point(280, 13);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập thông tin cần tìm...";
            txtTimKiem.SelectedText = "";
            txtTimKiem.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtTimKiem.Size = new Size(350, 34);
            txtTimKiem.TabIndex = 2;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BorderRadius = 7;
            btnTimKiem.CustomizableEdges = customizableEdges5;
            btnTimKiem.FillColor = Color.FromArgb(35, 120, 210);
            btnTimKiem.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(645, 13);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnTimKiem.Size = new Size(110, 34);
            btnTimKiem.TabIndex = 3;
            btnTimKiem.Text = "Tìm kiếm";
            // 
            // pnlThongTin
            // 
            pnlThongTin.BorderRadius = 9;
            pnlThongTin.Controls.Add(picHinhAnh);
            pnlThongTin.Controls.Add(lblMaNhanVien);
            pnlThongTin.Controls.Add(lblHoTen);
            pnlThongTin.Controls.Add(lblSoDienThoai);
            pnlThongTin.Controls.Add(lblTaiKhoan);
            pnlThongTin.Controls.Add(lblVaiTro);
            pnlThongTin.CustomizableEdges = customizableEdges9;
            pnlThongTin.Dock = DockStyle.Fill;
            pnlThongTin.FillColor = Color.FromArgb(248, 250, 253);
            pnlThongTin.Location = new Point(0, 120);
            pnlThongTin.Margin = new Padding(0, 5, 0, 10);
            pnlThongTin.Name = "pnlThongTin";
            pnlThongTin.ShadowDecoration.CustomizableEdges = customizableEdges10;
            pnlThongTin.Size = new Size(1020, 135);
            pnlThongTin.TabIndex = 2;
            // 
            // picHinhAnh
            // 
            picHinhAnh.BackColor = Color.White;
            picHinhAnh.BorderStyle = BorderStyle.FixedSingle;
            picHinhAnh.Location = new Point(15, 10);
            picHinhAnh.Name = "picHinhAnh";
            picHinhAnh.Size = new Size(125, 125);
            picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
            picHinhAnh.TabIndex = 0;
            picHinhAnh.TabStop = false;
            // 
            // lblMaNhanVien
            // 
            lblMaNhanVien.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMaNhanVien.ForeColor = Color.FromArgb(31, 58, 95);
            lblMaNhanVien.Location = new Point(170, 15);
            lblMaNhanVien.Name = "lblMaNhanVien";
            lblMaNhanVien.Size = new Size(350, 25);
            lblMaNhanVien.TabIndex = 1;
            lblMaNhanVien.Text = "Mã nhân viên:";
            // 
            // lblHoTen
            // 
            lblHoTen.Font = new Font("Segoe UI", 10F);
            lblHoTen.ForeColor = Color.FromArgb(50, 65, 85);
            lblHoTen.Location = new Point(170, 42);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(450, 25);
            lblHoTen.TabIndex = 2;
            lblHoTen.Text = "Họ tên:";
            // 
            // lblSoDienThoai
            // 
            lblSoDienThoai.Font = new Font("Segoe UI", 10F);
            lblSoDienThoai.ForeColor = Color.FromArgb(50, 65, 85);
            lblSoDienThoai.Location = new Point(170, 69);
            lblSoDienThoai.Name = "lblSoDienThoai";
            lblSoDienThoai.Size = new Size(450, 25);
            lblSoDienThoai.TabIndex = 3;
            lblSoDienThoai.Text = "Số điện thoại:";
            // 
            // lblTaiKhoan
            // 
            lblTaiKhoan.Font = new Font("Segoe UI", 10F);
            lblTaiKhoan.ForeColor = Color.FromArgb(50, 65, 85);
            lblTaiKhoan.Location = new Point(170, 96);
            lblTaiKhoan.Name = "lblTaiKhoan";
            lblTaiKhoan.Size = new Size(450, 25);
            lblTaiKhoan.TabIndex = 4;
            lblTaiKhoan.Text = "Tài khoản:";
            // 
            // lblVaiTro
            // 
            lblVaiTro.Font = new Font("Segoe UI", 10F);
            lblVaiTro.ForeColor = Color.FromArgb(50, 65, 85);
            lblVaiTro.Location = new Point(650, 15);
            lblVaiTro.Name = "lblVaiTro";
            lblVaiTro.Size = new Size(250, 25);
            lblVaiTro.TabIndex = 5;
            lblVaiTro.Text = "Vai trò:";
            // 
            // dgvNhanVien
            // 
            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.AllowUserToDeleteRows = false;
            dgvNhanVien.AllowUserToResizeColumns = false;
            dgvNhanVien.AllowUserToResizeRows = false;
            dgvNhanVien.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(29, 67, 120);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvNhanVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvNhanVien.ColumnHeadersHeight = 42;
            dgvNhanVien.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5 });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(220, 235, 252);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(31, 58, 95);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvNhanVien.DefaultCellStyle = dataGridViewCellStyle2;
            dgvNhanVien.GridColor = Color.FromArgb(231, 229, 255);
            dgvNhanVien.Location = new Point(3, 268);
            dgvNhanVien.MultiSelect = false;
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.ReadOnly = true;
            dgvNhanVien.RowHeadersVisible = false;
            dgvNhanVien.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvNhanVien.RowTemplate.Height = 38;
            dgvNhanVien.Size = new Size(1014, 254);
            dgvNhanVien.TabIndex = 3;
            dgvNhanVien.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(29, 67, 120);
            dgvNhanVien.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvNhanVien.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvNhanVien.ThemeStyle.HeaderStyle.Height = 42;
            dgvNhanVien.ThemeStyle.ReadOnly = true;
            dgvNhanVien.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9.5F);
            dgvNhanVien.ThemeStyle.RowsStyle.Height = 38;
            dgvNhanVien.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(220, 235, 252);
            dgvNhanVien.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(31, 58, 95);
            
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Mã nhân viên";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Họ tên";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Số điện thoại";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Tài khoản";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Vai trò";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // pnlActions
            // 
            pnlActions.Controls.Add(tableLayoutButtons);
            pnlActions.CustomizableEdges = customizableEdges17;
            pnlActions.Dock = DockStyle.Fill;
            pnlActions.FillColor = Color.White;
            pnlActions.Location = new Point(3, 528);
            pnlActions.Name = "pnlActions";
            pnlActions.ShadowDecoration.CustomizableEdges = customizableEdges18;
            pnlActions.Size = new Size(1014, 69);
            pnlActions.TabIndex = 4;
            // 
            // tableLayoutButtons
            // 
            tableLayoutButtons.BackColor = Color.White;
            tableLayoutButtons.ColumnCount = 3;
            tableLayoutButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tableLayoutButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tableLayoutButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
            tableLayoutButtons.Controls.Add(btnThem, 0, 0);
            tableLayoutButtons.Controls.Add(btnSua, 1, 0);
            tableLayoutButtons.Controls.Add(btnXoa, 2, 0);
            tableLayoutButtons.Dock = DockStyle.Left;
            tableLayoutButtons.Location = new Point(0, 0);
            tableLayoutButtons.Margin = new Padding(0);
            tableLayoutButtons.Name = "tableLayoutButtons";
            tableLayoutButtons.RowCount = 1;
            tableLayoutButtons.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            tableLayoutButtons.Size = new Size(600, 69);
            tableLayoutButtons.TabIndex = 0;
            // 
            // btnThem
            // 
            btnThem.BorderRadius = 8;
            btnThem.CustomizableEdges = customizableEdges11;
            btnThem.Dock = DockStyle.Bottom;
            btnThem.FillColor = Color.FromArgb(35, 120, 210);
            btnThem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(0, 24);
            btnThem.Margin = new Padding(0, 0, 8, 0);
            btnThem.Name = "btnThem";
            btnThem.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnThem.Size = new Size(191, 45);
            btnThem.TabIndex = 0;
            btnThem.Text = "＋  Thêm";
            // 
            // btnSua
            // 
            btnSua.BorderRadius = 8;
            btnSua.CustomizableEdges = customizableEdges13;
            btnSua.Dock = DockStyle.Bottom;
            btnSua.FillColor = Color.FromArgb(235, 160, 45);
            btnSua.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(203, 24);
            btnSua.Margin = new Padding(4, 0, 4, 0);
            btnSua.Name = "btnSua";
            btnSua.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnSua.Size = new Size(191, 45);
            btnSua.TabIndex = 1;
            btnSua.Text = "✎  Sửa";
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BorderRadius = 8;
            btnXoa.CustomizableEdges = customizableEdges15;
            btnXoa.Dock = DockStyle.Bottom;
            btnXoa.FillColor = Color.FromArgb(220, 65, 75);
            btnXoa.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(406, 24);
            btnXoa.Margin = new Padding(8, 0, 0, 0);
            btnXoa.Name = "btnXoa";
            btnXoa.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnXoa.Size = new Size(194, 45);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "✕  Xóa";
            btnXoa.Click += btnXoa_Click;
            // 
            // frmNhanVien
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 246, 251);
            ClientSize = new Size(1100, 680);
            Controls.Add(pnlMain);
            MinimumSize = new Size(950, 600);
            Name = "frmNhanVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý nhân viên";
            pnlMain.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            layoutMain.ResumeLayout(false);
            pnlSearch.ResumeLayout(false);
            pnlThongTin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
            pnlActions.ResumeLayout(false);
            tableLayoutButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Guna2Panel pnlMain;
        private Guna2Panel pnlContent;
        private Guna2Panel pnlSearch;
        private Guna2Panel pnlThongTin;
        private Guna2Panel pnlActions;

        private TableLayoutPanel layoutMain;
        private TableLayoutPanel tableLayoutButtons;

        private Label lblTieuDe;
        private Label lblTimKiem;
        private Label lblMaNhanVien;
        private Label lblHoTen;
        private Label lblSoDienThoai;
        private Label lblTaiKhoan;
        private Label lblVaiTro;

        private Guna2ComboBox cboTimTheo;
        private Guna2TextBox txtTimKiem;

        private PictureBox picHinhAnh;
        private Guna2DataGridView dgvNhanVien;

        private Guna2Button btnTimKiem;
        private Guna2Button btnThem;
        private Guna2Button btnSua;
        private Guna2Button btnXoa;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    }
}
