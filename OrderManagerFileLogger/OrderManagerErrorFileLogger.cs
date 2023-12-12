using Microsoft.Extensions.Logging;

namespace OrderManagerFileLogger
{
    public class ErrorFileLoggerProvider : ILoggerProvider
    {
        private readonly string _filePath;
        private readonly long _fileSizeLimitBytes;

        public ErrorFileLoggerProvider(string filePath, long fileSizeLimitBytes)
        {
            _filePath = filePath;
            _fileSizeLimitBytes = fileSizeLimitBytes;

            // Check if the file exists and create it if it doesn't
            if (!File.Exists(_filePath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_filePath));
                File.Create(_filePath).Dispose();
            }
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new UnityErrorFileLogger(_filePath, _fileSizeLimitBytes);
        }

        public void Dispose() { }
    }

    public class UnityErrorFileLogger : ILogger
    {
        private readonly string _filePath;
        private readonly long _fileSizeLimitBytes;
        private static object _lock = new object();

        public UnityErrorFileLogger(string filePath, long fileSizeLimitBytes)
        {
            _filePath = filePath;
            _fileSizeLimitBytes = fileSizeLimitBytes;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel >= LogLevel.Error; // Adjust the minimum log level as needed
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;

            lock (_lock)
            {
                var logMessage = formatter(state, exception);
                TruncateLogFileIfNeeded(logLevel, logMessage);
                using (StreamWriter writer = new StreamWriter(_filePath, true))
                {
                    writer.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} - EventID: {eventId} - {logLevel}: {logMessage}");
                    writer.WriteLine("-----------------------------------------------------");
                }
            }
        }

        private void TruncateLogFileIfNeeded(LogLevel logLevel, string logMessage)
        {
            FileInfo fileInfo = new FileInfo(_filePath);
            while (fileInfo.Exists && fileInfo.Length >= _fileSizeLimitBytes)
            {
                string[] lines = File.ReadAllLines(_filePath);
                long currentSize = new FileInfo(_filePath).Length;

                // Calculate the space required for the new log entry
                long newLogSize = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} - {logLevel}: {logMessage}".Length + Environment.NewLine.Length;

                // Calculate how many lines to remove to make space for the new log entry
                int linesToRemove = 0;
                for (int i = 0; i < lines.Length; i++)
                {
                    currentSize -= lines[i].Length + Environment.NewLine.Length;
                    linesToRemove++;
                    if (currentSize + newLogSize < _fileSizeLimitBytes)
                        break;
                }

                string[] linesToWrite = lines.Skip(linesToRemove).ToArray();
                File.WriteAllLines(_filePath, linesToWrite);
                fileInfo = new FileInfo(_filePath); // Update file info after truncating
            }
        }
    }
}
