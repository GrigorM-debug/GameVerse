namespace GameVerse.Web.Areas.Administrator.Services.Interfaces
{
    /// <summary>
    /// Provides methods for managing and retrieving application log files.
    /// </summary>
    public interface ILogService
    {
        /// <summary>
        /// Retrieves the content of a specified log file.
        /// </summary>
        /// <param name="fileName">The name of the log file to retrieve.</param>
        /// <returns>
        /// A tuple containing the file content as a byte array, the content type as a string, 
        /// and the file name as a string, or <c>null</c> if the file is not found.
        /// </returns>
        public (byte[] FileContent, string ContentType, string FileName)? GetLogFile(string fileName);

        /// <summary>
        /// Checks whether a log file with the specified name exists.
        /// </summary>
        /// <param name="fileName">The name of the log file to check.</param>
        /// <returns>
        /// <c>true</c> if the log file exists; otherwise, <c>false</c>.
        /// </returns>
        public bool LogFileExists(string fileName);

        /// <summary>
        /// Retrieves the names of the latest log files, up to the specified number.
        /// </summary>
        /// <param name="numberOfFiles">The number of recent log files to retrieve.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> of strings representing the names of the latest log files.
        /// </returns>
        IEnumerable<string> GetLatestLogFiles(int numberOfFiles);
    }
}
