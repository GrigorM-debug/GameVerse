using GameVerse.Web.Areas.Administrator.Services.Interfaces;

namespace GameVerse.Web.Areas.Administrator.Services
{
    /// <summary>
    /// Service for managing and retrieving log files from the application.
    /// </summary>
    public class LogService : ILogService
    {
        private readonly string _logDirectory;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogService"/> class.
        /// Sets the log directory path to the "logs" folder in the application's root directory.
        /// </summary>
        public LogService()
        {
            _logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "logs");
        }

        /// <summary>
        /// Retrieves the content of a specific log file.
        /// </summary>
        /// <param name="fileName">The name of the log file to retrieve.</param>
        /// <returns>
        /// A tuple containing:
        /// <list type="bullet">
        /// <item><description>The file content as a byte array.</description></item>
        /// <item><description>The content type (default: "application/octet-stream").</description></item>
        /// <item><description>The name of the file.</description></item>
        /// </list>
        /// Returns <c>null</c> if the file does not exist.
        /// </returns>
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

        /// <summary>
        /// Checks whether a log file with the specified name exists in the log directory.
        /// </summary>
        /// <param name="fileName">The name of the log file to check.</param>
        /// <returns><c>true</c> if the file exists; otherwise, <c>false</c>.</returns>
        public bool LogFileExists(string fileName)
        {
            string filePath = Path.Combine(_logDirectory, fileName);
            return System.IO.File.Exists(filePath);
        }

        /// <summary>
        /// Retrieves the names of the most recent log files, ordered by their last modification time.
        /// </summary>
        /// <param name="numberOfFiles">The maximum number of recent log files to retrieve.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> of strings representing the full paths of the latest log files.
        /// Returns an empty list if the log directory does not exist or contains no files.
        /// </returns>
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
