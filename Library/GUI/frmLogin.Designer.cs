
using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Library
{
    partial class frmLogin
    {
        private System.ComponentModel.IContainer components = null;

        private Guna2Panel pnlMain;
        private Guna2Panel pnlLogin;
        private Guna2Panel pnlIcon;

        private Guna2HtmlLabel lblTieuDe;
        private Guna2HtmlLabel lblMoTa;
        private Guna2HtmlLabel lblTaiKhoan;
        private Guna2HtmlLabel lblMatKhau;
        private Guna2HtmlLabel lblFooter;

        private Guna2TextBox txtTaiKhoan;
        private Guna2TextBox txtMatKhau;

        private Guna2Button btnDangNhap;
        private Guna2Button btnThoat;
        private Guna2Button btnHienMatKhau;

        private Guna2CirclePictureBox picLogo;
        private Guna2BorderlessForm borderlessForm;
        private Guna2DragControl dragControl;

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
            components = new System.ComponentModel.Container();

            pnlMain = new Guna2Panel();
            pnlLogin = new Guna2Panel();
            pnlIcon = new Guna2Panel();

            lblTieuDe = new Guna2HtmlLabel();
            lblMoTa = new Guna2HtmlLabel();
            lblTaiKhoan = new Guna2HtmlLabel();
            lblMatKhau = new Guna2HtmlLabel();
            lblFooter = new Guna2HtmlLabel();

            txtTaiKhoan = new Guna2TextBox();
            txtMatKhau = new Guna2TextBox();

            btnDangNhap = new Guna2Button();
            btnThoat = new Guna2Button();
            btnHienMatKhau = new Guna2Button();

            picLogo = new Guna2CirclePictureBox();
            borderlessForm = new Guna2BorderlessForm(components);
            dragControl = new Guna2DragControl(components);

            pnlMain.SuspendLayout();
            pnlLogin.SuspendLayout();
            pnlIcon.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)
                picLogo).BeginInit();

            SuspendLayout();

            Color mauNen = Color.FromArgb(237, 243, 251);
            Color mauXanh = Color.FromArgb(37, 99, 235);
            Color mauXanhDam = Color.FromArgb(30, 58, 95);
            Color mauChu = Color.FromArgb(51, 65, 85);
            Color mauMo = Color.FromArgb(100, 116, 139);
            Color mauVien = Color.FromArgb(203, 213, 225);
            Color mauDo = Color.FromArgb(220, 53, 69);

            pnlMain.Name = "pnlMain";
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.FillColor = mauNen;
            pnlMain.Controls.Add(pnlLogin);

            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new Size(430, 510);
            pnlLogin.Location = new Point(235, 45);
            pnlLogin.BorderRadius = 20;
            pnlLogin.FillColor = Color.White;
            pnlLogin.ShadowDecoration.Enabled = true;
            pnlLogin.ShadowDecoration.Depth = 15;
            pnlLogin.ShadowDecoration.Color =
                Color.FromArgb(170, 185, 210);

            pnlLogin.Controls.Add(pnlIcon);
            pnlLogin.Controls.Add(lblTieuDe);
            pnlLogin.Controls.Add(lblMoTa);
            pnlLogin.Controls.Add(lblTaiKhoan);
            pnlLogin.Controls.Add(txtTaiKhoan);
            pnlLogin.Controls.Add(lblMatKhau);
            pnlLogin.Controls.Add(txtMatKhau);
            pnlLogin.Controls.Add(btnHienMatKhau);
            pnlLogin.Controls.Add(btnDangNhap);
            pnlLogin.Controls.Add(btnThoat);
            pnlLogin.Controls.Add(lblFooter);

            pnlIcon.Name = "pnlIcon";
            pnlIcon.Location = new Point(175, 25);
            pnlIcon.Size = new Size(80, 80);
            pnlIcon.BorderRadius = 40;
            pnlIcon.FillColor = Color.FromArgb(232, 241, 255);
            pnlIcon.Controls.Add(picLogo);

            picLogo.Name = "picLogo";
            picLogo.Size = new Size(54, 54);
            picLogo.Location = new Point(13, 13);
            picLogo.BackColor = Color.Transparent;
            picLogo.FillColor = mauXanh;
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;

            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Text = "QUẢN LÝ THƯ VIỆN";
            lblTieuDe.Font = new Font(
                "Segoe UI", 18F, FontStyle.Bold);
            lblTieuDe.ForeColor = mauXanhDam;
            lblTieuDe.BackColor = Color.Transparent;
            lblTieuDe.AutoSize = false;
            lblTieuDe.Size = new Size(390, 40);
            lblTieuDe.Location = new Point(20, 115);
            lblTieuDe.TextAlignment =
                ContentAlignment.MiddleCenter;

            lblMoTa.Name = "lblMoTa";
            lblMoTa.Text = "Đăng nhập vào hệ thống";
            lblMoTa.Font = new Font("Segoe UI", 10F);
            lblMoTa.ForeColor = mauMo;
            lblMoTa.BackColor = Color.Transparent;
            lblMoTa.AutoSize = false;
            lblMoTa.Size = new Size(390, 28);
            lblMoTa.Location = new Point(20, 155);
            lblMoTa.TextAlignment =
                ContentAlignment.MiddleCenter;

            lblTaiKhoan.Name = "lblTaiKhoan";
            lblTaiKhoan.Text = "Tài khoản";
            lblTaiKhoan.Font = new Font(
                "Segoe UI", 10F, FontStyle.Bold);
            lblTaiKhoan.ForeColor = mauChu;
            lblTaiKhoan.BackColor = Color.Transparent;
            lblTaiKhoan.Location = new Point(40, 205);

            txtTaiKhoan.Name = "txtTaiKhoan";
            txtTaiKhoan.Location = new Point(40, 233);
            txtTaiKhoan.Size = new Size(350, 45);
            txtTaiKhoan.BorderRadius = 9;
            txtTaiKhoan.BorderColor = mauVien;
            txtTaiKhoan.BorderThickness = 1;
            txtTaiKhoan.FillColor = Color.White;
            txtTaiKhoan.ForeColor = mauChu;
            txtTaiKhoan.Font = new Font("Segoe UI", 11F);
            txtTaiKhoan.PlaceholderText = "Nhập tài khoản";
            txtTaiKhoan.PlaceholderForeColor =
                Color.FromArgb(148, 163, 184);
            txtTaiKhoan.FocusedState.BorderColor = mauXanh;
            txtTaiKhoan.HoverState.BorderColor = mauXanh;
            txtTaiKhoan.TabIndex = 0;

            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Text = "Mật khẩu";
            lblMatKhau.Font = new Font(
                "Segoe UI", 10F, FontStyle.Bold);
            lblMatKhau.ForeColor = mauChu;
            lblMatKhau.BackColor = Color.Transparent;
            lblMatKhau.Location = new Point(40, 294);

            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Location = new Point(40, 322);
            txtMatKhau.Size = new Size(350, 45);
            txtMatKhau.BorderRadius = 9;
            txtMatKhau.BorderColor = mauVien;
            txtMatKhau.BorderThickness = 1;
            txtMatKhau.FillColor = Color.White;
            txtMatKhau.ForeColor = mauChu;
            txtMatKhau.Font = new Font("Segoe UI", 11F);
            txtMatKhau.PlaceholderText = "Nhập mật khẩu";
            txtMatKhau.PlaceholderForeColor =
                Color.FromArgb(148, 163, 184);
            txtMatKhau.UseSystemPasswordChar = true;
            txtMatKhau.FocusedState.BorderColor = mauXanh;
            txtMatKhau.HoverState.BorderColor = mauXanh;
            txtMatKhau.TabIndex = 1;

            btnHienMatKhau.Name = "btnHienMatKhau";
            btnHienMatKhau.Text = "Hiện";
            btnHienMatKhau.Location = new Point(326, 330);
            btnHienMatKhau.Size = new Size(55, 28);
            btnHienMatKhau.BorderRadius = 6;
            btnHienMatKhau.FillColor =
                Color.FromArgb(241, 245, 249);
            btnHienMatKhau.ForeColor = mauMo;
            btnHienMatKhau.Font = new Font(
                "Segoe UI", 9F, FontStyle.Bold);
            btnHienMatKhau.Cursor = Cursors.Hand;
            btnHienMatKhau.TabStop = false;
            btnHienMatKhau.BringToFront();

            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.Location = new Point(40, 397);
            btnDangNhap.Size = new Size(168, 46);
            btnDangNhap.BorderRadius = 9;
            btnDangNhap.FillColor = mauXanh;
            btnDangNhap.ForeColor = Color.White;
            btnDangNhap.Font = new Font(
                "Segoe UI", 11F, FontStyle.Bold);
            btnDangNhap.Cursor = Cursors.Hand;
            btnDangNhap.HoverState.FillColor =
                Color.FromArgb(29, 78, 216);
            btnDangNhap.TabIndex = 2;

            btnThoat.Name = "btnThoat";
            btnThoat.Text = "Thoát";
            btnThoat.Location = new Point(222, 397);
            btnThoat.Size = new Size(168, 46);
            btnThoat.BorderRadius = 9;
            btnThoat.FillColor = mauDo;
            btnThoat.ForeColor = Color.White;
            btnThoat.Font = new Font(
                "Segoe UI", 11F, FontStyle.Bold);
            btnThoat.Cursor = Cursors.Hand;
            btnThoat.HoverState.FillColor =
                Color.FromArgb(185, 28, 28);
            btnThoat.TabIndex = 3;

            lblFooter.Name = "lblFooter";
            lblFooter.Text = "Hệ thống quản lý thư viện";
            lblFooter.Font = new Font("Segoe UI", 9F);
            lblFooter.ForeColor = mauMo;
            lblFooter.BackColor = Color.Transparent;
            lblFooter.AutoSize = false;
            lblFooter.Size = new Size(390, 25);
            lblFooter.Location = new Point(20, 465);
            lblFooter.TextAlignment =
                ContentAlignment.MiddleCenter;

            borderlessForm.ContainerControl = this;
            borderlessForm.BorderRadius = 15;
            borderlessForm.TransparentWhileDrag = true;

            dragControl.TargetControl = pnlMain;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;

            ClientSize = new Size(900, 600);
            BackColor = mauNen;

            Controls.Add(pnlMain);

            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            MinimizeBox = false;

            Name = "frmLogin";
            Text = "Đăng nhập - Quản lý thư viện";

            AcceptButton = btnDangNhap;
            CancelButton = btnThoat;

            pnlMain.ResumeLayout(false);
            pnlLogin.ResumeLayout(false);
            pnlIcon.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)
                picLogo).EndInit();

            ResumeLayout(false);
        }
    }
}
