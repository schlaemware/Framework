﻿using System.Security.Cryptography;

namespace SW.MUSICBase.Logic.Security {
  public sealed class PasswordHasher {
    private const int _SALT_SIZE = 16; // 128 bit 
    private const int _KEY_SIZE = 32; // 256 bit

    private readonly HashingOptions _Options;

    #region CONSTRUCTORS
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="options"></param>
    public PasswordHasher(HashingOptions options) {
      _Options = options;
    }
    #endregion CONSTRUCTORS

    /// <summary>
    /// COMMENT
    /// </summary>
    /// <param name="password"></param>
    /// <returns></returns>
    public string Hash(string password) {
      using (Rfc2898DeriveBytes algorithm = new Rfc2898DeriveBytes(
        password,
        _SALT_SIZE,
        _Options.Iterations,
        HashAlgorithmName.SHA512)) {
        string key = Convert.ToBase64String(algorithm.GetBytes(_KEY_SIZE));
        string salt = Convert.ToBase64String(algorithm.Salt);

        return $"{_Options.Iterations}.{salt}.{key}";
      }
    }

    /// <summary>
    /// COMMENT
    /// </summary>
    /// <param name="hash"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public (bool Verified, bool NeedsUpgrade) Check(string hash, string password) {
      if (string.IsNullOrEmpty(hash)) {
        return (false, false);
      }

      string[] parts = hash.Split('.', 3);

      if (parts.Length != 3) {
        throw new FormatException("Unexpected hash format. " +
          "Should be formatted as `{iterations}.{salt}.{hash}`");
      }

      int iterations = Convert.ToInt32(parts[0]);
      byte[] salt = Convert.FromBase64String(parts[1]);
      byte[] key = Convert.FromBase64String(parts[2]);

      bool needsUpgrade = iterations != _Options.Iterations;

      using (Rfc2898DeriveBytes algorithm = new(password, salt, iterations, HashAlgorithmName.SHA512)) {
        byte[] keyToCheck = algorithm.GetBytes(_KEY_SIZE);
        bool verified = keyToCheck.SequenceEqual(key);

        return (verified, needsUpgrade);
      }
    }
  }
}
