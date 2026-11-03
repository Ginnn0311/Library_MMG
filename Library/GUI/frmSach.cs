
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using Guna.UI2.WinForms;

namespace Library
{
    public partial class frmSach : Form
    {
        private readonly SachBLL sachBLL = new SachBLL();
        private List<Sach> danhSachSach = new List<Sach>();

        public frmSach()
        {
            InitializeComponent();

            dgvSach.SelectionChanged -= dgvSach_SelectionChanged;
            dgvSach.SelectionChanged += dgvSach_SelectionChanged;

            pictureBoxSach.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void btnThemSach_Click(object sender, EventArgs e)
        {
            using frmThemSach frm = new frmThemSach();

            frm.Text = "Thêm sách";
            frm.MaSachEditable = true;

            if (frm.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                Sach sach = new Sach
                {
                    MaSach = frm.MaSach,
                    TenSach = frm.TenSach,
                    TacGia = frm.TacGia,
                    TheLoai = frm.TheLoai,
                    NhaXuatBan = frm.NhaXuatBan,
                    NamXuatBan = frm.NamXuatBan,
                    SoLuong = frm.SoLuong,
                    HinhAnh = frm.HinhAnh
                };

                sachBLL.ThemSach(sach);
                HienThiDanhSach();

                ThongBao.ThanhCong("Thêm sách thành công");
            }
            catch (Exception ex)
            {
                ThongBao.Loi("Lỗi! Thêm sách thất bại!");
            }
        }

        private void btnSuaSach_Click(object sender, EventArgs e)
        {
            if (dgvSach.SelectedRows.Count == 0)
            {
                ThongBao.CanhBao("Vui lòng chọn sách cần sửa!");
                return;
            }

            DataGridViewRow row = dgvSach.SelectedRows[0];

            using frmThemSach frm = new frmThemSach();

            frm.Text = "Sửa sách";
            frm.MaSach = Convert.ToString(row.Cells[0].Value) ?? "";
            frm.MaSachEditable = false;
            frm.TenSach = Convert.ToString(row.Cells[1].Value) ?? "";
            frm.TacGia = Convert.ToString(row.Cells[2].Value) ?? "";
            frm.TheLoai = Convert.ToString(row.Cells[3].Value) ?? "";
            frm.NhaXuatBan = Convert.ToString(row.Cells[4].Value) ?? "";
            frm.NamXuatBan = Convert.ToInt32(row.Cells[5].Value);
            frm.SoLuong = Convert.ToInt32(row.Cells[6].Value);
            frm.KhoaSoLuong = true;
            frm.HinhAnh = sachBLL.LayDuongDanAnh(frm.MaSach);

            if (frm.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                Sach sach = new Sach
                {
                    MaSach = frm.MaSach,
                    TenSach = frm.TenSach,
                    TacGia = frm.TacGia,
                    TheLoai = frm.TheLoai,
                    NhaXuatBan = frm.NhaXuatBan,
                    NamXuatBan = frm.NamXuatBan,
                    SoLuong = frm.SoLuong,
                    HinhAnh = frm.HinhAnh
                };

                sachBLL.SuaSach(sach);
                HienThiDanhSach();

                ThongBao.ThanhCong("Sửa sách thành công!");
            }
            catch (Exception ex)
            {
                ThongBao.Loi("Lỗi sửa sách: " + ex.Message);
            }
        }

        private void btnXoaSach_Click(object sender, EventArgs e)
        {
            if (dgvSach.SelectedRows.Count == 0)
            {
                ThongBao.CanhBao("Vui lòng chọn sách cần xóa!");
                return;
            }

            string maSach = Convert.ToString(
                dgvSach.SelectedRows[0].Cells[0].Value) ?? "";

            string tenSach = Convert.ToString(
                dgvSach.SelectedRows[0].Cells[1].Value) ?? "";

            if (!ThongBao.XacNhan(
                "Bạn có chắc muốn xóa sách \"" + tenSach + "\" không?"))
            {
                return;
            }

            try
            {
                sachBLL.XoaSach(maSach);
                HienThiDanhSach();

                ThongBao.ThanhCong("Xóa sách thành công!");
            }
            catch (Exception ex)
            {
                ThongBao.Loi("Lỗi khi xóa sách: " + ex.Message);
            }
        }

        private string LayCotTimKiem()
        {
            switch (cboTimTheo.SelectedItem?.ToString())
            {
                case "Mã sách":
                    return "MaSach";
                case "Tên sách":
                    return "TenSach";
                case "Tác giả":
                    return "TacGia";
                case "Thể loại":
                    return "TheLoai";
                case "Nhà xuất bản":
                    return "NhaXuatBan";
                default:
                    return "MaSach";
            }
        }

        private void TimKiemSach()
        {
            try
            {
                string tuKhoa = txtTimKiem.Text.Trim();
                danhSachSach = string.IsNullOrEmpty(tuKhoa)
                    ? sachBLL.GetAll()
                    : sachBLL.TimKiem(LayCotTimKiem(), tuKhoa);

                DoDuLieuLenBang();
            }
            catch (Exception ex)
            {
                ThongBao.Loi("Lỗi tìm kiếm:\n" + ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TimKiemSach();
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TimKiemSach();
                e.SuppressKeyPress = true;
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            TimKiemSach();
        }

        private void HienThiDanhSach()
        {
            try
            {
                danhSachSach = sachBLL.GetAll();
                DoDuLieuLenBang();
            }
            catch (Exception ex)
            {
                ThongBao.Loi("Lỗi tải danh sách sách: " + ex.Message);
            }
        }

        private void DoDuLieuLenBang()
        {
            dgvSach.Rows.Clear();

            foreach (Sach sach in danhSachSach)
            {
                dgvSach.Rows.Add(
                    sach.MaSach,
                    sach.TenSach,
                    sach.TacGia,
                    sach.TheLoai,
                    sach.NhaXuatBan,
                    sach.NamXuatBan,
                    sach.SoLuong);
            }

            if (dgvSach.Rows.Count > 0)
            {
                dgvSach.ClearSelection();
                dgvSach.Rows[0].Selected = true;
                dgvSach.CurrentCell = dgvSach.Rows[0].Cells[0];
            }
            else
            {
                if (pictureBoxSach.Image != null)
                {
                    Image anhCu = pictureBoxSach.Image;
                    pictureBoxSach.Image = null;
                    anhCu.Dispose();
                }
            }
        }

        private void frmSach_Load(object sender, EventArgs e)
        {
            cboTimTheo.SelectedIndex = 0;

            dgvSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSach.RowHeadersVisible = false;
            dgvSach.AllowUserToAddRows = false;
            dgvSach.AllowUserToDeleteRows = false;
            dgvSach.ReadOnly = true;
            dgvSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSach.MultiSelect = false;

            HienThiDanhSach();
        }

        private void toolStrip1_ItemClicked(
            object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
        }

        private void dgvSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgvSach_SelectionChanged(object sender, EventArgs e)
        {
            if (pictureBoxSach.Image != null)
            {
                Image anhCu = pictureBoxSach.Image;
                pictureBoxSach.Image = null;
                anhCu.Dispose();
            }

            if (dgvSach.CurrentRow == null ||
                dgvSach.CurrentRow.IsNewRow)
            {
                return;
            }

            string maSach = Convert.ToString(
                dgvSach.CurrentRow.Cells[0].Value) ?? "";

            if (string.IsNullOrWhiteSpace(maSach))
                return;

            try
            {
                string duongDanAnh = sachBLL.LayDuongDanAnh(maSach);

                if (string.IsNullOrWhiteSpace(duongDanAnh))
                    return;

                if (!Path.IsPathRooted(duongDanAnh))
                {
                    duongDanAnh = Path.Combine(
                        Application.StartupPath,
                        duongDanAnh.Replace('/', Path.DirectorySeparatorChar));
                }

                if (!File.Exists(duongDanAnh))
                {
                    return;
                }

                using (Image anh = Image.FromFile(duongDanAnh))
                {
                    pictureBoxSach.Image = new Bitmap(anh);
                }
            }
            catch (Exception ex)
            {
                ThongBao.CanhBao(
                    "Không thể hiển thị ảnh sách: " + ex.Message);
            }
        }

        private void lblListTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
