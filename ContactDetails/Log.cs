using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDetails
{
    public sealed class Log
    {
        public enum LogType
        {
            Error,
            Info
        }

        public static string ErrorPath { get { return System.IO.Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Error.log"); } }
        public static string InfoPath { get { return System.IO.Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Info.log"); } }
        List<string> _errorLogs = new List<string>();
        List<string> _infoLogs = new List<string>();
        Log() { }
        private static Log _logInstance = null;
        public static Log LogInstance 
        {
            get 
            {
                if (_logInstance == null) 
                {
                    _logInstance = new Log();
                    File.Delete(ErrorPath);
                    File.Delete(InfoPath);
                }
                return _logInstance;
            } 
        }

        public void Error(string message) 
        {
            var msg = $"{DateTime.Now} - {message}";
            _errorLogs.Add(msg);
            File.WriteAllText(InfoPath, msg);
        }
        public void Info(string message)
        { 
            var msg = $"{DateTime.Now} - {message}";
            _infoLogs.Add($"{DateTime.Now} - {msg}");
            File.WriteAllText(InfoPath, msg);
        }

        public List<string> GetLogs(LogType logType)
        {
            switch (logType)
            {
                case LogType.Error:
                    return _errorLogs;
                case LogType.Info:
                    return _infoLogs; 
                default:
                    return new List<string>() { "No logs found." };
            }
        }

    }
}
