using Castle.Core.Smtp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using SendGrid.Helpers.Mail;
using SendGrid;

namespace GameVerse.Services.Tests
{
    [TestFixture]
    public class EmailSenderTests
    {
        private Mock<ILogger<EmailSender>> _mockLogger;
        private Mock<IConfiguration> _mockConfiguration;
        private Mock<IConfigurationSection> _mockSendGridSection;
        private EmailSender _emailSender;

        [SetUp]
        public void SetUp()
        {
            _mockLogger = new Mock<ILogger<EmailSender>>();
            _mockConfiguration = new Mock<IConfiguration>();
            _mockSendGridSection = new Mock<IConfigurationSection>();

            _mockSendGridSection.Setup(sg => sg["ApiKey"]).Returns("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");
            _mockConfiguration.Setup(x => x.GetSection("SendGrid")).Returns(_mockSendGridSection.Object);

            _emailSender = new EmailSender(_mockLogger.Object, _mockConfiguration.Object);
        }

        [Test]
        public async Task SendEmailSync_ShouldSendEmailSuccessfully()
        {
            //Arrange
            string email = "grigormarinov761@gmail.com";
            string subject = "Programming";
            string message = "Ne stavash za programist";

            //Act & Assert
            Assert.DoesNotThrowAsync(() => _emailSender.SendEmailAsync(email, subject, message));
        }

        [Test]
        public void SendEmailAsync_ShouldThrowException_WhenApiKeyIsMissing()
        {
            // Arrange
            _mockSendGridSection.Setup(x => x["ApiKey"]).Returns("fake-api-key");

            string email = "test@example.com";
            string subject = "Test Subject";
            string message = "Test Message";

            // Act & Assert
            InvalidOperationException exception = Assert.ThrowsAsync<InvalidOperationException>(() => _emailSender.SendEmailAsync(email, subject, message));
            Assert.That(exception.Message, Is.EqualTo("An error occurred while sending email"));
        }

        [Test]
        public async Task SendEmailAsync_ShouldThrowException_OnApiFailure()
        {
            _mockSendGridSection.Setup(x => x["ApiKey"]).Returns("fake-api-key");

            var mockSendGridClient = new Mock<ISendGridClient>();

            mockSendGridClient
                .Setup(client => client.SendEmailAsync(It.IsAny<SendGridMessage>(), default))
                .ReturnsAsync(new Response(System.Net.HttpStatusCode.BadRequest, null, null));

            EmailSender emailSender = new EmailSender(_mockLogger.Object, _mockConfiguration.Object);

            string email = "test@example.com";
            string subject = "Test Subject";
            string message = "Test Message";

            // Act & Assert
            InvalidOperationException exception = Assert.ThrowsAsync<InvalidOperationException>(() => emailSender.SendEmailAsync(email, subject, message));
            Assert.That(exception.Message, Is.EqualTo("An error occurred while sending email"));
        }

        [Test]
        public void SendEmailAsync_ShouldThrowException_WhenEmailIsInvalid()
        {
            // Arrange
            string invalidEmail = "invalid-email";
            string subject = "Test Subject";
            string message = "Test Message";

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(() => _emailSender.SendEmailAsync(invalidEmail, subject, message));
        }

    }
}
