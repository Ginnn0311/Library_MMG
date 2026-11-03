
using Library.DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Library
{
    public class SachDAL
    {
        public List<Sach> GetAll()
        {
            List<Sach> danhSach = new List<Sach>();

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT MaSach, TenSach, TacGia, TheLoai,
                           NhaXuatBan, NamXuatBan, SoLuong, HinhAnh
                    FROM Sach
                    ORDER BY MaSach";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        danhSach.Add(ChuyenDuLieu(reader));
                    }
                }
            }

            return danhSach;
        }

        public bool Exists(string maSach)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string sql = "SELECT COUNT(*) FROM Sach WHERE MaSach = @MaSach";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSach", maSach);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public void Insert(Sach sach)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string sql = @"
                    INSERT INTO Sach
                    (MaSach, TenSach, TacGia, TheLoai, NhaXuatBan,
                     NamXuatBan, SoLuong, HinhAnh)
                    VALUES
                    (@MaSach, @TenSach, @TacGia, @TheLoai, @NhaXuatBan,
                     @NamXuatBan, @SoLuong, @HinhAnh)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    AddParameters(cmd, sach);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Update(Sach sach)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string sql = @"
            UPDATE Sach
            SET TenSach = @TenSach,
                TacGia = @TacGia,
                TheLoai = @TheLoai,
                NhaXuatBan = @NhaXuatBan,
                NamXuatBan = @NamXuatBan,
                HinhAnh = @HinhAnh
            WHERE MaSach = @MaSach";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    AddParameters(cmd, sach);

                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        throw new Exception(
                            "Không tìm thấy sách cần sửa.");
                    }
                }
            }
        }


        public void Delete(string maSach)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string sql = "DELETE FROM Sach WHERE MaSach = @MaSach";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSach", maSach);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Sach> Search(string cot, string tuKhoa)
        {
            List<Sach> danhSach = new List<Sach>();

            string[] cotHopLe =
            {
                "MaSach", "TenSach", "TacGia", "TheLoai", "NhaXuatBan"
            };

            if (Array.IndexOf(cotHopLe, cot) < 0)
                cot = "MaSach";

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string sql = $@"
                    SELECT MaSach, TenSach, TacGia, TheLoai,
                           NhaXuatBan, NamXuatBan, SoLuong, HinhAnh
                    FROM Sach
                    WHERE {cot} LIKE @TuKhoa
                    ORDER BY MaSach";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            danhSach.Add(ChuyenDuLieu(reader));
                        }
                    }
                }
            }

            return danhSach;
        }

        public string LayDuongDanAnh(string maSach)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string sql =
                    "SELECT HinhAnh FROM Sach WHERE MaSach = @MaSach";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSach", maSach);

                    object ketQua = cmd.ExecuteScalar();

                    return ketQua == null || ketQua == DBNull.Value
                        ? ""
                        : ketQua.ToString() ?? "";
                }
            }
        }

        private Sach ChuyenDuLieu(SqlDataReader reader)
        {
            return new Sach
            {
                MaSach = reader["MaSach"]?.ToString() ?? "",
                TenSach = reader["TenSach"]?.ToString() ?? "",
                TacGia = reader["TacGia"]?.ToString() ?? "",
                TheLoai = reader["TheLoai"]?.ToString() ?? "",
                NhaXuatBan = reader["NhaXuatBan"]?.ToString() ?? "",
                NamXuatBan = Convert.ToInt32(reader["NamXuatBan"]),
                SoLuong = Convert.ToInt32(reader["SoLuong"]),
                HinhAnh = reader["HinhAnh"] == DBNull.Value
                    ? ""
                    : reader["HinhAnh"]?.ToString() ?? ""
            };
        }

        private void AddParameters(SqlCommand cmd, Sach sach)
        {
            cmd.Parameters.AddWithValue("@MaSach", sach.MaSach);
            cmd.Parameters.AddWithValue("@TenSach", sach.TenSach);
            cmd.Parameters.AddWithValue("@TacGia", sach.TacGia);
            cmd.Parameters.AddWithValue("@TheLoai", sach.TheLoai);
            cmd.Parameters.AddWithValue("@NhaXuatBan", sach.NhaXuatBan);
            cmd.Parameters.AddWithValue("@NamXuatBan", sach.NamXuatBan);
            cmd.Parameters.AddWithValue("@SoLuong", sach.SoLuong);
            cmd.Parameters.AddWithValue(
                "@HinhAnh",
                string.IsNullOrWhiteSpace(sach.HinhAnh)
                    ? DBNull.Value
                    : sach.HinhAnh);
        }
    }
}
