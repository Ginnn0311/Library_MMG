
using Library.DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace Library
{
    public partial class frmMain : Form
    {
        private Form formDangMo;
        private string vaiTroDangNhap = "";
        private int maNhanVienDangNhap;
        private string hoTenDangNhap = "";
        private bool dangDangXuat = false;

        public frmMain(
            int maNhanVien,
            string hoTen,
            string vaiTro = "Nhân viên")
        {
            InitializeComponent();

            maNhanVienDangNhap = maNhanVien;
            hoTenDangNhap = hoTen;
            vaiTroDangNhap = vaiTro;

            GanSuKien();
            PhanQuyen(vaiTroDangNhap);
            HienThiTaiKhoan();
            HienThiTongQuan();

            Load += frmMain_Load;
        }

        private bool LaQuanTriVien(string vaiTro)
        {
            return string.Equals(
                vaiTro?.Trim(),
                "Quản trị viên",
                StringComparison.OrdinalIgnoreCase);
        }

        private bool LaQuanLy(string vaiTro)
        {
            return string.Equals(
                vaiTro?.Trim(),
                "Quản lý",
                StringComparison.OrdinalIgnoreCase);
        }

        private bool CoQuyenQuanLy(string vaiTro)
        {
            return LaQuanTriVien(vaiTro) ||
                   LaQuanLy(vaiTro);
        }

        private bool CapNhatQuyenTuDatabase()
        {
            try
            {
                using (SqlConnection conn =
                    Database.GetConnection())
                {
                    const string sql = @"
                        SELECT VaiTro
                        FROM NhanVien
                        WHERE MaNhanVien = @MaNhanVien";

                    using (SqlCommand cmd =
                        new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add(
                            "@MaNhanVien",
                            SqlDbType.Int).Value =
                            maNhanVienDangNhap;

                        conn.Open();

                        object ketQua = cmd.ExecuteScalar();

                        if (ketQua == null ||
                            ketQua == DBNull.Value)
                        {
                            vaiTroDangNhap = "";
                            PhanQuyen(vaiTroDangNhap);

                            ThongBao.CanhBao(
                                "Tài khoản đăng nhập " +
                                "không còn tồn tại!");

                            return false;
                        }

                        vaiTroDangNhap =
                            Convert.ToString(ketQua)?.Trim()
                            ?? "";

                        PhanQuyen(vaiTroDangNhap);

                        lblVaiTroDangNhap.Text =
                            "Mã NV: " + maNhanVienDangNhap +
                            " | " + vaiTroDangNhap;

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                vaiTroDangNhap = "";
                PhanQuyen(vaiTroDangNhap);

                ThongBao.Loi(
                    "Không thể kiểm tra quyền tài khoản:\n" +
                    ex.Message);

                return false;
            }
        }

        private bool KiemTraQuyenQuanLyNhanVien()
        {
            if (!CapNhatQuyenTuDatabase())
                return false;

            if (!CoQuyenQuanLy(vaiTroDangNhap))
            {
                ThongBao.CanhBao(
                    "Bạn không có quyền quản lý nhân viên!");

                return false;
            }

            return true;
        }

        private bool KiemTraQuyenBaoCao()
        {
            if (!CapNhatQuyenTuDatabase())
                return false;

            if (!CoQuyenQuanLy(vaiTroDangNhap))
            {
                ThongBao.CanhBao(
                    "Bạn không có quyền xem báo cáo!");

                return false;
            }

            return true;
        }

        private void GanSuKien()
        {
            btnTongQuan.Click += (s, e) =>
            {
                DanhDauMenu(btnTongQuan);
                HienThiTongQuan();
            };

            btnSach.Click += (s, e) =>
            {
                DanhDauMenu(btnSach);
                MoForm(new frmSach());
            };

            btnDocGia.Click += (s, e) =>
            {
                DanhDauMenu(btnDocGia);
                MoForm(new frmDocGia());
            };

            btnMuonTra.Click += (s, e) =>
            {
                DanhDauMenu(btnMuonTra);

                MoForm(new frmPhieuMuon(
                    maNhanVienDangNhap,
                    hoTenDangNhap));
            };

            btnChiTietMuon.Click += (s, e) =>
            {
                DanhDauMenu(btnChiTietMuon);
                MoForm(new frmChiTietMuon());
            };

            btnNhanVien.Click += (s, e) =>
            {
                if (!KiemTraQuyenQuanLyNhanVien())
                    return;

                DanhDauMenu(btnNhanVien);

                MoForm(new frmNhanVien(
                    maNhanVienDangNhap));
            };

            btnBaoCao.Click += (s, e) =>
            {
                MoBaoCao();
            };

            btnDangXuat.Click +=
                thoátToolStripMenuItem_Click;

            pnlDashboard.Resize += (s, e) =>
                CanChinhDashboard();

            DanhDauMenu(btnTongQuan);
        }

        public void PhanQuyen(string vaiTro)
        {
            bool duocQuanLy =
                CoQuyenQuanLy(vaiTro);

            btnNhanVien.Enabled = duocQuanLy;
            btnBaoCao.Enabled = duocQuanLy;

            btnNhanVien.Visible = true;
            btnBaoCao.Visible = true;

            btnNhanVien.DisabledState.FillColor =
                Color.FromArgb(80, 95, 115);

            btnNhanVien.DisabledState.ForeColor =
                Color.LightGray;

            btnBaoCao.DisabledState.FillColor =
                Color.FromArgb(80, 95, 115);

            btnBaoCao.DisabledState.ForeColor =
                Color.LightGray;
        }

        private void CanChinhDashboard()
        {
            int width = Math.Max(
                300,
                pnlDashboard.ClientSize.Width - 24);

            cardSach.Width = width;
            cardDocGia.Width = width;
            cardQuaHan.Width = width;
        }

        private void HienThiTaiKhoan()
        {
            lblTaiKhoanDangNhap.Text =
                string.IsNullOrWhiteSpace(hoTenDangNhap)
                    ? "Chưa xác định"
                    : hoTenDangNhap;

            lblVaiTroDangNhap.Text =
                "Mã NV: " + maNhanVienDangNhap +
                " | " + vaiTroDangNhap;

            TaiAnhDaiDien();
        }

        private void TaiAnhDaiDien()
        {
            Image anh = null;

            try
            {
                using (SqlConnection conn =
                    Database.GetConnection())
                {
                    conn.Open();

                    string sqlCot = @"
                        SELECT TOP 1 COLUMN_NAME
                        FROM INFORMATION_SCHEMA.COLUMNS
                        WHERE TABLE_SCHEMA = 'dbo'
                          AND TABLE_NAME = 'NhanVien'
                          AND COLUMN_NAME IN
                          (
                              'AnhDaiDien',
                              'HinhAnh',
                              'AnhNhanVien'
                          )
                        ORDER BY CASE COLUMN_NAME
                            WHEN 'AnhDaiDien' THEN 1
                            WHEN 'HinhAnh' THEN 2
                            ELSE 3
                        END";

                    string tenCot;

                    using (SqlCommand cmd =
                        new SqlCommand(sqlCot, conn))
                    {
                        tenCot =
                            Convert.ToString(
                                cmd.ExecuteScalar()) ?? "";
                    }

                    if (!string.IsNullOrEmpty(tenCot))
                    {
                        string sql =
                            "SELECT [" + tenCot + "] " +
                            "FROM dbo.NhanVien " +
                            "WHERE MaNhanVien = @MaNhanVien";

                        using (SqlCommand cmd =
                            new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.Add(
                                "@MaNhanVien",
                                SqlDbType.Int).Value =
                                maNhanVienDangNhap;

                            object giaTri =
                                cmd.ExecuteScalar();

                            if (giaTri is byte[] duLieuAnh &&
                                duLieuAnh.Length > 0)
                            {
                                using (MemoryStream ms =
                                    new MemoryStream(duLieuAnh))
                                using (Image anhGoc =
                                    Image.FromStream(ms))
                                {
                                    anh = new Bitmap(anhGoc);
                                }
                            }
                            else if (
                                giaTri is string duongDan &&
                                File.Exists(duongDan))
                            {
                                using (Image anhGoc =
                                    Image.FromFile(duongDan))
                                {
                                    anh = new Bitmap(anhGoc);
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                anh?.Dispose();
                anh = null;
            }

            if (anh == null)
                anh = TaoAvatarMacDinh();

            Image anhCu = picAvatar.Image;
            picAvatar.Image = anh;
            anhCu?.Dispose();
        }

        private Image TaoAvatarMacDinh()
        {
            Bitmap bitmap = new Bitmap(100, 100);

            using (Graphics g =
                Graphics.FromImage(bitmap))
            {
                g.SmoothingMode =
                    SmoothingMode.AntiAlias;

                g.Clear(Color.Transparent);

                using (SolidBrush nen =
                    new SolidBrush(
                        Color.FromArgb(37, 99, 235)))
                {
                    g.FillEllipse(nen, 0, 0, 99, 99);
                }

                string chu = "NV";

                if (!string.IsNullOrWhiteSpace(
                    hoTenDangNhap))
                {
                    string[] cacTu =
                        hoTenDangNhap.Trim().Split(
                            ' ',
                            StringSplitOptions
                                .RemoveEmptyEntries);

                    if (cacTu.Length >= 2)
                    {
                        chu = (
                            cacTu[cacTu.Length - 2][0]
                                .ToString() +
                            cacTu[cacTu.Length - 1][0]
                                .ToString()
                        ).ToUpper();
                    }
                    else if (cacTu.Length == 1)
                    {
                        chu = cacTu[0].Substring(
                            0,
                            Math.Min(
                                2,
                                cacTu[0].Length)
                        ).ToUpper();
                    }
                }

                using (Font font = new Font(
                    "Segoe UI",
                    27F,
                    FontStyle.Bold))
                using (SolidBrush mauChu =
                    new SolidBrush(Color.White))
                using (StringFormat format =
                    new StringFormat())
                {
                    format.Alignment =
                        StringAlignment.Center;

                    format.LineAlignment =
                        StringAlignment.Center;

                    g.DrawString(
                        chu,
                        font,
                        mauChu,
                        new RectangleF(
                            0, 0, 100, 100),
                        format);
                }
            }

            return bitmap;
        }

        private void HienThiTongQuan()
        {
            DongFormDangMo();

            pnlBody.Controls.Clear();

            lblTitle.Text = "Tổng quan";
            lblSubtitle.Text =
                "Quản lý thư viện của bạn";

            pnlBody.Controls.Add(pnlDashboard);

            pnlDashboard.Visible = true;
            pnlDashboard.BringToFront();

            CanChinhDashboard();
            CapNhatThongKe();
        }

        private void MoForm(Form frm)
        {
            if (frm == null)
                return;

            DongFormDangMo();

            pnlBody.Controls.Clear();

            lblTitle.Text = frm.Text;
            lblSubtitle.Text =
                "Hệ thống quản lý thư viện";

            frm.TopLevel = false;
            frm.FormBorderStyle =
                FormBorderStyle.None;

            frm.Dock = DockStyle.Fill;
            frm.StartPosition =
                FormStartPosition.Manual;

            formDangMo = frm;

            pnlBody.Controls.Add(frm);

            frm.Show();
            frm.BringToFront();
        }

        private void DongFormDangMo()
        {
            if (formDangMo != null)
            {
                Form formCu = formDangMo;
                formDangMo = null;

                pnlBody.Controls.Remove(formCu);

                formCu.Close();
                formCu.Dispose();
            }
        }

        private void CapNhatThongKe()
        {
            try
            {
                using (SqlConnection conn =
                    Database.GetConnection())
                {
                    conn.Open();

                    using (SqlCommand cmd =
                        new SqlCommand(
                            "SELECT COUNT(*) FROM Sach",
                            conn))
                    {
                        lblSoSach.Text =
                            Convert.ToInt32(
                                cmd.ExecuteScalar())
                            .ToString();
                    }

                    using (SqlCommand cmd =
                        new SqlCommand(
                            "SELECT COUNT(*) FROM DocGia",
                            conn))
                    {
                        lblSoDocGia.Text =
                            Convert.ToInt32(
                                cmd.ExecuteScalar())
                            .ToString();
                    }

                    string sql = @"
                        SELECT
                            COUNT(CASE
                                WHEN pm.HanTra >=
                                    CONVERT(DATE, GETDATE())
                                 AND pm.HanTra <=
                                    DATEADD(
                                        DAY,
                                        3,
                                        CONVERT(
                                            DATE,
                                            GETDATE()))
                                THEN 1
                            END) AS SapDenHan,

                            COUNT(CASE
                                WHEN pm.HanTra <
                                    CONVERT(DATE, GETDATE())
                                THEN 1
                            END) AS QuaHan

                        FROM PhieuMuon pm

                        WHERE EXISTS
                        (
                            SELECT 1
                            FROM ChiTietMuon ct
                            WHERE ct.MaPhieuMuon =
                                pm.MaPhieuMuon
                              AND ct.NgayTra IS NULL
                        )";

                    using (SqlCommand cmd =
                        new SqlCommand(sql, conn))
                    using (SqlDataReader reader =
                        cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblSapDenHan.Text =
                                Convert.ToInt32(
                                    reader["SapDenHan"])
                                .ToString();

                            lblQuaHan.Text =
                                Convert.ToInt32(
                                    reader["QuaHan"])
                                .ToString();
                        }
                    }

                    lblSoQuaHan.Text =
                        "Các phiếu chưa trả hết sách";
                }
            }
            catch (Exception ex)
            {
                lblSoSach.Text = "--";
                lblSoDocGia.Text = "--";
                lblSapDenHan.Text = "--";
                lblQuaHan.Text = "--";

                ThongBao.Loi(
                    "Không thể tải dữ liệu thống kê:\n" +
                    ex.Message);
            }
        }

        private void MoBaoCao()
        {
            if (!KiemTraQuyenBaoCao())
                return;

            DanhDauMenu(btnBaoCao);

            MoForm(new frmBaoCao());
        }

        private void frmMain_Load(
            object sender,
            EventArgs e)
        {
            CanChinhDashboard();
            CapNhatThongKe();
        }

        private void thoátToolStripMenuItem_Click(
            object sender,
            EventArgs e)
        {
            if (dangDangXuat)
                return;

            dangDangXuat = true;

            DongFormDangMo();
            Hide();

            try
            {
                using (frmLogin login =
                    new frmLogin())
                {
                    if (login.ShowDialog() ==
                        DialogResult.OK)
                    {
                        maNhanVienDangNhap =
                            login.MaNhanVienDangNhap;

                        hoTenDangNhap =
                            login.HoTenDangNhap;

                        vaiTroDangNhap =
                            login.VaiTroDangNhap;

                        PhanQuyen(vaiTroDangNhap);
                        HienThiTaiKhoan();

                        Show();
                        HienThiTongQuan();
                        Activate();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
            finally
            {
                dangDangXuat = false;
            }
        }

        private void DanhDauMenu(
            Guna.UI2.WinForms.Guna2Button nutDangChon)
        {
            Guna.UI2.WinForms.Guna2Button[] danhSachNut =
            {
                btnTongQuan,
                btnSach,
                btnDocGia,
                btnNhanVien,
                btnMuonTra,
                btnChiTietMuon,
                btnBaoCao
            };

            foreach (var nut in danhSachNut)
            {
                nut.FillColor =
                    Color.FromArgb(43, 81, 132);

                nut.BorderThickness = 0;
            }

            nutDangChon.FillColor =
                Color.FromArgb(65, 113, 176);

            nutDangChon.BorderThickness = 0;
        }

        private void chiTietMuonToolStripMenuItem_Click(
            object sender,
            EventArgs e)
        {
            using (frmChiTietMuon frm =
                new frmChiTietMuon())
            {
                frm.ShowDialog();
            }
        }
    }
}
