
using Library.DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Library
{
    public partial class frmPhieuMuon : Form
    {
        private DataTable danhSachSach;
        private DataTable duLieuDocGia;
        private DataTable duLieuSach;

        private DataView viewGoiYDocGia;
        private DataView viewGoiYSach;

        private readonly int maNhanVienDangNhap;
        private readonly string hoTenDangNhap;

        private int? maDocGiaDaChon;
        private string maSachDaChon = "";

        private bool dangChonDocGia;
        private bool dangChonSach;

        public frmPhieuMuon(int maNhanVien, string hoTen)
        {
            InitializeComponent();

            maNhanVienDangNhap = maNhanVien;
            hoTenDangNhap = hoTen;

            KetNoiSuKien();
            TaoBangSachMuon();
            HienThiNhanVienDangNhap();

            try
            {
                TaiDocGia();
                TaiSach();
            }
            catch (Exception ex)
            {
                ThongBao.Loi(
                    "Không thể tải dữ liệu:\n" + ex.Message);
            }

            dtpNgayMuon.Value = DateTime.Today;
            dtpHanTra.Value = DateTime.Today.AddDays(7);
        }

        private void KetNoiSuKien()
        {
            txtTimDocGia.TextChanged += txtTimDocGia_TextChanged;
            txtTimSach.TextChanged += txtTimSach_TextChanged;

            txtTimDocGia.KeyDown += txtTimDocGia_KeyDown;
            txtTimSach.KeyDown += txtTimSach_KeyDown;

            lstGoiYDocGia.Click += lstGoiYDocGia_Click;
            lstGoiYSach.Click += lstGoiYSach_Click;

            lstGoiYDocGia.KeyDown += lstGoiYDocGia_KeyDown;
            lstGoiYSach.KeyDown += lstGoiYSach_KeyDown;

            btnThemSach.Click += btnThemSach_Click;
            btnXoaSach.Click += btnXoaSach_Click;
            btnXacNhan.Click += btnXacNhan_Click;
            btnLamMoi.Click += btnLamMoi_Click;
        }

        private void TaoBangSachMuon()
        {
            danhSachSach = new DataTable();

            danhSachSach.Columns.Add("MaSach", typeof(string));
            danhSachSach.Columns.Add("TenSach", typeof(string));
            danhSachSach.Columns.Add("SoLuong", typeof(int));
            danhSachSach.Columns.Add("TonKho", typeof(int));

            dgvSachMuon.DataSource = danhSachSach;

            dgvSachMuon.Columns["MaSach"].HeaderText = "Mã sách";
            dgvSachMuon.Columns["TenSach"].HeaderText = "Tên sách";
            dgvSachMuon.Columns["SoLuong"].HeaderText = "Số lượng mượn";
            dgvSachMuon.Columns["TonKho"].HeaderText = "Tồn kho";

            dgvSachMuon.Columns["MaSach"].FillWeight = 70;
            dgvSachMuon.Columns["TenSach"].FillWeight = 200;
        }

        private void HienThiNhanVienDangNhap()
        {
            txtNhanVien.Text =
                maNhanVienDangNhap + " - " + hoTenDangNhap;

            txtNhanVien.ReadOnly = true;
            txtNhanVien.TabStop = false;
        }

        private void TaiDocGia()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT MaDocGia, HoTen, NgayHetHan
                    FROM DocGia
                    ORDER BY HoTen";

                using (SqlDataAdapter da =
                    new SqlDataAdapter(sql, conn))
                {
                    duLieuDocGia = new DataTable();
                    da.Fill(duLieuDocGia);
                }
            }

            duLieuDocGia.Columns.Add("HienThi", typeof(string));
            duLieuDocGia.Columns.Add("TuKhoa", typeof(string));

            foreach (DataRow row in duLieuDocGia.Rows)
            {
                string ma = row["MaDocGia"].ToString();
                string ten = row["HoTen"].ToString();

                row["HienThi"] = ma + " - " + ten;
                row["TuKhoa"] = ma + " " + ten;
            }

            viewGoiYDocGia = new DataView(duLieuDocGia);

            lstGoiYDocGia.DataSource = viewGoiYDocGia;
            lstGoiYDocGia.DisplayMember = "HienThi";
            lstGoiYDocGia.ValueMember = "MaDocGia";
            lstGoiYDocGia.Visible = false;
        }

        private void TaiSach()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT MaSach, TenSach, SoLuong
                    FROM Sach
                    WHERE SoLuong > 0
                    ORDER BY TenSach";

                using (SqlDataAdapter da =
                    new SqlDataAdapter(sql, conn))
                {
                    duLieuSach = new DataTable();
                    da.Fill(duLieuSach);
                }
            }

            duLieuSach.Columns.Add("HienThi", typeof(string));
            duLieuSach.Columns.Add("TuKhoa", typeof(string));

            foreach (DataRow row in duLieuSach.Rows)
            {
                string ma = row["MaSach"].ToString();
                string ten = row["TenSach"].ToString();

                row["HienThi"] = ma + " - " + ten;
                row["TuKhoa"] = ma + " " + ten;
            }

            viewGoiYSach = new DataView(duLieuSach);

            lstGoiYSach.DataSource = viewGoiYSach;
            lstGoiYSach.DisplayMember = "HienThi";
            lstGoiYSach.ValueMember = "MaSach";
            lstGoiYSach.Visible = false;
        }

        private string TaoDieuKienTimKiem(string tuKhoa)
        {
            if (string.IsNullOrWhiteSpace(tuKhoa))
                return "";

            string tuKhoaAnToan = tuKhoa.Trim()
                .Replace("'", "''")
                .Replace("[", "[[]")
                .Replace("%", "[%]")
                .Replace("*", "[*]");

            return "TuKhoa LIKE '%" + tuKhoaAnToan + "%'";
        }

        private void txtTimDocGia_TextChanged(
            object sender, EventArgs e)
        {
            if (dangChonDocGia || viewGoiYDocGia == null)
                return;

            maDocGiaDaChon = null;

            viewGoiYDocGia.RowFilter =
                TaoDieuKienTimKiem(txtTimDocGia.Text);

            lstGoiYDocGia.Visible =
                !string.IsNullOrWhiteSpace(txtTimDocGia.Text)
                && viewGoiYDocGia.Count > 0;

            if (lstGoiYDocGia.Visible)
            {
                lstGoiYDocGia.SelectedIndex = -1;
                lstGoiYDocGia.BringToFront();
            }
        }

        private void txtTimSach_TextChanged(
            object sender, EventArgs e)
        {
            if (dangChonSach || viewGoiYSach == null)
                return;

            maSachDaChon = "";

            viewGoiYSach.RowFilter =
                TaoDieuKienTimKiem(txtTimSach.Text);

            lstGoiYSach.Visible =
                !string.IsNullOrWhiteSpace(txtTimSach.Text)
                && viewGoiYSach.Count > 0;

            if (lstGoiYSach.Visible)
            {
                lstGoiYSach.SelectedIndex = -1;
                lstGoiYSach.BringToFront();
            }
        }

        private bool KiemTraHanThe(
            int maDocGia,
            string hoTen,
            bool hienThiCanhBao,
            SqlConnection conn = null,
            SqlTransaction transaction = null)
        {
            bool tuMoKetNoi = conn == null;

            if (tuMoKetNoi)
            {
                conn = Database.GetConnection();
                conn.Open();
            }

            try
            {
                string sql = @"
                    SELECT NgayHetHan
                    FROM DocGia
                    WHERE MaDocGia = @MaDocGia";

                using (SqlCommand cmd =
                    new SqlCommand(sql, conn, transaction))
                {
                    cmd.Parameters.Add("@MaDocGia", SqlDbType.Int)
                        .Value = maDocGia;

                    object ketQua = cmd.ExecuteScalar();

                    if (ketQua == null)
                    {
                        if (hienThiCanhBao)
                        {
                            ThongBao.Loi(
                                "Không tìm thấy độc giả trong hệ thống.");
                        }

                        return false;
                    }

                    if (ketQua == DBNull.Value)
                    {
                        if (hienThiCanhBao)
                        {
                            ThongBao.CanhBao(
                                "Độc giả: " + hoTen +
                                "\nThẻ chưa có ngày hết hạn." +
                                "\nVui lòng cập nhật thẻ trước khi mượn sách.");
                        }

                        return false;
                    }

                    DateTime ngayHetHan =
                        Convert.ToDateTime(ketQua).Date;

                    DateTime homNay = DateTime.Today;

                    if (ngayHetHan < homNay)
                    {
                        if (hienThiCanhBao)
                        {
                            ThongBao.CanhBao(
                                "THẺ ĐỘC GIẢ ĐÃ HẾT HẠN!" +
                                "\n\nĐộc giả: " + hoTen +
                                "\nMã độc giả: " + maDocGia +
                                "\nNgày hết hạn: " +
                                ngayHetHan.ToString("dd/MM/yyyy") +
                                "\n\nVui lòng gia hạn thẻ trước khi lập phiếu mượn.");
                        }

                        return false;
                    }

                    if (ngayHetHan <= homNay.AddDays(7))
                    {
                        if (hienThiCanhBao)
                        {
                            int soNgayConLai =
                                (ngayHetHan - homNay).Days;

                            ThongBao.CanhBao(
                                "THẺ ĐỘC GIẢ SẮP HẾT HẠN!" +
                                "\n\nĐộc giả: " + hoTen +
                                "\nNgày hết hạn: " +
                                ngayHetHan.ToString("dd/MM/yyyy") +
                                "\nCòn lại: " + soNgayConLai + " ngày." +
                                "\n\nBạn vẫn có thể lập phiếu mượn.");
                        }
                    }

                    return true;
                }
            }
            finally
            {
                if (tuMoKetNoi)
                    conn.Dispose();
            }
        }

        private void ChonDocGia()
        {
            if (!(lstGoiYDocGia.SelectedItem is DataRowView dong))
                return;

            int maDocGia = Convert.ToInt32(dong["MaDocGia"]);
            string hoTen = dong["HoTen"].ToString();

            lstGoiYDocGia.Visible = false;

            try
            {
                bool hopLe = KiemTraHanThe(
                    maDocGia,
                    hoTen,
                    true);

                if (!hopLe)
                {
                    maDocGiaDaChon = null;

                    dangChonDocGia = true;

                    try
                    {
                        txtTimDocGia.Clear();
                    }
                    finally
                    {
                        dangChonDocGia = false;
                    }

                    txtTimDocGia.Focus();
                    return;
                }

                dangChonDocGia = true;

                try
                {
                    maDocGiaDaChon = maDocGia;
                    txtTimDocGia.Text =
                        dong["HienThi"].ToString();

                    txtTimDocGia.Focus();

                    txtTimDocGia.SelectionStart =
                        txtTimDocGia.Text.Length;
                }
                finally
                {
                    dangChonDocGia = false;
                }
            }
            catch (Exception ex)
            {
                maDocGiaDaChon = null;

                ThongBao.Loi(
                    "Không thể kiểm tra thẻ độc giả:\n" +
                    ex.Message);
            }
        }

        private void ChonSach()
        {
            if (!(lstGoiYSach.SelectedItem is DataRowView dong))
                return;

            dangChonSach = true;

            try
            {
                maSachDaChon = dong["MaSach"].ToString();
                txtTimSach.Text = dong["HienThi"].ToString();

                lstGoiYSach.Visible = false;

                txtTimSach.Focus();

                txtTimSach.SelectionStart =
                    txtTimSach.Text.Length;
            }
            finally
            {
                dangChonSach = false;
            }
        }

        private void lstGoiYDocGia_Click(
            object sender, EventArgs e)
        {
            ChonDocGia();
        }

        private void lstGoiYSach_Click(
            object sender, EventArgs e)
        {
            ChonSach();
        }

        private void txtTimDocGia_KeyDown(
            object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter &&
                lstGoiYDocGia.Visible &&
                lstGoiYDocGia.Items.Count > 0)
            {
                lstGoiYDocGia.SelectedIndex = 0;
                ChonDocGia();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Down &&
                     lstGoiYDocGia.Visible &&
                     lstGoiYDocGia.Items.Count > 0)
            {
                lstGoiYDocGia.Focus();
                lstGoiYDocGia.SelectedIndex = 0;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                lstGoiYDocGia.Visible = false;
            }
        }

        private void txtTimSach_KeyDown(
            object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter &&
                lstGoiYSach.Visible &&
                lstGoiYSach.Items.Count > 0)
            {
                lstGoiYSach.SelectedIndex = 0;
                ChonSach();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Down &&
                     lstGoiYSach.Visible &&
                     lstGoiYSach.Items.Count > 0)
            {
                lstGoiYSach.Focus();
                lstGoiYSach.SelectedIndex = 0;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                lstGoiYSach.Visible = false;
            }
        }

        private void lstGoiYDocGia_KeyDown(
            object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ChonDocGia();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                lstGoiYDocGia.Visible = false;
                txtTimDocGia.Focus();
            }
        }

        private void lstGoiYSach_KeyDown(
            object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ChonSach();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                lstGoiYSach.Visible = false;
                txtTimSach.Focus();
            }
        }

        private void btnThemSach_Click(
            object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maSachDaChon))
            {
                ThongBao.CanhBao(
                    "Vui lòng chọn sách từ danh sách gợi ý.");

                txtTimSach.Focus();
                return;
            }

            DataRow[] ketQua = duLieuSach.Select(
                "MaSach = '" +
                maSachDaChon.Replace("'", "''") + "'");

            if (ketQua.Length == 0)
            {
                ThongBao.Loi(
                    "Không tìm thấy thông tin sách.");
                return;
            }

            DataRow sach = ketQua[0];

            string maSach = sach["MaSach"].ToString();
            string tenSach = sach["TenSach"].ToString();

            int tonKho = Convert.ToInt32(sach["SoLuong"]);
            int soLuong = Convert.ToInt32(numSoLuong.Value);

            if (soLuong <= 0)
            {
                ThongBao.CanhBao(
                    "Số lượng mượn phải lớn hơn 0.");
                return;
            }

            DataRow dongCu = null;

            foreach (DataRow row in danhSachSach.Rows)
            {
                if (row["MaSach"].ToString() == maSach)
                {
                    dongCu = row;
                    break;
                }
            }

            int tongMuon = soLuong;

            if (dongCu != null)
                tongMuon += Convert.ToInt32(dongCu["SoLuong"]);

            if (tongMuon > tonKho)
            {
                ThongBao.CanhBao(
                    "Số lượng mượn vượt quá số lượng còn trong kho.");
                return;
            }

            if (dongCu == null)
            {
                danhSachSach.Rows.Add(
                    maSach, tenSach, soLuong, tonKho);
            }
            else
            {
                dongCu["SoLuong"] = tongMuon;
            }

            CapNhatTongSoLuong();

            dangChonSach = true;

            try
            {
                txtTimSach.Clear();
            }
            finally
            {
                dangChonSach = false;
            }

            maSachDaChon = "";
            lstGoiYSach.Visible = false;
            viewGoiYSach.RowFilter = "";

            numSoLuong.Value = 1;
        }

        private void btnXoaSach_Click(
            object sender, EventArgs e)
        {
            if (dgvSachMuon.CurrentRow == null ||
                dgvSachMuon.CurrentRow.Index < 0)
            {
                ThongBao.CanhBao(
                    "Vui lòng chọn sách cần xóa.");
                return;
            }

            int index = dgvSachMuon.CurrentRow.Index;

            if (index < danhSachSach.Rows.Count)
            {
                danhSachSach.Rows.RemoveAt(index);
                CapNhatTongSoLuong();
            }
        }

        private void CapNhatTongSoLuong()
        {
            int tong = 0;

            foreach (DataRow row in danhSachSach.Rows)
            {
                tong += Convert.ToInt32(row["SoLuong"]);
            }

            lblTongSoLuong.Text =
                "Tổng số lượng: " + tong;
        }

        private void btnXacNhan_Click(
            object sender, EventArgs e)
        {
            if (maDocGiaDaChon == null)
            {
                ThongBao.CanhBao(
                    "Vui lòng chọn độc giả từ danh sách gợi ý.");

                txtTimDocGia.Focus();
                return;
            }

            if (maNhanVienDangNhap <= 0)
            {
                ThongBao.CanhBao(
                    "Không xác định được nhân viên đăng nhập.");
                return;
            }

            if (danhSachSach.Rows.Count == 0)
            {
                ThongBao.CanhBao(
                    "Vui lòng thêm ít nhất một cuốn sách.");
                return;
            }

            if (dtpHanTra.Value.Date < dtpNgayMuon.Value.Date)
            {
                ThongBao.CanhBao(
                    "Hạn trả không được trước ngày mượn.");
                return;
            }

            if (dtpNgayMuon.Value.Date < DateTime.Today)
            {
                ThongBao.CanhBao(
                    "Ngày mượn không được trước ngày hiện tại.");
                return;
            }

            int maDocGia = maDocGiaDaChon.Value;

            string hoTenDocGia = "";

            if (duLieuDocGia != null)
            {
                foreach (DataRow row in duLieuDocGia.Rows)
                {
                    if (Convert.ToInt32(row["MaDocGia"]) == maDocGia)
                    {
                        hoTenDocGia = row["HoTen"].ToString();
                        break;
                    }
                }
            }

            try
            {
                bool hopLe = KiemTraHanThe(
                    maDocGia,
                    hoTenDocGia,
                    true);

                if (!hopLe)
                {
                    maDocGiaDaChon = null;
                    txtTimDocGia.Clear();
                    txtTimDocGia.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                ThongBao.Loi(
                    "Không thể kiểm tra thẻ độc giả:\n" +
                    ex.Message);
                return;
            }

            using (SqlConnection conn = Database.GetConnection())
            {
                try
                {
                    conn.Open();

                    using (SqlTransaction transaction =
                        conn.BeginTransaction(IsolationLevel.Serializable))
                    {
                        try
                        {
                            string sqlKiemTra = @"
                                SELECT NgayHetHan
                                FROM DocGia WITH (UPDLOCK, HOLDLOCK)
                                WHERE MaDocGia = @MaDocGia";

                            using (SqlCommand cmd =
                                new SqlCommand(
                                    sqlKiemTra, conn, transaction))
                            {
                                cmd.Parameters.Add(
                                    "@MaDocGia", SqlDbType.Int)
                                    .Value = maDocGia;

                                object ketQua = cmd.ExecuteScalar();

                                if (ketQua == null ||
                                    ketQua == DBNull.Value)
                                {
                                    throw new Exception(
                                        "Thẻ độc giả không hợp lệ hoặc chưa có ngày hết hạn.");
                                }

                                DateTime ngayHetHan =
                                    Convert.ToDateTime(ketQua).Date;

                                if (ngayHetHan < DateTime.Today)
                                {
                                    throw new Exception(
                                        "Thẻ độc giả đã hết hạn ngày " +
                                        ngayHetHan.ToString("dd/MM/yyyy") +
                                        ". Vui lòng gia hạn trước khi mượn sách.");
                                }
                            }

                            string sqlPhieu = @"
                                INSERT INTO PhieuMuon
                                (MaDocGia, MaNhanVien, NgayMuon, HanTra)
                                OUTPUT INSERTED.MaPhieuMuon
                                VALUES
                                (@MaDocGia, @MaNhanVien, @NgayMuon, @HanTra)";

                            int maPhieuMuon;

                            using (SqlCommand cmd =
                                new SqlCommand(
                                    sqlPhieu, conn, transaction))
                            {
                                cmd.Parameters.Add(
                                    "@MaDocGia", SqlDbType.Int)
                                    .Value = maDocGia;

                                cmd.Parameters.Add(
                                    "@MaNhanVien", SqlDbType.Int)
                                    .Value = maNhanVienDangNhap;

                                cmd.Parameters.Add(
                                    "@NgayMuon", SqlDbType.Date)
                                    .Value = dtpNgayMuon.Value.Date;

                                cmd.Parameters.Add(
                                    "@HanTra", SqlDbType.Date)
                                    .Value = dtpHanTra.Value.Date;

                                maPhieuMuon =
                                    Convert.ToInt32(cmd.ExecuteScalar());
                            }

                            foreach (DataRow row in danhSachSach.Rows)
                            {
                                string maSach =
                                    row["MaSach"].ToString();

                                int soLuong =
                                    Convert.ToInt32(row["SoLuong"]);

                                string sqlTruKho = @"
                                    UPDATE Sach
                                    SET SoLuong = SoLuong - @SoLuong
                                    WHERE MaSach = @MaSach
                                      AND SoLuong >= @SoLuong";

                                using (SqlCommand cmd =
                                    new SqlCommand(
                                        sqlTruKho, conn, transaction))
                                {
                                    cmd.Parameters.Add(
                                        "@MaSach",
                                        SqlDbType.NVarChar, 40)
                                        .Value = maSach;

                                    cmd.Parameters.Add(
                                        "@SoLuong", SqlDbType.Int)
                                        .Value = soLuong;

                                    if (cmd.ExecuteNonQuery() == 0)
                                    {
                                        throw new Exception(
                                            "Sách mã " + maSach +
                                            " không đủ số lượng trong kho.");
                                    }
                                }

                                string sqlChiTiet = @"
                                    INSERT INTO ChiTietMuon
                                    (MaPhieuMuon, MaSach, SoLuong, NgayTra, TrangThai)
                                    VALUES
                                    (@MaPhieuMuon, @MaSach, @SoLuong, NULL, @TrangThai)";

                                using (SqlCommand cmd =
                                    new SqlCommand(
                                        sqlChiTiet, conn, transaction))
                                {
                                    cmd.Parameters.Add(
                                        "@MaPhieuMuon", SqlDbType.Int)
                                        .Value = maPhieuMuon;

                                    cmd.Parameters.Add(
                                        "@MaSach",
                                        SqlDbType.NVarChar, 40)
                                        .Value = maSach;

                                    cmd.Parameters.Add(
                                        "@SoLuong", SqlDbType.Int)
                                        .Value = soLuong;

                                    cmd.Parameters.Add(
                                        "@TrangThai",
                                        SqlDbType.NVarChar, 60)
                                        .Value = "Đang mượn";

                                    cmd.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();

                            ThongBao.ThanhCong(
                                "Lập phiếu mượn thành công!\n" +
                                "Mã phiếu: " + maPhieuMuon);

                            LamMoi();
                        }
                        catch (Exception ex)
                        {
                            try
                            {
                                transaction.Rollback();
                            }
                            catch
                            {
                            }

                            ThongBao.Loi(
                                "Không thể lập phiếu mượn:\n" +
                                ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ThongBao.Loi(
                        "Lỗi kết nối cơ sở dữ liệu:\n" +
                        ex.Message);
                }
            }
        }

        private void btnLamMoi_Click(
            object sender, EventArgs e)
        {
            LamMoi();
        }

        private void LamMoi()
        {
            danhSachSach.Clear();

            maDocGiaDaChon = null;
            maSachDaChon = "";

            dangChonDocGia = true;

            try
            {
                txtTimDocGia.Clear();
            }
            finally
            {
                dangChonDocGia = false;
            }

            dangChonSach = true;

            try
            {
                txtTimSach.Clear();
            }
            finally
            {
                dangChonSach = false;
            }

            if (viewGoiYDocGia != null)
                viewGoiYDocGia.RowFilter = "";

            if (viewGoiYSach != null)
                viewGoiYSach.RowFilter = "";

            lstGoiYDocGia.Visible = false;
            lstGoiYSach.Visible = false;

            numSoLuong.Value = 1;

            dtpNgayMuon.Value = DateTime.Today;
            dtpHanTra.Value = DateTime.Today.AddDays(7);

            CapNhatTongSoLuong();
            HienThiNhanVienDangNhap();
        }
    }
}
