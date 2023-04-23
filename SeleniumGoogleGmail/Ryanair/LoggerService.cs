using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryanair
{
    public sealed class LoggerService
    {
        private static LoggerService? _instance;
        private const string PATH = @"C:\Users\Irina\Documents\MyLog.txt";

        private LoggerService() 
        {
            File.WriteAllText(PATH, string.Empty);
        }
        public static LoggerService GetLogger()
        {
            _instance ??= new LoggerService();
            return _instance;
        }

        internal async Task WriteLogAsync(string message)
        {
            using StreamWriter sw = new(PATH, true, System.Text.Encoding.Default);
            await sw.WriteLineAsync(message);
        }
    }
}
