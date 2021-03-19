using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
namespace ATIS
{
    class ATIS_shell
    {
        public static void Main(string[] args)
        {
            ATIS_config config = new ATIS_config();
            ATIS_user users_manipulation = new ATIS_user();
            ATIS_dump dump = new ATIS_dump();
            ATIS_installer installer = new ATIS_installer();
            ATIS_web web = new ATIS_web();
            ATIS_server server = new ATIS_server();
            ATIS_wrapper wrapper = new ATIS_wrapper();
            Console.Title = config.getShellTitle();
            Console.SetWindowSize(config.getWindowWidth(), config.getWindowHeight());
            Console.ForegroundColor = config.getShellTextColor();
            String processname = Process.GetCurrentProcess().ProcessName;
            Process[] running_processes = Process.GetProcessesByName(processname);
            if (running_processes.Length > 1)
            {
                Console.WriteLine("APPLICATION IS ALREADY RUNNING - EXITING");
                Thread.Sleep(2000);
                Environment.Exit(0);
            }
            Console.WriteLine(config.getShellMainMenuList());
            Console.Write("CHOOSEN OPERATION: ");
            config.setOperationSwitcher(Console.ReadLine());

            switch (config.getOperationSwitcher())
            {
                case "1":
                    Process WSUMCHECKER = new Process();
                    WSUMCHECKER.StartInfo.FileName = config.getWSumCheckerRelativePath();
                    WSUMCHECKER.StartInfo.WindowStyle = config.getWSumCheckerProcessWindowStyle();
                    WSUMCHECKER.Start();
                    WSUMCHECKER.WaitForExit();
                    Console.Clear();
                    Main(null);
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine(config.getShellUsersList());
                    config.setOperationSwitcher("NOT SELECTED YET");
                    Console.Write("CHOOSEN OPERATION: ");
                    config.setOperationSwitcher(Console.ReadLine());
                    switch (config.getOperationSwitcher())
                    {
                        case "1":
                            Console.Clear();
                            Console.Write("NAME OF THE NEW USER : ");
                            string name_op1 = Console.ReadLine();
                            if (name_op1 == "ATIS_BACK") { Console.Clear(); Main(null); }
                            Console.Write("\nPASSWORD : ");
                            string password_op1 = Console.ReadLine();
                            if (password_op1 == "ATIS_BACK") { Console.Clear(); Main(null); }
                            Console.Write("\nDESCRIPTION : ");
                            string description_op1 = Console.ReadLine();
                            if (description_op1 == "ATIS_BACK") { Console.Clear(); Main(null); }
                            Console.Write("\nGROUP (LEAVE BLANK OR WRITE 'NONE' IF YOU DONT WANT TO ASSIGN) : ");
                            string group_op1 = Console.ReadLine();
                            if (group_op1 == "ATIS_BACK") { Console.Clear(); Main(null); }
                            users_manipulation.addLocalUser(name_op1, password_op1, description_op1, group_op1);
                            Thread.Sleep(5000);
                            Console.Clear();
                            Main(null);
                        break;
                        case "2":
                            Console.Clear();
                            Console.WriteLine(config.getShellSeparator());
                            Console.WriteLine("                                              AVAILABLE USERS IN THE SYSTEM");
                            Console.WriteLine(config.getShellSeparator());
                            users_manipulation.getAllUsers();
                            Console.Write("\nNAME OF THE USER : ");
                            string name_op2 = Console.ReadLine();
                            if (name_op2 == "ATIS_BACK") { Console.Clear(); Main(null); }
                            users_manipulation.removeLocalUser(name_op2);
                            Thread.Sleep(5000);
                            Console.Clear();
                            Main(null);
                            break;
                        case "3":
                            Console.Clear();
                            Console.Write("NAME OF THE NEW GROUP : ");
                            string name_op3 = Console.ReadLine();
                            if (name_op3 == "ATIS_BACK") { Console.Clear(); Main(null); }
                            Console.Write("\nDESCRIPTION OF THE GROUP (LEAVE BLANK OR WRITE 'NONE' IF YOU DONT WANT TO ASSIGN) : ");
                            string description_op3 = Console.ReadLine();
                            if (description_op3 == "ATIS_BACK") { Console.Clear(); Main(null); }
                            users_manipulation.addLocalGroup(name_op3,description_op3);
                            Thread.Sleep(5000);
                            Console.Clear();
                            Main(null);
                            break;
                        case "4":
                            Console.Clear();
                            Console.WriteLine(config.getShellSeparator());
                            Console.WriteLine("                                              AVAILABLE GROUPS IN THE SYSTEM\n");
                            Console.WriteLine(config.getShellSeparator());
                            users_manipulation.getAllGroups();
                            Console.WriteLine(config.getShellSeparator());
                            Console.Write("\nNAME OF THE GROUP TO REMOVE: ");
                            string name_op4 = Console.ReadLine();
                            if (name_op4 == "ATIS_BACK") { Console.Clear(); Main(null); }
                            users_manipulation.removeLocalGroup(name_op4);
                            Thread.Sleep(5000);
                            Console.Clear();
                            Main(null);
                            break;
                        case "5":
                            Console.Clear();
                            Console.WriteLine(config.getShellSeparator());
                            Console.WriteLine("                                              AVAILABLE USERS IN THE SYSTEM");
                            Console.WriteLine(config.getShellSeparator());
                            users_manipulation.getAllUsers();
                            Console.Write("\nNAME OF THE USER : ");
                            string name_op5 = Console.ReadLine();
                            if (name_op5 == "ATIS_BACK") { Console.Clear(); Main(null); }
                            Console.Clear();
                            Console.WriteLine(config.getShellSeparator());
                            Console.WriteLine("                                              AVAILABLE GROUPS IN THE SYSTEM");
                            Console.WriteLine(config.getShellSeparator());
                            users_manipulation.getAllGroups();
                            Console.WriteLine(config.getShellSeparator());
                            Console.Write("\nNAME OF THE GROUP FOR USER "+"'"+ name_op5 + "'" + " : ");
                            string group_op5 = Console.ReadLine();
                            if (group_op5 == "ATIS_BACK") { Console.Clear(); Main(null); }
                            users_manipulation.addUserToLocalGroup(name_op5, group_op5);
                            Thread.Sleep(5000);
                            Console.Clear();
                            Main(null);
                            break;
                        case "6":
                            Console.Clear();
                            Console.WriteLine(config.getShellSeparator());
                            Console.WriteLine("                                      AVAILABLE USERS IN THE SYSTEM AND THEIR GROUPS");
                            Console.WriteLine(config.getShellSeparator());
                            users_manipulation.getAllUsers();
                            Console.Write("\nNAME OF THE USER : ");
                            string name_op6 = Console.ReadLine();
                            if (name_op6 == "ATIS_BACK") { Console.Clear(); Main(null); }
                            Console.Write("\nNAME OF GROUP TO REMOVE FROM THE USER '"+name_op6+"' : ");
                            string group_op6 = Console.ReadLine();
                            if (group_op6 == "ATIS_BACK") { Console.Clear(); Main(null); }
                            users_manipulation.removeUserFromGroup(name_op6, group_op6);
                            Thread.Sleep(5000);
                            Console.Clear();
                            Main(null);
                            break;
                        case "7":
                            Console.Clear();
                            Console.WriteLine(config.getShellSeparator());
                            Console.WriteLine("                                               AVAILABLE USERS IN THE SYSTEM");
                            Console.WriteLine(config.getShellSeparator());
                            users_manipulation.getAllUsers();
                            Console.WriteLine("\nDO YOU WANT TO DUMP THIS INFO INTO A FILE? (y/n)");
                            string choice_op7 = Console.ReadLine();
                            if (choice_op7 == "ATIS_BACK") { Console.Clear(); Main(null); }
                            if (choice_op7.ToLower() == "y") { dump.dumpAllUsers(); Console.Clear(); Main(null); }
                            else if (choice_op7.ToLower() == "n") {
                                Console.Clear();
                                Main(null);
                            }
                            else {
                                Console.Clear();
                                Main(null);
                            }
                            break;
                        case "8":
                            Console.Clear();
                            Console.WriteLine(config.getShellSeparator());
                            Console.WriteLine("                                              AVAILABLE GROUPS IN THE SYSTEM");
                            Console.WriteLine(config.getShellSeparator());
                            users_manipulation.getAllGroups();
                            Console.WriteLine("\nDO YOU WANT TO DUMP THIS INFO INTO A FILE? (y/n)");
                            string choice_op8 = Console.ReadLine();
                            if (choice_op8 == "ATIS_BACK") { Console.Clear(); Main(null); }
                            if (choice_op8.ToLower() == "y") { dump.dumpAllGroups(); Console.Clear(); Main(null); }
                            else if (choice_op8.ToLower() == "n")
                            {
                                Console.Clear();
                                Main(null);
                            }
                            else
                            {
                                Console.Clear();
                                Main(null);
                            }
                            break;
                        case "9":
                            dump.dumpAllUsers();
                            break;
                        case "B":
                            Console.Clear();
                            Main(null);
                            break;
                        case "b":
                            Console.Clear();
                            Main(null);
                            break;
                        default:
                            Console.WriteLine("UNRECOGNISED INPUT - BACK TO MAIN MENU");
                            Thread.Sleep(5000);
                            Console.Clear();
                            Main(null);
                            break;
                    }
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine(config.getShellInstallationList());
                    config.setOperationSwitcher("NOT SELECTED YET");
                    Console.Write("CHOOSEN OPERATION: ");
                    config.setOperationSwitcher(Console.ReadLine());
                    switch (config.getOperationSwitcher())
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine(config.getShellBrowsersList());
                            config.setOperationSwitcher("NOT SELECTED YET");
                            Console.Write("CHOOSEN OPERATION: ");
                            config.setOperationSwitcher(Console.ReadLine());
                            switch (config.getOperationSwitcher())
                            {
                                case "1":
                                    Console.Clear();
                                    if (web.pingHost("www.google.com"))
                                    {
                                        Console.WriteLine("DOWNLOADING AND INSTALLING MOZILLA FIREFOX BROWSER...");
                                        Console.WriteLine("DOWNLOADING MOZILLA FIREFOX INSTALLER...");
                                        web.downloadFileFromURL("https://download.mozilla.org/?product=firefox-stub&os=win&lang=pl", web.getRelativeDefaultPath(), "firefox_installer", ".exe");
                                        Console.WriteLine("DOWNLOAD FINISHED - INSTALLING...");
                                        installer.installEXE(".\\DOWNLOADS\\", "firefox_installer", "");
                                        Console.WriteLine("INSTALLATION FINISHED SUCCESSFULLY");
                                        Thread.Sleep(5000);
                                        Console.Clear();
                                        Main(null);
                                    }
                                    else
                                    {
                                        Console.Write("=======================================================================================================================\n");
                                        Console.WriteLine("CONNECTION CANNOT BE ESTABLISHED CHECK YOUR INTERNET - OPERATION FAILED");
                                        Console.Write("=======================================================================================================================\n");
                                        Thread.Sleep(5000);
                                        Main(null);
                                    }
                                    break;
                                case "2":
                                    Console.Clear();
                                    if (web.pingHost("www.google.com"))
                                    {
                                        Console.WriteLine("DOWNLOADING AND INSTALLING GOOGLE CHROME BROWSER...");
                                        Console.WriteLine("DOWNLOADING GOOGLE CHROME INSTALLER...");
                                        web.downloadFileFromURL("http://dl.google.com/chrome/install/149.27/chrome_installer.exe", web.getRelativeDefaultPath(), "gchrome_installer", ".exe");
                                        Console.WriteLine("DOWNLOAD FINISHED - INSTALLING...");
                                        installer.installEXE(".\\DOWNLOADS\\", "gchrome_installer", "");
                                        Console.WriteLine("INSTALLATION FINISHED SUCCESSFULLY");
                                        Thread.Sleep(5000);
                                        Console.Clear();
                                        Main(null);
                                    }
                                    else
                                    {
                                        Console.Write("=======================================================================================================================\n");
                                        Console.WriteLine("CONNECTION CANNOT BE ESTABLISHED CHECK YOUR INTERNET - OPERATION FAILED");
                                        Console.Write("=======================================================================================================================\n");
                                        Thread.Sleep(5000);
                                        Main(null);
                                    }
                                    break;
                                case "3":
                                    Console.Clear();
                                    if (web.pingHost("www.google.com"))
                                    {
                                        Console.WriteLine("DOWNLOADING AND INSTALLING VIVALDI BROWSER...");
                                        Console.WriteLine("DOWNLOADING VIVALDI INSTALLER...");
                                        web.downloadFileFromURL("https://downloads.vivaldi.com/stable/Vivaldi.3.6.2165.40.x64.exe", web.getRelativeDefaultPath(), "vivaldi_installer", ".exe");
                                        Console.WriteLine("DOWNLOAD FINISHED - INSTALLING...");
                                        installer.installEXE(".\\DOWNLOADS\\", "vivaldi_installer", "");
                                        Console.WriteLine("INSTALLATION FINISHED SUCCESSFULLY");
                                        Thread.Sleep(5000);
                                        Console.Clear();
                                        Main(null);
                                    }
                                    else
                                    {
                                        Console.Write("=======================================================================================================================\n");
                                        Console.WriteLine("CONNECTION CANNOT BE ESTABLISHED CHECK YOUR INTERNET - OPERATION FAILED");
                                        Console.Write("=======================================================================================================================\n");
                                        Thread.Sleep(5000);
                                        Main(null);
                                    }
                                    break;
                                case "4":
                                    Console.Clear();
                                    if (web.pingHost("www.google.com"))
                                    {
                                        Console.WriteLine("DOWNLOADING AND INSTALLING OPERA BROWSER...");
                                        Console.WriteLine("DOWNLOADING OPERA INSTALLER...");
                                        web.downloadFileFromURL("https://downloads.vivaldi.com/stable/Vivaldi.3.6.2165.40.x64.exe", web.getRelativeDefaultPath(), "opera_installer", ".exe");
                                        Console.WriteLine("DOWNLOAD FINISHED - INSTALLING...");
                                        installer.installEXE(".\\DOWNLOADS\\", "opera_installer", "");
                                        Console.WriteLine("INSTALLATION FINISHED SUCCESSFULLY");
                                        Thread.Sleep(5000);
                                        Console.Clear();
                                        Main(null);
                                    }
                                    else
                                    {
                                        Console.Write("=======================================================================================================================\n");
                                        Console.WriteLine("CONNECTION CANNOT BE ESTABLISHED CHECK YOUR INTERNET - OPERATION FAILED");
                                        Console.Write("=======================================================================================================================\n");
                                        Thread.Sleep(5000);
                                        Main(null);
                                    }
                                    break;
                                case "B":
                                    Console.Clear();
                                    Main(null);
                                    break;
                                case "b":
                                    Console.Clear();
                                    Main(null);
                                    break;
                                default:
                                    Console.WriteLine("UNRECOGNISED INPUT - BACK TO MAIN MENU");
                                    Thread.Sleep(5000);
                                    Console.Clear();
                                    Main(null);
                                    break;
                            }
                            break;
                        case "2":
                            Console.Clear();
                            Console.Write("PROVIDE A PATH OF THE DIRECTORY (OR LEAVE BLANK FOR DEFAULT) (EXAMPLE 'C:\\installation\\') : ");
                            string directory_op1 = Console.ReadLine();
                            if (directory_op1 == "ATIS_BACK") { Console.Clear(); Main(null); }
                            Console.Write("\nPROVIDE A NAME OF THE FILE (OR LEAVE BLANK TO INSTALL ALL FROM DIRECTORY) : ");
                            string name_op1 = Console.ReadLine();
                            if (name_op1 == "ATIS_BACK") { Console.Clear(); Main(null); }
                            Console.Write("\nPROVIDE ARGUMENTS IF NEEDED (OR LEAVE BLANK FOR NONE) : ");
                            string arguments_op1 = Console.ReadLine();
                            if (arguments_op1 == "ATIS_BACK") { Console.Clear(); Main(null); }
                            if (directory_op1 == "") { directory_op1 = installer.getRelativeDefaultPath(); }
                            if (name_op1 == "") { name_op1 = "ATIS_INSTALL_ALL"; }
                            Console.Clear();
                            installer.installEXE(directory_op1, name_op1, arguments_op1);
                            Thread.Sleep(5000);
                            Console.Clear();
                            Main(null);
                            break;
                        case "3":
                            Console.Clear();
                            Console.Write("PROVIDE A PATH OF THE DIRECTORY (OR LEAVE BLANK FOR DEFAULT) (EXAMPLE 'C:\\installation\\') : ");
                            string directory_op3 = Console.ReadLine();
                            if (directory_op3 == "ATIS_BACK") { Console.Clear(); Main(null); }
                            Console.Write("\nPROVIDE A NAME OF THE FILE (OR LEAVE BLANK TO INSTALL ALL FROM DIRECTORY) : ");
                            string name_op3 = Console.ReadLine();
                            if (name_op3 == "ATIS_BACK") { Console.Clear(); Main(null); }
                            Console.Write("\nPROVIDE ARGUMENTS IF NEEDED (OR LEAVE BLANK FOR NONE) : ");
                            string arguments_op3 = Console.ReadLine();
                            if (arguments_op3 == "ATIS_BACK") { Console.Clear(); Main(null); }
                            if (directory_op3 == "") { directory_op3 = installer.getRelativeDefaultPath(); }
                            if (name_op3 == "") { name_op3 = "ATIS_INSTALL_ALL"; }
                            Console.Clear();
                            installer.installMSI(directory_op3, name_op3, arguments_op3);
                            Thread.Sleep(5000);
                            Console.Clear();
                            Main(null);
                            break;
                        case "4":
                            Console.Clear();
                            Console.Write("PROVIDE A PATH OF THE DIRECTORY (OR LEAVE BLANK FOR DEFAULT) (EXAMPLE 'C:\\installation\\') : ");
                            string directory_op4 = Console.ReadLine();
                            if (directory_op4 == "ATIS_BACK") { Console.Clear(); Main(null); }
                            Console.Write("\nPROVIDE ARGUMENTS IF NEEDED FOR MSI (OR LEAVE BLANK FOR NONE) : ");
                            string arguments_msi_op4 = Console.ReadLine();
                            if (arguments_msi_op4 == "ATIS_BACK") { Console.Clear(); Main(null); }
                            Console.Write("\nPROVIDE ARGUMENTS IF NEEDED FOR EXE (OR LEAVE BLANK FOR NONE) : ");
                            string arguments_exe_op4 = Console.ReadLine();
                            if (arguments_exe_op4 == "ATIS_BACK") { Console.Clear(); Main(null); }
                            if (directory_op4 == "") { directory_op4 = installer.getRelativeDefaultPath(); }
                            string name_op4 = "ATIS_INSTALL_ALL";
                            Console.Clear();
                            installer.installMSI(directory_op4, name_op4, arguments_msi_op4);
                            installer.installEXE(directory_op4, name_op4, arguments_exe_op4);
                            Thread.Sleep(5000);
                            Console.Clear();
                            Main(null);
                            break;
                        case "B":
                            Console.Clear();
                            Main(null);
                            break;
                        case "b":
                            Console.Clear();
                            Main(null);
                            break;
                        default:
                            Console.WriteLine("UNRECOGNISED INPUT - BACK TO MAIN MENU");
                            Thread.Sleep(5000);
                            Console.Clear();
                            Main(null);
                            break;
                    }
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine(config.getShellServerMYSQLSoftwareList());
                    server.listAllServerApps(server.getConnectionMYSQLString());
                    config.setOperationSwitcher("NOT SELECTED YET");
                    Console.WriteLine("\n\n(B) GO BACK TO MAIN MENU");
                    Console.Write("\nCHOOSEN OPERATION: ");
                    config.setOperationSwitcher(Console.ReadLine());
                    switch (config.getOperationSwitcher())
                    {
                        case "B":
                            Console.Clear();
                            Main(null);
                            break;
                        case "b":
                            Console.Clear();
                            Main(null);
                            break;
                        default:
                            try
                            {
                                server.makeListOfNumbersOfApps(server.getConnectionMYSQLString());
                                if (server.getListOfNumbersOfApps().Contains(Convert.ToInt32(config.getOperationSwitcher())))
                                {
                                    string source = server.getSourceOfAppById(server.getConnectionMYSQLString(), server.getIdOfAppByNumber(server.getConnectionMYSQLString(), Convert.ToInt32(config.getOperationSwitcher())));
                                    string main_path = server.getServerInstallationDirectoryPath() + server.getServerInstallationDirectoryName();
                                    string specific_path = main_path + "\\" + server.getIdOfAppByNumber(server.getConnectionMYSQLString(), Convert.ToInt32(config.getOperationSwitcher()));
                                    if (!Directory.Exists(specific_path))
                                    {
                                        Directory.CreateDirectory(main_path);
                                        Directory.CreateDirectory(specific_path);
                                        server.serverDownload(server.getServerRelativeDatabasePath() + source, server.getServerFTPUser(), server.getServerFTPPass(), main_path + "\\" + server.getIdOfAppByNumber(server.getConnectionMYSQLString(), Convert.ToInt32(config.getOperationSwitcher())) + "\\" + source);
                                        DirectoryInfo directory = new DirectoryInfo(specific_path + "\\");
                                        wrapper.DecompressServer(directory, source);
                                        File.Delete(specific_path + "\\" + source);
                                        Console.Clear();
                                        Console.WriteLine("OPERATION FINISHED SUCCESSFULLY");
                                        Thread.Sleep(5000);
                                        Console.Clear();
                                        Main(null);
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("THIS ENTRY IS ALREADY INSTALLED");
                                        Thread.Sleep(5000);
                                        Console.Clear();
                                        Main(null);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("THERE IS NO SUCH NUMBER - BACK TO MAIN MENU");
                                    Thread.Sleep(5000);
                                    Console.Clear();
                                    Main(null);
                                }
                            }
                            catch (Exception exception_log)
                            {
                                Console.WriteLine("UNRECOGNISED INPUT - BACK TO MAIN MENU");
                                Thread.Sleep(5000);
                                Console.Clear();
                                Main(null);
                            }
                            break;
                    }
                    break;
                case "5":
                    Console.Clear();
                    Console.WriteLine(config.getShellServerInstalledSoftwareList());
                    if (Directory.Exists(server.getServerInstallationDirectoryPath() + server.getServerInstallationDirectoryName()))
                    {
                        server.getServerInstalledSoftwareList();
                        server.getServerInstalledAppsFromMYSQL(server.getConnectionMYSQLString());
                    }
                    else
                    {
                        Console.Write("");
                    }
                    config.setOperationSwitcher("NOT SELECTED YET");
                    Console.WriteLine("\n\n(B) GO BACK TO MAIN MENU");
                    Console.Write("\nCHOOSEN OPERATION: ");
                    config.setOperationSwitcher(Console.ReadLine());
                    switch (config.getOperationSwitcher())
                    {
                        case "B":
                            Console.Clear();
                            Main(null);
                            break;
                        case "b":
                            Console.Clear();
                            Main(null);
                            break;
                        default:
                            try
                            {
                                if (server.getServerInstalledSoftwareList().Contains(Convert.ToInt32(config.getOperationSwitcher())))
                                {
                                    string main_path = server.getServerInstallationDirectoryPath() + server.getServerInstallationDirectoryName();
                                    string specific_path = main_path + "\\" + server.getIdOfAppByNumber(server.getConnectionMYSQLString(), Convert.ToInt32(config.getOperationSwitcher()));
                                    DirectoryInfo directory = new DirectoryInfo(specific_path);
                                    DirectoryInfo main_directory = new DirectoryInfo(main_path);
                                    wrapper.Empty(directory);
                                    Directory.Delete(specific_path);
                                    if (wrapper.CountAllFilesAndDirectories(main_directory) == 0)
                                    {
                                        Directory.Delete(main_path);
                                    }
                                    Console.WriteLine("TOOL SUCCESSFULLY REMOVED - BACK TO MAIN MENU");
                                    Thread.Sleep(5000);
                                    Console.Clear();
                                    Main(null);
                                }
                                else
                                {
                                    Console.WriteLine("THERE IS NO SUCH NUMBER - BACK TO MAIN MENU");
                                    Thread.Sleep(5000);
                                    Console.Clear();
                                    Main(null);
                                }
                            }
                            catch (Exception exception_log)
                            {
                                Console.WriteLine("UNRECOGNISED INPUT - BACK TO MAIN MENU");
                                Thread.Sleep(5000);
                                Console.Clear();
                                Main(null);
                            }
                            break;
                    }
                    break;
                case "E":
                    Environment.Exit(0);
                    break;
                case "e":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("WRONG COMMAND - RETRY");
                    Thread.Sleep(2000);
                    Console.Clear();
                    Main(null);
                    break;
            }
        }
    }
}
