namespace GameVerse.Web.Areas.Administrator.Services.Interfaces
{
    public interface ILogService
    {
        public (byte[] FileContent, string ContentType, string FileName)? GetLogFile(string fileName);

        public bool LogFileExists(string fileName);

        List<string> GetLatestLogFiles(int numberOfFiles);
    }
}
