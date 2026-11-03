
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Library
{
    public partial class frmThemSach : Form
    {
        private string duongDanAnh = "";
        private Guna2Button btnChonAnh;
        private Guna2Button btnXoaAnh;

       

        public frmThemSach()
        {
            InitializeComponent();
            LoadTheLoai();

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;

            pictureBox1.Location = new Point(15, 15);
            pictureBox1.Size = new Size(230, 250);

            btnChonAnh = new Guna2Button
            {
                Text = "Chọn ảnh",
                Location = new Point(15, 280),
                Size = new Size(105, 38),
                BorderRadius = 7,
                FillColor = Color.FromArgb(35, 120, 210),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };

            btnXoaAnh = new Guna2Button
            {
                Text = "Xóa ảnh",
                Location = new Point(135, 280),
                Size = new Size(110, 38),
                BorderRadius = 7,
                FillColor = Color.FromArgb(220, 65, 75),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };

            btnChonAnh.Click += btnChonAnh_Click;
            btnXoaAnh.Click += btnXoaAnh_Click;

            pnlImage.Controls.Add(btnChonAnh);
            pnlImage.Controls.Add(btnXoaAnh);

            btnChonAnh.BringToFront();
            btnXoaAnh.BringToFront();

            btnLuu.Click -= btnLuu_Click;
            btnLuu.Click += btnLuu_Click;

            btnHuy.Click -= btnHuy_Click;
            btnHuy.Click += btnHuy_Click;

            txtMaSach.KeyDown += TextBox_KeyDown;
            txtTenSach.KeyDown += TextBox_KeyDown;
            txtTacGia.KeyDown += TextBox_KeyDown;
            cboTheLoai.KeyDown += TextBox_KeyDown;
            txtNhaXuatBan.KeyDown += TextBox_KeyDown;
            txtNamXB.KeyDown += TextBox_KeyDown;
            txtSoLuong.KeyDown += TextBox_KeyDown;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string HinhAnh
        {
            get { return duongDanAnh; }
            set
            {
                duongDanAnh = value ?? "";
                HienThiAnh();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string MaSach
        {
            get { return txtMaSach.Text.Trim(); }
            set { txtMaSach.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string TenSach
        {
            get { return txtTenSach.Text.Trim(); }
            set { txtTenSach.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string TacGia
        {
            get { return txtTacGia.Text.Trim(); }
            set { txtTacGia.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string TheLoai
        {
            get { return cboTheLoai.Text.Trim(); }
            set { cboTheLoai.SelectedItem = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string NhaXuatBan
        {
            get { return txtNhaXuatBan.Text.Trim(); }
            set { txtNhaXuatBan.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int NamXuatBan
        {
            get { return int.Parse(txtNamXB.Text.Trim()); }
            set { txtNamXB.Text = value.ToString(); }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SoLuong
        {
            get { return int.Parse(txtSoLuong.Text.Trim()); }
            set { txtSoLuong.Text = value.ToString(); }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool MaSachEditable
        {
            get { return txtMaSach.Enabled; }
            set { txtMaSach.Enabled = value; }
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Chọn hình ảnh";
                openFileDialog.Filter =
                    "Tất cả định dạng ảnh|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tif;*.tiff;*.webp|" +
                    "JPEG|*.jpg;*.jpeg|" +
                    "PNG|*.png|" +
                    "Bitmap|*.bmp|" +
                    "GIF|*.gif|" +
                    "TIFF|*.tif;*.tiff|" +
                    "WEBP|*.webp|" +
                    "Tất cả tệp|*.*";

                openFileDialog.FilterIndex = 1;
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    string duongDanNguon = openFileDialog.FileName;

                    string thuMuc = Path.Combine(
                        Application.StartupPath, "Images", "Sach");

                    Directory.CreateDirectory(thuMuc);

                    string tenFile = Guid.NewGuid().ToString("N")
                        + Path.GetExtension(duongDanNguon);

                    string duongDanDich = Path.Combine(thuMuc, tenFile);

                    File.Copy(duongDanNguon, duongDanDich, true);

                    duongDanAnh = Path.Combine("Images", "Sach", tenFile);

                    HienThiAnh();
                }
                catch (Exception ex)
                {
                    ThongBao.Loi("Không thể tải ảnh!!!!");
                }
            }
        }

        private void btnXoaAnh_Click(object sender, EventArgs e)
        {
            duongDanAnh = "";

            if (pictureBox1.Image != null)
            {
                Image anhCu = pictureBox1.Image;
                pictureBox1.Image = null;
                anhCu.Dispose();
            }
        }

        private void HienThiAnh()
        {
            if (pictureBox1.Image != null)
            {
                Image anhCu = pictureBox1.Image;
                pictureBox1.Image = null;
                anhCu.Dispose();
            }

            if (string.IsNullOrWhiteSpace(duongDanAnh))
                return;

            string duongDan = Path.IsPathRooted(duongDanAnh)
                ? duongDanAnh
                : Path.Combine(Application.StartupPath, duongDanAnh);

            if (!File.Exists(duongDan))
                return;

            using Image anh = Image.FromFile(duongDan);
            pictureBox1.Image = new Bitmap(anh);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSach.Text))
            {
                ThongBao.CanhBao("Vui lòng nhập mã sách!");
                txtMaSach.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenSach.Text))
            {
                ThongBao.CanhBao("Vui lòng nhập tên sách!");
                txtTenSach.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTacGia.Text))
            {
                ThongBao.CanhBao("Vui lòng nhập tác giả!");
                txtTacGia.Focus();
                return;
            }

            if(cboTheLoai.SelectedIndex == -1)
{
                ThongBao.CanhBao("Vui lòng chọn thể loại!");
                cboTheLoai.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNhaXuatBan.Text))
            {
                ThongBao.CanhBao("Vui lòng nhập nhà xuất bản!");
                txtNhaXuatBan.Focus();
                return;
            }

            if (!int.TryParse(txtNamXB.Text.Trim(), out int nam) ||
                nam < 1000 || nam > DateTime.Now.Year)
            {
                ThongBao.CanhBao("Năm xuất bản không hợp lệ!");
                txtNamXB.Focus();
                return;
            }

            if (!int.TryParse(txtSoLuong.Text.Trim(), out int soLuong) ||
                soLuong < 0)
            {
                ThongBao.CanhBao("Số lượng phải là số nguyên!");
                txtSoLuong.Focus();
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.Browsable(false)]
        public bool KhoaSoLuong
        {
            get
            {
                return txtSoLuong.ReadOnly;
            }
            set
            {
                txtSoLuong.ReadOnly = value;
                txtSoLuong.TabStop = !value;
            }
        }


        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            e.SuppressKeyPress = true;

            Control control = (Control)sender;

            if (control == txtMaSach)
                txtTenSach.Focus();
            else if (control == txtTenSach)
                txtTacGia.Focus();
            else if (control == txtTacGia)
                cboTheLoai.Focus();
            else if (control == cboTheLoai)
                txtNhaXuatBan.Focus();
            else if (control == txtNhaXuatBan)
                txtNamXB.Focus();
            else if (control == txtNamXB)
                txtSoLuong.Focus();
            else if (control == txtSoLuong)
                btnLuu.Focus();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Image anhCu = pictureBox1.Image;
                pictureBox1.Image = null;
                anhCu.Dispose();
            }

            base.OnFormClosed(e);
        }
        private void LoadTheLoai()
        {
            cboTheLoai.Items.Clear();

            cboTheLoai.Items.AddRange(new object[]
            {
                "Văn học",
                "Khoa học",
                "Kinh tế",
                "Tâm lý - Kỹ năng sống",
                "Lịch sử",
                "Giáo dục",
                "Công nghệ thông tin",
                "Thiếu nhi",
                "Ngoại ngữ",
                "Y học",
                "Triết học",
                "Truyện tranh",
                "Tôn giáo",
                "Thể thao",
                "Khác"
            });

            cboTheLoai.SelectedIndex = -1;
        }
        private void pnlForm_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
