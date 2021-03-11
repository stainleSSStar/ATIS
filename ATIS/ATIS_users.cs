using System;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Security.Principal;

namespace ATIS
{
    class ATIS_users
    {
        ATIS_config config = new ATIS_config();

        public void addLocalUser(string name , string pass, string description,string group)
        {
            string user_name = name;
            string password = pass;
            DirectoryEntry local_computer_path = new DirectoryEntry("WinNT://" + Environment.MachineName + ",computer");
            DirectoryEntry new_user = local_computer_path.Children.Add(user_name, "user");
            new_user.Invoke("SetPassword", new object[] { password });
            new_user.Invoke("Put", new object[] { "Description", description });
            new_user.CommitChanges();
            DirectoryEntry local_group = local_computer_path.Children.Find(group, "group");
            local_group.Invoke("Add", new object[] { new_user.Path.ToString() });
        }

        public void removeLocalUser(string name)
        {
            string user_name = name;
            DirectoryEntry local_computer_path = new DirectoryEntry("WinNT://" + Environment.MachineName + ",computer");
            DirectoryEntries users = local_computer_path.Children;
            DirectoryEntry existing_user = users.Find(user_name);
            users.Remove(existing_user);
        }

        public void getAllUsers()
        {
            string sPath = "WinNT://" + Environment.MachineName + ",computer";
            using (var computerEntry = new DirectoryEntry(sPath))
                foreach (DirectoryEntry childEntry in computerEntry.Children)
                    if (childEntry.SchemaClassName == "User")
                    {
                        Console.WriteLine(childEntry.Name);
                        object obGroups = childEntry.Invoke("Groups");
                        foreach (object ob in (System.Collections.IEnumerable)obGroups)
                        {
                            DirectoryEntry obGpEntry = new DirectoryEntry(ob);
                            Console.WriteLine("\t" + obGpEntry.Name);
                            obGpEntry.Close();
                        }
                    }
        }
        public void getAllGroups()
        {
            DirectoryEntry machine = new DirectoryEntry("WinNT://" + Environment.MachineName + ",Computer");
            foreach (DirectoryEntry child in machine.Children)
            {
                if (child.SchemaClassName == "Group")
                {
                    Console.WriteLine(child.Name);
                }
            }
        }
    }
}

