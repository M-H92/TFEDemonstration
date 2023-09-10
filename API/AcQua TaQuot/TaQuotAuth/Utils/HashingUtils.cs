using System.Security.Cryptography;

namespace TaQuotAuth.Utils
{
    public static class HashingUtils
    {
        private const int hashSize = 20;
        private const int saltSize = 20;
        private const int iterations = 8192;
        public static string HashPassword(string password)
        {
            byte[] saltBuffer;
            byte[] hashBuffer;

            using (var keyDerivation = new Rfc2898DeriveBytes(password, saltSize, iterations, HashAlgorithmName.SHA1))
            {
                saltBuffer = keyDerivation.Salt;
                hashBuffer = keyDerivation.GetBytes(hashSize);
            }

            byte[] result = new byte[hashSize + saltSize];
            Buffer.BlockCopy(hashBuffer, 0, result, 0, saltSize);
            Buffer.BlockCopy(saltBuffer, 0, result, hashSize, saltSize);
            return Convert.ToBase64String(result);
        }
        public static bool VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            byte[] hashedPasswordBytes = Convert.FromBase64String(hashedPassword);
            if (hashedPasswordBytes.Length != hashSize + saltSize)
            {
                return false;
            }

            byte[] hashBytes = new byte[hashSize];
            Buffer.BlockCopy(hashedPasswordBytes, 0, hashBytes, 0, hashSize);
            byte[] saltBytes = new byte[saltSize];
            Buffer.BlockCopy(hashedPasswordBytes, hashSize, saltBytes, 0, saltSize);

            byte[] providedHashBytes;
            using (var keyDerivation = new Rfc2898DeriveBytes(providedPassword, saltBytes, iterations, HashAlgorithmName.SHA1))
            {
                providedHashBytes = keyDerivation.GetBytes(hashSize);
            }

            return compare(hashBytes, providedHashBytes);
        }

        private static bool compare(byte[] x, byte[] y)
        {

            if (x == y)
            {
                return true;
            }

            if (x == null || y == null || x.Length != y.Length)
            {
                return false;
            }

            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] != y[i])
                    return false;
            }

            return true;
        }
    }
}
