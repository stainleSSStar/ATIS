using System;
using System.Diagnostics;
namespace ATIS
{
    class ATIS_config
    {
        //CONFIG VARIABLES
        private string shell_title = "Administration Tasks Initialization Shell";
        private int shell_min_max_window_size_height = 30;
        private int shell_min_max_window_size_width = 120;
        private ConsoleColor shell_text_color = ConsoleColor.DarkYellow;
        private string shell_separator = "=======================================================================================================================";
        private string shell_main_menu_list =
        "=======================================================================================================================\n" +
        "                                           ADMINISTRATION TASKS INITIALIZATION SHELL                    \n" +
        "=======================================================================================================================\n\n" +
        "                   WELCOME TO ATIS V0 BETA THIS SHELL ALLOWS TO EXECUTE MULTIPLE ADMINISTRATIVE TASKS\n\n" +
        "                                                  CHOOSE ONE BELOW TO START\n\n\n" +
        "(1) CHECK CHECKSUMS OF A FILE (USING WSUMCHECKER)\n" +
        "(2) USERS AND GROUPS MANIPULATION MENU\n" +
        "(3) \n" +
        "(4) \n" +
        "(5) \n" +
        "(6) \n" +
        "(7) \n" +
        "(8) \n" +
        "(9) INSTALL SOFTWARE FROM OTHER SOURCES (MSI)\n" +
        "(10) UNINSTALL SOFTWARE FROM OTHER SOURCES (MSI)\n" +
        "(11) firewall / browser / backup / zip /\n" +
        "(E) EXIT THE SCRIPT\n";
        private string operation_switcher = "";
        private string wsumchecker_relative_path = ".\\WSUMCHECKER\\WSumChecker.exe";
        private ProcessWindowStyle wsumchecker_process_window_style = ProcessWindowStyle.Normal;

        private string shell_users_list =
       "=======================================================================================================================\n" +
       "                                                   USERS MANIPULATION MENU                    \n" +
       "=======================================================================================================================\n\n" +
       "                                                  CHOOSE ONE BELOW TO START\n\n\n" +
       "(1) ADD USER TO THE SYSTEM\n" +
       "(2) REMOVE USER FROM THE SYSTEM\n" +
       "(3) ADD LOCAL USERS GROUP\n" +
       "(4) REMOVE LOCAL USERS GROUP\n" +
       "(5) ADD USER TO THE LOCAL GROUP\n" +
       "(6) REMOVE USER FROM THE LOCAL GROUP\n" +
       "(7) GET ALL USERS AND GROUPS\n" +
       "(8) GET ALL CREATED GROUPS\n" +
       "(B) GO BACK TO MAIN MENU\n";
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
        public string getShellUsersList()
        {
            return shell_users_list;
        }
        public string getShellSeparator()
        {
            return shell_separator;
        }
    }
}
