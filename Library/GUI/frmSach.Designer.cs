using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace Library
{
    partial class frmSach
    {
        private System.ComponentModel.IContainer components = null;

        private Guna2Panel pnlMain;
        private Guna2Panel pnlHeader;
        private Guna2Panel pnlLeft;
        private Guna2Panel pnlRight;
        private Guna2Panel pnlSearch;
        private Guna2Panel pnlImage;

        private Label lblTitle;
        private Label lblSubTitle;
        private Label lblImageTitle;
        private Label lblListTitle;
        private Label lblSearch;

        private Guna2Button btnThemSach;
        private Guna2Button btnSuaSach;
        private Guna2Button btnXoaSach;
        private Guna2Button btnTimKiem;

        private Guna2TextBox txtTimKiem;
        private Guna2ComboBox cboTimTheo;

        private Guna2DataGridView dgvSach;

        private PictureBox pictureBoxSach;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlMain = new Guna2Panel();
            pnlRight = new Guna2Panel();
            dgvSach = new Guna2DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            dgvNhaXuatBan = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            pnlSearch = new Guna2Panel();
            txtTimKiem = new Guna2TextBox();
            cboTimTheo = new Guna2ComboBox();
            btnTimKiem = new Guna2Button();
            lblSearch = new Label();
            lblListTitle = new Label();
            pnlLeft = new Guna2Panel();
            btnXoaSach = new Guna2Button();
            btnSuaSach = new Guna2Button();
            btnThemSach = new Guna2Button();
            pnlImage = new Guna2Panel();
            pictureBoxSach = new PictureBox();
            lblImageTitle = new Label();
            pnlHeader = new Guna2Panel();
            lblTitle = new Label();
            lblSubTitle = new Label();
            pnlMain.SuspendLayout();
            pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSach).BeginInit();
            pnlSearch.SuspendLayout();
            pnlLeft.SuspendLayout();
            pnlImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSach).BeginInit();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(pnlRight);
            pnlMain.Controls.Add(pnlLeft);
            pnlMain.Controls.Add(pnlHeader);
            pnlMain.CustomizableEdges = customizableEdges23;
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.FillColor = Color.FromArgb(245, 247, 251);
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(20);
            pnlMain.ShadowDecoration.CustomizableEdges = customizableEdges24;
            pnlMain.Size = new Size(1100, 680);
            pnlMain.TabIndex = 0;
            // 
            // pnlRight
            // 
            pnlRight.BorderRadius = 12;
            pnlRight.Controls.Add(dgvSach);
            pnlRight.Controls.Add(pnlSearch);
            pnlRight.Controls.Add(lblListTitle);
            pnlRight.CustomizableEdges = customizableEdges9;
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.FillColor = Color.White;
            pnlRight.Location = new Point(280, 20);
            pnlRight.Name = "pnlRight";
            pnlRight.Padding = new Padding(15);
            pnlRight.ShadowDecoration.CustomizableEdges = customizableEdges10;
            pnlRight.Size = new Size(800, 640);
            pnlRight.TabIndex = 0;
            // 
            // dgvSach
            // 
            dgvSach.AllowUserToAddRows = false;
            dgvSach.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(247, 249, 252);
            dgvSach.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(35, 85, 145);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvSach.ColumnHeadersHeight = 42;
            dgvSach.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvSach.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, dgvNhaXuatBan, Column5, Column6 });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(55, 65, 80);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(220, 235, 250);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(30, 50, 80);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvSach.DefaultCellStyle = dataGridViewCellStyle3;
            dgvSach.Dock = DockStyle.Fill;
            dgvSach.GridColor = Color.FromArgb(230, 234, 240);
            dgvSach.Location = new Point(15, 145);
            dgvSach.MultiSelect = false;
            dgvSach.Name = "dgvSach";
            dgvSach.ReadOnly = true;
            dgvSach.RowHeadersVisible = false;
            dgvSach.RowTemplate.Height = 38;
            dgvSach.Size = new Size(770, 480);
            dgvSach.TabIndex = 0;
            dgvSach.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(247, 249, 252);
            dgvSach.ThemeStyle.GridColor = Color.FromArgb(230, 234, 240);
            dgvSach.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(35, 85, 145);
            dgvSach.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvSach.ThemeStyle.HeaderStyle.Height = 42;
            dgvSach.ThemeStyle.ReadOnly = true;
            dgvSach.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvSach.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(55, 65, 80);
            dgvSach.ThemeStyle.RowsStyle.Height = 38;
            dgvSach.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(220, 235, 250);
            dgvSach.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(30, 50, 80);
            dgvSach.SelectionChanged += dgvSach_SelectionChanged;
            // 
            // Column1
            // 
            Column1.HeaderText = "Mã sách";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.HeaderText = "Tên sách";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.HeaderText = "Tác giả";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // Column4
            // 
            Column4.HeaderText = "Thể loại";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            // 
            // dgvNhaXuatBan
            // 
            dgvNhaXuatBan.HeaderText = "Nhà xuất bản";
            dgvNhaXuatBan.Name = "dgvNhaXuatBan";
            dgvNhaXuatBan.ReadOnly = true;
            // 
            // Column5
            // 
            Column5.HeaderText = "Năm xuất bản";
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            // 
            // Column6
            // 
            Column6.HeaderText = "Số lượng";
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            // 
            // pnlSearch
            // 
            pnlSearch.Controls.Add(txtTimKiem);
            pnlSearch.Controls.Add(cboTimTheo);
            pnlSearch.Controls.Add(btnTimKiem);
            pnlSearch.Controls.Add(lblSearch);
            pnlSearch.CustomizableEdges = customizableEdges7;
            pnlSearch.Dock = DockStyle.Top;
            pnlSearch.FillColor = Color.White;
            pnlSearch.Location = new Point(15, 55);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.ShadowDecoration.CustomizableEdges = customizableEdges8;
            pnlSearch.Size = new Size(770, 90);
            pnlSearch.TabIndex = 1;
            // 
            // txtTimKiem
            // 
            txtTimKiem.BorderRadius = 7;
            txtTimKiem.CustomizableEdges = customizableEdges1;
            txtTimKiem.DefaultText = "";
            txtTimKiem.Font = new Font("Segoe UI", 9F);
            txtTimKiem.Location = new Point(140, 28);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập từ khóa tìm kiếm...";
            txtTimKiem.SelectedText = "";
            txtTimKiem.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtTimKiem.Size = new Size(220, 38);
            txtTimKiem.TabIndex = 0;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            txtTimKiem.KeyDown += txtTimKiem_KeyDown;
            // 
            // cboTimTheo
            // 
            cboTimTheo.BackColor = Color.Transparent;
            cboTimTheo.BorderRadius = 7;
            cboTimTheo.CustomizableEdges = customizableEdges3;
            cboTimTheo.DrawMode = DrawMode.OwnerDrawFixed;
            cboTimTheo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTimTheo.FocusedColor = Color.Empty;
            cboTimTheo.Font = new Font("Segoe UI", 9F);
            cboTimTheo.ForeColor = Color.FromArgb(45, 55, 75);
            cboTimTheo.ItemHeight = 30;
            cboTimTheo.Items.AddRange(new object[] { "Mã sách", "Tên sách", "Tác giả", "Thể loại", "Nhà xuất bản" });
            cboTimTheo.Location = new Point(0, 28);
            cboTimTheo.Name = "cboTimTheo";
            cboTimTheo.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cboTimTheo.Size = new Size(130, 36);
            cboTimTheo.TabIndex = 1;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BorderRadius = 7;
            btnTimKiem.CustomizableEdges = customizableEdges5;
            btnTimKiem.FillColor = Color.FromArgb(35, 120, 210);
            btnTimKiem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(370, 28);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnTimKiem.Size = new Size(75, 38);
            btnTimKiem.TabIndex = 2;
            btnTimKiem.Text = "Tìm";
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // lblSearch
            // 
            lblSearch.BackColor = Color.White;
            lblSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSearch.ForeColor = Color.FromArgb(31, 58, 95);
            lblSearch.Location = new Point(0, 2);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(150, 22);
            lblSearch.TabIndex = 3;
            lblSearch.Text = "Tìm kiếm sách";
            // 
            // lblListTitle
            // 
            lblListTitle.BackColor = Color.White;
            lblListTitle.Dock = DockStyle.Top;
            lblListTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblListTitle.ForeColor = Color.FromArgb(31, 58, 95);
            lblListTitle.Location = new Point(15, 15);
            lblListTitle.Name = "lblListTitle";
            lblListTitle.Size = new Size(770, 40);
            lblListTitle.TabIndex = 2;
            lblListTitle.Text = "DANH SÁCH SÁCH";
            lblListTitle.TextAlign = ContentAlignment.MiddleLeft;
            lblListTitle.Click += lblListTitle_Click;
            // 
            // pnlLeft
            // 
            pnlLeft.BorderRadius = 12;
            pnlLeft.Controls.Add(btnXoaSach);
            pnlLeft.Controls.Add(btnSuaSach);
            pnlLeft.Controls.Add(btnThemSach);
            pnlLeft.Controls.Add(pnlImage);
            pnlLeft.CustomizableEdges = customizableEdges19;
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.FillColor = Color.White;
            pnlLeft.Location = new Point(20, 20);
            pnlLeft.Margin = new Padding(0, 15, 15, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Padding = new Padding(15);
            pnlLeft.ShadowDecoration.CustomizableEdges = customizableEdges20;
            pnlLeft.Size = new Size(260, 640);
            pnlLeft.TabIndex = 1;
            // 
            // btnXoaSach
            // 
            btnXoaSach.BorderRadius = 8;
            btnXoaSach.CustomizableEdges = customizableEdges11;
            btnXoaSach.Dock = DockStyle.None;
            btnXoaSach.FillColor = Color.FromArgb(220, 65, 75);
            btnXoaSach.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXoaSach.ForeColor = Color.White;
            btnXoaSach.Location = new Point(15, 450);
            btnXoaSach.Margin = new Padding(0, 20, 0, 10);
            btnXoaSach.Name = "btnXoaSach";
            btnXoaSach.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnXoaSach.Size = new Size(230, 40);
            btnXoaSach.TabIndex = 0;
            btnXoaSach.Text = "✕  Xóa sách";
            btnXoaSach.Click += btnXoaSach_Click;
            // 
            // btnSuaSach
            // 
            btnSuaSach.BorderRadius = 8;
            btnSuaSach.CustomizableEdges = customizableEdges13;
            btnSuaSach.Dock = DockStyle.None;
            btnSuaSach.FillColor = Color.FromArgb(235, 160, 45);
            btnSuaSach.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSuaSach.ForeColor = Color.White;
            btnSuaSach.Location = new Point(15, 400);
            btnSuaSach.Margin = new Padding(0, 0, 0, 10);
            btnSuaSach.Name = "btnSuaSach";
            btnSuaSach.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnSuaSach.Size = new Size(230, 40);
            btnSuaSach.TabIndex = 1;
            btnSuaSach.Text = "✎  Sửa sách";
            btnSuaSach.Click += btnSuaSach_Click;
            // 
            // btnThemSach
            // 
            btnThemSach.BorderRadius = 8;
            btnThemSach.CustomizableEdges = customizableEdges15;
            btnThemSach.Dock = DockStyle.None;
            btnThemSach.FillColor = Color.FromArgb(35, 120, 210);
            btnThemSach.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThemSach.ForeColor = Color.White;
            btnThemSach.Location = new Point(15, 350);
            btnThemSach.Margin = new Padding(0, 0, 0, 10);
            btnThemSach.Name = "btnThemSach";
            btnThemSach.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnThemSach.Size = new Size(230, 40);
            btnThemSach.TabIndex = 2;
            btnThemSach.Text = "＋  Thêm sách";
            btnThemSach.Click += btnThemSach_Click;
            // 
            // pnlImage
            // 
            pnlImage.BorderRadius = 10;
            pnlImage.Controls.Add(pictureBoxSach);
            pnlImage.Controls.Add(lblImageTitle);
            pnlImage.CustomizableEdges = customizableEdges17;
            pnlImage.Dock = DockStyle.Top;
            pnlImage.FillColor = Color.FromArgb(245, 247, 251);
            pnlImage.Location = new Point(15, 15);
            pnlImage.Name = "pnlImage";
            pnlImage.ShadowDecoration.CustomizableEdges = customizableEdges18;
            pnlImage.Size = new Size(230, 270);
            pnlImage.TabIndex = 3;
            // 
            // pictureBoxSach
            // 
            pictureBoxSach.BackColor = Color.White;
            pictureBoxSach.Dock = DockStyle.Fill;
            pictureBoxSach.Location = new Point(0, 38);
            pictureBoxSach.Margin = new Padding(10);
            pictureBoxSach.Name = "pictureBoxSach";
            pictureBoxSach.Size = new Size(230, 232);
            pictureBoxSach.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxSach.TabIndex = 0;
            pictureBoxSach.TabStop = false;
            // 
            // lblImageTitle
            // 
            lblImageTitle.BackColor = Color.White;
            lblImageTitle.Dock = DockStyle.Top;
            lblImageTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblImageTitle.ForeColor = Color.FromArgb(31, 58, 95);
            lblImageTitle.Location = new Point(0, 0);
            lblImageTitle.Name = "lblImageTitle";
            lblImageTitle.Size = new Size(230, 38);
            lblImageTitle.TabIndex = 1;
            lblImageTitle.Text = "HÌNH ẢNH SÁCH";
            lblImageTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlHeader
            // 
            pnlHeader.CustomizableEdges = customizableEdges21;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.ShadowDecoration.CustomizableEdges = customizableEdges22;
            pnlHeader.Size = new Size(200, 100);
            pnlHeader.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(100, 23);
            lblTitle.TabIndex = 0;
            // 
            // lblSubTitle
            // 
            lblSubTitle.Location = new Point(0, 0);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new Size(100, 23);
            lblSubTitle.TabIndex = 0;
            // 
            // frmSach
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 251);
            ClientSize = new Size(1100, 680);
            Controls.Add(pnlMain);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(850, 550);
            Name = "frmSach";
            Text = "Quản lý sách";
            Load += frmSach_Load;
            pnlMain.ResumeLayout(false);
            pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSach).EndInit();
            pnlSearch.ResumeLayout(false);
            pnlLeft.ResumeLayout(false);
            pnlImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxSach).EndInit();
            ResumeLayout(false);
        }

        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn dgvNhaXuatBan;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
    }
}