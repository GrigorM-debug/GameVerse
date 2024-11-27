

using GameVerse.Services.Interfaces;
using QRCoder;

namespace GameVerse.Services
{
    /// <summary>
    /// Provides functionality for generating QR codes as Base64-encoded images.
    /// </summary>
    public class QrCodeService :IQrCodeService
    {
        /// <summary>
        /// Generates a QR code from the specified data and returns it as a Base64-encoded string.
        /// </summary>
        /// <param name="data">The data to encode into the QR code.</param>
        /// <returns>
        /// A Base64-encoded string representing the generated QR code image.
        /// </returns>
        public string GenerateQrCode(string data)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();

            QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);

            Base64QRCode base64QrCode = new Base64QRCode(qrCodeData);

            string qrCodeImageAsBase64 = base64QrCode.GetGraphic(20);

            return qrCodeImageAsBase64;
        }
    }
}
