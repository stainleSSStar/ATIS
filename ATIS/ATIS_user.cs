using System;
using System.Collections;
using System.DirectoryServices;
using System.Globalization;
using System.Threading;

namespace ATIS
{
   public class ATIS_user
    {

        public void addLocalUser(string name, string pass, string description, string group)
        {
            try
            {
                string user_name = name;
                string password = pass;
                DirectoryEntry local_computer_path = new DirectoryEntry("WinNT://" + Environment.MachineName + ",computer");
                DirectoryEntry new_user = local_computer_path.Children.Add(user_name, "user");
                new_user.Invoke("SetPassword", new object[] { password });
                new_user.Invoke("Put", new object[] { "Description", description });
                new_user.CommitChanges();
                if (group.ToLower() != "none" || group != "")
                {
                    try
                    {
                        DirectoryEntry local_group = local_computer_path.Children.Find(group, "group");
                        local_group.Invoke("Add", new object[] { new_user.Path.ToString() });
                        Console.WriteLine("\nSUCCESSFULLY ADDED NEW USER AND ASSIGNED A GROUP");
                    }
                    catch
                    {
                        Console.WriteLine("\nGROUP NOT FOUND IN A SYSTEM OR NOT PROVIDED - SKIPPING");
                        Console.WriteLine("SUCCESSFULLY ADDED NEW USER");
                    }
                }
                else
                {
                    Console.WriteLine("SUCCESSFULLY ADDED NEW USER");
                }
            }
            catch(Exception exception_log)
            {
                Console.Clear();
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine(exception_log.ToString() + "\n");
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine("USER ALREADY EXISTS - OPERATION FAILED");
                Thread.Sleep(5000);
            }
        }
        public void removeLocalUser(string name)
        {
            try
            {
                string user_name = name;
                DirectoryEntry local_computer_path = new DirectoryEntry("WinNT://" + Environment.MachineName + ",computer");
                DirectoryEntries users = local_computer_path.Children;
                DirectoryEntry existing_user = users.Find(user_name);
                users.Remove(existing_user);
                Console.WriteLine("\nUSER REMOVED SUCCESSFULLY");
            }
            catch (Exception exception_log)
            {
                Console.Clear();
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine(exception_log.ToString() + "\n");
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine("USER DOES NOT EXIST - OPERATION FAILED");
                Thread.Sleep(5000);
            }
        }
        public void getAllUsers()
        {
            try
            {
                string sPath = "WinNT://" + Environment.MachineName + ",computer";
                using (var local_computer_path = new DirectoryEntry(sPath))
                    foreach (DirectoryEntry user_entry in local_computer_path.Children)
                        if (user_entry.SchemaClassName == "User")
                        {
                            Console.WriteLine(user_entry.Name);
                            object groups = user_entry.Invoke("Groups");
                            foreach (object ob in (System.Collections.IEnumerable)groups)
                            {
                                DirectoryEntry group_entry = new DirectoryEntry(ob);
                                Console.WriteLine("\t(" + group_entry.Name + ")");
                                group_entry.Close();
                            }
                        }
            }
            catch(Exception exception_log)
            {
                Console.Clear();
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine(exception_log.ToString() + "\n");
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine("THERE IS NO USERS OR YOU HAVE NO PREMISSIONS TO DO THAT - OPERATION FAILED");
                Thread.Sleep(5000);
            }
        }
        public void getAllGroups()
        {
            try
            {
                DirectoryEntry local_computer_path = new DirectoryEntry("WinNT://" + Environment.MachineName + ",Computer");
                foreach (DirectoryEntry group in local_computer_path.Children)
                {
                    if (group.SchemaClassName == "Group")
                    {
                        Console.WriteLine(group.Name);
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
        public void removeUserFromGroup(string user, string group)
        {
            try
            {
                DirectoryEntry local_computer_path = new DirectoryEntry("WinNT://" + Environment.MachineName + ",Computer");
                var groups = local_computer_path.Children.Find(group, "group");

                foreach (object member in (IEnumerable)groups.Invoke("Members"))
                {
                    using (var member_entry = new DirectoryEntry(member))
                        if (member_entry.Name == user)
                            groups.Invoke("Remove", new[] { member_entry.Path });
                }

                groups.CommitChanges();
                groups.Dispose();
                Console.WriteLine("USER '" + user + "' REMOVED FROM GROUP '" + group + "' SUCCESSFULLY");
            }
            catch (Exception exception_log)
            {
                Console.Clear();
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine(exception_log.ToString() + "\n");
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine("GROUP/USER DOES/DOES NOT EXIST/WAS NOT PROVIDED OR ALREADY DOES NOT BELONG TO THE GROUP - OPERATION FAILED");
                Thread.Sleep(5000);
            }
        }
        public void addLocalGroup(string name_of_group , string description)
        {
            try
            {
                var ad = new DirectoryEntry("WinNT://" + Environment.MachineName + ",computer");
                DirectoryEntry new_group = ad.Children.Add(name_of_group, "group");
                if (description.ToLower() != "none" || description != "")
                {
                    new_group.Invoke("Put", new object[] { "Description", description });
                }
                new_group.CommitChanges();
                Console.WriteLine("\nLOCAL USERS GROUP CREATED SUCCESSFULLY");
            }
            catch (Exception exception_log)
            {
                Console.Clear();
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine(exception_log.ToString() + "\n");
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine("GROUP ALREADY EXISTS OR USER DID NOT PROVIDE GROUP NAME - OPERATION FAILED");
                Thread.Sleep(5000);
            }
        }
        public void removeLocalGroup(string name_of_group)
        {
            try
            {
                var ad = new DirectoryEntry("WinNT://" + Environment.MachineName + ",computer");
                DirectoryEntry group = ad.Children.Find(name_of_group, "group");
                ad.Children.Remove(group);
                Console.WriteLine("\nGROUP REMOVED SUCCESSFULLY");
            }
            catch (Exception exception_log)
            {
                Console.Clear();
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine(exception_log.ToString() + "\n");
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine("GROUP DOES NOT EXIST OR USER DID NOT PROVIDE GROUP NAME - OPERATION FAILED");
                Thread.Sleep(5000);
            }
        }
        public bool addUserToLocalGroup(string user_name, string group_name)
        {
            DirectoryEntry user_group = null;

            try
            {
                string group_path = String.Format(CultureInfo.CurrentUICulture, "WinNT://{0}/{1},group", Environment.MachineName, group_name);
                user_group = new DirectoryEntry(group_path);

                if ((null == user_group) || (true == String.IsNullOrEmpty(user_group.SchemaClassName)) || (0 != String.Compare(user_group.SchemaClassName, "group", true, CultureInfo.CurrentUICulture)))
                    return false;

                String user_path = String.Format(CultureInfo.CurrentUICulture, "WinNT://{0},user", user_name);
                user_group.Invoke("Add", new object[] { user_path });
                user_group.CommitChanges();
                Console.WriteLine("USER '"+user_name+"' ADDED TO GROUP '"+group_name+"' SUCCESSFULLY");
                return true;
            }
            catch (Exception exception_log)
            {
                Console.Clear();
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine(exception_log.ToString() + "\n");
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine("GROUP/USER DOES/DOES NOT EXIST/WAS NOT PROVIDED OR ALREADY ASSIGNED TO THE SAME GROUP - OPERATION FAILED");
                Thread.Sleep(5000);
                return false;
            }
            finally
            {
                if (null != user_group) { 
                    user_group.Dispose();
                }

            }
        }
    }
}

