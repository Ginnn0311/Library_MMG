
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Library.DTO;

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

            toolStripTextBox1.TextChanged += txtTimKiem_TextChanged;
            toolStripTextBox1.KeyDown += txtTimKiem_KeyDown;
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
                MaDocGia = frm.MaDocGia,
                HoTen = frm.HoTen,
                NgaySinh = frm.NgaySinh,
                SoDienThoai = frm.SoDienThoai,
                DiaChi = frm.DiaChi,
                GioiTinh = frm.GioiTinh,
                Email = frm.Email
            };
        }

        private void btnThemDocGia_Click(object sender, EventArgs e)
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
                    docGiaBLL.ThemDocGia(docGia);

                    HienThiDanhSach();

                    ThongBao.ThanhCong(
                        "Thêm độc giả thành công!\n" +
                        "Thẻ có thời hạn 3 tháng kể từ ngày đăng ký.");
                }
                catch (Exception ex)
                {
                    ThongBao.Loi(
                        "Lỗi thêm độc giả:\n" + ex.Message);
                }
            }
        }

        private void btnSuaDocGia_Click(object sender, EventArgs e)
        {
            if (dgvDocGia.SelectedRows.Count == 0)
            {
                ThongBao.CanhBao(
                    "Vui lòng chọn độc giả cần sửa.");
                return;
            }

            DataGridViewRow row = dgvDocGia.SelectedRows[0];

            using (frmThemDocGia frm = new frmThemDocGia
            {
                Text = "Sửa độc giả",

                MaDocGia = Convert.ToString(
                    row.Cells["Column1"].Value) ?? "",

                MaDocGiaEditable = false,

                HoTen = Convert.ToString(
                    row.Cells["Column2"].Value) ?? "",

                NgaySinh = Convert.ToDateTime(
                    row.Cells["Column3"].Value),

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

                    docGiaBLL.SuaDocGia(docGia);

                    HienThiDanhSach();

                    ThongBao.ThanhCong(
                        "Sửa độc giả thành công!");
                }
                catch (Exception ex)
                {
                    ThongBao.Loi(
                        "Lỗi sửa độc giả:\n" + ex.Message);
                }
            }
        }

        private void btnXoaDocGia_Click(object sender, EventArgs e)
        {
            if (dgvDocGia.SelectedRows.Count == 0)
            {
                ThongBao.CanhBao(
                    "Vui lòng chọn độc giả cần xóa.");
                return;
            }

            DataGridViewRow row = dgvDocGia.SelectedRows[0];

            string maDocGia =
                Convert.ToString(
                    row.Cells["Column1"].Value) ?? "";

            string hoTen =
                Convert.ToString(
                    row.Cells["Column2"].Value) ?? "";

            bool xacNhan = ThongBao.XacNhan(
                "Bạn có chắc muốn xóa độc giả \"" +
                hoTen + "\" không?");

            if (!xacNhan)
                return;

            try
            {
                docGiaBLL.XoaDocGia(maDocGia);

                HienThiDanhSach();

                ThongBao.ThanhCong(
                    "Xóa độc giả thành công!");
            }
            catch (Exception ex)
            {
                ThongBao.Loi(
                    "Lỗi xóa độc giả:\n" + ex.Message);
            }
        }

        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            if (dgvDocGia.SelectedRows.Count == 0)
            {
                ThongBao.CanhBao(
                    "Vui lòng chọn độc giả cần gia hạn.");
                return;
            }

            DataGridViewRow row = dgvDocGia.SelectedRows[0];

            string maDocGia =
                Convert.ToString(
                    row.Cells["Column1"].Value) ?? "";

            string hoTen =
                Convert.ToString(
                    row.Cells["Column2"].Value) ?? "";

            string ngayHetHanCu = "Chưa xác định";

            if (row.Cells["colNgayHetHan"].Value
                is DateTime ngay)
            {
                ngayHetHanCu = ngay.ToString("dd/MM/yyyy");
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

                HienThiDanhSach();

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
            string tuKhoa = toolStripTextBox1.Text.Trim();

            try
            {
                if (string.IsNullOrWhiteSpace(tuKhoa))
                {
                    HienThiDanhSach();
                    return;
                }

                List<DocGia> danhSach =
                    docGiaBLL.TimKiem(
                        LayCotTimKiem(), tuKhoa);

                DoDuLieuLenBang(danhSach);
            }
            catch (Exception ex)
            {
                ThongBao.Loi(
                    "Lỗi tìm kiếm độc giả:\n" + ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
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
                    "Lỗi tải danh sách độc giả:\n" + ex.Message);
            }
        }

        private void DoDuLieuLenBang(List<DocGia> danhSach)
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
                        ? docGia.NgayDangKy.Value
                        : DBNull.Value;

                row.Cells["colNgayHetHan"].Value =
                    docGia.NgayHetHan.HasValue
                        ? docGia.NgayHetHan.Value
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
