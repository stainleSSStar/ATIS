using System;
using System.Diagnostics;
namespace ATIS
{
    class ATIS_config
    {
        //CONFIG VARIABLES
        private string shell_title = "Application Tree Installation Shell";
        private int shell_min_max_window_size_height = 30;
        private int shell_min_max_window_size_width = 120;
        private ConsoleColor shell_text_color = ConsoleColor.DarkYellow;

        private string shell_main_menu_list =
        "=======================================================================================================================\n" +
        "                                             APPLICATION TREE INSTALLATION SHELL                    \n" +
        "=======================================================================================================================\n\n" +
        "                   WELCOME TO ATIS V0 BETA THIS SHELL ALLOWS TO EXECUTE MULTIPLE ADMINISTRATIVE TASKS\n\n" +
        "                                                  CHOOSE ONE BELOW TO START\n\n\n" +
        "(1) CHECK CHECKSUMS OF A FILE (USING WISUMCHECKER)\n" +
        "(2) ADD USER TO THE SYSTEM\n" +
        "(3) REMOVE USER FROM THE SYSTEM\n" +
        "(4) ADD USER TO LOCAL GROUP\n" +
        "(5) REMOVE USER FROM THE LOCAL GROUP\n" +
        "(6) \n" +
        "(7) \n" +
        "(8) \n" +
        "(9) INSTALL SOFTWARE FROM OTHER SOURCES (MSI)\n" +
        "(10) UNINSTALL SOFTWARE FROM OTHER SOURCES (MSI)\n" +
        "(11) firewall / browser / backup / zip /\n";

        private string operation_choice_message = "CHOOSEN OPERATION : ";
        private string operation_switcher = "";
        private string wsumchecker_relative_path = ".\\WSUMCHECKER\\WSumChecker.exe";
        private ProcessWindowStyle wsumchecker_process_window_style = ProcessWindowStyle.Normal;
        private string main_application_already_running_message = "APPLICATION IS ALREADY RUNNING - EXITING";
        //FUNCTIONS (GETTERS / SETTERS)
        public string getShellTitle()
        {
            return shell_title;
        }
        public int getWindowHeight()
        {
            return shell_min_max_window_size_height;
        }
        public int getWindowWidth()
        {
            return shell_min_max_window_size_width;
        }
        public ConsoleColor getShellTextColor()
        {
            return shell_text_color;
        }
        public string getShellMainMenuList()
        {
            return shell_main_menu_list;
        }
        public string getOperationChoiceMessage()
        {
            return operation_choice_message;
        }
        public void setOperationSwitcher(string input)
        {
            operation_switcher = input;
        }
        public string getOperationSwitcher()
        {
            return operation_switcher;
        }
        public string getWSumCheckerRelativePath()
        {
            return wsumchecker_relative_path;
        }
        public ProcessWindowStyle getWSumCheckerProcessWindowStyle()
        {
            return wsumchecker_process_window_style;
        }
        
        public string getMainApplicationAlreadyRunningMessage()
        {
            return main_application_already_running_message;
        }
    }
}
