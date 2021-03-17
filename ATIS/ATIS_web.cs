using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Threading;

namespace ATIS
{
    class ATIS_web
    {
        private string relative_application_download_folder_path = ".\\DOWNLOADS\\";
        public string getRelativeDefaultPath() {
            return relative_application_download_folder_path;
        }
        public bool downloadFileFromURL(string URL,string path,string name_of_file,string extension)
        {
            try
            {
                var client = new WebClient();
                string full_path = Path.GetFullPath(path);
                client.DownloadFile(URL, full_path + "\\" + name_of_file + extension);
                return true;
            }
            catch (Exception exception_log)
            {
                Console.Clear();
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine(exception_log.ToString() + "\n");
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine("URL/PATH IS INCORRECT OR FILE OF THAT NAME ALREADY EXISTS - OPERATION FAILED");
                Thread.Sleep(5000);
                return false;
            }
        }

        public bool pingHost(string hostname)
        {
            bool pingable = false;
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(hostname);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException exception_log)
            {

                Console.Clear();
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine(exception_log.ToString() + "\n");
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine("CONNECTION CANNOT BE ESTABLISHED - OPERATION FAILED");
                Thread.Sleep(5000);
                return false;
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            return pingable;
        }
    }
}
