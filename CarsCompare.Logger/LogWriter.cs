using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace CarsCompare.Logger
{
    public class LogWriter
    {
        private readonly log4net.ILog _writer;

        public LogWriter()
        {
            log4net.Config.XmlConfigurator.Configure();
            log4net.LogicalThreadContext.Properties["ipaddress"] = GetIPAddress();
            _writer = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Uncomment this if you are having config problems
            //            if (!log4net.LogManager.GetRepository().Configured)
            //            {
            //                // log4net not configured
            //                System.Diagnostics.Debug.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            //                
            //                foreach (var message in log4net.LogManager.GetRepository().ConfigurationMessages.Cast<log4net.Util.LogLog>())
            //                {
            //                    System.Diagnostics.Debug.WriteLine(message);
            //                }
            //
            //                System.Diagnostics.Debug.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            //            }
        }

        public Task WriteDebugAsync(string message, Exception exception = null)
        {
            return Task.Run(() => _writer.Debug(message, exception));
        }

        public Task WriteInfoAsync(string message, Exception exception = null)
        {
            return Task.Run(() => _writer.Info(message, exception));
        }

        public Task WriteWarningAsync(string message, Exception exception = null)
        {
            return Task.Run(() => _writer.Warn(message, exception));
        }

        public void WriteError(string message, Exception exception = null)
        {
            _writer.Error(message, exception);
        }

        public void WriteFatal(string message, Exception exception = null)
        {
            _writer.Fatal(message, exception);
        }

        private string GetIPAddress()
        {
            string localIp = "?";

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIp = ip.ToString();
                    break;
                }
            }

            return localIp;
        }
    }
}