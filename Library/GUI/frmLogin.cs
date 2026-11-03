
using System;
using System.Windows.Forms;
using Library.DTO;
using Microsoft.Data.SqlClient;

namespace Library
{
    public partial class frmLogin : Form
    {
        public int MaNhanVienDangNhap { get; private set; }
        public string HoTenDangNhap { get; private set; } = "";
        public string VaiTroDangNhap { get; private set; } = "";

        public frmLogin()
        {
            InitializeComponent();

            txtMatKhau.UseSystemPasswordChar = true;
            btnHienMatKhau.Text = "Hiện";

            AcceptButton = btnDangNhap;

            btnDangNhap.Click += btnDangNhap_Click;
            btnThoat.Click += btnThoat_Click;
            btnHienMatKhau.Click += btnHienMatKhau_Click;
        }

        private void btnHienMatKhau_Click(object sender, EventArgs e)
        {
            bool dangAnMatKhau =
                txtMatKhau.UseSystemPasswordChar;

            txtMatKhau.UseSystemPasswordChar = !dangAnMatKhau;

            btnHienMatKhau.Text =
                dangAnMatKhau ? "Ẩn" : "Hiện";

            txtMatKhau.Focus();

            txtMatKhau.SelectionStart =
                txtMatKhau.Text.Length;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string taiKhoan = txtTaiKhoan.Text.Trim();
            string matKhau = txtMatKhau.Text;

            if (string.IsNullOrWhiteSpace(taiKhoan))
            {
                ThongBao.CanhBao(
                    "Vui lòng nhập tài khoản.");

                txtTaiKhoan.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(matKhau))
            {
                ThongBao.CanhBao(
                    "Vui lòng nhập mật khẩu.");

                txtMatKhau.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    string sql = @"
                        SELECT TOP 1 MaNhanVien, HoTen, VaiTro
                        FROM NhanVien
                        WHERE TaiKhoan = @TaiKhoan
                          AND MatKhau = @MatKhau";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@TaiKhoan", taiKhoan);

                        cmd.Parameters.AddWithValue(
                            "@MatKhau", matKhau);

                        using (SqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                MaNhanVienDangNhap =
                                    Convert.ToInt32(
                                        reader["MaNhanVien"]);

                                HoTenDangNhap =
                                    Convert.ToString(
                                        reader["HoTen"]) ?? "";

                                VaiTroDangNhap =
                                    Convert.ToString(
                                        reader["VaiTro"]) ?? "";

                                DialogResult = DialogResult.OK;
                                Close();
                            }
                            else
                            {
                                ThongBao.CanhBao(
                                    "Tài khoản hoặc mật khẩu không chính xác.");

                                txtMatKhau.Clear();
                                txtMatKhau.UseSystemPasswordChar = true;
                                btnHienMatKhau.Text = "Hiện";
                                txtMatKhau.Focus();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ThongBao.Loi(
                    "Lỗi đăng nhập:\n" + ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
