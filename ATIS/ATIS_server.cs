using System;
using System.IO;
using System.Net;
using System.Threading;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ATIS
{
    class ATIS_server
    {
        private string server_ftp_user = "ATISUSER";
        public string getServerFTPUser()
        {
            return server_ftp_user;
        }
        private string server_ftp_pass = "ATISREQUEST";
        public string getServerFTPPass()
        {
            return server_ftp_pass;
        }
        private string server_relative_backup_path = "ftp://127.0.0.1/ATISBACKUP/";
        public string getServerRelativePath()
        {
            return server_relative_backup_path;
        }
        private string server_relative_database_path = "ftp://127.0.0.1/ATISDATABASE/";
        public string getServerRelativeDatabasePath()
        {
            return server_relative_database_path;
        }
        private string server_installation_directory_name = "ATISINSTALLATION";
        public string getServerInstallationDirectoryName()
        {
            return server_installation_directory_name;
        }
        private string server_installation_directory_path = "C:\\";
        public string getServerInstallationDirectoryPath()
        {
            return server_installation_directory_path;
        }
        public void serverDownload(string download_source, string user, string password, string download_path)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(download_source);
                request.Credentials = new NetworkCredential(user, password);
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                using (Stream ftpStream = request.GetResponse().GetResponseStream())
                using (Stream fileStream = File.Create(@download_path))
                {
                    byte[] buffer = new byte[10240];
                    int read;
                    while ((read = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fileStream.Write(buffer, 0, read);
                        Console.WriteLine("Downloaded {0} bytes", fileStream.Position);
                    }
                }
            }
            catch (Exception exception_log)
            {
                Console.Clear();
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine(exception_log.ToString() + "\n");
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine("DOWNLOAD ERROR - OPERATION FAILED");
                Thread.Sleep(5000);
            }
        }
        public void serverUpload(string upload_source, string user, string password, string upload_path)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(upload_path);
                request.Credentials = new NetworkCredential(user, password);
                request.Method = WebRequestMethods.Ftp.UploadFile;

                using (Stream fileStream = File.OpenRead(@upload_source))
                using (Stream ftpStream = request.GetRequestStream())
                {
                    byte[] buffer = new byte[10240];
                    int read;
                    while ((read = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ftpStream.Write(buffer, 0, read);
                        Console.WriteLine("Uploaded {0} bytes", fileStream.Position);
                    }
                }
            }
            catch (Exception exception_log)
            {
                Console.Clear();
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine(exception_log.ToString() + "\n");
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine("UPLOAD ERROR - OPERATION FAILED");
                Thread.Sleep(5000);
            }
        }

        private string connection_mysql_string = "datasource=127.0.0.1;port=3306;username=ATISUSER;password=ATISREQUEST;database=atis;";
       public string getConnectionMYSQLString()
        {
            return connection_mysql_string;
        }
        private string mysql_query = "";
        public string getMYSQLQuery()
        {
            return mysql_query;
        }
        public void setMYSQLQuery(string query)
        {
            mysql_query = query;
        }

        public void listAllServerApps(string database_connection_string)
        {
            try
            {
                MySqlConnection database_connection = new MySqlConnection(database_connection_string);
                MySqlCommand database_command = new MySqlCommand("SELECT * FROM software;", database_connection);
                database_command.CommandTimeout = 60;
                MySqlDataReader reader;
                database_connection.Open();
                reader = database_command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string[] row = { reader.GetString(1), reader.GetString(2), reader.GetString(3) };
                        Console.WriteLine("("+row[0]+") "+row[1]+" "+row[2]);
                    }
                }
                else
                {
                    Console.WriteLine("DATABASE IS EMPTY");
                }
                database_connection.Close();
            }
            catch (Exception exception_log)
            {
                Console.Clear();
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine(exception_log.ToString() + "\n");
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine("DATABASE ERROR - OPERATION FAILED");
                Thread.Sleep(5000);
            }
        }
        private List<Int32> list_of_numbers_of_apps = new List<Int32>();
        public List<Int32> getListOfNumbersOfApps() {
            return list_of_numbers_of_apps;
        }
        public List<int> makeListOfNumbersOfApps(string database_connection_string)
        {
            try
            {
                MySqlConnection database_connection = new MySqlConnection(database_connection_string);
                MySqlCommand database_command = new MySqlCommand("SELECT number FROM software;", database_connection);
                database_command.CommandTimeout = 60;
                MySqlDataReader reader;
                database_connection.Open();
                reader = database_command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list_of_numbers_of_apps.Add(reader.GetInt32(0));
                    }
                }
                else
                {
                    Console.WriteLine("DATABASE IS EMPTY");
                    return list_of_numbers_of_apps;
                }
                database_connection.Close();
                return list_of_numbers_of_apps;
            }
            catch (Exception exception_log)
            {
                Console.Clear();
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine(exception_log.ToString() + "\n");
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine("DATABASE ERROR - OPERATION FAILED");
                Thread.Sleep(5000);
                return list_of_numbers_of_apps;
            }
        }
        public int getIdOfAppByNumber(string database_connection_string , int number)
        {
            try
            {
                MySqlConnection database_connection = new MySqlConnection(database_connection_string);
                MySqlCommand database_command = new MySqlCommand("SELECT id FROM software WHERE number="+number, database_connection);
                database_command.CommandTimeout = 60;
                MySqlDataReader reader;
                int id = -1;
                database_connection.Open();
                reader = database_command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = reader.GetInt32(0);
                    }
                }
                else
                {
                    Console.WriteLine("DATABASE IS EMPTY");
                    return id;
                }
                database_connection.Close();
                return id;
            }
            catch (Exception exception_log)
            {
                Console.Clear();
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine(exception_log.ToString() + "\n");
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine("DATABASE ERROR - OPERATION FAILED");
                Thread.Sleep(5000);
                return -1;
            }
        }
        public string getSourceOfAppById(string database_connection_string, int id)
        {
            try
            {
                MySqlConnection database_connection = new MySqlConnection(database_connection_string);
                MySqlCommand database_command = new MySqlCommand("SELECT source FROM software WHERE id=" + id, database_connection);
                database_command.CommandTimeout = 60;
                MySqlDataReader reader;
                string source = "";
                database_connection.Open();
                reader = database_command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        source = reader.GetString(0);
                        return source;
                    }
                }
                else
                {
                    Console.WriteLine("DATABASE IS EMPTY");
                    return source;
                }
                database_connection.Close();
                return source;
            }
            catch (Exception exception_log)
            {
                Console.Clear();
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine(exception_log.ToString() + "\n");
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine("DATABASE ERROR - OPERATION FAILED");
                Thread.Sleep(5000);
                return "";
            }
        }

    }
}
