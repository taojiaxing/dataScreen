using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Compile
{
    internal class Compile
    {
        private static void Main(string[] args)
        {
            string currentPath = Directory.GetCurrentDirectory();

            string nuget = ConfigurationManager.AppSettings["nuget.exe"];
            string msbuildPath = ConfigurationManager.AppSettings["msbuildPath"];
            string compileTxt = ConfigurationManager.AppSettings["compileTxt"];
            string loggerClass = ConfigurationManager.AppSettings["loggerClass"];
            //string loggerPath = currentPath + "\\" + ConfigurationManager.AppSettings["loggerName"];
            string loggerPath = ConfigurationManager.AppSettings["loggerName"];
            string nugetPath = currentPath + "\\" + nuget;

            string diskDriveCMD = currentPath.Substring(0, 2) + " & cd " + currentPath;

            string compileTxtPath = string.Format(currentPath + "\\" + compileTxt);

            string dateTime = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            string logDirctoryPath = currentPath + "\\Log\\" + dateTime;
            if (!File.Exists(nugetPath))
            {
                ShowMessage(nuget);
                return;
            }
            if (!File.Exists(msbuildPath))
            {
                ShowMessage(msbuildPath);
                return;
            }
            if (!File.Exists(compileTxtPath))
            {
                ShowMessage(compileTxt);
                return;
            }
            if (!File.Exists(loggerPath))
            {
                ShowMessage(loggerPath);
                return;
            }
            if (!Directory.Exists(logDirctoryPath))
            {
                Directory.CreateDirectory(logDirctoryPath);
            }
            Process compile = new Process();
            compile.StartInfo.FileName = "cmd.exe";
            compile.StartInfo.UseShellExecute = false;
            compile.StartInfo.RedirectStandardInput = true;
            compile.StartInfo.RedirectStandardOutput = true;
            compile.StartInfo.RedirectStandardError = true;
            compile.StartInfo.CreateNoWindow = true;
            compile.Start();
            compile.StandardInput.WriteLine(diskDriveCMD);
            string[] projectNames = File.ReadAllLines(compileTxtPath);
            foreach (var item in projectNames)
            {
                
                var files = Directory.GetFiles(currentPath + "\\Project\\" + item, "*.sln");
                if (files.Length==0)
                    continue;
                string updataCmd = nuget + " update " + files[0];
                string restoreCmd = nuget + " restore " + files[0];
                string msbuildCmd = msbuildPath + " " + files[0] + " /t:Rebuild /p:Configuration=Debug /nologo /noconsolelogger /logger:" +
                    loggerClass + "," + loggerPath + ";" + logDirctoryPath + "\\" + item + ".xml";
                compile.StandardInput.WriteLine(updataCmd);
                compile.StandardInput.WriteLine(restoreCmd);
                compile.StandardInput.WriteLine(msbuildCmd);
                
            }
            compile.StandardInput.AutoFlush = true;
            compile.StandardInput.WriteLine("exit");
            string str=compile.StandardOutput.ReadToEnd();
            compile.WaitForExit();
            compile.Close();
        }
        private static void ShowMessage(string messageStr)
        {
            MessageBox.Show(messageStr + " does not exist！" + "Please check the configuration file!");
        }
    }
}