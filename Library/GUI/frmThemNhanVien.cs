using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Library
{
    public partial class frmThemNhanVien : Form
    {
        private NhanVienDAL nhanVienDAL = new NhanVienDAL();
        private NhanVien nhanVienSua;
        private string duongDanAnh = "";

        public frmThemNhanVien()
        {
            InitializeComponent();
        }

        public frmThemNhanVien(NhanVien nv)
        {
            InitializeComponent();

            nhanVienSua = nv;

            lblTieuDe.Text = "CẬP NHẬT NHÂN VIÊN";

            HienThiThongTin();
        }

        private void HienThiThongTin()
        {
            if (nhanVienSua == null)
                return;

            txtHoTen.Text = nhanVienSua.HoTen;
            txtSoDienThoai.Text = nhanVienSua.SoDienThoai;
            txtTaiKhoan.Text = nhanVienSua.TaiKhoan;
            txtMatKhau.Text = nhanVienSua.MatKhau;

            if (!string.IsNullOrWhiteSpace(nhanVienSua.VaiTro))
            {
                if (!cboVaiTro.Items.Contains(nhanVienSua.VaiTro))
                    cboVaiTro.Items.Add(nhanVienSua.VaiTro);

                cboVaiTro.SelectedItem = nhanVienSua.VaiTro;
            }

            duongDanAnh = nhanVienSua.HinhAnh;
            HienThiAnh(duongDanAnh);
        }

        

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Title = "Chọn ảnh nhân viên";
                openFile.Filter =
                    "Tất cả định dạng ảnh|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tif;*.tiff;*.webp;*.ico;*.jfif|" +
                    "JPEG (*.jpg;*.jpeg;*.jfif)|*.jpg;*.jpeg;*.jfif|" +
                    "PNG (*.png)|*.png|" +
                    "Bitmap (*.bmp)|*.bmp|" +
                    "GIF (*.gif)|*.gif|" +
                    "TIFF (*.tif;*.tiff)|*.tif;*.tiff|" +
                    "WebP (*.webp)|*.webp|" +
                    "Icon (*.ico)|*.ico|" +
                    "Tất cả tệp (*.*)|*.*";

                openFile.FilterIndex = 1;
                openFile.Multiselect = false;

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (Image img = Image.FromFile(openFile.FileName))
                        {
                            picHinhAnh.Image = new Bitmap(img);
                        }

                        duongDanAnh = openFile.FileName;
                    }
                    catch
                    {
                        ThongBao.CanhBao("Không thể đọc định dạng ảnh này. Vui lòng chọn ảnh JPG, PNG, BMP, GIF hoặc TIFF.");
                    }
                }
            }
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

            string path = duongDan;

            if (!Path.IsPathRooted(path))
                path = Path.Combine(Application.StartupPath, path);

            if (!File.Exists(path))
                return;

            using (Image img = Image.FromFile(path))
            {
                picHinhAnh.Image = new Bitmap(img);
            }
        }

        private string LuuAnh()
        {
            if (string.IsNullOrWhiteSpace(duongDanAnh))
                return "";

            string thuMuc = Path.Combine(
                Application.StartupPath,
                "Images",
                "NhanVien");

            Directory.CreateDirectory(thuMuc);

            string tenFile = Guid.NewGuid().ToString()
                + Path.GetExtension(duongDanAnh);

            string duongDanMoi = Path.Combine(thuMuc, tenFile);

            File.Copy(duongDanAnh, duongDanMoi, true);

            return Path.Combine("Images", "NhanVien", tenFile);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                ThongBao.CanhBao("Vui lòng nhập họ tên!");
                txtHoTen.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTaiKhoan.Text))
            {
                ThongBao.CanhBao("Vui lòng nhập tài khoản!");
                txtTaiKhoan.Focus();
                return;
            }

            if (nhanVienSua == null &&
                string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                ThongBao.CanhBao("Vui lòng nhập mật khẩu!");
                txtMatKhau.Focus();
                return;
            }

            if (nhanVienDAL.KiemTraTaiKhoan(
                txtTaiKhoan.Text.Trim(),
                nhanVienSua == null ? 0 : nhanVienSua.MaNhanVien))
            {
                ThongBao.CanhBao("Tài khoản đã tồn tại!");
                txtTaiKhoan.Focus();
                return;
            }

            try
            {
                string anhLuu = duongDanAnh;

                if (!string.IsNullOrWhiteSpace(duongDanAnh))
                {
                    if (nhanVienSua == null ||
                        duongDanAnh != nhanVienSua.HinhAnh)
                    {
                        anhLuu = LuuAnh();
                    }
                }

                NhanVien nv = new NhanVien
                {
                    MaNhanVien = nhanVienSua == null
                        ? 0
                        : nhanVienSua.MaNhanVien,

                    HoTen = txtHoTen.Text.Trim(),
                    SoDienThoai = txtSoDienThoai.Text.Trim(),
                    TaiKhoan = txtTaiKhoan.Text.Trim(),
                    MatKhau = txtMatKhau.Text.Trim(),
                    VaiTro = cboVaiTro.Text,
                    HinhAnh = anhLuu
                };

                bool ketQua;

                if (nhanVienSua == null)
                    ketQua = nhanVienDAL.Them(nv);
                else
                    ketQua = nhanVienDAL.Sua(nv);

                if (ketQua)
                {
                    ThongBao.ThanhCong(
                        nhanVienSua == null
                            ? "Thêm nhân viên thành công!"
                            : "Cập nhật nhân viên thành công!");

                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    ThongBao.CanhBao("Không thể lưu nhân viên!");
                }
            }
            catch (Exception ex)
            {
                ThongBao.Loi("Lỗi: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (picHinhAnh.Image != null)
            {
                picHinhAnh.Image.Dispose();
                picHinhAnh.Image = null;
            }

            base.OnFormClosed(e);
        }
    }
}