using System;
using System.IO;
using System.Text;

namespace SingletonLoggerLib
{
    public enum LogLevel
    {
        INFO = 1,
        WARNING = 2,
        ERROR = 3
    }

    public class Logger
    {
        private static Logger _logger = null;
        private static readonly object _classLock = typeof(Logger);
        private static readonly object _locker = new object();

        private static StreamWriter _output = null;
        public static string _logFilePath = @"LogDetails.log";


        private Logger()
        {
        }

        public static Logger GetLoggerInstance()
        {
            lock (_classLock)
            {
                if (_logger == null)
                {
                    _logger = new Logger();
                }
            }

            return _logger;
        }

        public void LogMessage(string msg, LogLevel logLevel)
        {
            try
            {
                lock (_locker)
                {
                    if (_output == null)
                    {
                        _output = new StreamWriter(_logFilePath, true, UnicodeEncoding.Default);
                    }

                    _output.WriteLine(DateTime.Now + " | " + logLevel.ToString().PadRight(7, ' ') +" | " + msg, new object[0]);

                    if (_output != null)
                    {
                        _output.Close();
                        _output = null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, new object[0]);
                throw;
            }
        }
    }
}
