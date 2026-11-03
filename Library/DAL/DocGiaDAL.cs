using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Library.DTO;

namespace Library
{
    public class DocGiaDAL
    {
        public List<DocGia> GetAll()
        {
            List<DocGia> danhSach = new List<DocGia>();

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT MaDocGia, HoTen, NgaySinh,
                           SoDienThoai, DiaChi, GioiTinh, Email,
                           NgayDangKy, NgayHetHan
                    FROM dbo.DocGia
                    ORDER BY MaDocGia";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        danhSach.Add(ChuyenDocGia(reader));
                }
            }

            return danhSach;
        }

        public bool Exists(string maDocGia)
        {
            int ma = ChuyenMaDocGia(maDocGia);

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT COUNT(*)
                    FROM dbo.DocGia
                    WHERE MaDocGia = @MaDocGia";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@MaDocGia", SqlDbType.Int)
                        .Value = ma;

                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public bool ExistsDuplicate(DocGia docGia)
        {
            int ma = ChuyenMaDocGia(docGia.MaDocGia);

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT COUNT(*)
                    FROM dbo.DocGia
                    WHERE MaDocGia = @MaDocGia
                       OR (
                           HoTen = @HoTen
                           AND NgaySinh = @NgaySinh
                           AND SoDienThoai = @SoDienThoai
                       )";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@MaDocGia", SqlDbType.Int)
                        .Value = ma;

                    cmd.Parameters.AddWithValue("@HoTen", docGia.HoTen);
                    cmd.Parameters.Add("@NgaySinh", SqlDbType.Date)
                        .Value = docGia.NgaySinh.Date;
                    cmd.Parameters.AddWithValue(
                        "@SoDienThoai", docGia.SoDienThoai);

                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public void Insert(DocGia docGia)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                using (SqlCommand identityOn =
                    new SqlCommand(
                        "SET IDENTITY_INSERT dbo.DocGia ON", conn))
                {
                    identityOn.ExecuteNonQuery();
                }

                try
                {
                    string sql = @"
                        INSERT INTO dbo.DocGia
                        (
                            MaDocGia, HoTen, NgaySinh,
                            SoDienThoai, DiaChi, GioiTinh, Email
                        )
                        VALUES
                        (
                            @MaDocGia, @HoTen, @NgaySinh,
                            @SoDienThoai, @DiaChi, @GioiTinh, @Email
                        )";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        AddParameters(cmd, docGia);
                        cmd.ExecuteNonQuery();
                    }
                }
                finally
                {
                    using (SqlCommand identityOff =
                        new SqlCommand(
                            "SET IDENTITY_INSERT dbo.DocGia OFF", conn))
                    {
                        identityOff.ExecuteNonQuery();
                    }
                }
            }
        }

        public void Update(DocGia docGia)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string sql = @"
                    UPDATE dbo.DocGia
                    SET HoTen = @HoTen,
                        NgaySinh = @NgaySinh,
                        SoDienThoai = @SoDienThoai,
                        DiaChi = @DiaChi,
                        GioiTinh = @GioiTinh,
                        Email = @Email
                    WHERE MaDocGia = @MaDocGia";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    AddParameters(cmd, docGia);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(string maDocGia)
        {
            int ma = ChuyenMaDocGia(maDocGia);

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string sql = @"
                    DELETE FROM dbo.DocGia
                    WHERE MaDocGia = @MaDocGia";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@MaDocGia", SqlDbType.Int)
                        .Value = ma;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<DocGia> Search(string cot, string tuKhoa)
        {
            List<DocGia> danhSach = new List<DocGia>();

            string[] cotHopLe =
            {
                "MaDocGia", "HoTen", "SoDienThoai",
                "DiaChi", "GioiTinh", "Email"
            };

            if (!Array.Exists(cotHopLe, c => c == cot))
                cot = "MaDocGia";

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string sql = $@"
                    SELECT MaDocGia, HoTen, NgaySinh,
                           SoDienThoai, DiaChi, GioiTinh, Email,
                           NgayDangKy, NgayHetHan
                    FROM dbo.DocGia
                    WHERE CAST({cot} AS NVARCHAR(255)) LIKE @TuKhoa
                    ORDER BY MaDocGia";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue(
                        "@TuKhoa", "%" + tuKhoa + "%");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            danhSach.Add(ChuyenDocGia(reader));
                    }
                }
            }

            return danhSach;
        }

        public DateTime GiaHanThe(string maDocGia)
        {
            int ma = ChuyenMaDocGia(maDocGia);

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string sql = @"
                    UPDATE dbo.DocGia
                    SET NgayHetHan = DATEADD(
                        MONTH, 3,
                        CASE
                            WHEN NgayHetHan >= CONVERT(DATE, GETDATE())
                                THEN NgayHetHan
                            ELSE CONVERT(DATE, GETDATE())
                        END
                    )
                    OUTPUT INSERTED.NgayHetHan
                    WHERE MaDocGia = @MaDocGia";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@MaDocGia", SqlDbType.Int)
                        .Value = ma;

                    object ketQua = cmd.ExecuteScalar();

                    if (ketQua == null || ketQua == DBNull.Value)
                        throw new Exception("Không tìm thấy độc giả cần gia hạn.");

                    return Convert.ToDateTime(ketQua);
                }
            }
        }

        private static DocGia ChuyenDocGia(SqlDataReader reader)
        {
            return new DocGia
            {
                MaDocGia = Convert.ToString(reader["MaDocGia"]) ?? "",
                HoTen = Convert.ToString(reader["HoTen"]) ?? "",
                NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                SoDienThoai =
                    Convert.ToString(reader["SoDienThoai"]) ?? "",
                DiaChi = Convert.ToString(reader["DiaChi"]) ?? "",
                GioiTinh = Convert.ToString(reader["GioiTinh"]) ?? "",
                Email = Convert.ToString(reader["Email"]) ?? "",

                NgayDangKy = reader["NgayDangKy"] == DBNull.Value
                    ? null
                    : Convert.ToDateTime(reader["NgayDangKy"]),

                NgayHetHan = reader["NgayHetHan"] == DBNull.Value
                    ? null
                    : Convert.ToDateTime(reader["NgayHetHan"])
            };
        }

        private static int ChuyenMaDocGia(string maDocGia)
        {
            if (!int.TryParse(maDocGia, out int ma) || ma <= 0)
                throw new Exception("Mã độc giả phải là số nguyên dương.");

            return ma;
        }

        private static void AddParameters(
            SqlCommand cmd, DocGia docGia)
        {
            cmd.Parameters.Add("@MaDocGia", SqlDbType.Int)
                .Value = ChuyenMaDocGia(docGia.MaDocGia);

            cmd.Parameters.AddWithValue("@HoTen", docGia.HoTen);

            cmd.Parameters.Add("@NgaySinh", SqlDbType.Date)
                .Value = docGia.NgaySinh.Date;

            cmd.Parameters.AddWithValue(
                "@SoDienThoai", docGia.SoDienThoai);

            cmd.Parameters.AddWithValue("@DiaChi", docGia.DiaChi);
            cmd.Parameters.AddWithValue("@GioiTinh", docGia.GioiTinh);
            cmd.Parameters.AddWithValue("@Email", docGia.Email);
        }
    }
}