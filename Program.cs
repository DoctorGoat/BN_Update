using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace BN_Update
{
    class Program
    {
        //the newest release, ideally
        private static Regex rx = new Regex(@"\/cataclysmbnteam\/Cataclysm-BN\/releases\/download\/\d{0,99}\/\S{0,99}win64-tiles.zip", RegexOptions.Compiled);
        static public string backupFolder = Environment.CurrentDirectory + "\\update_backup\\" + DateTime.Now.Ticks + "\\";
        private static DirectoryInfo currentDirectory = new DirectoryInfo(Environment.CurrentDirectory);
        //we're going to use this a bit so it may as well be hardcoded, and if it's not gotten immediately and made static we're going to end up with like thirty folders by the end of backing up
        static void Main(string[] args)
        {
            doBackup();
            CleanDirectory();
            DownloadUpdate();
        }

        private static void CleanDirectory()
        {
            foreach (string f in Directory.GetFiles(Environment.CurrentDirectory))
            {
                if (!f.Contains("BN_Update"))
                {
                    File.Delete(f);
                }
            }
            foreach (string f in Directory.GetDirectories(Environment.CurrentDirectory))
            {
                if (!f.Contains("update_backup"))
                {
                    Directory.Delete(f, true);
                }
            }
        }

        static public void doBackup()
        {
            //basic output
            Console.WriteLine("Backing up current folder...");
            Console.WriteLine("Folder name: " + backupFolder);
            Directory.CreateDirectory(backupFolder);
            DirectoryInfo targetDir = new DirectoryInfo(backupFolder);
            CopyAll(currentDirectory, targetDir);
        }

        //connnect to github, download latest release, feed the filename back to main()
        private static void DownloadUpdate()
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("user-agent", "Goat BN Updater");
                //this is extremely finicky and I hate it.
                string ohGodOhFuck = client.DownloadString(@"https://github.com/cataclysmbnteam/Cataclysm-BN/releases");
                //this should return ONE result, ever
                MatchCollection matches = rx.Matches(ohGodOhFuck);
                //download match, use string manipulation to get the correct filename
                string returnValue = matches[0].ToString().Split('/').Last();
                Console.WriteLine("DOWNLOADING GAME. PLEASE WAIT. I DO NOT KNOW WHAT HAPPENS IF YOU DON'T HAVE INTERNET.");
                client.DownloadFile(@"https://github.com/" + matches[0], matches[0].ToString().Split('/').Last());
                ZipFile.ExtractToDirectory(matches[0].ToString().Split('/').Last(), Environment.CurrentDirectory, true);
                Console.WriteLine("DOWNLOADING KENAN'S PACK.");
                client.DownloadFile(@"https://github.com/Kenan2000/Bright-Nights-Kenan-Mod-Pack/archive/master.zip", "kenan.zip");
                ZipFile.ExtractToDirectory("kenan.zip", Environment.CurrentDirectory + "\\kenan\\");
                Console.WriteLine("DOWNLOADING GOATGOD'S PACK.");
                client.DownloadFile(@"https://github.com/TheGoatGod/Goats-Mod-Compilation/archive/Bright-Nights.zip", "goatgod.zip");
                ZipFile.ExtractToDirectory("goatgod.zip", Environment.CurrentDirectory + "\\goatgod\\");
                Console.WriteLine("DOWNLOADING SDG TILESET AND ACTUALLY INSTALLING IT UNLIKE THE LAST TWO.");
                client.DownloadFile(@"https://github.com/SomeDeadGuy/UndeadPeopleTileset/archive/master.zip", "sdg.zip");
                ZipFile.ExtractToDirectory("sdg.zip", Environment.CurrentDirectory + "\\gfx\\");
            }
        }

        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                if (diSourceSubDir.Name != "update_backup")
                {
                    DirectoryInfo nextTargetSubDir =
                        target.CreateSubdirectory(diSourceSubDir.Name);
                    CopyAll(diSourceSubDir, nextTargetSubDir);
                }
            }
        }


    }
}