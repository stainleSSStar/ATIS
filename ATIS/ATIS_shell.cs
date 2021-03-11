using System;
using System.Threading;
namespace ATIS
{
    class ATIS_shell
    {
        public static void Main(string[] args)
        {
            ATIS_config config = new ATIS_config();

            Console.Title = config.getShellTitle();
            Console.SetWindowSize(config.getWindowWidth(), config.getWindowHeight());
            Console.ForegroundColor = config.getShellTextColor();
            Console.WriteLine(config.getShellMainMenuList());
            Console.Write(config.getOperationChoiceMessage());
            config.setOperationSwitcher(Console.ReadLine());

            switch (config.getOperationSwitcher())
            {
                case "1":
                    Console.WriteLine("1");
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
