using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;
using System.Text;

namespace SGQP.Domain.ValueObjects
{
    public class Password
    {
        public int Id { get; set; }
        //public string Content { get; set; }

        public string CreateHash(string value, string salt)
        {
            var valueBytes = KeyDerivation.Pbkdf2(
                    password: value,
                    salt: Encoding.UTF8.GetBytes(salt),
                    prf: KeyDerivationPrf.HMACSHA512,
                    iterationCount: 10000,
                    numBytesRequested: 256 / 8);

            return Convert.ToBase64String(valueBytes);
        }

        public bool Validate(string value, string salt, string hash)
            => CreateHash(value, salt) == hash;

        public string CreateSalt()
        {
            byte[] randomBytes = new byte[128 / 8];
            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(randomBytes);
                //return Convert.ToBase64String(randomBytes);
                return "BCiFRpKRo4kjTnI8yLIp0w==";
            }
        }
    }
}