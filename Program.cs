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
        private static string[] definitelyCopy = { "config", "save", "gfx", "font", "graveyard", "memorial", "sound", "templates", "update_backup" };
        static public string backupFolder = Environment.CurrentDirectory + "\\update_backup\\" + DateTime.Now.Ticks + "\\";

        //we're going to use this a bit so it may as well be hardcoded, and if it's not gotten immediately and made static we're going to end up with like thirty folders by the end of backing up
        static void Main(string[] args)
        {
            DownloadUpdate();
            Console.ReadLine();
        }

        //connnect to github, download latest release, feed the filename back to main()
        private static void DownloadUpdate()
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("user-agent", "Goat BN Updater");
                //this is extremely finicky and I hate it.
                string ohGodOhFuck = client.DownloadString("https://github.com/cataclysmbnteam/Cataclysm-BN/releases/tag/869");
                //string ohGodOhFuck = client.DownloadString(@"https://github.com/cataclysmbnteam/Cataclysm-BN/releases/latest");
                //this should return ONE result, ever
                MatchCollection matches = rx.Matches(ohGodOhFuck);
                //download match, use string manipulation to get the correct filename
                string returnValue = matches[0].ToString().Split('/').Last();
                Console.WriteLine("DOWNLOADING FILE. PLEASE WAIT. I DO NOT KNOW WHAT HAPPENS IF YOU DON'T HAVE INTERNET.");
                client.DownloadFile(@"https://github.com/" + matches[0], matches[0].ToString().Split('/').Last());
                ZipFile.ExtractToDirectory(returnValue, Environment.CurrentDirectory);
                Console.WriteLine("DOWNLOADING KENAN'S PACK. I HAVE THE FLU.");
                client.DownloadFile(@"https://github.com/Kenan2000/Bright-Nights-Kenan-Mod-Pack/archive/master.zip", "kenan.zip");
                ZipFile.ExtractToDirectory("kenan.zip", Environment.CurrentDirectory + "\\kenan\\");
                Console.WriteLine("DOWNLOADING GOATGOD'S PACK. DEAL WITH IT YOURSELF.");
                client.DownloadFile(@"https://github.com/TheGoatGod/Goats-Mod-Compilation/archive/Bright-Nights.zip", "goatgod.zip");
                ZipFile.ExtractToDirectory("goatgod.zip", Environment.CurrentDirectory + "\\goatgod\\");
                Console.WriteLine("DOWNLOADING SDG TILESET AND ACTUALLY INSTALLING IT UNLIKE THE LAST TWO.");
                client.DownloadFile(@"https://github.com/SomeDeadGuy/UndeadPeopleTileset/archive/master.zip", "sdg.zip");
                ZipFile.ExtractToDirectory("sdg.zip", Environment.CurrentDirectory + "\\gfx\\");
            }
        }
    }
}