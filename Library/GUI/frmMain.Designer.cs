
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Library
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;

        private Guna2Panel pnlSidebar;
        private Guna2Panel pnlMain;
        private Guna2Panel pnlHeader;
        private Guna2Panel pnlDashboard;
        private Panel pnlBody;

        private Label lblLibrary;
        private Label lblTitle;
        private Label lblSubtitle;

        private PictureBox picLogo;

        private Guna2Panel pnlTaiKhoan;
        private Guna2CirclePictureBox picAvatar;
        private Label lblTaiKhoanDangNhap;
        private Label lblVaiTroDangNhap;

        private Guna2Button btnTongQuan;
        private Guna2Button btnSach;
        private Guna2Button btnDocGia;
        private Guna2Button btnNhanVien;
        private Guna2Button btnMuonTra;
        private Guna2Button btnChiTietMuon;
        private Guna2Button btnBaoCao;
        private Guna2Button btnDangXuat;

        private Guna2Panel cardSach;
        private Guna2Panel cardDocGia;
        private Guna2Panel cardQuaHan;

        private Label lblSoSach;
        private Label lblSoDocGia;
        private Label lblSoQuaHan;
        private Label lblSapDenHan;
        private Label lblQuaHan;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            pnlSidebar = new Guna2Panel();
            pnlMain = new Guna2Panel();
            pnlHeader = new Guna2Panel();
            pnlDashboard = new Guna2Panel();
            pnlBody = new Panel();

            lblLibrary = new Label();
            lblTitle = new Label();
            lblSubtitle = new Label();

            picLogo = new PictureBox();

            pnlTaiKhoan = new Guna2Panel();
            picAvatar = new Guna2CirclePictureBox();
            lblTaiKhoanDangNhap = new Label();
            lblVaiTroDangNhap = new Label();

            btnTongQuan = new Guna2Button();
            btnSach = new Guna2Button();
            btnDocGia = new Guna2Button();
            btnNhanVien = new Guna2Button();
            btnMuonTra = new Guna2Button();
            btnChiTietMuon = new Guna2Button();
            btnBaoCao = new Guna2Button();
            btnDangXuat = new Guna2Button();

            cardSach = new Guna2Panel();
            cardDocGia = new Guna2Panel();
            cardQuaHan = new Guna2Panel();

            lblSoSach = new Label();
            lblSoDocGia = new Label();
            lblSoQuaHan = new Label();
            lblSapDenHan = new Label();
            lblQuaHan = new Label();

            ((System.ComponentModel.ISupportInitialize)
                picLogo).BeginInit();

            ((System.ComponentModel.ISupportInitialize)
                picAvatar).BeginInit();

            SuspendLayout();

            Color mauNen = Color.FromArgb(245, 247, 251);
            Color mauSidebar = Color.FromArgb(29, 67, 120);
            Color mauXanh = Color.FromArgb(37, 99, 235);
            Color mauChu = Color.FromArgb(51, 65, 85);
            Color mauMo = Color.FromArgb(100, 116, 139);

            Name = "frmMain";
            Text = "Quản lý thư viện";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(1200, 750);
            MinimumSize = new Size(950, 600);
            BackColor = mauNen;
            Font = new Font("Segoe UI", 10F);

            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Width = 275;
            pnlSidebar.FillColor = mauSidebar;
            pnlSidebar.BorderThickness = 0;

            picLogo.Name = "picLogo";
            picLogo.Location = new Point(22, 17);
            picLogo.Size = new Size(43, 43);
            picLogo.BackColor = Color.Transparent;
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.Image = TaoIconMenu("book", Color.White);

            lblLibrary.Name = "lblLibrary";
            lblLibrary.Text = "LIBRARY";
            lblLibrary.Font = new Font(
                "Segoe UI", 16F, FontStyle.Bold);
            lblLibrary.ForeColor = Color.White;
            lblLibrary.BackColor = Color.Transparent;
            lblLibrary.Location = new Point(78, 22);
            lblLibrary.Size = new Size(170, 35);

            TaoNutMenu(btnTongQuan, "Tổng quan", 115);
            TaoNutMenu(btnSach, "Quản lý sách", 165);
            TaoNutMenu(btnDocGia, "Độc giả", 215);
            TaoNutMenu(btnNhanVien, "Nhân viên", 265);
            TaoNutMenu(btnMuonTra, "Lập phiếu mượn", 315);
            TaoNutMenu(btnChiTietMuon, "Chi tiết mượn", 365);
            TaoNutMenu(btnBaoCao, "Báo cáo", 415);
            TaoNutMenu(btnDangXuat, "Đăng xuất", 475);

            btnTongQuan.Image = TaoIconMenu(
                "dashboard", Color.White);

            btnSach.Image = TaoIconMenu(
                "book", Color.White);

            btnDocGia.Image = TaoIconMenu(
                "users", Color.White);

            btnNhanVien.Image = TaoIconMenu(
                "employee", Color.White);

            btnMuonTra.Image = TaoIconMenu(
                "borrow", Color.White);

            btnChiTietMuon.Image = TaoIconMenu(
                "details", Color.White);

            btnBaoCao.Image = TaoIconMenu(
                "report", Color.White);

            btnDangXuat.Image = TaoIconMenu(
                "logout", Color.White);

            pnlSidebar.Controls.Add(picLogo);
            pnlSidebar.Controls.Add(lblLibrary);

            pnlSidebar.Controls.Add(btnTongQuan);
            pnlSidebar.Controls.Add(btnSach);
            pnlSidebar.Controls.Add(btnDocGia);
            pnlSidebar.Controls.Add(btnNhanVien);
            pnlSidebar.Controls.Add(btnMuonTra);
            pnlSidebar.Controls.Add(btnChiTietMuon);
            pnlSidebar.Controls.Add(btnBaoCao);
            pnlSidebar.Controls.Add(btnDangXuat);

            pnlHeader.Name = "pnlHeader";
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 90;
            pnlHeader.FillColor = Color.White;
            pnlHeader.BorderThickness = 0;

            lblTitle.Name = "lblTitle";
            lblTitle.Text = "Tổng quan";
            lblTitle.Font = new Font(
                "Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = mauSidebar;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Location = new Point(22, 12);
            lblTitle.Size = new Size(380, 36);
            lblTitle.AutoEllipsis = true;

            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Text = "Quản lý thư viện của bạn";
            lblSubtitle.Font = new Font("Segoe UI", 9F);
            lblSubtitle.ForeColor = mauMo;
            lblSubtitle.BackColor = Color.Transparent;
            lblSubtitle.Location = new Point(23, 51);
            lblSubtitle.Size = new Size(380, 23);

            pnlTaiKhoan.Name = "pnlTaiKhoan";
            pnlTaiKhoan.Size = new Size(290, 65);
            pnlTaiKhoan.Location = new Point(600, 12);
            pnlTaiKhoan.FillColor =
                Color.FromArgb(242, 246, 253);
            pnlTaiKhoan.BorderRadius = 12;
            pnlTaiKhoan.BorderThickness = 0;
            pnlTaiKhoan.BorderColor = Color.Transparent;

            picAvatar.Name = "picAvatar";
            picAvatar.Location = new Point(12, 9);
            picAvatar.Size = new Size(46, 46);
            picAvatar.BackColor = Color.Transparent;
            picAvatar.FillColor =
                Color.FromArgb(232, 241, 255);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.TabStop = false;

            lblTaiKhoanDangNhap.Name =
                "lblTaiKhoanDangNhap";
            lblTaiKhoanDangNhap.Text = "Nhân viên";
            lblTaiKhoanDangNhap.Font = new Font(
                "Segoe UI", 10F, FontStyle.Bold);
            lblTaiKhoanDangNhap.ForeColor = mauChu;
            lblTaiKhoanDangNhap.BackColor =
                Color.Transparent;
            lblTaiKhoanDangNhap.Location =
                new Point(68, 10);
            lblTaiKhoanDangNhap.Size =
                new Size(205, 24);
            lblTaiKhoanDangNhap.AutoEllipsis = true;

            lblVaiTroDangNhap.Name =
                "lblVaiTroDangNhap";
            lblVaiTroDangNhap.Text = "Mã NV: --";
            lblVaiTroDangNhap.Font =
                new Font("Segoe UI", 9F);
            lblVaiTroDangNhap.ForeColor = mauMo;
            lblVaiTroDangNhap.BackColor =
                Color.Transparent;
            lblVaiTroDangNhap.Location =
                new Point(68, 35);
            lblVaiTroDangNhap.Size =
                new Size(205, 22);
            lblVaiTroDangNhap.AutoEllipsis = true;

            pnlTaiKhoan.Controls.Add(picAvatar);
            pnlTaiKhoan.Controls.Add(lblTaiKhoanDangNhap);
            pnlTaiKhoan.Controls.Add(lblVaiTroDangNhap);

            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(pnlTaiKhoan);

            pnlHeader.Resize += (s, e) =>
            {
                pnlTaiKhoan.Left =
                    pnlHeader.ClientSize.Width -
                    pnlTaiKhoan.Width - 20;

                int khoangTrong =
                    pnlTaiKhoan.Left - 35;

                lblTitle.Width = Math.Max(150, khoangTrong);
                lblSubtitle.Width = Math.Max(150, khoangTrong);
            };

            pnlBody.Name = "pnlBody";
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.BackColor = mauNen;

            pnlDashboard.Name = "pnlDashboard";
            pnlDashboard.Dock = DockStyle.Fill;
            pnlDashboard.FillColor = mauNen;
            pnlDashboard.BorderThickness = 0;
            pnlDashboard.AutoScroll = true;

            TaoTheThongKe(
                cardSach, lblSoSach, "TỔNG SỐ SÁCH");

            TaoTheThongKe(
                cardDocGia, lblSoDocGia, "TỔNG SỐ ĐỘC GIẢ");

            cardSach.Location = new Point(12, 15);
            cardDocGia.Location = new Point(12, 115);

            PictureBox picSach = TaoPictureIcon(
                "book", mauXanh, 45, 45);

            picSach.Location = new Point(20, 18);
            cardSach.Controls.Add(picSach);
            picSach.BringToFront();

            PictureBox picDocGia = TaoPictureIcon(
                "users", mauXanh, 45, 45);

            picDocGia.Location = new Point(20, 18);
            cardDocGia.Controls.Add(picDocGia);
            picDocGia.BringToFront();

            cardQuaHan.Name = "cardQuaHan";
            cardQuaHan.Size = new Size(600, 160);
            cardQuaHan.Location = new Point(12, 215);
            cardQuaHan.FillColor = Color.White;
            cardQuaHan.BorderRadius = 13;
            cardQuaHan.BorderThickness = 0;
            cardQuaHan.BorderColor = Color.Transparent;

            PictureBox picPhieuMuon = TaoPictureIcon(
                "borrow", mauXanh, 34, 34);

            picPhieuMuon.Location = new Point(20, 15);

            Label lblTieuDePhieu = new Label();
            lblTieuDePhieu.Text =
                "TÌNH TRẠNG PHIẾU MƯỢN";
            lblTieuDePhieu.Font = new Font(
                "Segoe UI", 11F, FontStyle.Bold);
            lblTieuDePhieu.ForeColor = mauSidebar;
            lblTieuDePhieu.BackColor = Color.Transparent;
            lblTieuDePhieu.Location = new Point(65, 14);
            lblTieuDePhieu.Size = new Size(450, 26);

            lblSoQuaHan.Name = "lblSoQuaHan";
            lblSoQuaHan.Text =
                "Các phiếu chưa trả hết sách";
            lblSoQuaHan.Font = new Font("Segoe UI", 9F);
            lblSoQuaHan.ForeColor = mauMo;
            lblSoQuaHan.BackColor = Color.Transparent;
            lblSoQuaHan.Location = new Point(65, 42);
            lblSoQuaHan.Size = new Size(450, 22);

            Guna2Panel pnlSapDenHan = new Guna2Panel();
            pnlSapDenHan.Name = "pnlSapDenHan";
            pnlSapDenHan.FillColor =
                Color.FromArgb(255, 247, 237);
            pnlSapDenHan.BorderRadius = 10;
            pnlSapDenHan.BorderThickness = 0;
            pnlSapDenHan.Location = new Point(20, 75);
            pnlSapDenHan.Size = new Size(265, 70);

            Label lblTenSapDenHan = new Label();
            lblTenSapDenHan.Text =
                "Sắp đến hạn (3 ngày)";
            lblTenSapDenHan.Font =
                new Font("Segoe UI", 9F);
            lblTenSapDenHan.ForeColor =
                Color.FromArgb(154, 85, 20);
            lblTenSapDenHan.BackColor =
                Color.Transparent;
            lblTenSapDenHan.Location =
                new Point(12, 8);
            lblTenSapDenHan.Size =
                new Size(200, 20);

            lblSapDenHan.Name = "lblSapDenHan";
            lblSapDenHan.Text = "--";
            lblSapDenHan.Font = new Font(
                "Segoe UI", 18F, FontStyle.Bold);
            lblSapDenHan.ForeColor =
                Color.FromArgb(217, 119, 6);
            lblSapDenHan.BackColor =
                Color.Transparent;
            lblSapDenHan.Location =
                new Point(12, 30);
            lblSapDenHan.Size =
                new Size(180, 35);

            pnlSapDenHan.Controls.Add(lblTenSapDenHan);
            pnlSapDenHan.Controls.Add(lblSapDenHan);

            Guna2Panel pnlQuaHan = new Guna2Panel();
            pnlQuaHan.Name = "pnlQuaHan";
            pnlQuaHan.FillColor =
                Color.FromArgb(254, 242, 242);
            pnlQuaHan.BorderRadius = 10;
            pnlQuaHan.BorderThickness = 0;
            pnlQuaHan.Location = new Point(300, 75);
            pnlQuaHan.Size = new Size(265, 70);

            Label lblTenQuaHan = new Label();
            lblTenQuaHan.Text = "Đã quá hạn";
            lblTenQuaHan.Font =
                new Font("Segoe UI", 9F);
            lblTenQuaHan.ForeColor =
                Color.FromArgb(153, 27, 27);
            lblTenQuaHan.BackColor =
                Color.Transparent;
            lblTenQuaHan.Location =
                new Point(12, 8);
            lblTenQuaHan.Size =
                new Size(200, 20);

            lblQuaHan.Name = "lblQuaHan";
            lblQuaHan.Text = "--";
            lblQuaHan.Font = new Font(
                "Segoe UI", 18F, FontStyle.Bold);
            lblQuaHan.ForeColor =
                Color.FromArgb(220, 38, 38);
            lblQuaHan.BackColor =
                Color.Transparent;
            lblQuaHan.Location =
                new Point(12, 30);
            lblQuaHan.Size =
                new Size(180, 35);

            pnlQuaHan.Controls.Add(lblTenQuaHan);
            pnlQuaHan.Controls.Add(lblQuaHan);

            cardQuaHan.Controls.Add(picPhieuMuon);
            cardQuaHan.Controls.Add(lblTieuDePhieu);
            cardQuaHan.Controls.Add(lblSoQuaHan);
            cardQuaHan.Controls.Add(pnlSapDenHan);
            cardQuaHan.Controls.Add(pnlQuaHan);

            cardQuaHan.Resize += (s, e) =>
            {
                int width = Math.Max(
                    120,
                    (cardQuaHan.ClientSize.Width - 55) / 2);

                pnlSapDenHan.Width = width;
                pnlQuaHan.Width = width;
                pnlQuaHan.Left = pnlSapDenHan.Right + 15;
            };

            pnlDashboard.Controls.Add(cardSach);
            pnlDashboard.Controls.Add(cardDocGia);
            pnlDashboard.Controls.Add(cardQuaHan);

            pnlMain.Name = "pnlMain";
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.FillColor = mauNen;
            pnlMain.BorderThickness = 0;

            pnlMain.Controls.Add(pnlBody);
            pnlMain.Controls.Add(pnlHeader);

            Controls.Add(pnlMain);
            Controls.Add(pnlSidebar);

            ((System.ComponentModel.ISupportInitialize)
                picLogo).EndInit();

            ((System.ComponentModel.ISupportInitialize)
                picAvatar).EndInit();

            ResumeLayout(false);
        }



        private void TaoNutMenu(
            Guna2Button btn,
            string text,
            int top)
        {
            btn.Name = btn.Name;
            btn.Text = text;
            btn.Location = new Point(12, top);
            btn.Size = new Size(250, 42);

            btn.BorderRadius = 0;
            btn.BorderThickness = 0;
            btn.BorderColor = Color.Transparent;
            btn.CustomBorderThickness = new Padding(0);
            btn.CustomBorderColor = Color.Transparent;

            btn.FillColor = Color.FromArgb(43, 81, 132);
            btn.ForeColor = Color.White;
            btn.BackColor = Color.FromArgb(29, 67, 120);

            btn.Font = new Font("Segoe UI", 10F);
            btn.TextAlign = HorizontalAlignment.Left;
            btn.TextOffset = new Point(18, 0);

            btn.ImageAlign = HorizontalAlignment.Left;
            btn.ImageOffset = new Point(12, 0);
            btn.ImageSize = new Size(22, 22);

            btn.HoverState.FillColor = Color.FromArgb(59, 104, 164);
            btn.HoverState.BorderColor = Color.Transparent;
            btn.HoverState.ForeColor = Color.White;

            btn.CheckedState.FillColor = Color.FromArgb(65, 113, 176);
            btn.CheckedState.BorderColor = Color.Transparent;
            btn.CheckedState.ForeColor = Color.White;

            btn.DisabledState.BorderColor = Color.Transparent;
            btn.DisabledState.FillColor = Color.FromArgb(40, 66, 100);
            btn.DisabledState.ForeColor = Color.LightGray;

            btn.PressedColor = Color.FromArgb(71, 121, 187);
            btn.FocusedColor = Color.Transparent;

            btn.ShadowDecoration.Enabled = false;
            btn.TabStop = false;
            btn.Cursor = Cursors.Hand;
        }



        private void TaoTheThongKe(
            Guna2Panel card,
            Label lbl,
            string text)
        {
            card.Size = new Size(600, 85);
            card.FillColor = Color.White;
            card.BorderRadius = 13;
            card.BorderThickness = 0;
            card.BorderColor = Color.Transparent;

            Label lblMoTa = new Label();
            lblMoTa.Text = text;
            lblMoTa.Font = new Font(
                "Segoe UI", 9F, FontStyle.Bold);
            lblMoTa.ForeColor =
                Color.FromArgb(100, 116, 139);
            lblMoTa.BackColor = Color.Transparent;
            lblMoTa.Location = new Point(85, 14);
            lblMoTa.Size = new Size(350, 24);

            lbl.Text = "--";
            lbl.Font = new Font(
                "Segoe UI", 22F, FontStyle.Bold);
            lbl.ForeColor =
                Color.FromArgb(29, 67, 120);
            lbl.BackColor = Color.Transparent;
            lbl.Location = new Point(85, 35);
            lbl.Size = new Size(350, 43);

            card.Controls.Add(lblMoTa);
            card.Controls.Add(lbl);
        }

        private PictureBox TaoPictureIcon(
            string loai,
            Color mau,
            int width,
            int height)
        {
            PictureBox pic = new PictureBox();
            pic.Size = new Size(width, height);
            pic.Image = TaoIconMenu(loai, mau);
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.BackColor = Color.Transparent;
            pic.TabStop = false;
            return pic;
        }

        private Bitmap TaoIconMenu(string loai, Color mau)
        {
            Bitmap bitmap = new Bitmap(64, 64);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);
                g.ScaleTransform(2f, 2f);

                using (Pen pen = new Pen(mau, 2.3f))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    pen.LineJoin = LineJoin.Round;

                    switch (loai)
                    {
                        case "dashboard":
                            VeKhungBoGoc(g, pen,
                                new Rectangle(4, 4, 10, 10), 2);
                            VeKhungBoGoc(g, pen,
                                new Rectangle(18, 4, 10, 10), 2);
                            VeKhungBoGoc(g, pen,
                                new Rectangle(4, 18, 10, 10), 2);
                            VeKhungBoGoc(g, pen,
                                new Rectangle(18, 18, 10, 10), 2);
                            break;

                        case "book":
                            g.DrawLine(pen, 16, 7, 16, 27);

                            g.DrawLines(pen, new Point[]
                            {
                                new Point(16, 9),
                                new Point(11, 6),
                                new Point(3, 6),
                                new Point(3, 24),
                                new Point(11, 24),
                                new Point(16, 27)
                            });

                            g.DrawLines(pen, new Point[]
                            {
                                new Point(16, 9),
                                new Point(21, 6),
                                new Point(29, 6),
                                new Point(29, 24),
                                new Point(21, 24),
                                new Point(16, 27)
                            });
                            break;

                        case "users":
                            g.DrawEllipse(pen, 10, 4, 12, 12);
                            g.DrawArc(pen, 5, 18, 22, 15, 180, 180);
                            g.DrawArc(pen, 0, 7, 10, 10, 190, 160);
                            g.DrawArc(pen, 22, 7, 10, 10, 190, 160);
                            break;

                        case "employee":
                            VeKhungBoGoc(g, pen,
                                new Rectangle(3, 6, 26, 21), 3);

                            g.DrawEllipse(pen, 7, 11, 8, 8);
                            g.DrawArc(pen, 6, 19, 10, 8, 180, 180);
                            g.DrawLine(pen, 19, 13, 26, 13);
                            g.DrawLine(pen, 19, 18, 26, 18);
                            break;

                        case "borrow":
                            VeKhungBoGoc(g, pen,
                                new Rectangle(6, 5, 20, 24), 3);

                            g.DrawLine(pen, 12, 3, 20, 3);
                            g.DrawLine(pen, 11, 13, 21, 13);
                            g.DrawLine(pen, 11, 19, 21, 19);
                            g.DrawLine(pen, 11, 25, 18, 25);
                            break;

                        case "details":
                            VeKhungBoGoc(g, pen,
                                new Rectangle(4, 4, 24, 24), 3);

                            g.DrawLine(pen, 13, 11, 24, 11);
                            g.DrawLine(pen, 13, 21, 24, 21);

                            g.DrawLines(pen, new Point[]
                            {
                                new Point(7, 10),
                                new Point(9, 12),
                                new Point(12, 8)
                            });

                            g.DrawLines(pen, new Point[]
                            {
                                new Point(7, 20),
                                new Point(9, 22),
                                new Point(12, 18)
                            });
                            break;

                        case "report":
                            g.DrawLine(pen, 4, 28, 28, 28);
                            g.DrawRectangle(pen, 6, 17, 5, 11);
                            g.DrawRectangle(pen, 14, 11, 5, 17);
                            g.DrawRectangle(pen, 22, 5, 5, 23);
                            break;

                        case "logout":
                            g.DrawLines(pen, new Point[]
                            {
                                new Point(16, 5),
                                new Point(5, 5),
                                new Point(5, 27),
                                new Point(16, 27)
                            });

                            g.DrawLine(pen, 12, 16, 29, 16);
                            g.DrawLine(pen, 23, 10, 29, 16);
                            g.DrawLine(pen, 23, 22, 29, 16);
                            break;
                    }
                }
            }

            return bitmap;
        }

        private void VeKhungBoGoc(
            Graphics g,
            Pen pen,
            Rectangle rect,
            int radius)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                int d = radius * 2;

                path.AddArc(
                    rect.X, rect.Y, d, d, 180, 90);

                path.AddArc(
                    rect.Right - d, rect.Y, d, d, 270, 90);

                path.AddArc(
                    rect.Right - d,
                    rect.Bottom - d,
                    d, d, 0, 90);

                path.AddArc(
                    rect.X,
                    rect.Bottom - d,
                    d, d, 90, 90);

                path.CloseFigure();

                g.DrawPath(pen, path);
            }
        }
    }
}
