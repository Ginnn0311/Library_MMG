
using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Library
{
    public static class ThongBao
    {
        public static void ThanhCong(string noiDung, string tieuDe = "Thành công")
        {
            HienThi(noiDung, tieuDe, "success");
        }

        public static void Loi(string noiDung, string tieuDe = "Có lỗi xảy ra")
        {
            HienThi(noiDung, tieuDe, "error");
        }

        public static void CanhBao(string noiDung, string tieuDe = "Cảnh báo")
        {
            HienThi(noiDung, tieuDe, "warning");
        }

        public static void ThongTin(string noiDung, string tieuDe = "Thông tin")
        {
            HienThi(noiDung, tieuDe, "info");
        }

        public static bool XacNhan(string noiDung, string tieuDe = "Xác nhận")
        {
            return HienThi(noiDung, tieuDe, "confirm") == DialogResult.Yes;
        }

        private static DialogResult HienThi(
            string noiDung,
            string tieuDe,
            string loai)
        {
            Color mau;
            Color nenIcon;
            string kyHieu;

            switch (loai)
            {
                case "success":
                    mau = Color.FromArgb(34, 197, 94);
                    nenIcon = Color.FromArgb(220, 252, 231);
                    kyHieu = "✓";
                    break;

                case "error":
                    mau = Color.FromArgb(239, 68, 68);
                    nenIcon = Color.FromArgb(254, 226, 226);
                    kyHieu = "!";
                    break;

                case "warning":
                case "confirm":
                    mau = Color.FromArgb(245, 158, 11);
                    nenIcon = Color.FromArgb(254, 243, 199);
                    kyHieu = "?";
                    break;

                default:
                    mau = Color.FromArgb(59, 130, 246);
                    nenIcon = Color.FromArgb(219, 234, 254);
                    kyHieu = "i";
                    break;
            }

            using (Form form = new Form())
            {
                form.Text = tieuDe;
                form.StartPosition = FormStartPosition.CenterParent;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Size = new Size(430, 255);
                form.BackColor = Color.White;
                form.ShowInTaskbar = false;
                form.MaximizeBox = false;
                form.MinimizeBox = false;

                Guna2BorderlessForm borderless = new Guna2BorderlessForm();
                borderless.ContainerControl = form;
                borderless.BorderRadius = 15;
                borderless.ShadowColor = Color.Gray;

                Guna2Panel thanhTieuDe = new Guna2Panel();
                thanhTieuDe.Dock = DockStyle.Top;
                thanhTieuDe.Height = 8;
                thanhTieuDe.FillColor = mau;
                form.Controls.Add(thanhTieuDe);

                Guna2Panel vungIcon = new Guna2Panel();
                vungIcon.Size = new Size(58, 58);
                vungIcon.Location = new Point(28, 35);
                vungIcon.BorderRadius = 29;
                vungIcon.FillColor = nenIcon;

                Label lblIcon = new Label();
                lblIcon.Dock = DockStyle.Fill;
                lblIcon.Text = kyHieu;
                lblIcon.Font = new Font("Segoe UI", 25, FontStyle.Bold);
                lblIcon.ForeColor = mau;
                lblIcon.TextAlign = ContentAlignment.MiddleCenter;
                vungIcon.Controls.Add(lblIcon);
                form.Controls.Add(vungIcon);

                Label lblTieuDe = new Label();
                lblTieuDe.Text = tieuDe;
                lblTieuDe.Font = new Font("Segoe UI", 15, FontStyle.Bold);
                lblTieuDe.ForeColor = Color.FromArgb(31, 41, 55);
                lblTieuDe.Location = new Point(105, 40);
                lblTieuDe.Size = new Size(285, 32);
                form.Controls.Add(lblTieuDe);

                Label lblNoiDung = new Label();
                lblNoiDung.Text = noiDung;
                lblNoiDung.Font = new Font("Segoe UI", 10);
                lblNoiDung.ForeColor = Color.FromArgb(75, 85, 99);
                lblNoiDung.Location = new Point(105, 80);
                lblNoiDung.MaximumSize = new Size(285, 0);
                lblNoiDung.AutoSize = true;
                lblNoiDung.AutoEllipsis = false;
                form.Controls.Add(lblNoiDung);

                Guna2Button btnDong = new Guna2Button();
                btnDong.Text = loai == "confirm" ? "Đồng ý" : "Đóng";
                btnDong.Size = new Size(115, 38);
                btnDong.Location = new Point(
                    loai == "confirm" ? 165 : 285, 185);
                btnDong.BorderRadius = 8;
                btnDong.FillColor = mau;
                btnDong.ForeColor = Color.White;
                btnDong.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                btnDong.DialogResult = loai == "confirm"
                    ? DialogResult.Yes
                    : DialogResult.OK;
                form.Controls.Add(btnDong);

                if (loai == "confirm")
                {
                    Guna2Button btnHuy = new Guna2Button();
                    btnHuy.Text = "Hủy";
                    btnHuy.Size = new Size(100, 38);
                    btnHuy.Location = new Point(275, 185);
                    btnHuy.BorderRadius = 8;
                    btnHuy.FillColor = Color.FromArgb(229, 231, 235);
                    btnHuy.ForeColor = Color.FromArgb(55, 65, 81);
                    btnHuy.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    btnHuy.DialogResult = DialogResult.No;
                    form.Controls.Add(btnHuy);

                    btnDong.Location = new Point(145, 185);
                    btnHuy.Location = new Point(270, 185);
                    form.CancelButton = btnHuy;
                }

                form.AcceptButton = btnDong;

                int chieuCaoNoiDung = lblNoiDung.Height;

                int viTriNut = Math.Max(
                    185,
                    lblNoiDung.Bottom + 30
                );

                btnDong.Top = viTriNut;

                if (loai == "confirm")
                {
                    foreach (Control control in form.Controls)
                    {
                        if (control is Guna2Button button && button != btnDong)
                        {
                            button.Top = viTriNut;
                        }
                    }
                }

                form.ClientSize = new Size(
                    430,
                    viTriNut + btnDong.Height + 30
                );

                return form.ShowDialog();
            }
        }
    }
}
