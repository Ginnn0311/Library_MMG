
using Library.DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Net.Mail;
using System.Windows.Forms;

namespace Library
{
    public partial class frmSachQuaHan : Form
    {
        private const decimal MucPhat = 5000m;

        public frmSachQuaHan()
        {
            InitializeComponent();
        }

        private void frmSachQuaHan_Load(object sender, EventArgs e)
        {
            LoadSachQuaHan();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadSachQuaHan();
        }

        private void LoadSachQuaHan()
        {
            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    string sql = @"
                        SELECT
                            ct.MaChiTiet,
                            pm.MaPhieuMuon,
                            dg.HoTen AS TenDocGia,
                            dg.Email,
                            s.TenSach,
                            ct.SoLuong,
                            pm.NgayMuon,
                            pm.HanTra,
                            DATEDIFF(
                                DAY,
                                CAST(pm.HanTra AS DATE),
                                CAST(GETDATE() AS DATE)
                            ) AS SoNgayTre
                        FROM ChiTietMuon ct
                        INNER JOIN PhieuMuon pm
                            ON ct.MaPhieuMuon = pm.MaPhieuMuon
                        INNER JOIN DocGia dg
                            ON pm.MaDocGia = dg.MaDocGia
                        INNER JOIN Sach s
                            ON ct.MaSach = s.MaSach
                        WHERE ct.TrangThai = N'Đang mượn'
                          AND ct.NgayTra IS NULL
                          AND CAST(pm.HanTra AS DATE)
                              < CAST(GETDATE() AS DATE)
                        ORDER BY pm.HanTra ASC";

                    DataTable dt = new DataTable();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }

                    dt.Columns.Add("TienPhat", typeof(decimal));

                    foreach (DataRow row in dt.Rows)
                    {
                        int soNgayTre = Convert.ToInt32(
                            row["SoNgayTre"]);

                        int soLuong = Convert.ToInt32(
                            row["SoLuong"]);

                        row["TienPhat"] =
                            soNgayTre * soLuong * MucPhat;
                    }

                    dgvQuaHan.DataSource = null;
                    dgvQuaHan.Columns.Clear();
                    dgvQuaHan.DataSource = dt;

                    DinhDangBang();

