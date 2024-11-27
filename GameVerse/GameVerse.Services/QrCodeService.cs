

using GameVerse.Services.Interfaces;
using QRCoder;

namespace GameVerse.Services
{
    public class QrCodeService :IQrCodeService
    {
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
