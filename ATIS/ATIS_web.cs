using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ATIS
{
    class ATIS_web
    {
        public bool downloadFileFromURL(string URL,string path,string name_of_file)
        {
            var client = new WebClient();
            string fullpath = Path.GetFullPath(path);
            client.DownloadFile(URL, fullpath+"\\"+name_of_file);
            return true;
        }
    }
}
