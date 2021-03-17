using System;
using System.Diagnostics;
using System.IO;

namespace ATIS
{
    class ATIS_installer
    {
        private string relative_application_installation_folder_path = ".\\INSTALLATION\\";
        public string getRelativeDefaultPath()
        {
            return relative_application_installation_folder_path;
        }
        public void installMSI(string path, string name_of_file , string arguments)
        {
            try
            {
                if (name_of_file == "ATIS_INSTALL_ALL")
                {
                    string[] all_files = Directory.GetFiles(path, "*.msi");
                    foreach (string file in all_files)
                    {
                        Console.WriteLine("Installing ... " + file);
                        string filef = Path.GetFullPath(file);
                        Process installer_process = new Process();
                        ProcessStartInfo start_info = new ProcessStartInfo();
                        //start_info.Arguments = " /i " + '"' + filef + '"' + " /q";
                        start_info.Arguments = " /i " + '"' + filef + '"' + arguments;
                        start_info.FileName = "msiexec";
                        installer_process.StartInfo = start_info;
                        installer_process.Start();
                        installer_process.WaitForExit();
                        Console.WriteLine("Installed ..." + file);
                    }
                }
                else
                {
                    string[] specific_file = Directory.GetFiles(path, name_of_file + ".msi");
                    foreach (string file in specific_file)
                    {
                        Console.WriteLine("Installing ... " + file);
                        string filef = Path.GetFullPath(file);
                        Process installer_process = new Process();
                        ProcessStartInfo start_info = new ProcessStartInfo();
                        //start_info.Arguments = " /i " + '"' + filef + '"' + " /q";
                        start_info.Arguments = " /i " + '"' + filef + '"' + arguments;
                        start_info.FileName = "msiexec";
                        installer_process.StartInfo = start_info;
                        installer_process.Start();
                        installer_process.WaitForExit();
                        Console.WriteLine("Installed ..." + file);
                    }
                }
            }
            catch (Exception exception_log)
            {
                Console.Clear();
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine(exception_log.ToString() + "\n");
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine("FILE DOESNT EXIST OR PROVIDED PARAMETERS ARE WRONG - OPERATION FAILED");
            }

        }

        public void installEXE(string path , string name_of_file , string arguments)
        {
            try
            {
                if (name_of_file == "ATIS_INSTALL_ALL")
                {
                    string[] all_files = Directory.GetFiles(path, "*.exe");
                    foreach (string file in all_files)
                    {

                        Console.WriteLine("Installing ... " + file);
                        Process installer_process = new Process();
                        ProcessStartInfo start_info = new ProcessStartInfo();
                        start_info.Arguments = arguments;
                        start_info.CreateNoWindow = false;
                        start_info.WindowStyle = ProcessWindowStyle.Normal;
                        start_info.FileName = Path.GetFullPath(file);
                        start_info.UseShellExecute = false;
                        installer_process.StartInfo = start_info;
                        installer_process.Start();
                        installer_process.WaitForExit();
                        Console.WriteLine("Installed ... " + file);
                    }
                }
                else
                {
                    string[] specific_file = Directory.GetFiles(path, name_of_file + ".exe");
                    foreach (string file in specific_file)
                    {

                        Console.WriteLine("Installing ... " + file);
                        Process installer_process = new Process();
                        ProcessStartInfo start_info = new ProcessStartInfo();
                        start_info.Arguments = "";
                        start_info.CreateNoWindow = false;
                        start_info.WindowStyle = ProcessWindowStyle.Normal;
                        start_info.FileName = Path.GetFullPath(file);
                        start_info.UseShellExecute = false;
                        installer_process.StartInfo = start_info;
                        installer_process.Start();
                        installer_process.WaitForExit();
                        Console.WriteLine("Installed ... " + file);
                    }
                }
            }
            catch (Exception exception_log)
            {
                Console.Clear();
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine(exception_log.ToString() + "\n");
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine("FILE DOESNT EXIST - OPERATION FAILED");
            }
        }
    }
}
