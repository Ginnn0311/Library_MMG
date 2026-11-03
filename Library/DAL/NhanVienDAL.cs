
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
                string query = @"SELECT MaNhanVien, HoTen, SoDienThoai,
                                        TaiKhoan, MatKhau, VaiTro, HinhAnh
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
                                MaNhanVien = Convert.ToInt32(reader["MaNhanVien"]),
                                HoTen = reader["HoTen"].ToString(),
                                SoDienThoai = reader["SoDienThoai"] == DBNull.Value ? "" : reader["SoDienThoai"].ToString(),
                                TaiKhoan = reader["TaiKhoan"] == DBNull.Value ? "" : reader["TaiKhoan"].ToString(),
                                MatKhau = reader["MatKhau"] == DBNull.Value ? "" : reader["MatKhau"].ToString(),
                                VaiTro = reader["VaiTro"].ToString(),
                                HinhAnh = reader["HinhAnh"] == DBNull.Value ? "" : reader["HinhAnh"].ToString()
                            });
                        }
                    }
                }
            }

            return danhSach;
        }

        public bool Them(NhanVien nv)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"INSERT INTO NhanVien
                                (HoTen, SoDienThoai, TaiKhoan, MatKhau, VaiTro, HinhAnh)
                                VALUES
                                (@HoTen, @SoDienThoai, @TaiKhoan, @MatKhau, @VaiTro, @HinhAnh)";

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
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"UPDATE NhanVien SET
                                HoTen = @HoTen,
                                SoDienThoai = @SoDienThoai,
                                TaiKhoan = @TaiKhoan,
                                MatKhau = @MatKhau,
                                VaiTro = @VaiTro,
                                HinhAnh = @HinhAnh
                                WHERE MaNhanVien = @MaNhanVien";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    GanThamSo(cmd, nv);
                    cmd.Parameters.AddWithValue("@MaNhanVien", nv.MaNhanVien);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Xoa(int maNhanVien)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "DELETE FROM NhanVien WHERE MaNhanVien = @MaNhanVien";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool KiemTraTaiKhoan(string taiKhoan, int maNhanVien = 0)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"SELECT COUNT(*) FROM NhanVien
                                 WHERE TaiKhoan = @TaiKhoan
                                 AND MaNhanVien <> @MaNhanVien";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TaiKhoan", taiKhoan);
                    cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);

                    conn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        private void GanThamSo(SqlCommand cmd, NhanVien nv)
        {
            cmd.Parameters.AddWithValue("@HoTen", nv.HoTen);
            cmd.Parameters.AddWithValue("@SoDienThoai",
                string.IsNullOrWhiteSpace(nv.SoDienThoai) ? (object)DBNull.Value : nv.SoDienThoai);
            cmd.Parameters.AddWithValue("@TaiKhoan",
                string.IsNullOrWhiteSpace(nv.TaiKhoan) ? (object)DBNull.Value : nv.TaiKhoan);
            cmd.Parameters.AddWithValue("@MatKhau",
                string.IsNullOrWhiteSpace(nv.MatKhau) ? (object)DBNull.Value : nv.MatKhau);
            cmd.Parameters.AddWithValue("@VaiTro", nv.VaiTro);
            cmd.Parameters.AddWithValue("@HinhAnh",
                string.IsNullOrWhiteSpace(nv.HinhAnh) ? (object)DBNull.Value : nv.HinhAnh);
        }
    }
}
