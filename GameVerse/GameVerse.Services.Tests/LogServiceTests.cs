

using GameVerse.Web.Areas.Administrator.Services;
using GameVerse.Web.Areas.Administrator.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace GameVerse.Services.Tests
{
    [TestFixture]
    public class LogServiceTests
    {
        private string _testLogDirectory;
        private ILogService _logService;

        [SetUp]
        public void SetUp()
        {
            _testLogDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(_testLogDirectory);

            _logService = new LogService();

            Type type = typeof(LogService);

            
            type
                .GetField("_logDirectory", BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(_logService, _testLogDirectory);
        }

        [TearDown]
        public void TearDown()
        {
            if (Directory.Exists(_testLogDirectory))
            {
                Directory.Delete(_testLogDirectory, true);
            }
        }

        [Test]
        public void GetLogFile_FileExists_ReturnsFileContent()
        {
            // Arrange
            string fileName = "test.log";
            string filePath = Path.Combine(_testLogDirectory, fileName);
            string content = "Test log content";
            File.WriteAllText(filePath, content);

            // Act
            var result = _logService.GetLogFile(fileName);

            // Assert
            Assert.NotNull(result);
            Assert.That(System.Text.Encoding.UTF8.GetString(result.Value.FileContent), Is.EqualTo(content));
            Assert.That(result.Value.ContentType, Is.EqualTo("application/octet-stream"));
            Assert.That(result.Value.FileName, Is.EqualTo(fileName));
        }

        [Test]
        public void GetLogFile_FileDoesNotExist_ReturnsNull()
        {
            // Act
            var result = _logService.GetLogFile("nonexistent.log");

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void LogFileExists_FileExists_ReturnsTrue()
        {
            //Arrange 
            string fileName = "existing.log";
            string filePath = Path.Combine(_testLogDirectory, fileName);
            File.WriteAllText(filePath, "Log content");

            //Act
            bool result = _logService.LogFileExists(fileName);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void LogFileExists_FileDoesNotExist_ReturnsFalse()
        {
            //Act
            bool result = _logService.LogFileExists("testFile.log");

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void GetLatestLogFile_NoFiles_ReturnsEmptyList()
        {
            //Act
            var result = _logService.GetLatestLogFiles(5);

            //Assert
            Assert.IsEmpty(result);
        }

        [Test]
        public void GetLatestLogFiles_ReturnsMostRecentFiles()
        {
            //Arrange
            List<string> fileNames = new List<string>() { "log1.log", "log2.log", "log3.log"};
            List<DateTime> timestamps = new List<DateTime>
            {
                DateTime.Now.AddHours(-3),
                DateTime.Now.AddHours(-1),
                DateTime.Now.AddHours(-2)
            };

            for(int i = 0; i < fileNames.Count; i++)
            {
                string filePath = Path.Combine(_testLogDirectory, fileNames[i]);
                File.WriteAllText(filePath, "Test content");
                File.SetLastWriteTime(filePath, timestamps[i]);
            }

            //Act
            List<string> result = _logService.GetLatestLogFiles(2).ToList();

            Assert.IsNotEmpty(result);
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.IsTrue(result[0].EndsWith("log2.log"));
            Assert.IsTrue(result[1].EndsWith("log3.log"));
        }
    }
}
