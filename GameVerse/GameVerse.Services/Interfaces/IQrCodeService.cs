

namespace GameVerse.Services.Interfaces
{
    /// <summary>
    /// Provides functionality for generating QR codes.
    /// </summary>
    public interface IQrCodeService
    {
        /// <summary>
        /// Generates a QR code from the specified data.
        /// </summary>
        /// <param name="data">The data to encode into the QR code.</param>
        /// <returns>
        /// A string representing the generated QR code, typically as a Base64-encoded image.
        /// </returns>
        public string GenerateQrCode(string data);
    }
}
