
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Library
{
    public partial class frmThemNhanVien : Form
    {
        private readonly NhanVienDAL nhanVienDAL = new NhanVienDAL();

        private NhanVien nhanVienSua;
        private string duongDanAnh = "";

     
        public frmThemNhanVien()
        {
            InitializeComponent();
            KhoiTaoForm();
        }

      
        public frmThemNhanVien(NhanVien nv)
        {
            InitializeComponent();
            KhoiTaoForm();

            nhanVienSua = nv;

            lblTieuDe.Text = "CẬP NHẬT NHÂN VIÊN";

            txtMatKhau.PlaceholderText =
                "Để trống nếu không đổi mật khẩu";

            HienThiThongTin();
        }

        private void KhoiTaoForm()
        {
            txtMatKhau.UseSystemPasswordChar = true;
            picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void HienThiThongTin()
        {
            if (nhanVienSua == null)
                return;

            txtHoTen.Text = nhanVienSua.HoTen;
            txtSoDienThoai.Text = nhanVienSua.SoDienThoai;
            txtTaiKhoan.Text = nhanVienSua.TaiKhoan;

            // Không hiển thị mật khẩu cũ
            txtMatKhau.Clear();
            txtMatKhau.UseSystemPasswordChar = true;

            if (!string.IsNullOrWhiteSpace(
                nhanVienSua.VaiTro))
            {
                if (!cboVaiTro.Items.Contains(
                    nhanVienSua.VaiTro))
                {
                    cboVaiTro.Items.Add(
                        nhanVienSua.VaiTro);
                }

                cboVaiTro.SelectedItem =
                    nhanVienSua.VaiTro;
            }

            duongDanAnh = nhanVienSua.HinhAnh ?? "";
            HienThiAnh(duongDanAnh);
        }

        private void btnChonAnh_Click(
            object sender, EventArgs e)
        {
            using (OpenFileDialog openFile =
                new OpenFileDialog())
            {
                openFile.Title = "Chọn ảnh nhân viên";
                openFile.Filter =
                    "Tệp ảnh|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tif;*.tiff;*.webp;*.ico;*.jfif|" +
                    "Tất cả tệp (*.*)|*.*";

                openFile.Multiselect = false;

                if (openFile.ShowDialog() !=
                    DialogResult.OK)
                {
                    return;
                }

                try
                {
                    using (Image img =
                        Image.FromFile(openFile.FileName))
                    {
                        Image anhCu = picHinhAnh.Image;

                        picHinhAnh.Image = new Bitmap(img);
                        anhCu?.Dispose();
                    }

                    duongDanAnh = openFile.FileName;
                }
                catch (Exception ex)
                {
                    ThongBao.CanhBao(
                        "Không thể đọc ảnh:\n" + ex.Message);
                }
            }
        }

        private void HienThiAnh(string duongDan)
        {
            Image anhCu = picHinhAnh.Image;
            picHinhAnh.Image = null;
            anhCu?.Dispose();

            if (string.IsNullOrWhiteSpace(duongDan))
                return;

            string path = duongDan;

            if (!Path.IsPathRooted(path))
            {
                path = Path.Combine(
                    Application.StartupPath, path);
            }

            if (!File.Exists(path))
                return;

            try
            {
                using (Image img = Image.FromFile(path))
                {
                    picHinhAnh.Image = new Bitmap(img);
                }
            }
            catch (Exception ex)
            {
                ThongBao.CanhBao(
                    "Không thể hiển thị ảnh:\n" +
                    ex.Message);
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

            string duongDanMoi =
                Path.Combine(thuMuc, tenFile);

            File.Copy(
                duongDanAnh,
                duongDanMoi,
                true);

            return Path.Combine(
                "Images", "NhanVien", tenFile);
        }

        private void btnLuu_Click(
            object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                ThongBao.CanhBao(
                    "Vui lòng nhập họ tên!");
                txtHoTen.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(
                txtTaiKhoan.Text))
            {
                ThongBao.CanhBao(
                    "Vui lòng nhập tài khoản!");
                txtTaiKhoan.Focus();
                return;
            }

            // Thêm mới bắt buộc có mật khẩu
            if (nhanVienSua == null &&
                string.IsNullOrWhiteSpace(
                    txtMatKhau.Text))
            {
                ThongBao.CanhBao(
                    "Vui lòng nhập mật khẩu!");
                txtMatKhau.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(
                cboVaiTro.Text))
            {
                ThongBao.CanhBao(
                    "Vui lòng chọn vai trò!");
                cboVaiTro.Focus();
                return;
            }

            try
            {
                string taiKhoan =
                    txtTaiKhoan.Text.Trim();

                int maNhanVien =
                    nhanVienSua?.MaNhanVien ?? 0;

                if (nhanVienDAL.KiemTraTaiKhoan(
                    taiKhoan, maNhanVien))
                {
                    ThongBao.CanhBao(
                        "Tài khoản đã tồn tại!");
                    txtTaiKhoan.Focus();
                    return;
                }

                string anhLuu = duongDanAnh;

                if (!string.IsNullOrWhiteSpace(
                    duongDanAnh))
                {
                    if (nhanVienSua == null ||
                        duongDanAnh !=
                        nhanVienSua.HinhAnh)
                    {
                        anhLuu = LuuAnh();
                    }
                }

                NhanVien nv = new NhanVien
                {
                    MaNhanVien = maNhanVien,
                    HoTen = txtHoTen.Text.Trim(),
                    SoDienThoai =
                        txtSoDienThoai.Text.Trim(),
                    TaiKhoan = taiKhoan,

                    // Để trống khi sửa = giữ mật khẩu cũ
                    MatKhau = nhanVienSua != null &&
                        string.IsNullOrWhiteSpace(
                            txtMatKhau.Text)
                        ? ""
                        : txtMatKhau.Text,

                    VaiTro = cboVaiTro.Text,
                    HinhAnh = anhLuu
                };

                bool ketQua;

                if (nhanVienSua == null)
                {
                    ketQua = nhanVienDAL.Them(nv);
                }
                else
                {
                    ketQua = nhanVienDAL.Sua(nv);
                }

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
                    ThongBao.CanhBao(
                        "Không thể lưu nhân viên!");
                }
            }
            catch (Exception ex)
            {
                ThongBao.Loi(
                    "Lỗi lưu nhân viên:\n" +
                    ex.Message);
            }
        }

        private void btnHuy_Click(
            object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        protected override void OnFormClosed(
            FormClosedEventArgs e)
        {
            Image anhCu = picHinhAnh.Image;
            picHinhAnh.Image = null;
            anhCu?.Dispose();

            base.OnFormClosed(e);
        }
    }
}
