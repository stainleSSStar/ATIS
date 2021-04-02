using System;
using System.Threading;
using WUApiLib;
namespace ATIS
{
   public class ATIS_osupdate
    {



        public void checkUpdates()
        {
            try
            {
                UpdateSession uSession = new UpdateSession();
                IUpdateSearcher uSearcher = uSession.CreateUpdateSearcher();
                ISearchResult uResult = uSearcher.Search("IsInstalled=0 and Type ='Software'");
                Console.WriteLine("FOUND " + uResult.Updates.Count + " UPDATE/S" + Environment.NewLine);
                foreach (IUpdate update in uResult.Updates)
                {
                    Console.WriteLine(update.Title);
                }
            }
            catch (Exception exception_log)
            {
                Console.Clear();
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine(exception_log.ToString() + "\n");
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine("FETCHING ERROR - OPERATION FAILED");
                Thread.Sleep(5000);
            }
        }
        public void installUpdates()
        {
            try
            {
                UpdateSession uSession = new UpdateSession();
                IUpdateSearcher uSearcher = uSession.CreateUpdateSearcher();
                ISearchResult uResult = uSearcher.Search("IsInstalled=0 and Type ='Software'");
                if (uResult.Updates.Count != 0)
                {
                    UpdateDownloader downloader = uSession.CreateUpdateDownloader();
                    downloader.Updates = uResult.Updates;
                    downloader.Download();
                    UpdateCollection updatesToInstall = new UpdateCollection();
                    foreach (IUpdate update in uResult.Updates)
                    {
                        if (update.IsDownloaded)
                            updatesToInstall.Add(update);
                    }
                    IUpdateInstaller installer = uSession.CreateUpdateInstaller();
                    installer.Updates = updatesToInstall;
                    IInstallationResult installationRes = installer.Install();
                    for (int i = 0; i < updatesToInstall.Count; i++)
                    {
                        if (installationRes.GetUpdateResult(i).HResult == 0)
                        {
                            Console.WriteLine("INSTALLED : " + updatesToInstall[i].Title);
                        }
                        else
                        {
                            Console.WriteLine("FAILED : " + updatesToInstall[i].Title);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("THERE IS NOTHING TO INSTALL");
                }
            }
            catch (Exception exception_log)
            {
                Console.Clear();
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine(exception_log.ToString() + "\n");
                Console.Write("=======================================================================================================================\n");
                Console.WriteLine("FETCHING OR INSTALLATION ERROR - OPERATION FAILED");
                Thread.Sleep(5000);
            }
        }
    }
}
