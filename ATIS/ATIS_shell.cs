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
            ATIS_users users_manipulation = new ATIS_users();
            Console.Title = config.getShellTitle();
            Console.SetWindowSize(config.getWindowWidth(), config.getWindowHeight());
            Console.ForegroundColor = config.getShellTextColor();
            String processname = Process.GetCurrentProcess().ProcessName;
            Process[] running_processes = Process.GetProcessesByName(processname);
            if (running_processes.Length > 1)
            {
                Console.WriteLine(config.getMainApplicationAlreadyRunningMessage());
                Thread.Sleep(2000);
                Environment.Exit(0);
            }
            Console.WriteLine(config.getShellMainMenuList());
            Console.Write(config.getOperationChoiceMessage());
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
                    users_manipulation.addLocalUser("Henryk","zaq1234","Nikt","Goście");
                    Console.ReadLine();
                    break;
                case "3":
                    users_manipulation.removeLocalUser("Henryk");
                    Console.ReadLine();
                    break;
                case "4":
                    users_manipulation.getAllUsers();
                    Console.ReadLine();
                    break;
                case "5":
                    users_manipulation.getAllGroups();
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("DEFAULT BLOCK EXECUTED");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
