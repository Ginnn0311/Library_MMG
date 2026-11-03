
using System;
using System.Collections.Generic;

namespace Library
{
    public class SachBLL
    {
        private readonly SachDAL sachDAL = new SachDAL();

        public List<Sach> GetAll()
        {
            return sachDAL.GetAll();
        }

        public void ThemSach(Sach sach)
        {
            KiemTraSach(sach);

            if (sachDAL.Exists(sach.MaSach))
                throw new Exception("Mã sách đã tồn tại.");

            sachDAL.Insert(sach);
        }

        public void SuaSach(Sach sach)
        {
            KiemTraSach(sach);

            if (!sachDAL.Exists(sach.MaSach))
                throw new Exception("Không tìm thấy sách cần sửa.");

            sachDAL.Update(sach);
        }

        public void XoaSach(string maSach)
        {
            if (string.IsNullOrWhiteSpace(maSach))
                throw new Exception("Mã sách không hợp lệ.");

            sachDAL.Delete(maSach);
        }

        public List<Sach> TimKiem(string cot, string tuKhoa)
        {
            return sachDAL.Search(cot, tuKhoa);
        }

        public string LayDuongDanAnh(string maSach)
        {
            return sachDAL.LayDuongDanAnh(maSach);
        }

        private void KiemTraSach(Sach sach)
        {
            if (sach == null)
                throw new Exception("Thông tin sách không hợp lệ.");

            if (string.IsNullOrWhiteSpace(sach.MaSach))
                throw new Exception("Vui lòng nhập mã sách.");

            if (string.IsNullOrWhiteSpace(sach.TenSach))
                throw new Exception("Vui lòng nhập tên sách.");

            if (string.IsNullOrWhiteSpace(sach.TacGia))
                throw new Exception("Vui lòng nhập tác giả.");

            if (string.IsNullOrWhiteSpace(sach.TheLoai))
                throw new Exception("Vui lòng nhập thể loại.");

            if (string.IsNullOrWhiteSpace(sach.NhaXuatBan))
                throw new Exception("Vui lòng nhập nhà xuất bản.");

            if (sach.NamXuatBan < 1000 ||
                sach.NamXuatBan > DateTime.Now.Year)
                throw new Exception("Năm xuất bản không hợp lệ.");

            if (sach.SoLuong < 0)
                throw new Exception("Số lượng không được nhỏ hơn 0.");
        }
    }
}
