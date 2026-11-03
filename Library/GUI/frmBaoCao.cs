
using Library.DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Library
{
    public partial class frmBaoCao : Form
    {
        private DataTable duLieuChiTiet = new DataTable();

        public frmBaoCao()
        {
            InitializeComponent();

            Load += frmBaoCao_Load;
            btnThongKe.Click += btnThongKe_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnXuatExcel.Click += btnXuatExcel_Click;

            cboLoaiBaoCao.SelectedIndex = 0;
            dtpTuNgay.Value = new DateTime(DateTime.Today.Year, 1, 1);
            dtpDenNgay.Value = DateTime.Today;
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            TaiBaoCao();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            TaiBaoCao();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dtpTuNgay.Value = new DateTime(DateTime.Today.Year, 1, 1);
            dtpDenNgay.Value = DateTime.Today;
            cboLoaiBaoCao.SelectedIndex = 0;

            TaiBaoCao();
        }

        private void TaiBaoCao()
        {
            if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
            {
                ThongBao.CanhBao(
                    "Ngày bắt đầu không được lớn hơn ngày kết thúc.");
                return;
            }

            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    TaiThongKeTongQuan(conn);
                    TaiBieuDo(conn);
                    TaiDanhSach(conn);
                }
            }
            catch (Exception ex)
            {
                ThongBao.Loi("Không thể tải báo cáo:\n" + ex.Message);
            }
        }

        private int LaySo(SqlConnection conn, string sql)
        {
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                object ketQua = cmd.ExecuteScalar();

                return ketQua == null || ketQua == DBNull.Value
                    ? 0
                    : Convert.ToInt32(ketQua);
            }
        }

        private void TaiThongKeTongQuan(SqlConnection conn)
        {
            lblTongSach.Text = LaySo(conn,
                "SELECT ISNULL(SUM(SoLuong), 0) FROM Sach")
                .ToString("N0");

            lblTongDocGia.Text = LaySo(conn,
                "SELECT COUNT(*) FROM DocGia")
                .ToString("N0");

            lblTongPhieuMuon.Text = LaySo(conn,
                "SELECT COUNT(*) FROM PhieuMuon")
                .ToString("N0");

            lblSachDangMuon.Text = LaySo(conn, @"
                SELECT ISNULL(SUM(
                    CASE
                        WHEN SoLuong > ISNULL(SoLuongDaTra, 0)
                        THEN SoLuong - ISNULL(SoLuongDaTra, 0)
                        ELSE 0
                    END
                ), 0)
                FROM ChiTietMuon").ToString("N0");

            lblPhieuSapHan.Text = LaySo(conn, @"
                SELECT COUNT(DISTINCT pm.MaPhieuMuon)
                FROM PhieuMuon pm
                INNER JOIN ChiTietMuon ct
                    ON pm.MaPhieuMuon = ct.MaPhieuMuon
                WHERE pm.HanTra >= CAST(GETDATE() AS DATE)
                  AND pm.HanTra <= DATEADD(
                      DAY, 3, CAST(GETDATE() AS DATE))
                  AND ct.SoLuong > ISNULL(ct.SoLuongDaTra, 0)
            ").ToString("N0");

            lblPhieuQuaHan.Text = LaySo(conn, @"
                SELECT COUNT(DISTINCT pm.MaPhieuMuon)
                FROM PhieuMuon pm
                INNER JOIN ChiTietMuon ct
                    ON pm.MaPhieuMuon = ct.MaPhieuMuon
                WHERE pm.HanTra < CAST(GETDATE() AS DATE)
                  AND ct.SoLuong > ISNULL(ct.SoLuongDaTra, 0)
            ").ToString("N0");
        }

        private void TaiBieuDo(SqlConnection conn)
        {
            chartMuonSach.Series.Clear();
            chartMuonSach.ChartAreas.Clear();
            chartMuonSach.Legends.Clear();
            chartMuonSach.Titles.Clear();

            chartMuonSach.BackColor = Color.White;
            chartMuonSach.BorderlineWidth = 0;

            ChartArea area = new ChartArea("ThongKe");
            area.BackColor = Color.White;

            area.AxisX.Interval = 1;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisX.MajorTickMark.Enabled = false;
            area.AxisX.LineColor = Color.FromArgb(210, 220, 235);
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 9F);
            area.AxisX.LabelStyle.ForeColor = Color.FromArgb(70, 85, 110);
            area.AxisX.LabelStyle.Angle = 0;

            area.AxisY.Minimum = 0;
            area.AxisY.Interval = 1;
            area.AxisY.IsStartedFromZero = true;
            area.AxisY.MajorGrid.LineColor = Color.FromArgb(235, 239, 245);
            area.AxisY.MajorTickMark.Enabled = false;
            area.AxisY.LineColor = Color.Transparent;
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 9F);
            area.AxisY.LabelStyle.ForeColor = Color.FromArgb(70, 85, 110);

            chartMuonSach.ChartAreas.Add(area);

            Series series = new Series("Số phiếu mượn");
            series.ChartType = SeriesChartType.Column;
            series.Color = Color.FromArgb(59, 130, 246);
            series.BorderWidth = 0;
            series.IsValueShownAsLabel = false;
            series["PointWidth"] = "0.5";
            series.XValueType = ChartValueType.Int32;

            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date;

            DateTime thangDau = new DateTime(tuNgay.Year, tuNgay.Month, 1);
            DateTime thangCuoi = new DateTime(denNgay.Year, denNgay.Month, 1);

            DataTable thongKe = new DataTable();

            string sql = @"
                SELECT
                    YEAR(NgayMuon) AS Nam,
                    MONTH(NgayMuon) AS Thang,
                    COUNT(*) AS SoPhieu
                FROM PhieuMuon
                WHERE NgayMuon >= @TuNgay
                  AND NgayMuon < DATEADD(DAY, 1, @DenNgay)
                GROUP BY YEAR(NgayMuon), MONTH(NgayMuon)
                ORDER BY Nam, Thang";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@TuNgay", SqlDbType.Date).Value = tuNgay;
                cmd.Parameters.Add("@DenNgay", SqlDbType.Date).Value = denNgay;

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(thongKe);
                }
            }

            int soThang = (thangCuoi.Year - thangDau.Year) * 12
                + thangCuoi.Month - thangDau.Month + 1;

            if (soThang > 36)
            {
                chartMuonSach.Titles.Add(
                    "Khoảng thời gian quá dài. Hãy chọn tối đa 36 tháng.");
                chartMuonSach.Invalidate();
                return;
            }

            int giaTriLonNhat = 0;

            for (int i = 0; i < soThang; i++)
            {
                DateTime thangHienTai = thangDau.AddMonths(i);
                int soPhieu = 0;

                foreach (DataRow row in thongKe.Rows)
                {
                    int nam = Convert.ToInt32(row["Nam"]);
                    int thang = Convert.ToInt32(row["Thang"]);

                    if (nam == thangHienTai.Year &&
                        thang == thangHienTai.Month)
                    {
                        soPhieu = Convert.ToInt32(row["SoPhieu"]);
                        break;
                    }
                }

                DataPoint point = new DataPoint();
                point.XValue = i + 1;
                point.YValues = new double[] { soPhieu };

                point.AxisLabel = soThang <= 12
                    ? thangHienTai.ToString("MM/yyyy")
                    : thangHienTai.ToString("MM/yy");

                point.Color = Color.FromArgb(59, 130, 246);
                point.ToolTip =
                    thangHienTai.ToString("MM/yyyy") +
                    ": " + soPhieu + " phiếu mượn";

                if (soPhieu > 0)
                {
                    point.IsValueShownAsLabel = true;
                    point.Label = soPhieu.ToString();
                    point.LabelForeColor = Color.FromArgb(29, 67, 120);
                    point.Font = new Font(
                        "Segoe UI", 9F, FontStyle.Bold);
                }

                series.Points.Add(point);

                if (soPhieu > giaTriLonNhat)
                    giaTriLonNhat = soPhieu;
            }

            area.AxisX.Minimum = 0.5;
            area.AxisX.Maximum = soThang + 0.5;
            area.AxisY.Maximum = Math.Max(5, giaTriLonNhat + 2);

            if (soThang > 12)
            {
                area.AxisX.LabelStyle.Angle = -45;
                area.AxisX.Interval = soThang > 24 ? 3 : 2;
            }

            chartMuonSach.Series.Add(series);
            chartMuonSach.Invalidate();
        }

        private void TaiDanhSach(SqlConnection conn)
        {
            string dieuKien = "";

            if (cboLoaiBaoCao.SelectedIndex == 1)
            {
                dieuKien = @"
                    AND pm.HanTra >= CAST(GETDATE() AS DATE)
                    AND pm.HanTra <= DATEADD(
                        DAY, 3, CAST(GETDATE() AS DATE))";
            }
            else if (cboLoaiBaoCao.SelectedIndex == 2)
            {
                dieuKien = @"
                    AND pm.HanTra < CAST(GETDATE() AS DATE)";
            }

            string sql = @"
                SELECT
                    pm.MaPhieuMuon AS [Mã phiếu],
                    dg.HoTen AS [Độc giả],
                    pm.NgayMuon AS [Ngày mượn],
                    pm.HanTra AS [Hạn trả],
                    SUM(ct.SoLuong) AS [Số lượng mượn],
                    SUM(ISNULL(ct.SoLuongDaTra, 0)) AS [Đã trả],
                    SUM(
                        CASE
                            WHEN ct.SoLuong > ISNULL(ct.SoLuongDaTra, 0)
                            THEN ct.SoLuong - ISNULL(ct.SoLuongDaTra, 0)
                            ELSE 0
                        END
                    ) AS [Chưa trả],
                    CASE
                        WHEN pm.HanTra < CAST(GETDATE() AS DATE)
                            THEN N'Quá hạn'
                        WHEN pm.HanTra <= DATEADD(
                            DAY, 3, CAST(GETDATE() AS DATE))
                            THEN N'Sắp đến hạn'
                        ELSE N'Đang mượn'
                    END AS [Trạng thái]
                FROM PhieuMuon pm
                INNER JOIN DocGia dg
                    ON pm.MaDocGia = dg.MaDocGia
                INNER JOIN ChiTietMuon ct
                    ON pm.MaPhieuMuon = ct.MaPhieuMuon
                WHERE pm.NgayMuon >= @TuNgay
                  AND pm.NgayMuon < DATEADD(DAY, 1, @DenNgay)
                " + dieuKien + @"
                GROUP BY
                    pm.MaPhieuMuon,
                    dg.HoTen,
                    pm.NgayMuon,
                    pm.HanTra
                HAVING SUM(
                    CASE
                        WHEN ct.SoLuong > ISNULL(ct.SoLuongDaTra, 0)
                        THEN ct.SoLuong - ISNULL(ct.SoLuongDaTra, 0)
                        ELSE 0
                    END
                ) > 0
                ORDER BY pm.HanTra ASC";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@TuNgay", SqlDbType.Date)
                    .Value = dtpTuNgay.Value.Date;

                cmd.Parameters.Add("@DenNgay", SqlDbType.Date)
                    .Value = dtpDenNgay.Value.Date;

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    duLieuChiTiet = new DataTable();
                    adapter.Fill(duLieuChiTiet);
                    dgvBaoCao.DataSource = duLieuChiTiet;
                }
            }

            dgvBaoCao.ReadOnly = true;
            dgvBaoCao.AllowUserToAddRows = false;
            dgvBaoCao.AllowUserToDeleteRows = false;
            dgvBaoCao.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvBaoCao.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            foreach (string tenCot in new[] { "Ngày mượn", "Hạn trả" })
            {
                if (dgvBaoCao.Columns.Contains(tenCot))
                {
                    dgvBaoCao.Columns[tenCot]
                        .DefaultCellStyle.Format = "dd/MM/yyyy";
                }
            }

            lblSoDong.Text =
                "Tổng cộng: " + duLieuChiTiet.Rows.Count + " phiếu";
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (duLieuChiTiet.Rows.Count == 0)
            {
                ThongBao.CanhBao("Không có dữ liệu để xuất.");
                return;
            }

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "CSV mở bằng Excel (*.csv)|*.csv";
                dialog.FileName =
                    "BaoCaoThuVien_" +
                    DateTime.Now.ToString("yyyyMMdd_HHmmss") +
                    ".csv";

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    using (StreamWriter writer = new StreamWriter(
                        dialog.FileName, false, new UTF8Encoding(true)))
                    {
                        string[] headers =
                            new string[duLieuChiTiet.Columns.Count];

                        for (int i = 0; i < headers.Length; i++)
                        {
                            headers[i] = Csv(
                                duLieuChiTiet.Columns[i].ColumnName);
                        }

                        writer.WriteLine(string.Join(",", headers));

                        foreach (DataRow row in duLieuChiTiet.Rows)
                        {
                            string[] values =
                                new string[duLieuChiTiet.Columns.Count];

                            for (int i = 0; i < values.Length; i++)
                            {
                                object value = row[i];

                                string text = value is DateTime date
                                    ? date.ToString("dd/MM/yyyy")
                                    : Convert.ToString(value) ?? "";

                                values[i] = Csv(text);
                            }

                            writer.WriteLine(string.Join(",", values));
                        }
                    }

                    ThongBao.ThanhCong("Xuất báo cáo thành công!");
                }
                catch (Exception ex)
                {
                    ThongBao.Loi(
                        "Không thể xuất báo cáo:\n" + ex.Message);
                }
            }
        }

        private string Csv(string value)
        {
            if (!string.IsNullOrEmpty(value) &&
                "=+-@".Contains(value[0]))
            {
                value = "'" + value;
            }

            return "\"" + value.Replace("\"", "\"\"") + "\"";
        }
    }
}
