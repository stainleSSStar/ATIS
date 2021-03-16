using System;
using System.Diagnostics;
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
                            Console.Write("NAME OF THE USER : ");
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
                    config.getShellUsersList();
                    Console.ReadKey();
                    break;
                case "10":
                    installer.installMSI(".\\INSTALLATION\\");
                    Console.ReadLine();
                    break;
                case "11":
                    installer.installEXE(".\\INSTALLATION\\");
                    Console.ReadLine();
                    break;
                case "12":
                    web.downloadFileFromURL("https://download.mozilla.org/?product=firefox-stub&os=win&lang=pl", ".\\DOWNLOADS\\","firefox1");
                    Console.ReadLine();
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
                    Main(null);
                    break;
            }
        }
    }
}
