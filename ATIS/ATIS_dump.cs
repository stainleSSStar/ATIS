using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ATIS
{
    class ATIS_dump
    {
        private string relative_application_dump_folder_path = ".\\DUMPS\\";



        public void dumpAllUsers()
        {
                try
                {
                    string sPath = "WinNT://" + Environment.MachineName + ",computer";
                using (var local_computer_path = new DirectoryEntry(sPath))
                    foreach (DirectoryEntry user_entry in local_computer_path.Children)
                    {
                        if (user_entry.SchemaClassName == "User")
                        {
                            File.AppendAllText(relative_application_dump_folder_path + "users_dump.txt", user_entry.Name);
                            object groups = user_entry.Invoke("Groups");
                            foreach (object ob in (System.Collections.IEnumerable)groups)
                            {
                                DirectoryEntry group_entry = new DirectoryEntry(ob);
                                File.AppendAllText(relative_application_dump_folder_path + "users_dump.txt", "(" + group_entry.Name + ")");
                                group_entry.Close();
                            }
                            File.AppendAllText(relative_application_dump_folder_path + "users_dump.txt", "\n");
                        }
                    }
                }
                catch (Exception exception_log)
                {
                    Console.Clear();
                    Console.Write("=======================================================================================================================\n");
                    Console.WriteLine(exception_log.ToString() + "\n");
                    Console.Write("=======================================================================================================================\n");
                    Console.WriteLine("THERE IS NO USERS OR YOU HAVE NO PREMISSIONS TO DO THAT - OPERATION FAILED");
                }
        }

        public void dumpAllGroups()
        {
            try
            {
                DirectoryEntry local_computer_path = new DirectoryEntry("WinNT://" + Environment.MachineName + ",Computer");
                foreach (DirectoryEntry group in local_computer_path.Children)
                {
                    if (group.SchemaClassName == "Group")
                    {
                        File.AppendAllText(relative_application_dump_folder_path + "groups_dump.txt", group.Name + "\n");
                    }
                }
            }
            catch (Exception exception_log)
            {
                Console.Clear();
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine(exception_log.ToString() + "\n");
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine("THERE IS NO GROUPS OR YOU HAVE NO PREMISSIONS TO DO THAT - OPERATION FAILED");
                Thread.Sleep(5000);
            }
        }
    }
}
