
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Library
{
    public partial class frmNhanVien : Form
    {
        private readonly NhanVienDAL nhanVienDAL = new NhanVienDAL();
        private List<NhanVien> danhSachNhanVien = new List<NhanVien>();

        public frmNhanVien()
        {
            InitializeComponent();

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

            Load += frmNhanVien_Load;
            btnTimKiem.Click += btnTimKiem_Click;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            txtTimKiem.KeyDown += txtTimKiem_KeyDown;
            cboTimTheo.SelectedIndexChanged += cboTimTheo_SelectedIndexChanged;

            dgvNhanVien.CellClick -= dgvNhanVien_CellClick;
            dgvNhanVien.CellClick += dgvNhanVien_CellClick;
            btnThem.Click += btnThem_Click;
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            HienThiDanhSach();
        }

        private void HienThiDanhSach()
        {
            try
            {
                danhSachNhanVien = nhanVienDAL.GetAll();

                if (danhSachNhanVien == null)
                    danhSachNhanVien = new List<NhanVien>();

                DoDuLieuLenBang(danhSachNhanVien);
            }
            catch (Exception ex)
            {
                ThongBao.Loi("Không thể tải danh sách nhân viên");
            }
        }

        private void DoDuLieuLenBang(List<NhanVien> danhSach)
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

            dgvNhanVien.CurrentCell = null;

            dgvNhanVien.Rows[0].Selected = true;

            HienThiThongTinNhanVien(dgvNhanVien.Rows[0]);
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            HienThiThongTinNhanVien(dgvNhanVien.Rows[e.RowIndex]);
        }

        private void HienThiThongTinNhanVien(DataGridViewRow row)
        {
            if (row == null || row.IsNewRow || row.Cells.Count < 5)
            {
                XoaThongTin();
                return;
            }

            string maNhanVien = Convert.ToString(row.Cells[0].Value);

            if (string.IsNullOrWhiteSpace(maNhanVien))
            {
                XoaThongTin();
                return;
            }

            NhanVien nv = danhSachNhanVien.FirstOrDefault(x => x.MaNhanVien.ToString() == maNhanVien);

            if (nv == null)
            {
                XoaThongTin();
                return;
            }

            lblMaNhanVien.Text = "Mã nhân viên: " + nv.MaNhanVien;
            lblHoTen.Text = "Họ tên: " + nv.HoTen;
            lblSoDienThoai.Text = "Số điện thoại: " + nv.SoDienThoai;
            lblTaiKhoan.Text = "Tài khoản: " + nv.TaiKhoan;
            lblVaiTro.Text = "Vai trò: " + nv.VaiTro;

            HienThiAnh(nv.HinhAnh);
        }

        private void HienThiAnh(string duongDan)
        {
            if (picHinhAnh.Image != null)
            {
                Image anhCu = picHinhAnh.Image;
                picHinhAnh.Image = null;
                anhCu.Dispose();
            }

            if (string.IsNullOrWhiteSpace(duongDan))
                return;

            string duongDanDayDu = duongDan;

            if (!Path.IsPathRooted(duongDanDayDu))
            {
                duongDanDayDu = Path.Combine(
                    Application.StartupPath,
                    duongDanDayDu);
            }

            if (!File.Exists(duongDanDayDu))
                return;

            try
            {
                using (Image img = Image.FromFile(duongDanDayDu))
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

            if (picHinhAnh.Image != null)
            {
                Image anhCu = picHinhAnh.Image;
                picHinhAnh.Image = null;
                anhCu.Dispose();
            }
        }

        private void TimKiemNhanVien()
        {
            string tuKhoa = txtTimKiem.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                DoDuLieuLenBang(danhSachNhanVien);
                return;
            }

            List<NhanVien> ketQua;

            switch (cboTimTheo.Text)
            {
                case "Mã nhân viên":
                    ketQua = danhSachNhanVien
                        .Where(nv => nv.MaNhanVien.ToString()
                        .Contains(tuKhoa))
                        .ToList();
                    break;

                case "Họ tên":
                    ketQua = danhSachNhanVien
                        .Where(nv => (nv.HoTen ?? "")
                        .ToLower().Contains(tuKhoa))
                        .ToList();
                    break;

                case "Số điện thoại":
                    ketQua = danhSachNhanVien
                        .Where(nv => (nv.SoDienThoai ?? "")
                        .ToLower().Contains(tuKhoa))
                        .ToList();
                    break;

                case "Tài khoản":
                    ketQua = danhSachNhanVien
                        .Where(nv => (nv.TaiKhoan ?? "")
                        .ToLower().Contains(tuKhoa))
                        .ToList();
                    break;

                case "Vai trò":
                    ketQua = danhSachNhanVien
                        .Where(nv => (nv.VaiTro ?? "")
                        .ToLower().Contains(tuKhoa))
                        .ToList();
                    break;

                default:
                    ketQua = danhSachNhanVien;
                    break;
            }

            DoDuLieuLenBang(ketQua);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TimKiemNhanVien();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            TimKiemNhanVien();
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                TimKiemNhanVien();
            }
        }

        private void cboTimTheo_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            TimKiemNhanVien();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            using (frmThemNhanVien frm = new frmThemNhanVien())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    HienThiDanhSach();
                }
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow == null)
            {
                ThongBao.CanhBao("Vui lòng chọn nhân viên cần sửa!");
                return;
            }

            int maNhanVien = Convert.ToInt32(
                dgvNhanVien.CurrentRow.Cells[0].Value);

            NhanVien nv = danhSachNhanVien.Find(x => x.MaNhanVien == maNhanVien);

            if (nv == null)
                return;

            using (frmThemNhanVien frm = new frmThemNhanVien(nv))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    HienThiDanhSach();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow == null)
            {
                ThongBao.CanhBao("Vui lòng chọn nhân viên cần xóa!");
                return;
            }

            int maNhanVien = Convert.ToInt32(
                dgvNhanVien.CurrentRow.Cells[0].Value);

            string hoTen = Convert.ToString(dgvNhanVien.CurrentRow.Cells[1].Value);

            if (!ThongBao.XacNhan(
                $"Bạn có chắc chắn muốn xóa nhân viên {hoTen} không?"))
            {
                return;
            }

            try
            {
                if (nhanVienDAL.Xoa(maNhanVien))
                {
                    ThongBao.ThanhCong("Xóa nhân viên thành công!");
                    HienThiDanhSach();
                }
                else
                {
                    ThongBao.Loi("Không tìm thấy nhân viên!");
                }
            }
            catch (Exception ex)
            {
                ThongBao.Loi("Không thể xóa nhân viên!");
            }
        }

    }
}