                    lblTongSo.Text =
                        "Tổng số chi tiết mượn quá hạn: " +
                        dt.Rows.Count;
                }
            }
            catch (Exception ex)
            {
                ThongBao.Loi(
                    "Không thể tải danh sách quá hạn!\n" +
                    ex.Message);
            }
        }

        private void DinhDangBang()
        {
            if (dgvQuaHan.Columns.Count == 0)
                return;

            dgvQuaHan.Columns["MaChiTiet"].Visible = false;

            dgvQuaHan.Columns["MaPhieuMuon"].HeaderText =
                "Mã phiếu";

            dgvQuaHan.Columns["TenDocGia"].HeaderText =
                "Tên độc giả";

            dgvQuaHan.Columns["Email"].HeaderText =
                "Email";

            dgvQuaHan.Columns["TenSach"].HeaderText =
                "Tên sách";

            dgvQuaHan.Columns["SoLuong"].HeaderText =
                "Số lượng";

            dgvQuaHan.Columns["NgayMuon"].HeaderText =
                "Ngày mượn";

            dgvQuaHan.Columns["HanTra"].HeaderText =
                "Hạn trả";

            dgvQuaHan.Columns["SoNgayTre"].HeaderText =
                "Số ngày trễ";

            dgvQuaHan.Columns["TienPhat"].HeaderText =
                "Tiền phạt dự kiến";

            dgvQuaHan.Columns["NgayMuon"].DefaultCellStyle.Format =
                "dd/MM/yyyy";

            dgvQuaHan.Columns["HanTra"].DefaultCellStyle.Format =
                "dd/MM/yyyy";

            dgvQuaHan.Columns["TienPhat"].DefaultCellStyle.Format =
                "N0";

            dgvQuaHan.Columns["TienPhat"].DefaultCellStyle.ForeColor =
                Color.FromArgb(220, 53, 69);

            dgvQuaHan.Columns["TienPhat"].DefaultCellStyle.Font =
                new Font("Segoe UI", 9, FontStyle.Bold);

            dgvQuaHan.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(100, 88, 255);

            dgvQuaHan.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvQuaHan.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dgvQuaHan.EnableHeadersVisualStyles = false;

            dgvQuaHan.DefaultCellStyle.Font =
                new Font("Segoe UI", 9);

            DataGridViewButtonColumn btnGmail =
                new DataGridViewButtonColumn
                {
                    Name = "GuiGmail",
                    HeaderText = "Thông báo",
                    Text = "Gửi Gmail",
                    UseColumnTextForButtonValue = true,
                    Width = 110,
                    AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.None,
                    FlatStyle = FlatStyle.Flat
                };

            dgvQuaHan.Columns.Add(btnGmail);
        }

        private void dgvQuaHan_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dgvQuaHan.Columns[e.ColumnIndex].Name != "GuiGmail")
                return;

            int maChiTiet = Convert.ToInt32(
                dgvQuaHan.Rows[e.RowIndex]
                .Cells["MaChiTiet"].Value);

            SoanGmail(maChiTiet);
        }

        private void SoanGmail(int maChiTiet)
        {
            try
            {
                string tenDocGia;
                string email;
                string tenSach;
                int soLuong;
                int maPhieu;
                DateTime ngayMuon;
                DateTime hanTra;
                int soNgayTre;

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    string sql = @"
                        SELECT
                            pm.MaPhieuMuon,
                            dg.HoTen,
                            dg.Email,
                            s.TenSach,
                            ct.SoLuong,
                            pm.NgayMuon,
                            pm.HanTra,
                            DATEDIFF(
                                DAY,
                                CAST(pm.HanTra AS DATE),
                                CAST(GETDATE() AS DATE)
                            ) AS SoNgayTre
                        FROM ChiTietMuon ct
                        INNER JOIN PhieuMuon pm
                            ON ct.MaPhieuMuon = pm.MaPhieuMuon
                        INNER JOIN DocGia dg
                            ON pm.MaDocGia = dg.MaDocGia
                        INNER JOIN Sach s
                            ON ct.MaSach = s.MaSach
                        WHERE ct.MaChiTiet = @MaChiTiet
                          AND ct.TrangThai = N'Đang mượn'
                          AND ct.NgayTra IS NULL
                          AND CAST(pm.HanTra AS DATE)
                              < CAST(GETDATE() AS DATE)";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add(
                            "@MaChiTiet", SqlDbType.Int)
                            .Value = maChiTiet;

                        using (SqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                ThongBao.CanhBao(
                                    "Sách không còn trong danh sách quá hạn!");
                                return;
                            }

                            maPhieu = Convert.ToInt32(
                                reader["MaPhieuMuon"]);

                            tenDocGia = Convert.ToString(
                                reader["HoTen"]) ?? "";

                            email = Convert.ToString(
                                reader["Email"]) ?? "";

                            tenSach = Convert.ToString(
                                reader["TenSach"]) ?? "";

                            soLuong = Convert.ToInt32(
                                reader["SoLuong"]);

                            ngayMuon = Convert.ToDateTime(
                                reader["NgayMuon"]);

                            hanTra = Convert.ToDateTime(
                                reader["HanTra"]);

                            soNgayTre = Convert.ToInt32(
                                reader["SoNgayTre"]);
                        }
                    }
                }

                if (string.IsNullOrWhiteSpace(email))
                {
                    ThongBao.CanhBao(
                        $"Độc giả {tenDocGia} chưa có email!");
                    return;
                }

                email = email.Trim();

                try
                {
                    MailAddress diaChi = new MailAddress(email);

                    if (!string.Equals(
                        diaChi.Address,
                        email,
                        StringComparison.OrdinalIgnoreCase))
                    {
                        throw new FormatException();
                    }
                }
                catch
                {
                    ThongBao.CanhBao(
                        "Email độc giả không hợp lệ!");
                    return;
                }

                decimal tienPhat =
                    soNgayTre * soLuong * MucPhat;

                string tieuDe =
                    "Thông báo sách quá hạn - Phiếu mượn " +
                    maPhieu;

                string noiDung =
                    $"Kính gửi {tenDocGia},\n\n" +
                    "Thư viện xin thông báo bạn đang có sách " +
                    "mượn quá hạn chưa được hoàn trả.\n\n" +

                    "THÔNG TIN MƯỢN SÁCH\n" +
                    $"Họ tên độc giả: {tenDocGia}\n" +
                    $"Mã phiếu mượn: {maPhieu}\n" +
                    $"Tên sách: {tenSach}\n" +
                    $"Số lượng: {soLuong}\n" +
                    $"Ngày mượn: {ngayMuon:dd/MM/yyyy}\n" +
                    $"Hạn trả: {hanTra:dd/MM/yyyy}\n" +
                    $"Số ngày quá hạn: {soNgayTre} ngày\n\n" +

                    "THÔNG TIN TIỀN PHẠT DỰ KIẾN\n" +
                    $"Mức phạt: {MucPhat:N0} VNĐ/ngày/quyển\n" +
                    $"Tổng tiền phạt: {tienPhat:N0} VNĐ\n\n" +

                    "Vui lòng đến thư viện để hoàn trả sách " +
                    "trong thời gian sớm nhất.\n" +
                    "Tiền phạt có thể tiếp tục tăng " +
                    "nếu chưa trả sách.\n\n" +

                    "Trân trọng,\n" +
                    "HỆ THỐNG QUẢN LÝ THƯ VIỆN";

                string url =
                    "https://mail.google.com/mail/?view=cm&fs=1" +
                    "&to=" + Uri.EscapeDataString(email) +
                    "&su=" + Uri.EscapeDataString(tieuDe) +
                    "&body=" + Uri.EscapeDataString(noiDung);

                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                ThongBao.Loi(
                    "Không thể soạn Gmail!\n" + ex.Message);
            }
        }
    }
}
