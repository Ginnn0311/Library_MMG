
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;
using Library.DTO;
using Microsoft.Data.SqlClient;

namespace Library
{
    public partial class frmDocGia : Form
    {
        private readonly DocGiaBLL docGiaBLL = new DocGiaBLL();

        public frmDocGia()
        {
            InitializeComponent();

            Load += frmDocGia_Load;

            cbTimTheo.Items.Clear();
            cbTimTheo.Items.Add("Mã độc giả");
            cbTimTheo.Items.Add("Họ tên");
            cbTimTheo.Items.Add("Số điện thoại");
            cbTimTheo.Items.Add("Địa chỉ");
            cbTimTheo.Items.Add("Giới tính");
            cbTimTheo.Items.Add("Email");
            cbTimTheo.SelectedIndex = 0;

            toolStripTextBox1.TextChanged +=
                txtTimKiem_TextChanged;

            toolStripTextBox1.KeyDown +=
                txtTimKiem_KeyDown;

            cbTimTheo.SelectedIndexChanged +=
                cboTimTheo_SelectedIndexChanged;

            toolStripButton1.Click += btnTimKiem_Click;
            btnGiaHan.Click += btnGiaHan_Click;
        }

        private void frmDocGia_Load(object sender, EventArgs e)
        {
            dgvDocGia.Dock = DockStyle.Fill;

            dgvDocGia.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.None;

            dgvDocGia.ScrollBars = ScrollBars.Both;
            dgvDocGia.RowHeadersVisible = false;
            dgvDocGia.AllowUserToAddRows = false;
            dgvDocGia.AllowUserToDeleteRows = false;

            dgvDocGia.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvDocGia.MultiSelect = false;
            dgvDocGia.ReadOnly = true;

            dgvDocGia.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvDocGia.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvDocGia.Columns["Column3"]
                .DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvDocGia.Columns["colNgayDangKy"]
                .DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvDocGia.Columns["colNgayHetHan"]
                .DefaultCellStyle.Format = "dd/MM/yyyy";

            HienThiDanhSach();
        }

        private DocGia LayThongTinTuForm(frmThemDocGia frm)
        {
            return new DocGia
            {
                MaDocGia = frm.MaDocGia?.Trim() ?? "",
                HoTen = frm.HoTen?.Trim() ?? "",
                NgaySinh = frm.NgaySinh,
                SoDienThoai = frm.SoDienThoai?.Trim() ?? "",
                DiaChi = frm.DiaChi?.Trim() ?? "",
                GioiTinh = frm.GioiTinh?.Trim() ?? "",
                Email = frm.Email?.Trim() ?? ""
            };
        }

