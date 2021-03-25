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
        "(3) INSTALLATION CONTROL MENU\n" +
        "(4) GET ACCESS TO ATIS SERVER TOOLS\n" +
        "(5) REMOVE ATIS TOOLS MENU\n" +
        "(6) BACKUP A FOLDER WITH DATA AND UPLOAD TO ATIS SERVER\n" +
        "(7) CHECK THE OPERATING SYSTEM UPDATES AND LIST THEM VIA WINDOWS UPDATE API\n" +
        "(8) INSTALL ALL OPERATING SYSTEM UPDATES VIA WINDOWS UPDATE API\n" +
        "(9) FILE DOWNLOADER - DIRECT LINK REQUIRED\n" +
        "(10) OPEN SERVICES SETTINGS WINDOW\n" +
        "(11) EDIT THE HOSTS FILE\n" +
        "(12) OPEN REGISTRY EDITOR\n" +
        "(13) GET SYSTEM INFORMATION\n" +
        "(14) OPEN TASK / AUTOSTART MANAGER\n" +
        "(x) firewall / icon / other scripts / changelog \n" +
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

        private string shell_browsers_list =
       "=======================================================================================================================\n" +
       "                                                  BROWSERS INSTALLATION MENU                    \n" +
       "=======================================================================================================================\n\n" +
       "                                                  CHOOSE ONE BELOW TO START\n\n\n" +
       "(1) MOZILLA FIREFOX\n" +
       "(2) GOOGLE CHROME\n" +
       "(3) VIVALDI\n" +
       "(4) OPERA\n"+
       "(B) GO BACK TO MAIN MENU\n";

        private string shell_installation_list =
       "=======================================================================================================================\n" +
       "                                                      INSTALLATION MENU                    \n" +
       "=======================================================================================================================\n\n" +
       "                                                  CHOOSE ONE BELOW TO START\n\n\n" +
       "(1) BROWSERS INSTALLATION MENU\n" +
       "(2) INSTALLATION OF EXE FILES\n" +
       "(3) INSTALLATION OF MSI FILES\n" +
       "(4) INSTALLATION OF BOTH TYPES IN DIRECTORY\n" +
       "(B) GO BACK TO MAIN MENU\n";

        private string shell_server_mysql_software_list =
       "=======================================================================================================================\n" +
       "                                               PACKAGES AVAILABLE IN ATIS SERVER                    \n" +
       "=======================================================================================================================\n\n" +
       "                                                  CHOOSE ONE BELOW TO START\n\n\n";
        private string shell_server_installed_software_list =
       "=======================================================================================================================\n" +
       "                                               PACKAGES PRESENT IN ATIS DIRECTORY                    \n" +
       "=======================================================================================================================\n\n" +
       "                                                   CHOOSE ONE BELOW TO START\n" +
       "                                IF THE LIST IS EMPTY NOTHING WAS INSTALLED FROM ATIS SERVER\n\n\n";
        private string shell_server_ftp_upload_message_list =
       "=======================================================================================================================\n" +
       "                                            UPLOADING FILES ON TO ATIS BACKUP SERVER                    \n" +
       "=======================================================================================================================\n\n" +
       "                                 PROVIDE AN ABSOLUTE PATH TO A FOLDER THAT NEEDS TO BE SAVED\n" +
       "                   WHEN UPLOAD IS SUCCESSFULL THEN YOU WILL BE ABLE TO ACCESS IT BY USING ANY FTP MANAGER\n\n\n";
        private string shell_osupdate_check_list =
       "=======================================================================================================================\n" +
       "                                                  AVAILABLE UPDATES TO INSTALL                   \n" +
       "=======================================================================================================================\n\n" +
       "                               THIS OPTION CHECKS WHETHER UPDATES ARE AVAILABLE OR NOT ONLY\n" +
       "                              IN ORDER TO INSTALL THEM SELECT THE SECOND OPTION IN MAIN MENU \n\n\n";
        private string shell_osupdate_install_list =
       "=======================================================================================================================\n" +
       "                                                  UPDATES ARE BEING INSTALLED                \n" +
       "=======================================================================================================================\n\n" +
       "                    YOU WILL SEE EVERY SINGLE INSTALLED UPDATE BELOW AS WELL AS ERRORS IF THEY OCCUR \n\n\n";
        private string shell_download_file_list =
       "=======================================================================================================================\n" +
       "                                                        DOWNLOAD A FILE                \n" +
       "=======================================================================================================================\n\n" +
       "                             PROVIDE ALL INFORMATION REQUIRED TO DOWNLOAD A FILE WITHOUT BROWSER  \n\n\n";
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
        public string getShellBrowsersList()
        {
            return shell_browsers_list;
        }
        public string getShellInstallationList()
        {
            return shell_installation_list;
        }
        public string getShellServerMYSQLSoftwareList()
        {
            return shell_server_mysql_software_list;
        }
        public string getShellServerInstalledSoftwareList()
        {
            return shell_server_installed_software_list;
        }
        public string getShellServerFTPUploadMessageList()
        {
            return shell_server_ftp_upload_message_list;
        }
        public string getShellOsUpdateCheckList()
        {
            return shell_osupdate_check_list;
        }
        public string getShellOsUpdateInstallList()
        {
            return shell_osupdate_install_list;
        }
        public string getShellDownloadFileList()
        {
            return shell_download_file_list;
        }
    }
}
