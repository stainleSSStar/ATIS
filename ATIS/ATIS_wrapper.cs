using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Threading;

namespace ATIS
{
    public class ATIS_wrapper
    {
        public void Compress(DirectoryInfo directory_path, string archive_name)
        {
            try
            {
                    string zip_path = directory_path.FullName + "\\" + archive_name + ".zip";
                    ZipFile.CreateFromDirectory(directory_path.FullName, directory_path.Parent.FullName+archive_name+".zip");
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
        public void Empty(DirectoryInfo directory)
        {
            foreach (FileInfo file in directory.GetFiles()) file.Delete();
            foreach (DirectoryInfo directory_inside in directory.GetDirectories()) directory_inside.Delete(true);
        }
        public int CountAllFilesAndDirectories(DirectoryInfo directory)
        {
            List<string> file_list = new List<string>();
            foreach (FileInfo file in directory.GetFiles()) file_list.Add(file.FullName);
            foreach (DirectoryInfo directory_inside in directory.GetDirectories()) file_list.Add(directory_inside.FullName);
            return file_list.Count;
        }
    }
}