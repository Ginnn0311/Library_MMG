
using Library.DTO;
using Microsoft.Data.SqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.Net.Mail;
using System.Windows.Forms;

namespace Library
{
    public partial class frmThemDocGia : Form
    {
        public frmThemDocGia()
        {
            InitializeComponent();

            cboGioiTinh.Items.Clear();
            cboGioiTinh.Items.Add("Nam");
            cboGioiTinh.Items.Add("Nữ");

            if (cboGioiTinh.Items.Count > 0)
                cboGioiTinh.SelectedIndex = 0;

            btnLuu.Click += btnLuu_Click;
            btnHuy.Click += btnHuy_Click;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string MaDocGia
        {
            get { return txtMaDocGia.Text.Trim(); }
            set { txtMaDocGia.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string HoTen
        {
            get { return txtHoTen.Text.Trim(); }
            set { txtHoTen.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime NgaySinh
        {
            get { return dtpNgaySinh.Value.Date; }
            set { dtpNgaySinh.Value = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SoDienThoai
        {
            get { return txtSoDienThoai.Text.Trim(); }
            set { txtSoDienThoai.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DiaChi
        {
            get { return txtDiaChi.Text.Trim(); }
            set { txtDiaChi.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string GioiTinh
        {
            get { return cboGioiTinh.Text.Trim(); }
            set { cboGioiTinh.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Email
        {
            get { return txtEmail.Text.Trim(); }
            set { txtEmail.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool MaDocGiaEditable
        {
            get { return txtMaDocGia.Enabled; }
            set { txtMaDocGia.Enabled = value; }
        }

        private bool KiemTraTrungDuLieu()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string sql = @"
            SELECT TOP 1
                MaDocGia,
                HoTen,
                LoaiTrung,
                GiaTriTrung
            FROM
            (
                SELECT
                    MaDocGia,
                    HoTen,
                    N'Mã độc giả' AS LoaiTrung,
                    CAST(MaDocGia AS NVARCHAR(255)) AS GiaTriTrung,
                    1 AS UuTien
                FROM DocGia
                WHERE @LaThem = 1
                  AND MaDocGia = @MaDocGia

                UNION ALL

                SELECT
                    MaDocGia,
                    HoTen,
                    N'Số điện thoại' AS LoaiTrung,
                    CAST(SoDienThoai AS NVARCHAR(255)) AS GiaTriTrung,
                    2 AS UuTien
                FROM DocGia
                WHERE LTRIM(RTRIM(SoDienThoai)) = @SoDienThoai
                  AND (@LaThem = 1 OR MaDocGia <> @MaDocGia)

                UNION ALL

                SELECT
                    MaDocGia,
                    HoTen,
                    N'Email' AS LoaiTrung,
                    CAST(Email AS NVARCHAR(255)) AS GiaTriTrung,
                    3 AS UuTien
                FROM DocGia
                WHERE LOWER(LTRIM(RTRIM(Email))) =
                      LOWER(@Email)
                  AND (@LaThem = 1 OR MaDocGia <> @MaDocGia)
            ) AS KetQua
            ORDER BY UuTien, MaDocGia";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@MaDocGia", SqlDbType.NVarChar, 40)
                        .Value = MaDocGia;

                    cmd.Parameters.Add("@SoDienThoai", SqlDbType.NVarChar, 30)
                        .Value = SoDienThoai;

                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 255)
                        .Value = Email;

                    cmd.Parameters.Add("@LaThem", SqlDbType.Bit)
                        .Value = MaDocGiaEditable;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                            return false;

                        string maTrung =
                            Convert.ToString(reader["MaDocGia"]) ?? "";

                        string tenDocGia =
                            Convert.ToString(reader["HoTen"]) ?? "";

                        string loaiTrung =
                            Convert.ToString(reader["LoaiTrung"]) ?? "";

                        string giaTriTrung =
                            Convert.ToString(reader["GiaTriTrung"]) ?? "";

                        string noiDung =
                            $"{loaiTrung} đã tồn tại trong hệ thống!\n\n" +
                            $"{loaiTrung}: {giaTriTrung}\n" +
                            "Đã trùng với \n" +
                            $"Mã độc giả: {maTrung}\n" +
                            $"Họ tên độc giả: {tenDocGia}\n\n" +
                            $"Vui lòng nhập {loaiTrung.ToLower()} khác.";

                        ThongBao.CanhBao(noiDung);

                        if (loaiTrung == "Mã độc giả")
                            txtMaDocGia.Focus();
                        else if (loaiTrung == "Số điện thoại")
                            txtSoDienThoai.Focus();
                        else if (loaiTrung == "Email")
                            txtEmail.Focus();

                        return true;
                    }
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MaDocGia))
            {
                ThongBao.CanhBao("Vui lòng nhập mã độc giả.");
                txtMaDocGia.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(HoTen))
            {
                ThongBao.CanhBao("Vui lòng nhập họ tên.");
                txtHoTen.Focus();
                return;
            }

            if (NgaySinh > DateTime.Today)
            {
                ThongBao.CanhBao("Ngày sinh không hợp lệ.");
                dtpNgaySinh.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(SoDienThoai))
            {
                ThongBao.CanhBao("Vui lòng nhập số điện thoại.");
                txtSoDienThoai.Focus();
                return;
            }

            if (SoDienThoai.Length != 10 ||
                !System.Text.RegularExpressions.Regex.IsMatch(
                    SoDienThoai, @"^0\d{9}$"))
            {
                ThongBao.CanhBao(
                    "Số điện thoại phải gồm 10 chữ số và bắt đầu bằng 0.");

                txtSoDienThoai.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(DiaChi))
            {
                ThongBao.CanhBao("Vui lòng nhập địa chỉ.");
                txtDiaChi.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(GioiTinh))
            {
                ThongBao.CanhBao("Vui lòng chọn giới tính.");
                cboGioiTinh.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(Email))
            {
                ThongBao.CanhBao("Vui lòng nhập email.");
                txtEmail.Focus();
                return;
            }

            try
            {
                MailAddress diaChiEmail = new MailAddress(Email);

                if (!string.Equals(
                    diaChiEmail.Address,
                    Email,
                    StringComparison.OrdinalIgnoreCase))
                {
                    throw new FormatException();
                }
            }
            catch
            {
                ThongBao.CanhBao(
                    "Email không đúng định dạng. Vui lòng kiểm tra lại.");

                txtEmail.Focus();
                return;
            }

            try
            {
                if (KiemTraTrungDuLieu())
                    return;
            }
            catch (Exception ex)
            {
                ThongBao.Loi(
                    "Không thể kiểm tra dữ liệu trong SQL Server!\n" +
                    ex.Message);

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

        private void frmThemDocGia_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void cboGioiTinh_SelectedIndexChanged(
            object sender, EventArgs e)
        {

        }
    }
}
