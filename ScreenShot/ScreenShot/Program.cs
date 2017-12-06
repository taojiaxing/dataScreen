using System;
using System.Configuration;
using System.IO;
using System.Text;

namespace ScreenShot
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /* Process p = Process.Start("E:/Thinkgeo/MapSuite9SamplesUpgrade/Tools/tool/DisplayWmsRasterLayerSample-ForWinForms/DisplayWmsRasterLayer/bin/Debug/Map Suite Desktop for WinForms App1.exe");
             p.WaitForExit();*/
            int fail = 0;
            int Success = 0;
            String selectResultPath = ConfigurationManager.AppSettings["selectResultPath"].ToString();
            String screenshotPath = ConfigurationManager.AppSettings["screenshotPath"].ToString();
            if (File.Exists(selectResultPath))
            {
                if (!Directory.Exists(screenshotPath))
                {
                    Directory.CreateDirectory(screenshotPath);
                }
                DirectoryInfo directory = new DirectoryInfo(screenshotPath);
                if (directory.Exists)
                {
                    StreamReader sr = new StreamReader(selectResultPath, Encoding.Default);
                    String line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        String[] Name = line.Split('-');
                        String fileName = Name[0].Replace("Sample", "");
                        String Directory = selectResultPath.Replace("\\", "/");
                        String workingDirectory = Directory.Replace("selectResult.txt", "") + "Project/" + line + "/" + fileName + "/bin/Debug";
                        Start start = new Start();
                        DirectoryInfo directoryInfo = new DirectoryInfo(workingDirectory);
                        StringBuilder stringBuilder = new StringBuilder();
                        foreach (FileInfo info in directoryInfo.GetFiles("*.exe"))
                        {
                            stringBuilder.Append(info.Name);
                        }
                        stringBuilder.Replace(".exeThinkGeo.MapSuite.ProductCenter.exe", "");
                        Boolean s = start.start(stringBuilder.ToString(), workingDirectory, screenshotPath);
                        if (s)
                        {
                            Success += 1;
                        }
                        else
                        {
                            fail += 1;
                        }
                    }
                }
                else
                {
                    Console.WriteLine(value: "screenShot文件不存在");
                }
            }
            else
            {
                Console.WriteLine("selectResult.txt不存在");
            }
            Console.WriteLine("成功截图：" + Success + "个项目");
            Console.WriteLine("失败    :" + fail + "个项目");
            Console.ReadKey(true);
        }
    }
}