
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Library
{
    public partial class frmNhanVien : Form
    {
        private readonly NhanVienDAL nhanVienDAL =
            new NhanVienDAL();

        private List<NhanVien> danhSachNhanVien =
            new List<NhanVien>();

        private readonly int maNhanVienDangNhap;

        public frmNhanVien(int maNhanVienDangNhap)
        {
            InitializeComponent();

            this.maNhanVienDangNhap = maNhanVienDangNhap;

            KhoiTaoForm();
        }

        // Constructor phục vụ Windows Forms Designer.
        public frmNhanVien() : this(0)
        {
        }

        private void KhoiTaoForm()
        {
            cboTimTheo.Items.Clear();

            cboTimTheo.Items.AddRange(new object[]
            {
                "Mã nhân viên",
                "Họ tên",
                "Số điện thoại",
                "Tài khoản",
                "Vai trò"
            });

            cboTimTheo.SelectedIndex = 0;

            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.MultiSelect = false;
            dgvNhanVien.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;

            Load -= frmNhanVien_Load;
            Load += frmNhanVien_Load;

            btnTimKiem.Click -= btnTimKiem_Click;
            btnTimKiem.Click += btnTimKiem_Click;

            txtTimKiem.TextChanged -=
                txtTimKiem_TextChanged;
            txtTimKiem.TextChanged +=
                txtTimKiem_TextChanged;

            txtTimKiem.KeyDown -= txtTimKiem_KeyDown;
            txtTimKiem.KeyDown += txtTimKiem_KeyDown;

            cboTimTheo.SelectedIndexChanged -=
                cboTimTheo_SelectedIndexChanged;
            cboTimTheo.SelectedIndexChanged +=
                cboTimTheo_SelectedIndexChanged;

            dgvNhanVien.CellClick -= dgvNhanVien_CellClick;
            dgvNhanVien.CellClick += dgvNhanVien_CellClick;

            btnThem.Click -= btnThem_Click;
            btnThem.Click += btnThem_Click;

            btnSua.Click -= btnSua_Click;
            btnSua.Click += btnSua_Click;

            btnXoa.Click -= btnXoa_Click;
            btnXoa.Click += btnXoa_Click;
        }

        private void frmNhanVien_Load(
            object sender, EventArgs e)
        {
            HienThiDanhSach();
        }

        private void HienThiDanhSach()
        {
            try
            {
                danhSachNhanVien =
                    nhanVienDAL.GetAll()
                    ?? new List<NhanVien>();

                TimKiemNhanVien();
            }
            catch (Exception ex)
            {
                ThongBao.Loi(
                    "Không thể tải danh sách nhân viên:\n"
                    + ex.Message);
            }
        }

        private void DoDuLieuLenBang(
            List<NhanVien> danhSach)
        {
            dgvNhanVien.Rows.Clear();
            XoaThongTin();

            if (danhSach == null || danhSach.Count == 0)
                return;

            foreach (NhanVien nv in danhSach)
            {
                dgvNhanVien.Rows.Add(
                    nv.MaNhanVien,
                    nv.HoTen,
                    nv.SoDienThoai,
                    nv.TaiKhoan,
                    nv.VaiTro
                );
            }

            dgvNhanVien.ClearSelection();

            dgvNhanVien.CurrentCell =
                dgvNhanVien.Rows[0].Cells[0];

            dgvNhanVien.Rows[0].Selected = true;

            HienThiThongTinNhanVien(
                dgvNhanVien.Rows[0]);
        }

        private void dgvNhanVien_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 ||
                e.RowIndex >= dgvNhanVien.Rows.Count)
                return;

            DataGridViewRow row =
                dgvNhanVien.Rows[e.RowIndex];

            if (row.IsNewRow)
                return;

            dgvNhanVien.CurrentCell = row.Cells[0];

            HienThiThongTinNhanVien(row);
        }

        private void HienThiThongTinNhanVien(
            DataGridViewRow row)
        {
            if (row == null ||
                row.IsNewRow ||
                row.Cells.Count < 5)
            {
                XoaThongTin();
                return;
            }

            if (!int.TryParse(
                Convert.ToString(row.Cells[0].Value),
                out int maNhanVien))
            {
                XoaThongTin();
                return;
            }

            NhanVien nv = danhSachNhanVien
                .FirstOrDefault(x =>
                    x.MaNhanVien == maNhanVien);

            if (nv == null)
            {
                XoaThongTin();
                return;
            }

            lblMaNhanVien.Text =
                "Mã nhân viên: " + nv.MaNhanVien;

            lblHoTen.Text =
                "Họ tên: " + nv.HoTen;

            lblSoDienThoai.Text =
                "Số điện thoại: " + nv.SoDienThoai;

            lblTaiKhoan.Text =
                "Tài khoản: " + nv.TaiKhoan;

            lblVaiTro.Text =
                "Vai trò: " + nv.VaiTro;

            HienThiAnh(nv.HinhAnh);
        }

        private void HienThiAnh(string duongDan)
        {
            Image anhCu = picHinhAnh.Image;
            picHinhAnh.Image = null;
            anhCu?.Dispose();

            if (string.IsNullOrWhiteSpace(duongDan))
                return;

            try
            {
                string duongDanDayDu = duongDan;

                if (!Path.IsPathRooted(duongDanDayDu))
                {
                    duongDanDayDu = Path.Combine(
                        Application.StartupPath,
                        duongDanDayDu);
                }

                if (!File.Exists(duongDanDayDu))
                    return;

                using (Image img =
                    Image.FromFile(duongDanDayDu))
                {
                    picHinhAnh.Image = new Bitmap(img);
                }
            }
            catch
            {
                picHinhAnh.Image = null;
            }
        }

        private void XoaThongTin()
        {
            lblMaNhanVien.Text = "Mã nhân viên:";
            lblHoTen.Text = "Họ tên:";
            lblSoDienThoai.Text = "Số điện thoại:";
            lblTaiKhoan.Text = "Tài khoản:";
            lblVaiTro.Text = "Vai trò:";

            Image anhCu = picHinhAnh.Image;
            picHinhAnh.Image = null;
            anhCu?.Dispose();
        }

        private void TimKiemNhanVien()
        {
            string tuKhoa =
                txtTimKiem.Text.Trim().ToLower();

            List<NhanVien> ketQua;

            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                ketQua = danhSachNhanVien;
            }
            else
            {
                switch (cboTimTheo.Text)
                {
                    case "Mã nhân viên":
                        ketQua = danhSachNhanVien
                            .Where(nv =>
                                nv.MaNhanVien.ToString()
                                .Contains(tuKhoa))
                            .ToList();
                        break;

                    case "Họ tên":
                        ketQua = danhSachNhanVien
                            .Where(nv =>
                                (nv.HoTen ?? "")
                                .ToLower()
                                .Contains(tuKhoa))
                            .ToList();
                        break;

                    case "Số điện thoại":
                        ketQua = danhSachNhanVien
                            .Where(nv =>
                                (nv.SoDienThoai ?? "")
                                .ToLower()
                                .Contains(tuKhoa))
                            .ToList();
                        break;

                    case "Tài khoản":
                        ketQua = danhSachNhanVien
                            .Where(nv =>
                                (nv.TaiKhoan ?? "")
                                .ToLower()
                                .Contains(tuKhoa))
                            .ToList();
                        break;

                    case "Vai trò":
                        ketQua = danhSachNhanVien
                            .Where(nv =>
                                (nv.VaiTro ?? "")
                                .ToLower()
                                .Contains(tuKhoa))
                            .ToList();
                        break;

                    default:
                        ketQua = danhSachNhanVien;
                        break;
                }
            }

            DoDuLieuLenBang(ketQua);
        }

        private void btnTimKiem_Click(
            object sender, EventArgs e)
        {
            TimKiemNhanVien();
        }

        private void txtTimKiem_TextChanged(
            object sender, EventArgs e)
        {
            TimKiemNhanVien();
        }

        private void txtTimKiem_KeyDown(
            object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                TimKiemNhanVien();
            }
        }

        private void cboTimTheo_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            TimKiemNhanVien();
        }

        // Kiểm tra quyền quản lý nhân viên
        private bool KiemTraQuyenQuanLy()
        {
            try
            {
                if (maNhanVienDangNhap <= 0)
                {
                    ThongBao.CanhBao(
                        "Không xác định được tài khoản đăng nhập!");
                    return false;
                }

                string vaiTro = nhanVienDAL.GetAll()
                    .FirstOrDefault(x =>
                        x.MaNhanVien == maNhanVienDangNhap)
                    ?.VaiTro?.Trim() ?? "";

                bool hopLe =
                    vaiTro.Equals(
                        "Quản trị viên",
                        StringComparison.OrdinalIgnoreCase)
                    ||
                    vaiTro.Equals(
                        "Quản lý",
                        StringComparison.OrdinalIgnoreCase);

                if (!hopLe)
                {
                    ThongBao.CanhBao(
                        "Bạn không có quyền quản lý nhân viên!");
                }

                return hopLe;
            }
            catch (Exception ex)
            {
                ThongBao.Loi(
                    "Không thể kiểm tra quyền: " + ex.Message);
                return false;
            }
        }

        private bool LaQuanTriVien(string vaiTro)
        {
            return string.Equals(
                vaiTro?.Trim(),
                "Quản trị viên",
                StringComparison.OrdinalIgnoreCase);
        }

        // Quản lý không được sửa/xóa quản trị viên
        private bool KiemTraQuyenSuaXoa(NhanVien nv)
        {
            try
            {
                var danhSachMoi = nhanVienDAL.GetAll();

                var nguoiThaoTac =
                    danhSachMoi.FirstOrDefault(
                        x => x.MaNhanVien ==
                            maNhanVienDangNhap);

                var nhanVienHienTai =
                    danhSachMoi.FirstOrDefault(
                        x => x.MaNhanVien ==
                            nv.MaNhanVien);

                if (nguoiThaoTac == null ||
                    nhanVienHienTai == null)
                {
                    ThongBao.CanhBao(
                        "Tài khoản không còn tồn tại!");
                    return false;
                }

                if (!LaQuanTriVien(nguoiThaoTac.VaiTro) &&
                    LaQuanTriVien(nhanVienHienTai.VaiTro))
                {
                    ThongBao.CanhBao(
                        "Chỉ quản trị viên được sửa hoặc " +
                        "xóa tài khoản quản trị!");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                ThongBao.Loi(
                    "Không thể kiểm tra quyền: " + ex.Message);
                return false;
            }
        }

        private void btnThem_Click(
            object sender, EventArgs e)
        {
            if (!KiemTraQuyenQuanLy())
                return;

            using (frmThemNhanVien frm =
                new frmThemNhanVien(maNhanVienDangNhap))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    HienThiDanhSach();
                }
            }
        }

        private void btnSua_Click(
            object sender, EventArgs e)
        {
            if (!KiemTraQuyenQuanLy())
                return;

            if (!LayNhanVienDangChon(
                out NhanVien nv))
            {
                ThongBao.CanhBao(
                    "Vui lòng chọn nhân viên cần sửa!");
                return;
            }

            if (!KiemTraQuyenSuaXoa(nv))
                return;

            using (frmThemNhanVien frm =
                new frmThemNhanVien(
                    nv, maNhanVienDangNhap))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    HienThiDanhSach();
                }
            }
        }

        private void btnXoa_Click(
            object sender, EventArgs e)
        {
            if (!KiemTraQuyenQuanLy())
                return;

            if (!LayNhanVienDangChon(
                out NhanVien nv))
            {
                ThongBao.CanhBao(
                    "Vui lòng chọn nhân viên cần xóa!");
                return;
            }

            if (!KiemTraQuyenSuaXoa(nv))
                return;

            if (nv.MaNhanVien == maNhanVienDangNhap)
            {
                ThongBao.CanhBao(
                    "Bạn không thể xóa tài khoản " +
                    "đang đăng nhập!");
                return;
            }

            try
            {
                if (!nhanVienDAL.CoTheXoaQuanTriVien(
                    nv.MaNhanVien))
                {
                    ThongBao.CanhBao(
                        "Không thể xóa quản trị viên " +
                        "cuối cùng của hệ thống!");
                    return;
                }

                if (!ThongBao.XacNhan(
                    "Bạn có chắc chắn muốn xóa nhân viên " +
                    nv.HoTen + " không?"))
                {
                    return;
                }

                if (nhanVienDAL.Xoa(nv.MaNhanVien))
                {
                    ThongBao.ThanhCong(
                        "Xóa nhân viên thành công!");

                    HienThiDanhSach();
                }
                else
                {
                    ThongBao.CanhBao(
                        "Không tìm thấy nhân viên " +
                        "hoặc nhân viên đã bị xóa.");
                }
            }
            catch (SqlException ex)
                when (ex.Number == 547)
            {
                ThongBao.CanhBao(
                    "Không thể xóa nhân viên vì " +
                    "đã có dữ liệu liên quan " +
                    "trong hệ thống.\n" +
                    "Cần giữ lại lịch sử mượn/trả sách.");
            }
            catch (Exception ex)
            {
                ThongBao.Loi(
                    "Không thể xóa nhân viên:\n" +
                    ex.Message);
            }
        }

        private bool LayNhanVienDangChon(
            out NhanVien nhanVien)
        {
            nhanVien = null;

            DataGridViewRow row =
                dgvNhanVien.CurrentRow;

            if (row == null || row.IsNewRow)
                return false;

            if (!int.TryParse(
                Convert.ToString(row.Cells[0].Value),
                out int maNhanVien))
            {
                return false;
            }

            nhanVien = danhSachNhanVien
                .FirstOrDefault(x =>
                    x.MaNhanVien == maNhanVien);

            return nhanVien != null;
        }
    }
}
