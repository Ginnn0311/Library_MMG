
using Library.DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Library
{
    public partial class frmChiTietMuon : Form
    {
        public frmChiTietMuon()
        {
            InitializeComponent();

            cboTimTheo.Items.Clear();
            cboTimTheo.Items.AddRange(new object[]
            {
                "Tất cả các cột",
                "Mã phiếu mượn",
                "Mã sách",
                "Tên sách",
                "Số lượng",
                "Ngày mượn",
                "Hạn trả",
                "Ngày trả",
                "Trạng thái",
                "Tình trạng hạn trả"
            });

            cboTimTheo.SelectedIndex = 0;

            cboTimTheo.SelectedIndexChanged +=
                (s, e) => LoadChiTietMuon(txtTimKiem.Text);

            txtTimKiem.TextChanged +=
                (s, e) => LoadChiTietMuon(txtTimKiem.Text);
        }

        private void frmChiTietMuon_Load(object sender, EventArgs e)
        {
            LoadChiTietMuon();
        }

        private int TinhSoNgayTre(DateTime hanTra, DateTime ngayTra)
        {
            return Math.Max(0, (ngayTra.Date - hanTra.Date).Days);
        }

        private void LoadChiTietMuon(string tuKhoa = "")
        {
            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    string sql = @"
                        SELECT
                            ct.MaChiTiet,
                            pm.MaPhieuMuon,
                            ct.MaSach,
                            s.TenSach,
                            ct.SoLuong,
                            pm.NgayMuon,
                            pm.HanTra,
                            ct.NgayTra,
                            ct.TrangThai
                        FROM ChiTietMuon ct
                        INNER JOIN PhieuMuon pm
                            ON ct.MaPhieuMuon = pm.MaPhieuMuon
                        INNER JOIN Sach s
                            ON ct.MaSach = s.MaSach
                        ORDER BY pm.MaPhieuMuon DESC";

                    DataTable dt = new DataTable();

                    using (SqlDataAdapter adapter =
                        new SqlDataAdapter(sql, conn))
                    {
                        adapter.Fill(dt);
                    }

                    dt.Columns.Add("TinhTrangHanTra", typeof(string));

                    foreach (DataRow row in dt.Rows)
                    {
                        DateTime hanTra =
                            Convert.ToDateTime(row["HanTra"]);

                        bool daTra = row["NgayTra"] != DBNull.Value;

                        if (daTra)
                        {
                            DateTime ngayTra =
                                Convert.ToDateTime(row["NgayTra"]);

                            int soNgayTre =
                                TinhSoNgayTre(hanTra, ngayTra);

                            row["TinhTrangHanTra"] = soNgayTre > 0
                                ? $"Đã trả trễ {soNgayTre} ngày"
                                : "Đã trả đúng hạn";
                        }
                        else
                        {
                            int soNgayTre =
                                TinhSoNgayTre(hanTra, DateTime.Now);

                            row["TinhTrangHanTra"] = soNgayTre > 0
                                ? $"Quá hạn {soNgayTre} ngày"
                                : "Còn hạn";
                        }
                    }

                    string cotTim =
                        cboTimTheo.SelectedItem?.ToString()
                        ?? "Tất cả các cột";

                    string keyword = tuKhoa.Trim();

                    if (!string.IsNullOrWhiteSpace(keyword))
                    {
                        DataTable ketQua = dt.Clone();

                        string[] cacCot = cotTim switch
                        {
                            "Mã phiếu mượn" => new[] { "MaPhieuMuon" },
                            "Mã sách" => new[] { "MaSach" },
                            "Tên sách" => new[] { "TenSach" },
                            "Số lượng" => new[] { "SoLuong" },
                            "Ngày mượn" => new[] { "NgayMuon" },
                            "Hạn trả" => new[] { "HanTra" },
                            "Ngày trả" => new[] { "NgayTra" },
                            "Trạng thái" => new[] { "TrangThai" },
                            "Tình trạng hạn trả" =>
                                new[] { "TinhTrangHanTra" },
                            _ => new[]
                            {
                                "MaPhieuMuon",
                                "MaSach",
                                "TenSach",
                                "SoLuong",
                                "NgayMuon",
                                "HanTra",
                                "NgayTra",
                                "TrangThai",
                                "TinhTrangHanTra"
                            }
                        };

                        foreach (DataRow row in dt.Rows)
                        {
                            foreach (string cot in cacCot)
                            {
                                if (row[cot] == DBNull.Value)
                                    continue;

                                string giaTri = row[cot] is DateTime ngay
                                    ? ngay.ToString("dd/MM/yyyy")
                                    : Convert.ToString(row[cot]) ?? "";

                                if (giaTri.Contains(
                                    keyword,
                                    StringComparison.OrdinalIgnoreCase))
                                {
                                    ketQua.ImportRow(row);
                                    break;
                                }
                            }
                        }

                        dgvChiTietMuon.DataSource = ketQua;
                    }
                    else
                    {
                        dgvChiTietMuon.DataSource = dt;
                    }
                }

                DinhDangBang();
                ToMauTrangThai();
            }
            catch (Exception ex)
            {
                ThongBao.Loi(
                    "Không thể tải danh sách chi tiết mượn.\n"
                    + ex.Message);
            }
        }

        private void DinhDangBang()
        {
            if (dgvChiTietMuon.Columns.Count == 0)
                return;

            dgvChiTietMuon.Columns["MaChiTiet"].Visible = false;

            dgvChiTietMuon.Columns["MaPhieuMuon"].HeaderText =
                "Mã phiếu mượn";

            dgvChiTietMuon.Columns["MaSach"].HeaderText =
                "Mã sách";

            dgvChiTietMuon.Columns["TenSach"].HeaderText =
                "Tên sách";

            dgvChiTietMuon.Columns["SoLuong"].HeaderText =
                "Số lượng";

            dgvChiTietMuon.Columns["NgayMuon"].HeaderText =
                "Ngày mượn";

            dgvChiTietMuon.Columns["HanTra"].HeaderText =
                "Hạn trả";

            dgvChiTietMuon.Columns["NgayTra"].HeaderText =
                "Ngày trả";

            dgvChiTietMuon.Columns["TrangThai"].HeaderText =
                "Trạng thái";

            dgvChiTietMuon.Columns["TinhTrangHanTra"].HeaderText =
                "Tình trạng hạn trả";

            foreach (string cot in new[]
            {
                "NgayMuon", "HanTra", "NgayTra"
            })
            {
                dgvChiTietMuon.Columns[cot]
                    .DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            dgvChiTietMuon.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(100, 88, 255);

            dgvChiTietMuon.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvChiTietMuon.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);

            dgvChiTietMuon.EnableHeadersVisualStyles = false;

            dgvChiTietMuon.DefaultCellStyle.Font =
                new Font("Segoe UI", 9F);

            dgvChiTietMuon.RowTemplate.Height = 32;
        }

        private void ToMauTrangThai()
        {
            foreach (DataGridViewRow row in dgvChiTietMuon.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string tinhTrang = Convert.ToString(
                    row.Cells["TinhTrangHanTra"].Value) ?? "";

                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.ForeColor =
                    Color.FromArgb(31, 41, 55);

                if (tinhTrang.StartsWith("Quá hạn"))
                {
                    row.DefaultCellStyle.BackColor =
                        Color.FromArgb(254, 226, 226);

                    row.DefaultCellStyle.ForeColor =
                        Color.FromArgb(153, 27, 27);
                }
                else if (tinhTrang.StartsWith("Đã trả trễ"))
                {
                    row.DefaultCellStyle.BackColor =
                        Color.FromArgb(255, 237, 213);

                    row.DefaultCellStyle.ForeColor =
                        Color.FromArgb(154, 52, 18);
                }
                else if (tinhTrang == "Đã trả đúng hạn")
                {
                    row.DefaultCellStyle.BackColor =
                        Color.FromArgb(220, 252, 231);

                    row.DefaultCellStyle.ForeColor =
                        Color.FromArgb(22, 101, 52);
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadChiTietMuon(txtTimKiem.Text);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            cboTimTheo.SelectedIndex = 0;
            LoadChiTietMuon();
        }

        private void dgvChiTietMuon_CellClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvChiTietMuon.ClearSelection();
                dgvChiTietMuon.Rows[e.RowIndex].Selected = true;
            }
        }

        private void btnTraSach_Click(object sender, EventArgs e)
        {
            if (dgvChiTietMuon.CurrentRow == null ||
                dgvChiTietMuon.CurrentRow.IsNewRow)
            {
                ThongBao.CanhBao("Vui lòng chọn sách cần trả!");
                return;
            }

            DataGridViewRow row = dgvChiTietMuon.CurrentRow;

            int maChiTiet = Convert.ToInt32(
                row.Cells["MaChiTiet"].Value);

            string maSach = Convert.ToString(
                row.Cells["MaSach"].Value) ?? "";

            int soLuong = Convert.ToInt32(
                row.Cells["SoLuong"].Value);

            string tenSach = Convert.ToString(
                row.Cells["TenSach"].Value) ?? "";

            string trangThai = Convert.ToString(
                row.Cells["TrangThai"].Value) ?? "";

            DateTime hanTra = Convert.ToDateTime(
                row.Cells["HanTra"].Value);

            if (trangThai != "Đang mượn" ||
                (row.Cells["NgayTra"].Value != DBNull.Value &&
                 row.Cells["NgayTra"].Value != null))
            {
                ThongBao.ThongTin("Sách này đã được trả trước đó!");
                return;
            }

            int soNgayTreDuKien =
                TinhSoNgayTre(hanTra, DateTime.Now);

            string noiDungXacNhan =
                $"Xác nhận trả sách:\n{tenSach}\nSố lượng: {soLuong}";

            if (soNgayTreDuKien > 0)
            {
                noiDungXacNhan +=
                    $"\nSách đã quá hạn {soNgayTreDuKien} ngày.";
            }

            if (!ThongBao.XacNhan(
                noiDungXacNhan, "Xác nhận trả sách"))
            {
                return;
            }

            try
            {
                DateTime ngayTraThucTe;

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    using (SqlTransaction transaction =
                        conn.BeginTransaction())
                    {
                        try
                        {
                            string sqlTraSach = @"
                                UPDATE ChiTietMuon
                                SET NgayTra = GETDATE(),
                                    TrangThai = N'Đã trả',
                                    SoLuongDaTra = SoLuong
                                OUTPUT INSERTED.NgayTra
                                WHERE MaChiTiet = @MaChiTiet
                                  AND TrangThai = N'Đang mượn'
                                  AND NgayTra IS NULL";

                            using (SqlCommand cmd = new SqlCommand(
                                sqlTraSach, conn, transaction))
                            {
                                cmd.Parameters.Add(
                                    "@MaChiTiet", SqlDbType.Int)
                                    .Value = maChiTiet;

                                object ketQua = cmd.ExecuteScalar();

                                if (ketQua == null ||
                                    ketQua == DBNull.Value)
                                {
                                    throw new Exception(
                                        "Chi tiết mượn này đã được xử lý trả sách.");
                                }

                                ngayTraThucTe =
                                    Convert.ToDateTime(ketQua);
                            }

                            string sqlCongKho = @"
                                UPDATE Sach
                                SET SoLuong = SoLuong + @SoLuong
                                WHERE MaSach = @MaSach";

                            using (SqlCommand cmd = new SqlCommand(
                                sqlCongKho, conn, transaction))
                            {
                                cmd.Parameters.Add(
                                    "@SoLuong", SqlDbType.Int)
                                    .Value = soLuong;

                                cmd.Parameters.Add(
                                    "@MaSach", SqlDbType.NVarChar, 40)
                                    .Value = maSach;

                                if (cmd.ExecuteNonQuery() == 0)
                                {
                                    throw new Exception(
                                        "Không tìm thấy sách trong kho.");
                                }
                            }

                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }

                int soNgayTre =
                    TinhSoNgayTre(hanTra, ngayTraThucTe);

                if (soNgayTre > 0)
                {
                    ThongBao.CanhBao(
                        $"Trả sách thành công!\nSách đã trễ hạn {soNgayTre} ngày.",
                        "Trả sách trễ hạn");
                }
                else
                {
                    ThongBao.ThanhCong("Trả sách thành công!");
                }

                LoadChiTietMuon(txtTimKiem.Text);
            }
            catch (Exception ex)
            {
                ThongBao.Loi(
                    "Không thể trả sách.\n" + ex.Message);
            }
        }

        private void btnSachQuaHan_Click(object sender, EventArgs e)
        {
            using (frmSachQuaHan frm = new frmSachQuaHan())
            {
                frm.ShowDialog(this);
            }

            LoadChiTietMuon(txtTimKiem.Text);
        }
    }
}
