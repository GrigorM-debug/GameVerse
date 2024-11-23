using GameVerse.Web.Areas.Administrator.Services.Interfaces;

namespace GameVerse.Web.Areas.Administrator.Services
{
    public class LogService : ILogService
    {
        private readonly string _logDirectory;

        public LogService()
        {
            _logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "logs");
        }

        public (byte[] FileContent, string ContentType, string FileName)? GetLogFile(string fileName)
        {
            string filePath = Path.Combine(_logDirectory, fileName);

            if (!System.IO.File.Exists(filePath))
            {
                return null; 
            }

            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            string contentType = "application/octet-stream";

            return (fileBytes, contentType, fileName);
        }

        public bool LogFileExists(string fileName)
        {
            string filePath = Path.Combine(_logDirectory, fileName);
            return System.IO.File.Exists(filePath);
        }

        public IEnumerable<string> GetLatestLogFiles(int numberOfFiles)
        {
            if (!Directory.Exists(_logDirectory))
            {
                return new List<string>();
            }

            IEnumerable<string> logFiles = Directory.GetFiles(_logDirectory)
                .Select(file => new FileInfo(file)) 
                .OrderByDescending(file => file.LastWriteTime) 
                .Take(numberOfFiles) 
                .Select(file => file.FullName) 
                .ToList();

            return logFiles;
        }
    }
}
