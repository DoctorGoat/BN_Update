using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Linq;

namespace Universal_Launcher
{
    public partial class Form1 : Form
    {
        //We want it to default to this folder.
        public string selectedDirectory = Environment.CurrentDirectory;
        //standard backup folder deal; this could easily be chosen by the user but i think timestamping is a valuable way to do this
        static public string backupFolder = Environment.CurrentDirectory + "\\update_backup\\" + DateTime.Now.Ticks + "\\";
        TextBox selectedFolder = new TextBox();
        static TextBox console = new TextBox();
        static StreamWriter sw = new StreamWriter("log.log");
        static Button button1;
        private static Boolean hasLoadedTemplate = true;

        public Form1()
        {
            //we make a new text box for the selected folder because dealing with textboxes being set at runtime is mildly irritating
            createFolderText();
            createConsoleOut();
            createGameButton();
            InitializeComponent();
        }

        //Current folder should be updated as needed
        private void createFolderText()
        {
            selectedFolder.Text = "Current Folder:";
            selectedFolder.Location = new Point(13, 28);
            selectedFolder.Multiline = true;
            selectedFolder.Size = new Size(776, 35);
            selectedFolder.ReadOnly = true;
            selectedFolder.AppendText(Environment.NewLine);
            selectedFolder.AppendText(selectedDirectory);
            this.Controls.Add(selectedFolder);
        }

        private void createConsoleOut()
        {
            console.Text = "";
            console.Location = new Point(12, 454);
            console.Multiline = true;
            console.Size = new Size(776, 184);
            console.ReadOnly = true;
            this.Controls.Add(console);
        }

        private void createGameButton()
        {
            //todo
            button1.Text = "";
            button1.Location = new Point(13, 70);
            button1.Size = new Size(255, 23);
            button1.Click += new System.EventHandler(gameButton_Click());
        }

        private EventHandler gameButton_Click()
        {
            throw new NotImplementedException();
        }

        //Selects and overwrites the default folder oF "this folder"
        private void targetFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            selectedDirectory = fbd.ShowDialog().ToString();
            selectedFolder.Text = "Current Folder: \n" + selectedDirectory;
        }

        //takes current folder and puts it in this folder + update_backup + timestamp
        private void backupTargetFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
                //basic output
                console.AppendText("Backing up current folder...");
                console.AppendText("Folder name: " + backupFolder);
                Directory.CreateDirectory(backupFolder);
                DirectoryInfo targetDir = new DirectoryInfo(backupFolder);
                DirectoryInfo sourceDir = new DirectoryInfo(selectedDirectory);
                CopyAll(sourceDir, targetDir);
        }

        //this is from MSDN
        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                console.AppendText(@"Copying " + target.FullName + fi.Name);
                sw.WriteLine(@"Copying " + target.FullName + fi.Name);
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
        
        //just neatly closes everything
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sw.Close();
            this.Close();
        }

        //ooooohhhhh booy this is where all the json loading code is
        private void loadTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            hasLoadedTemplate = true;
        }

        //return filename for actual installation using json information
        //both of these two functions use some similar ideas: url.split.last gives the filename of a url unless it's some absolutely
        //cursed bullshit, both use a client with a header so it's not rejected as a unknown client

        //Regex ideally always gets exactly one match. If not, the regex is flawed. The pages are always ones with one match, such as 
        //https://github.com/cataclysmbnteam/Cataclysm-BN/releases/latest
        private string githubGet(string url, string regex)
        {
            string fileName = "";
            using (var client = new WebClient())
            {
                client.Headers.Add("user-agent", "Goat Updater");
                Regex rx = new Regex(regex);
                string githubPage = client.DownloadString(url);
                MatchCollection matches = rx.Matches(githubPage);
                fileName = matches[0].ToString().Split('/').Last();
                client.DownloadFile(@"https://github.com/" + matches[0], matches[0].ToString().Split('/').Last());
                console.AppendText("Downloaded" + url.Split('/').Last());
            }
            return fileName;
        }

        //return filename for actual installation using json information
        //honestly kind of tempted to combine this and githubGet
        private string urlGet(string url)
        {
            string fileName = "";
            using (var client = new WebClient())
            {
                //gets filename from URL
                client.Headers.Add("user-agent", "Goat Updater");
                client.DownloadFile(url, url.Split('/').Last());
                console.AppendText("Downloaded" + url.Split('/').Last()); 
                fileName = url.Split('/').Last();
            }
            return fileName;
        }
    }
}
