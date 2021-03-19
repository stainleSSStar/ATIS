using System;
using System.IO;
using System.IO.Compression;
using System.Threading;

namespace ATIS
{
    class ATIS_wrapper
    {
        public void Compress(DirectoryInfo directory_path, string archive_name)
        {
            try
            {
                foreach (DirectoryInfo directory in directory_path.GetDirectories())
                {
                    var path = directory_path.FullName;
                    string start_path = path + directory.Name;
                    string zip_path = path + "" + archive_name + ".zip";
                    ZipFile.CreateFromDirectory(start_path, zip_path);
                }
            }
            catch (Exception exception_log)
            {
                Console.Clear();
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine(exception_log.ToString() + "\n");
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine("FILE DOESNT EXIST OR YOU DO NOT HAVE PREMISSIONS TO DO THAT - OPERATION FAILED");
                Thread.Sleep(5000);
            }
        }
        public void DecompressNormal(DirectoryInfo directory_path, string name_of_file)
        {
            try
            {
                var path = directory_path.FullName;
                string zip_path = path + name_of_file + ".zip";
                string extract_path = path;
                ZipFile.ExtractToDirectory(zip_path, extract_path);
            }
            catch (Exception exception_log)
            {
                Console.Clear();
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine(exception_log.ToString() + "\n");
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine("FILE DOESNT EXIST OR YOU DO NOT HAVE PREMISSIONS TO DO THAT - OPERATION FAILED");
                Thread.Sleep(5000);
            }
        }

        public void DecompressServer(DirectoryInfo directory_path, string name_of_file)
        {
            try
            {
                var path = directory_path.FullName;
                string zip_path = path + name_of_file;
                string extract_path = path;
                ZipFile.ExtractToDirectory(zip_path, extract_path);
            }
            catch (Exception exception_log)
            {
                Console.Clear();
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine(exception_log.ToString() + "\n");
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine("FILE DOESNT EXIST OR YOU DO NOT HAVE PREMISSIONS TO DO THAT - OPERATION FAILED");
                Thread.Sleep(5000);
            }
        }
    }
}