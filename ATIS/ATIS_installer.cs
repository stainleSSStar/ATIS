using System;
using System.Diagnostics;
using System.IO;

namespace ATIS
{
    class ATIS_installer
    {
        public void installMSI(string path)
        {
            string[] allFiles = Directory.GetFiles(path, "*.msi");
            foreach (string file in allFiles)
            {
                Console.WriteLine("Installing ... " + file);
                string filef = Path.GetFullPath(file);
                Process installerProcess = new Process();
                ProcessStartInfo processInfo = new ProcessStartInfo();
                processInfo.Arguments = " /i "+'"'+filef+'"'+" /q";
                processInfo.FileName = "msiexec";
                installerProcess.StartInfo = processInfo;
                installerProcess.Start();
                installerProcess.WaitForExit();
                Console.WriteLine("Installed ..." + file);
            }

        }

        public void installEXE(string path)
        {
            string[] allFiles = Directory.GetFiles(path, "*.exe");
            foreach (string file in allFiles)
            {
                Console.WriteLine("Installing ... " + file);
                Process installerProcess = new Process();
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.Arguments = "";
                psi.CreateNoWindow = false;
                psi.WindowStyle = ProcessWindowStyle.Normal;
                psi.FileName = Path.GetFullPath(file);
                psi.UseShellExecute = false;
                installerProcess.StartInfo =psi;
                installerProcess.Start();
                installerProcess.WaitForExit();
                Console.WriteLine("Installed ..." + file);
            }

        }
    }
}