        private bool KiemTraDuLieu(DocGia docGia)
        {
            if (!int.TryParse(docGia.MaDocGia, out int ma)
                || ma <= 0)
            {
                ThongBao.CanhBao(
                    "Mã độc giả phải là số nguyên dương.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(docGia.HoTen))
            {
                ThongBao.CanhBao(
                    "Vui lòng nhập họ tên độc giả.");
                return false;
            }

            if (docGia.NgaySinh == DateTime.MinValue
                || docGia.NgaySinh.Date > DateTime.Today)
            {
                ThongBao.CanhBao(
                    "Ngày sinh không hợp lệ.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(docGia.SoDienThoai))
            {
                ThongBao.CanhBao(
                    "Vui lòng nhập số điện thoại.");
                return false;
            }

            string soDienThoai = docGia.SoDienThoai;

            if (soDienThoai.Length != 10 ||
                soDienThoai[0] != '0' ||
                !soDienThoai.All(char.IsDigit))
            {
                ThongBao.CanhBao(
                    "Số điện thoại phải gồm 10 chữ số và bắt đầu bằng 0.");
                return false;
            }

            if (!string.IsNullOrWhiteSpace(docGia.Email))
            {
                try
                {
                    MailAddress diaChiEmail =
                        new MailAddress(docGia.Email);

                    if (!string.Equals(
                        diaChiEmail.Address,
                        docGia.Email,
                        StringComparison.OrdinalIgnoreCase))
                    {
                        ThongBao.CanhBao(
                            "Địa chỉ email không hợp lệ.");
                        return false;
                    }
                }
                catch
                {
                    ThongBao.CanhBao(
                        "Địa chỉ email không hợp lệ.");
                    return false;
                }
            }

            return true;
        }

        private bool KiemTraTrungSoDienThoai(DocGia docGia)
        {
            using (SqlConnection conn =
                Database.GetConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT COUNT(*)
                    FROM dbo.DocGia
                    WHERE LTRIM(RTRIM(SoDienThoai))
                        = @SoDienThoai
                      AND MaDocGia <> @MaDocGia";

                using (SqlCommand cmd =
                    new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(
                        "@SoDienThoai",
                        SqlDbType.NVarChar,
                        30).Value = docGia.SoDienThoai;

                    cmd.Parameters.Add(
                        "@MaDocGia",
                        SqlDbType.Int).Value =
                        Convert.ToInt32(docGia.MaDocGia);

                    return Convert.ToInt32(
                        cmd.ExecuteScalar()) > 0;
                }
            }
        }

        private bool CoSachChuaTra(string maDocGia)
        {
            using (SqlConnection conn =
                Database.GetConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT CASE
                        WHEN EXISTS
                        (
                            SELECT 1
                            FROM dbo.PhieuMuon pm
                            INNER JOIN dbo.ChiTietMuon ct
                                ON ct.MaPhieuMuon = pm.MaPhieuMuon
                            WHERE pm.MaDocGia = @MaDocGia
                              AND ct.NgayTra IS NULL
                        )
                        THEN 1
                        ELSE 0
                    END";

                using (SqlCommand cmd =
                    new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(
                        "@MaDocGia",
                        SqlDbType.Int).Value =
                        Convert.ToInt32(maDocGia);

                    return Convert.ToInt32(
                        cmd.ExecuteScalar()) == 1;
                }
            }
        }

        private DataGridViewRow LayDongDangChon()
        {
            if (dgvDocGia.SelectedRows.Count == 0)
                return null;

            DataGridViewRow row =
                dgvDocGia.SelectedRows[0];

            if (row.IsNewRow)
                return null;

            return row;
        }

        private string LayMaDocGia(DataGridViewRow row)
        {
            return Convert.ToString(
                row.Cells["Column1"].Value) ?? "";
        }

        private void ChonLaiDocGia(string maDocGia)
        {
            if (string.IsNullOrWhiteSpace(maDocGia))
                return;

            dgvDocGia.ClearSelection();

            foreach (DataGridViewRow row in dgvDocGia.Rows)
            {
                string ma = LayMaDocGia(row);

                if (ma == maDocGia)
                {
                    row.Selected = true;

                    if (row.Index >= 0)
                    {
                        dgvDocGia.FirstDisplayedScrollingRowIndex =
                            row.Index;
                    }

                    break;
                }
            }
        }

        private void LamMoiDanhSach(string maDocGia = "")
        {
            if (string.IsNullOrWhiteSpace(
                toolStripTextBox1.Text))
            {
                HienThiDanhSach();
            }
            else
            {
                TimKiemDocGia();
            }

            ChonLaiDocGia(maDocGia);
        }

        private void btnThemDocGia_Click(
            object sender, EventArgs e)
        {
            using (frmThemDocGia frm = new frmThemDocGia
            {
                Text = "Thêm độc giả",
                MaDocGiaEditable = true
            })
            {
                if (frm.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    DocGia docGia = LayThongTinTuForm(frm);

                    if (!KiemTraDuLieu(docGia))
                        return;

                    if (KiemTraTrungSoDienThoai(docGia))
                    {
                        ThongBao.CanhBao(
                            "Số điện thoại này đã được sử dụng bởi độc giả khác.");
                        return;
                    }

                    docGiaBLL.ThemDocGia(docGia);

                    LamMoiDanhSach(docGia.MaDocGia);

                    ThongBao.ThanhCong(
                        "Thêm độc giả thành công!\n" +
                        "Thẻ có thời hạn 3 tháng kể từ ngày đăng ký.");
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2601 || ex.Number == 2627)
                    {
                        ThongBao.CanhBao(
                            "Mã độc giả hoặc thông tin đã tồn tại.");
                    }
                    else
                    {
                        ThongBao.Loi(
                            "Lỗi thêm độc giả:\n" + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    ThongBao.Loi(
                        "Lỗi thêm độc giả:\n" + ex.Message);
                }
            }
        }

        private void btnSuaDocGia_Click(
            object sender, EventArgs e)
        {
            DataGridViewRow row = LayDongDangChon();

            if (row == null)
            {
                ThongBao.CanhBao(
                    "Vui lòng chọn độc giả cần sửa.");
                return;
            }

            DateTime ngaySinh;

            if (!DateTime.TryParse(
                Convert.ToString(
                    row.Cells["Column3"].Value),
                out ngaySinh))
            {
                ThongBao.CanhBao(
                    "Ngày sinh của độc giả không hợp lệ.");
                return;
            }

            using (frmThemDocGia frm = new frmThemDocGia
            {
                Text = "Sửa độc giả",

                MaDocGia = LayMaDocGia(row),

                MaDocGiaEditable = false,

                HoTen = Convert.ToString(
                    row.Cells["Column2"].Value) ?? "",

                NgaySinh = ngaySinh,

                SoDienThoai = Convert.ToString(
                    row.Cells["Column4"].Value) ?? "",

                DiaChi = Convert.ToString(
                    row.Cells["dgvNhaXuatBan"].Value) ?? "",

                GioiTinh = Convert.ToString(
                    row.Cells["Column5"].Value) ?? "",

                Email = Convert.ToString(
                    row.Cells["Column6"].Value) ?? ""
            })
            {
                if (frm.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    DocGia docGia = LayThongTinTuForm(frm);

                    if (!KiemTraDuLieu(docGia))
                        return;

                    if (KiemTraTrungSoDienThoai(docGia))
                    {
                        ThongBao.CanhBao(
                            "Số điện thoại này đã được sử dụng bởi độc giả khác.");
                        return;
                    }

                    docGiaBLL.SuaDocGia(docGia);

                    LamMoiDanhSach(docGia.MaDocGia);

                    ThongBao.ThanhCong(
                        "Sửa độc giả thành công!");
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2601 || ex.Number == 2627)
                    {
                        ThongBao.CanhBao(
                            "Thông tin độc giả bị trùng.");
                    }
                    else
                    {
                        ThongBao.Loi(
                            "Lỗi sửa độc giả:\n" + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    ThongBao.Loi(
                        "Lỗi sửa độc giả:\n" + ex.Message);
                }
            }
        }

        private void btnXoaDocGia_Click(
            object sender, EventArgs e)
        {
            DataGridViewRow row = LayDongDangChon();

            if (row == null)
            {
                ThongBao.CanhBao(
                    "Vui lòng chọn độc giả cần xóa.");
                return;
            }

            string maDocGia = LayMaDocGia(row);

            string hoTen = Convert.ToString(
                row.Cells["Column2"].Value) ?? "";

            try
            {
                if (CoSachChuaTra(maDocGia))
                {
                    ThongBao.CanhBao(
                        "Không thể xóa độc giả này vì vẫn còn sách chưa trả.\n" +
                        "Vui lòng hoàn tất trả sách trước khi xóa.");
                    return;
                }

                bool xacNhan = ThongBao.XacNhan(
                    "Bạn có chắc muốn xóa độc giả \"" +
                    hoTen + "\" không?");

                if (!xacNhan)
                    return;

                if (CoSachChuaTra(maDocGia))
                {
                    ThongBao.CanhBao(
                        "Độc giả hiện có sách chưa trả. Không thể xóa.");
                    return;
                }

                docGiaBLL.XoaDocGia(maDocGia);

                LamMoiDanhSach();

                ThongBao.ThanhCong(
                    "Xóa độc giả thành công!");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    ThongBao.CanhBao(
                        "Không thể xóa độc giả vì còn dữ liệu mượn sách hoặc dữ liệu liên quan.\n" +
                        "Cần giữ lại lịch sử giao dịch của độc giả.");
                }
                else
                {
                    ThongBao.Loi(
                        "Lỗi xóa độc giả:\n" + ex.Message);
                }
            }
            catch (Exception ex)
            {
                ThongBao.Loi(
                    "Lỗi xóa độc giả:\n" + ex.Message);
            }
        }

        private void btnGiaHan_Click(
            object sender, EventArgs e)
        {
            DataGridViewRow row = LayDongDangChon();

            if (row == null)
            {
                ThongBao.CanhBao(
                    "Vui lòng chọn độc giả cần gia hạn.");
                return;
            }

            string maDocGia = LayMaDocGia(row);

            string hoTen = Convert.ToString(
                row.Cells["Column2"].Value) ?? "";

            string ngayHetHanCu = "Chưa xác định";

            object giaTriNgay =
                row.Cells["colNgayHetHan"].Value;

            if (giaTriNgay != null &&
                giaTriNgay != DBNull.Value &&
                DateTime.TryParse(
                    Convert.ToString(giaTriNgay),
                    out DateTime ngayHetHan))
            {
                ngayHetHanCu =
                    ngayHetHan.ToString("dd/MM/yyyy");
            }

            bool xacNhan = ThongBao.XacNhan(
                "Gia hạn thẻ cho độc giả: " + hoTen +
                "\nMã độc giả: " + maDocGia +
                "\nNgày hết hạn hiện tại: " + ngayHetHanCu +
                "\n\nBạn có muốn gia hạn thêm 3 tháng không?");

            if (!xacNhan)
                return;

            try
            {
                DateTime ngayHetHanMoi =
                    docGiaBLL.GiaHanThe(maDocGia);

                LamMoiDanhSach(maDocGia);

                ThongBao.ThanhCong(
                    "Gia hạn thẻ thành công!\n" +
                    "Ngày hết hạn mới: " +
                    ngayHetHanMoi.ToString("dd/MM/yyyy"));
            }
            catch (Exception ex)
            {
                ThongBao.Loi(
                    "Lỗi gia hạn thẻ:\n" + ex.Message);
            }
        }

        private string LayCotTimKiem()
        {
            switch (cbTimTheo.SelectedItem?.ToString())
            {
                case "Mã độc giả":
                    return "MaDocGia";

                case "Họ tên":
                    return "HoTen";

                case "Số điện thoại":
                    return "SoDienThoai";

                case "Địa chỉ":
                    return "DiaChi";

                case "Giới tính":
                    return "GioiTinh";

                case "Email":
                    return "Email";

                default:
                    return "MaDocGia";
            }
        }

        private void TimKiemDocGia()
        {
            string tuKhoa =
                toolStripTextBox1.Text.Trim();

            try
            {
                if (string.IsNullOrWhiteSpace(tuKhoa))
                {
                    HienThiDanhSach();
                    return;
                }

                List<DocGia> danhSach =
                    docGiaBLL.TimKiem(
                        LayCotTimKiem(),
                        tuKhoa);

                DoDuLieuLenBang(danhSach);
            }
            catch (Exception ex)
            {
                ThongBao.Loi(
                    "Lỗi tìm kiếm độc giả:\n" +
                    ex.Message);
            }
        }

        private void btnTimKiem_Click(
            object sender, EventArgs e)
        {
            TimKiemDocGia();
        }

        private void cboTimTheo_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            TimKiemDocGia();
        }

        private void txtTimKiem_KeyDown(
            object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TimKiemDocGia();
                e.SuppressKeyPress = true;
            }
        }

        private void txtTimKiem_TextChanged(
            object sender, EventArgs e)
        {
            TimKiemDocGia();
        }

        private void HienThiDanhSach()
        {
            try
            {
                List<DocGia> danhSach =
                    docGiaBLL.GetAll();

                DoDuLieuLenBang(danhSach);
            }
            catch (Exception ex)
            {
                ThongBao.Loi(
                    "Lỗi tải danh sách độc giả:\n" +
                    ex.Message);
            }
        }

        private void DoDuLieuLenBang(
            List<DocGia> danhSach)
        {
            dgvDocGia.Rows.Clear();

            foreach (DocGia docGia in danhSach)
            {
                int index = dgvDocGia.Rows.Add();

                DataGridViewRow row =
                    dgvDocGia.Rows[index];

                row.Cells["Column1"].Value =
                    docGia.MaDocGia;

                row.Cells["Column2"].Value =
                    docGia.HoTen;

                row.Cells["Column3"].Value =
                    docGia.NgaySinh;

                row.Cells["Column4"].Value =
                    docGia.SoDienThoai;

                row.Cells["dgvNhaXuatBan"].Value =
                    docGia.DiaChi;

                row.Cells["Column5"].Value =
                    docGia.GioiTinh;

                row.Cells["Column6"].Value =
                    docGia.Email;

                row.Cells["colNgayDangKy"].Value =
                    docGia.NgayDangKy.HasValue
                        ? (object)docGia.NgayDangKy.Value
                        : DBNull.Value;

                row.Cells["colNgayHetHan"].Value =
                    docGia.NgayHetHan.HasValue
                        ? (object)docGia.NgayHetHan.Value
                        : DBNull.Value;

                DataGridViewCell cell =
                    row.Cells["colTrangThaiThe"];

                cell.Value = docGia.TrangThaiThe;

                switch (docGia.TrangThaiThe)
                {
                    case "Còn hạn":
                        cell.Style.ForeColor =
                            Color.FromArgb(22, 163, 74);
                        break;

                    case "Sắp hết hạn":
                        cell.Style.ForeColor =
                            Color.FromArgb(217, 119, 6);
                        break;

                    case "Hết hạn":
                        cell.Style.ForeColor =
                            Color.FromArgb(220, 38, 38);
                        break;

                    default:
                        cell.Style.ForeColor = Color.Gray;
                        break;
                }

                cell.Style.Font = new Font(
                    "Segoe UI",
                    9.5F,
                    FontStyle.Bold);
            }

            dgvDocGia.ClearSelection();
        }

        private void lblDanhSach_Click(
            object sender, EventArgs e)
        {
        }

        private void dgvDocGia_CellContentClick(
            object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
