using System;
using System.Collections;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Globalization;
using System.Security.Principal;

namespace ATIS
{
    class ATIS_users
    {
        ATIS_config config = new ATIS_config();

        public void addLocalUser(string name, string pass, string description, string group)
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
        public bool RemoveUserFromAdminGroup(string user)
        {
            try
            {
                DirectoryEntry machine = new DirectoryEntry("WinNT://" + Environment.MachineName + ",Computer");
                var objGroup = machine.Children.Find("Goście", "group");

                foreach (object member in (IEnumerable)objGroup.Invoke("Members"))
                {
                    using (var memberEntry = new DirectoryEntry(member))
                        if (memberEntry.Name == user)
                            objGroup.Invoke("Remove", new[] { memberEntry.Path });
                }

                objGroup.CommitChanges();
                objGroup.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public void addLocalGroup(string name_of_group)
        {
            var ad = new DirectoryEntry("WinNT://" + Environment.MachineName + ",computer");
            DirectoryEntry newGroup = ad.Children.Add(name_of_group, "group");
            newGroup.Invoke("Put", new object[] { "Description", "Test Group from .NET" });
            newGroup.CommitChanges();
        }
        public void removeLocalGroup(string name_of_group)
        {
            var ad = new DirectoryEntry("WinNT://" + Environment.MachineName + ",computer");
            DirectoryEntry group = ad.Children.Find(name_of_group, "group");
            ad.Children.Remove(group);
        }
        public  bool AddUserToLocalGroup(string userName, string groupName)
        {
            DirectoryEntry userGroup = null;

            try
            {
                string groupPath = String.Format(CultureInfo.CurrentUICulture, "WinNT://{0}/{1},group", Environment.MachineName, groupName);
                userGroup = new DirectoryEntry(groupPath);

                if ((null == userGroup) || (true == String.IsNullOrEmpty(userGroup.SchemaClassName)) || (0 != String.Compare(userGroup.SchemaClassName, "group", true, CultureInfo.CurrentUICulture)))
                    return false;

                String userPath = String.Format(CultureInfo.CurrentUICulture, "WinNT://{0},user", userName);
                userGroup.Invoke("Add", new object[] { userPath });
                userGroup.CommitChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (null != userGroup) userGroup.Dispose();
            }
        }
    }
}

