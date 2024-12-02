using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GameVerse.Services.Tests
{
    [TestFixture]
    public class QrCodeServiceTests
    {
        private QrCodeService _qrCodeService;

        [SetUp]
        public void SetUp()
        {
            _qrCodeService = new QrCodeService();
        }

        [Test]
        public void GenerateQrCode_ValidData_ReturnsBase64String()
        {
            //Arrange
            string data = "Test data";

            //Act
            string result = _qrCodeService.GenerateQrCode(data);

            //Assert
            Assert.IsNotNull(result, "Qr code result should not be null.");
            Assert.IsTrue(IsBase64String(result), "Result should be a valid Base64 string.");
        }

        [Test]
        public void GenerateQrCode_EmptyData_ReturnsBase64String()
        {
            //Arrange
            string data = "";

            //Act
            string result = _qrCodeService.GenerateQrCode(data);


            //Assert
            Assert.IsNotNull(result, "Qr code result should not be null.");
            Assert.IsTrue(IsBase64String(result), "Result should be valid Base64 string");
        }

        [Test]
        public void GenerateQrCode_NullData_ThrowsArgumentNullException()
        {
            //Arrange
            string data = null;

            //Act and Assert
            Assert.Throws<ArgumentNullException>(() => _qrCodeService.GenerateQrCode(data));
        }

        [Test]
        public void GenerateQrCode_OutputCanBeDecoded_ValidQrCode()
        {
            //Arrange
            string data = "Test Qr code data";

            //Act
            string base64String = _qrCodeService.GenerateQrCode(data);

            //Ensure that QrCode can be converted to Qr code image
            byte[] imageBytes = Convert.FromBase64String(base64String);

            //Assert
            Assert.IsNotNull(imageBytes, "Decoded image bytes should not be null");
            Assert.Greater(imageBytes.Length, 0, "Decoded image bytes should have content");
        }

        [Test]
        public void GenerateQrCode_LargeData_ValidQrCode()
        {
            //Arrange
            string largeData = new string('x', 1000);

            //Act
            string result = _qrCodeService.GenerateQrCode(largeData);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(IsBase64String(result));
        }

        [Test]
        public void GenerateQrCode_SpecialCharacters_ValidQrCode()
        {
            //Arrange
            string data = "@#$%^&*😀";

            //Act
            string result = _qrCodeService.GenerateQrCode(data);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(IsBase64String(result));
        }

        private bool IsBase64String(string base64)
        {
            Span<byte> buffer = new Span<byte>(new byte[base64.Length]);
            return Convert.TryFromBase64String(base64, buffer, out _);
        }

    }
}
