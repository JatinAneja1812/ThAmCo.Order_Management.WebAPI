using Enums;
using Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Services.Classes
{
    public class GuidUtility : IGuidUtility
    {
        private readonly ILogger<GuidUtility> _logger;

        public GuidUtility(ILogger<GuidUtility> Logger)
        {
            _logger = Logger;
        }

        public string GenerateShortGuid(Guid guid)
        {
            try
            {
                // Convert the GUID to bytes
                byte[] guidBytes = guid.ToByteArray();

                // Compute the MD5 hash
                using (MD5 md5 = MD5.Create())
                {
                    byte[] hashBytes = md5.ComputeHash(guidBytes);

                    // Convert the hash to a hexadecimal string
                    StringBuilder hashStringBuilder = new StringBuilder();
                    foreach (byte b in hashBytes)
                    {
                        hashStringBuilder.Append(b.ToString("x2"));
                    }

                    // Take the first 8 characters for a shorter representation
                    string shortHash = hashStringBuilder.ToString().Substring(0, 12);

                    return shortHash;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(
                new EventId((int)LogEventIdEnum.UnknownError),
                      $"Failed to return short guid. Error occured in GuidUtility at GenerateShortGuid() .\nException:\n{ex.Message}\nInner exception:\n{ex.InnerException}\nStack trace:\n{ex.StackTrace}");

                return "";
            }
        }
    }
}
