using System.Security.Cryptography;
using System.Text;
using MPS.Domain.Modules.SecurityModules.PasswordModule.Interfaces;

namespace Application.Security.Passwords;

public class Sha256PasswordManager : IPasswordManager
{

    public string CreatePasswordHash(string password)
    {
        using var hashingAlgorithm = SHA256.Create();
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        return BitConverter.ToString(hashingAlgorithm.ComputeHash(passwordBytes));
    }

    public bool VerifyPasswordHash(string password, string passwordHash)
    {
        return passwordHash.Equals(CreatePasswordHash(password));
    }
}