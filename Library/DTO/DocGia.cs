using System;

namespace Library.DTO
{
    public class DocGia
    {
        public string MaDocGia { get; set; } = "";
        public string HoTen { get; set; } = "";
        public DateTime NgaySinh { get; set; }
        public string SoDienThoai { get; set; } = "";
        public string DiaChi { get; set; } = "";
        public string GioiTinh { get; set; } = "";
        public string Email { get; set; } = "";

        public DateTime? NgayDangKy { get; set; }
        public DateTime? NgayHetHan { get; set; }

        public string TrangThaiThe
        {
            get
            {
                if (!NgayHetHan.HasValue)
                    return "Chưa xác định";

                DateTime ngayHetHan = NgayHetHan.Value.Date;
                DateTime homNay = DateTime.Today;

                if (ngayHetHan < homNay)
                    return "Hết hạn";

                if (ngayHetHan <= homNay.AddDays(7))
                    return "Sắp hết hạn";

                return "Còn hạn";
            }
        }
    }
}