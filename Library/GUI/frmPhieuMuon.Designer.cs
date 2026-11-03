
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Library
{
    partial class frmPhieuMuon
    {
        private System.ComponentModel.IContainer components = null;

        private Guna.UI2.WinForms.Guna2GroupBox groupThongTin;
        private Guna.UI2.WinForms.Guna2GroupBox groupSach;

        private System.Windows.Forms.Label lblDocGia;
        private System.Windows.Forms.Label lblNgayMuon;
        private System.Windows.Forms.Label lblHanTra;
        private System.Windows.Forms.Label lblSach;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.Label lblTongSoLuong;

        private Guna.UI2.WinForms.Guna2TextBox txtTimDocGia;
        private Guna.UI2.WinForms.Guna2TextBox txtNhanVien;
        private Guna.UI2.WinForms.Guna2TextBox txtTimSach;

        private System.Windows.Forms.ListBox lstGoiYDocGia;
        private System.Windows.Forms.ListBox lstGoiYSach;

        private Guna.UI2.WinForms.Guna2NumericUpDown numSoLuong;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgayMuon;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpHanTra;

        private Guna.UI2.WinForms.Guna2DataGridView dgvSachMuon;

        private Guna.UI2.WinForms.Guna2Button btnThemSach;
        private Guna.UI2.WinForms.Guna2Button btnXoaSach;
        private Guna.UI2.WinForms.Guna2Button btnXacNhan;
        private Guna.UI2.WinForms.Guna2Button btnLamMoi;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            groupThongTin = new Guna.UI2.WinForms.Guna2GroupBox();
            lblDocGia = new Label();
            txtTimDocGia = new Guna.UI2.WinForms.Guna2TextBox();
            txtNhanVien = new Guna.UI2.WinForms.Guna2TextBox();
            lblNgayMuon = new Label();
            dtpNgayMuon = new Guna.UI2.WinForms.Guna2DateTimePicker();
            lblHanTra = new Label();
            dtpHanTra = new Guna.UI2.WinForms.Guna2DateTimePicker();
            lstGoiYDocGia = new ListBox();
            groupSach = new Guna.UI2.WinForms.Guna2GroupBox();
            lblSach = new Label();
            txtTimSach = new Guna.UI2.WinForms.Guna2TextBox();
            lstGoiYSach = new ListBox();
            lblSoLuong = new Label();
            numSoLuong = new Guna.UI2.WinForms.Guna2NumericUpDown();
            btnThemSach = new Guna.UI2.WinForms.Guna2Button();
            btnXoaSach = new Guna.UI2.WinForms.Guna2Button();
            dgvSachMuon = new Guna.UI2.WinForms.Guna2DataGridView();
            lblTongSoLuong = new Label();
            btnXacNhan = new Guna.UI2.WinForms.Guna2Button();
            btnLamMoi = new Guna.UI2.WinForms.Guna2Button();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            groupThongTin.SuspendLayout();
            groupSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSachMuon).BeginInit();
            SuspendLayout();
            // 
            // groupThongTin
            // 
            groupThongTin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupThongTin.BorderRadius = 8;
            groupThongTin.Controls.Add(guna2HtmlLabel1);
            groupThongTin.Controls.Add(lblDocGia);
            groupThongTin.Controls.Add(txtTimDocGia);
            groupThongTin.Controls.Add(txtNhanVien);
            groupThongTin.Controls.Add(lblNgayMuon);
            groupThongTin.Controls.Add(dtpNgayMuon);
            groupThongTin.Controls.Add(lblHanTra);
            groupThongTin.Controls.Add(dtpHanTra);
            groupThongTin.Controls.Add(lstGoiYDocGia);
            groupThongTin.CustomBorderColor = Color.FromArgb(192, 192, 255);
            groupThongTin.CustomizableEdges = customizableEdges9;
            groupThongTin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupThongTin.ForeColor = Color.Black;
            groupThongTin.Location = new Point(22, 19);
            groupThongTin.Name = "groupThongTin";
            groupThongTin.ShadowDecoration.CustomizableEdges = customizableEdges10;
            groupThongTin.Size = new Size(814, 216);
            groupThongTin.TabIndex = 0;
            groupThongTin.Text = "Thông tin phiếu mượn";
            // 
            // lblDocGia
            // 
            lblDocGia.Location = new Point(18, 52);
            lblDocGia.Name = "lblDocGia";
            lblDocGia.Size = new Size(131, 23);
            lblDocGia.TabIndex = 0;
            lblDocGia.Text = "Tìm độc giả:";
            // 
            // txtTimDocGia
            // 
            txtTimDocGia.BorderRadius = 5;
            txtTimDocGia.CustomizableEdges = customizableEdges1;
            txtTimDocGia.DefaultText = "";
            txtTimDocGia.Font = new Font("Segoe UI", 10F);
            txtTimDocGia.Location = new Point(18, 80);
            txtTimDocGia.Name = "txtTimDocGia";
            txtTimDocGia.PlaceholderText = "Nhập mã hoặc tên độc giả...";
            txtTimDocGia.SelectedText = "";
            txtTimDocGia.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtTimDocGia.Size = new Size(359, 39);
            txtTimDocGia.TabIndex = 1;
            // 
            // txtNhanVien
            // 
            
            txtNhanVien.BorderRadius = 5;
            txtNhanVien.CustomizableEdges = customizableEdges3;
            txtNhanVien.DefaultText = "";
            txtNhanVien.Enabled = false;
            txtNhanVien.FillColor = Color.FromArgb(240, 240, 240);
            txtNhanVien.Font = new Font("Segoe UI", 11F);
            txtNhanVien.ForeColor = Color.FromArgb(80, 80, 80);
            txtNhanVien.Location = new Point(400, 80);
            txtNhanVien.Name = "txtNhanVien";
            txtNhanVien.PlaceholderText = "";
            txtNhanVien.ReadOnly = true;
            txtNhanVien.SelectedText = "";
            txtNhanVien.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtNhanVien.Size = new Size(359, 39);
            txtNhanVien.TabIndex = 3;
            txtNhanVien.TabStop = false;
            // 
            // lblNgayMuon
            // 
            lblNgayMuon.Location = new Point(18, 136);
            lblNgayMuon.Name = "lblNgayMuon";
            lblNgayMuon.Size = new Size(105, 23);
            lblNgayMuon.TabIndex = 4;
            lblNgayMuon.Text = "Ngày mượn:";
            // 
            // dtpNgayMuon
            // 
            dtpNgayMuon.BackColor = Color.White;
            dtpNgayMuon.Checked = true;
            dtpNgayMuon.CustomizableEdges = customizableEdges5;
            dtpNgayMuon.FillColor = Color.White;
            dtpNgayMuon.Font = new Font("Segoe UI", 10F);
            dtpNgayMuon.Format = DateTimePickerFormat.Short;
            dtpNgayMuon.Location = new Point(18, 164);
            dtpNgayMuon.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpNgayMuon.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpNgayMuon.Name = "dtpNgayMuon";
            dtpNgayMuon.ShadowDecoration.CustomizableEdges = customizableEdges6;
            dtpNgayMuon.Size = new Size(359, 34);
            dtpNgayMuon.TabIndex = 5;
            dtpNgayMuon.Value = new DateTime(2026, 11, 1, 20, 11, 46, 824);
            // 
            // lblHanTra
            // 
            
            lblHanTra.Location = new Point(400, 136);
            lblHanTra.Name = "lblHanTra";
            lblHanTra.Size = new Size(105, 23);
            lblHanTra.TabIndex = 6;
            lblHanTra.Text = "Hạn trả:";
            // 
            // dtpHanTra
            // 
            
            dtpHanTra.Checked = true;
            dtpHanTra.CustomizableEdges = customizableEdges7;
            dtpHanTra.FillColor = Color.White;
            dtpHanTra.Font = new Font("Segoe UI", 10F);
            dtpHanTra.Format = DateTimePickerFormat.Short;
            dtpHanTra.Location = new Point(400, 164);
            dtpHanTra.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpHanTra.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpHanTra.Name = "dtpHanTra";
            dtpHanTra.ShadowDecoration.CustomizableEdges = customizableEdges8;
            dtpHanTra.Size = new Size(359, 34);
            dtpHanTra.TabIndex = 7;
            dtpHanTra.Value = new DateTime(2026, 11, 1, 20, 11, 46, 846);
            // 
            // lstGoiYDocGia
            // 
            lstGoiYDocGia.BorderStyle = BorderStyle.FixedSingle;
            lstGoiYDocGia.Font = new Font("Segoe UI", 10F);
            lstGoiYDocGia.IntegralHeight = false;
            lstGoiYDocGia.Location = new Point(18, 113);
            lstGoiYDocGia.Name = "lstGoiYDocGia";
            lstGoiYDocGia.Size = new Size(359, 46);
            lstGoiYDocGia.TabIndex = 8;
            lstGoiYDocGia.Visible = false;
            // 
            // groupSach
            // 
            groupSach.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupSach.BorderRadius = 8;
            groupSach.Controls.Add(lblSach);
            groupSach.Controls.Add(txtTimSach);
            groupSach.Controls.Add(lstGoiYSach);
            groupSach.Controls.Add(lblSoLuong);
            groupSach.Controls.Add(numSoLuong);
            groupSach.Controls.Add(btnThemSach);
            groupSach.Controls.Add(btnXoaSach);
            groupSach.Controls.Add(dgvSachMuon);
            groupSach.Controls.Add(lblTongSoLuong);
            groupSach.CustomBorderColor = Color.FromArgb(192, 192, 255);
            groupSach.CustomizableEdges = customizableEdges19;
            groupSach.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupSach.ForeColor = Color.Black;
            groupSach.Location = new Point(22, 248);
            groupSach.Name = "groupSach";
            groupSach.ShadowDecoration.CustomizableEdges = customizableEdges20;
            groupSach.Size = new Size(814, 347);
            groupSach.TabIndex = 1;
            groupSach.Text = "Thông tin sách mượn";
            // 
            // lblSach
            // 
            lblSach.Location = new Point(18, 45);
            lblSach.Name = "lblSach";
            lblSach.Size = new Size(105, 23);
            lblSach.TabIndex = 0;
            lblSach.Text = "Tìm sách:";
            // 
            // txtTimSach
            // 
            txtTimSach.BorderRadius = 5;
            txtTimSach.CustomizableEdges = customizableEdges11;
            txtTimSach.DefaultText = "";
            txtTimSach.Font = new Font("Segoe UI", 10F);
            txtTimSach.Location = new Point(18, 70);
            txtTimSach.Name = "txtTimSach";
            txtTimSach.PlaceholderText = "Nhập mã hoặc tên sách...";
            txtTimSach.SelectedText = "";
            txtTimSach.ShadowDecoration.CustomizableEdges = customizableEdges12;
            txtTimSach.Size = new Size(376, 34);
            txtTimSach.TabIndex = 1;
            // 
            // lstGoiYSach
            // 
            lstGoiYSach.BorderStyle = BorderStyle.FixedSingle;
            lstGoiYSach.Font = new Font("Segoe UI", 10F);
            lstGoiYSach.IntegralHeight = false;
            lstGoiYSach.Location = new Point(18, 104);
            lstGoiYSach.Name = "lstGoiYSach";
            lstGoiYSach.Size = new Size(376, 80);
            lstGoiYSach.TabIndex = 2;
            lstGoiYSach.Visible = false;
            // 
            // lblSoLuong
            // 
            
            lblSoLuong.Location = new Point(411, 45);
            lblSoLuong.Name = "lblSoLuong";
            lblSoLuong.Size = new Size(88, 23);
            lblSoLuong.TabIndex = 3;
            lblSoLuong.Text = "Số lượng:";
            // 
            // numSoLuong
            // 
            
            numSoLuong.BackColor = Color.Transparent;
            numSoLuong.CustomizableEdges = customizableEdges13;
            numSoLuong.Font = new Font("Segoe UI", 10F);
            numSoLuong.Location = new Point(411, 70);
            numSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numSoLuong.Name = "numSoLuong";
            numSoLuong.ShadowDecoration.CustomizableEdges = customizableEdges14;
            numSoLuong.Size = new Size(105, 34);
            numSoLuong.TabIndex = 4;
            numSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnThemSach
            // 
            
            btnThemSach.BorderRadius = 6;
            btnThemSach.CustomizableEdges = customizableEdges15;
            btnThemSach.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnThemSach.ForeColor = Color.White;
            btnThemSach.Location = new Point(534, 70);
            btnThemSach.Name = "btnThemSach";
            btnThemSach.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnThemSach.Size = new Size(114, 34);
            btnThemSach.TabIndex = 5;
            btnThemSach.Text = "Thêm sách";
            // 
            // btnXoaSach
            // 
            
            btnXoaSach.BorderRadius = 6;
            btnXoaSach.CustomizableEdges = customizableEdges17;
            btnXoaSach.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnXoaSach.ForeColor = Color.White;
            btnXoaSach.Location = new Point(661, 70);
            btnXoaSach.Name = "btnXoaSach";
            btnXoaSach.ShadowDecoration.CustomizableEdges = customizableEdges18;
            btnXoaSach.Size = new Size(114, 34);
            btnXoaSach.TabIndex = 6;
            btnXoaSach.Text = "Xóa sách";
            // 
            // dgvSachMuon
            // 
            dgvSachMuon.AllowUserToAddRows = false;
            dgvSachMuon.AllowUserToDeleteRows = false;
            dgvSachMuon.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvSachMuon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvSachMuon.ColumnHeadersHeight = 38;
            dgvSachMuon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvSachMuon.DefaultCellStyle = dataGridViewCellStyle2;
            dgvSachMuon.GridColor = Color.FromArgb(231, 229, 255);
            dgvSachMuon.Location = new Point(18, 123);
            dgvSachMuon.MultiSelect = false;
            dgvSachMuon.Name = "dgvSachMuon";
            dgvSachMuon.ReadOnly = true;
            dgvSachMuon.RowHeadersVisible = false;
            dgvSachMuon.Size = new Size(779, 169);
            dgvSachMuon.TabIndex = 7;
            dgvSachMuon.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvSachMuon.ThemeStyle.HeaderStyle.Height = 38;
            dgvSachMuon.ThemeStyle.ReadOnly = true;
            dgvSachMuon.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvSachMuon.ThemeStyle.RowsStyle.Height = 25;
            // 
            // lblTongSoLuong
            // 
            lblTongSoLuong.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTongSoLuong.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTongSoLuong.Location = new Point(18, 295);
            lblTongSoLuong.Name = "lblTongSoLuong";
            lblTongSoLuong.Size = new Size(219, 23);
            lblTongSoLuong.TabIndex = 8;
            lblTongSoLuong.Text = "Tổng số lượng: 0";
            // 
            // btnXacNhan
            // 
            btnXacNhan.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnXacNhan.BorderRadius = 6;
            btnXacNhan.CustomizableEdges = customizableEdges21;
            btnXacNhan.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnXacNhan.ForeColor = Color.White;
            btnXacNhan.Location = new Point(569, 614);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.ShadowDecoration.CustomizableEdges = customizableEdges22;
            btnXacNhan.Size = new Size(131, 39);
            btnXacNhan.TabIndex = 2;
            btnXacNhan.Text = "Xác nhận mượn";
            // 
            // btnLamMoi
            // 
            btnLamMoi.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLamMoi.BorderRadius = 6;
            btnLamMoi.CustomizableEdges = customizableEdges23;
            btnLamMoi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(713, 614);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.ShadowDecoration.CustomizableEdges = customizableEdges24;
            btnLamMoi.Size = new Size(122, 39);
            btnLamMoi.TabIndex = 3;
            btnLamMoi.Text = "Làm mới";
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Location = new Point(400, 50);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(108, 19);
            guna2HtmlLabel1.TabIndex = 9;
            guna2HtmlLabel1.Text = "Người lập phiếu:";
            // 
            // frmPhieuMuon
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(875, 675);
            Controls.Add(groupThongTin);
            Controls.Add(groupSach);
            Controls.Add(btnXacNhan);
            Controls.Add(btnLamMoi);
            MinimumSize = new Size(875, 675);
            Name = "frmPhieuMuon";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lập phiếu mượn sách";
            groupThongTin.ResumeLayout(false);
            groupThongTin.PerformLayout();
            groupSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numSoLuong).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSachMuon).EndInit();
            ResumeLayout(false);
        }

        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
    }
}
