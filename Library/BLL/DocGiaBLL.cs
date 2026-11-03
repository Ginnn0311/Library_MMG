using System;
using System.Collections.Generic;
using Library.DTO;

namespace Library
{
    public class DocGiaBLL
    {
        private readonly DocGiaDAL docGiaDAL = new DocGiaDAL();

        public List<DocGia> GetAll()
        {
            return docGiaDAL.GetAll();
        }

        public List<DocGia> TimKiem(string cot, string tuKhoa)
        {
            return docGiaDAL.Search(cot, tuKhoa);
        }

        public void ThemDocGia(DocGia docGia)
        {
            KiemTra(docGia);

            if (docGiaDAL.ExistsDuplicate(docGia))
                throw new Exception(
                    "Độc giả đã tồn tại hoặc mã độc giả đã được sử dụng!");

            docGiaDAL.Insert(docGia);
        }

        public void SuaDocGia(DocGia docGia)
        {
            KiemTra(docGia);

            if (!docGiaDAL.Exists(docGia.MaDocGia))
                throw new Exception("Không tìm thấy độc giả cần sửa.");

            docGiaDAL.Update(docGia);
        }

        public void XoaDocGia(string maDocGia)
        {
            if (string.IsNullOrWhiteSpace(maDocGia))
                throw new Exception("Mã độc giả không hợp lệ.");

            if (!docGiaDAL.Exists(maDocGia))
                throw new Exception("Không tìm thấy độc giả cần xóa.");

            docGiaDAL.Delete(maDocGia);
        }

        public DateTime GiaHanThe(string maDocGia)
        {
            if (string.IsNullOrWhiteSpace(maDocGia))
                throw new Exception("Vui lòng chọn độc giả cần gia hạn.");

            if (!docGiaDAL.Exists(maDocGia))
                throw new Exception("Không tìm thấy độc giả cần gia hạn.");

            return docGiaDAL.GiaHanThe(maDocGia);
        }

        private void KiemTra(DocGia docGia)
        {
            if (docGia == null)
                throw new Exception("Thông tin độc giả không hợp lệ.");

            if (!int.TryParse(docGia.MaDocGia, out int ma)
                || ma <= 0)
                throw new Exception("Mã độc giả phải là số nguyên dương.");

            if (string.IsNullOrWhiteSpace(docGia.HoTen))
                throw new Exception("Vui lòng nhập họ tên.");

            if (docGia.NgaySinh == DateTime.MinValue
                || docGia.NgaySinh.Date > DateTime.Today)
                throw new Exception("Ngày sinh không hợp lệ.");

            if (string.IsNullOrWhiteSpace(docGia.SoDienThoai))
                throw new Exception("Vui lòng nhập số điện thoại.");
        }
    }
}