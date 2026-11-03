
using System.Collections.Generic;

namespace Library
{
    public class NhanVienBLL
    {
        private readonly NhanVienDAL dal = new NhanVienDAL();

        public List<NhanVien> GetAll()
        {
            return dal.GetAll();
        }

        public bool Them(NhanVien nv)
        {
            return dal.Them(nv);
        }

        public bool Sua(NhanVien nv)
        {
            return dal.Sua(nv);
        }

        public bool Xoa(int maNhanVien)
        {
            return dal.Xoa(maNhanVien);
        }

        public bool KiemTraTaiKhoan(string taiKhoan, int maNhanVien = 0)
        {
            return dal.KiemTraTaiKhoan(taiKhoan, maNhanVien);
        }
    }
}
