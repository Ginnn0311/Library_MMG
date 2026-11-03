
using System;
using System.Security.Cryptography;

namespace Library
{
    public static class MatKhauBaoMat
    {
        private const int SoLanLap = 210000;
        private const int DoDaiSalt = 16;
        private const int DoDaiHash = 32;
        private const string TienTo = "PBKDF2-SHA256";

        public static string Bam(string matKhau)
        {
            if (string.IsNullOrWhiteSpace(matKhau))
                throw new ArgumentException(
                    "Mật khẩu không được để trống.");

            byte[] salt = RandomNumberGenerator.GetBytes(
                DoDaiSalt);

            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                matKhau,
                salt,
                SoLanLap,
                HashAlgorithmName.SHA256,
                DoDaiHash);

            return string.Join("$",
                TienTo,
                SoLanLap,
                Convert.ToBase64String(salt),
                Convert.ToBase64String(hash));
        }

        public static bool KiemTra(
            string matKhau,
            string matKhauDaLuu)
        {
            if (string.IsNullOrEmpty(matKhau) ||
                string.IsNullOrEmpty(matKhauDaLuu))
                return false;

            if (!matKhauDaLuu.StartsWith(
                TienTo + "$",
                StringComparison.Ordinal))
            {
                // Hỗ trợ tài khoản cũ chưa chuyển đổi.
                return string.Equals(
                    matKhau,
                    matKhauDaLuu,
                    StringComparison.Ordinal);
            }

            try
            {
                string[] phan = matKhauDaLuu.Split('$');

                if (phan.Length != 4 ||
                    phan[0] != TienTo ||
                    !int.TryParse(phan[1], out int soLanLap) ||
                    soLanLap < 100000 ||
                    soLanLap > 1000000)
                {
                    return false;
                }

                byte[] salt = Convert.FromBase64String(
                    phan[2]);

                byte[] hashCu = Convert.FromBase64String(
                    phan[3]);

                if (salt.Length != DoDaiSalt ||
                    hashCu.Length != DoDaiHash)
                {
                    return false;
                }

                byte[] hashMoi =
                    Rfc2898DeriveBytes.Pbkdf2(
                        matKhau,
                        salt,
                        soLanLap,
                        HashAlgorithmName.SHA256,
                        hashCu.Length);

                return CryptographicOperations
                    .FixedTimeEquals(hashMoi, hashCu);
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static bool LaMatKhauDaBam(string giaTri)
        {
            return !string.IsNullOrEmpty(giaTri) &&
                giaTri.StartsWith(
                    TienTo + "$",
                    StringComparison.Ordinal);
        }
    }
}
