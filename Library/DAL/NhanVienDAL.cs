
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Library.DTO;

namespace Library
{
    public class NhanVienDAL
    {
        public List<NhanVien> GetAll()
        {
            List<NhanVien> danhSach = new List<NhanVien>();

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"
                    SELECT MaNhanVien, HoTen, SoDienThoai,
                           TaiKhoan, VaiTro, HinhAnh
                    FROM NhanVien
                    ORDER BY MaNhanVien";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            danhSach.Add(new NhanVien
                            {
                                MaNhanVien = Convert.ToInt32(
                                    reader["MaNhanVien"]),

                                HoTen = Convert.ToString(
                                    reader["HoTen"]) ?? "",

                                SoDienThoai = Convert.ToString(
                                    reader["SoDienThoai"]) ?? "",

                                TaiKhoan = Convert.ToString(
                                    reader["TaiKhoan"]) ?? "",

                                // Không trả mật khẩu trong danh sách
                                MatKhau = "",

                                VaiTro = Convert.ToString(
                                    reader["VaiTro"]) ?? "",

                                HinhAnh = Convert.ToString(
                                    reader["HinhAnh"]) ?? ""
                            });
                        }
                    }
                }
            }

            return danhSach;
        }

        public bool Them(NhanVien nv)
        {
            if (nv == null)
                throw new ArgumentNullException(nameof(nv));

            if (string.IsNullOrWhiteSpace(nv.MatKhau))
                throw new Exception(
                    "Vui lòng nhập mật khẩu nhân viên.");

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"
                    INSERT INTO NhanVien
                    (
                        HoTen, SoDienThoai, TaiKhoan,
                        MatKhau, VaiTro, HinhAnh
                    )
                    VALUES
                    (
                        @HoTen, @SoDienThoai, @TaiKhoan,
                        @MatKhau, @VaiTro, @HinhAnh
                    )";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    GanThamSo(cmd, nv);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Sua(NhanVien nv)
        {
            if (nv == null)
                throw new ArgumentNullException(nameof(nv));

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"
                    UPDATE NhanVien
                    SET HoTen = @HoTen,
                        SoDienThoai = @SoDienThoai,
                        TaiKhoan = @TaiKhoan,
                        MatKhau = CASE
                            WHEN @MatKhau IS NULL
                            THEN MatKhau
                            ELSE @MatKhau
                        END,
                        VaiTro = @VaiTro,
                        HinhAnh = @HinhAnh
                    WHERE MaNhanVien = @MaNhanVien";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    GanThamSo(cmd, nv);

                    cmd.Parameters.AddWithValue(
                        "@MaNhanVien", nv.MaNhanVien);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Xoa(int maNhanVien)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"
                    DELETE FROM NhanVien
                    WHERE MaNhanVien = @MaNhanVien";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue(
                        "@MaNhanVien", maNhanVien);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool KiemTraTaiKhoan(
            string taiKhoan,
            int maNhanVien = 0)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"
                    SELECT COUNT(*)
                    FROM NhanVien
                    WHERE TaiKhoan = @TaiKhoan
                      AND MaNhanVien <> @MaNhanVien";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue(
                        "@TaiKhoan", taiKhoan);

                    cmd.Parameters.AddWithValue(
                        "@MaNhanVien", maNhanVien);

                    conn.Open();

                    return Convert.ToInt32(
                        cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public bool CoTheXoaQuanTriVien(int maNhanVien)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string sql = @"
            SELECT
                CASE
                    WHEN EXISTS (
                        SELECT 1
                        FROM NhanVien
                        WHERE MaNhanVien = @MaNhanVien
                          AND VaiTro IN
                          (N'Quản lý', N'Quản trị viên')
                    )
                    AND (
                        SELECT COUNT(*)
                        FROM NhanVien
                        WHERE VaiTro IN
                        (N'Quản lý', N'Quản trị viên')
                    ) <= 1
                    THEN 0
                    ELSE 1
                END";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue(
                        "@MaNhanVien", maNhanVien);

                    conn.Open();

                    return Convert.ToInt32(
                        cmd.ExecuteScalar()) == 1;
                }
            }
        }

        public string LayVaiTro(int maNhanVien)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                const string sql = @"
            SELECT VaiTro
            FROM NhanVien
            WHERE MaNhanVien = @MaNhanVien";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue(
                        "@MaNhanVien", maNhanVien);

                    conn.Open();

                    return Convert.ToString(
                        cmd.ExecuteScalar())?.Trim() ?? "";
                }
            }
        }

        public bool CoQuyenQuanLyNhanVien(int maNguoiThaoTac)
        {
            string vaiTro = LayVaiTro(maNguoiThaoTac);

            return LaQuanTriVien(vaiTro)
                || string.Equals(
                    vaiTro,
                    "Quản lý",
                    StringComparison.OrdinalIgnoreCase);
        }

        public static bool LaQuanTriVien(string vaiTro)
        {
            return string.Equals(
                vaiTro?.Trim(),
                "Quản trị viên",
                StringComparison.OrdinalIgnoreCase);
        }


        private void GanThamSo(
            SqlCommand cmd,
            NhanVien nv)
        {
            cmd.Parameters.AddWithValue(
                "@HoTen", nv.HoTen);

            cmd.Parameters.AddWithValue(
                "@SoDienThoai",
                string.IsNullOrWhiteSpace(nv.SoDienThoai)
                    ? (object)DBNull.Value
                    : nv.SoDienThoai);

            cmd.Parameters.AddWithValue(
                "@TaiKhoan",
                string.IsNullOrWhiteSpace(nv.TaiKhoan)
                    ? (object)DBNull.Value
                    : nv.TaiKhoan);

            // Chỉ băm khi người dùng nhập mật khẩu mới.
            object matKhauLuu =
                string.IsNullOrWhiteSpace(nv.MatKhau)
                    ? DBNull.Value
                    : MatKhauBaoMat.Bam(nv.MatKhau);

            cmd.Parameters.AddWithValue(
                "@MatKhau", matKhauLuu);

            cmd.Parameters.AddWithValue(
                "@VaiTro", nv.VaiTro);

            cmd.Parameters.AddWithValue(
                "@HinhAnh",
                string.IsNullOrWhiteSpace(nv.HinhAnh)
                    ? (object)DBNull.Value
                    : nv.HinhAnh);
        }
    }
}
