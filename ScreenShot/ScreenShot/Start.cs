using System;
using System.Diagnostics;
using System.Drawing;

namespace ScreenShot
{
    internal class Start
    {
        public Boolean start(String fileName, String workingDirectory, String screenshotPath)
        {
            ProcessStartInfo Info = new ProcessStartInfo
            {
                FileName = fileName + ".exe", //"Map Suite Desktop for WinForms App1.exe",
                WorkingDirectory = workingDirectory //"E:/Thinkgeo/MapSuite9SamplesUpgrade/Tools/tool/DisplayWmsRasterLayerSample-ForWinForms/DisplayWmsRasterLayer/bin/Debug/"
            };
            Process Proc;
            try
            {
                Proc = Process.Start(Info);
            }
            catch (System.ComponentModel.Win32Exception e)
            {
                Console.WriteLine("系统找不到指定的程序文件。\r{0}", e);
                return false;
            }

            //打印出外部程序的开始执行时间
            Console.WriteLine(fileName + "截图开始执行时间：{0}", Proc.StartTime);

            //等待3秒钟
            Proc.WaitForExit(10000);
            ScreenShot s = new ScreenShot();
            Image img = s.CaptureWindow(Proc.MainWindowHandle);
            img.Save(screenshotPath + "/" + fileName + ".png");
            //如果这个外部程序没有结束运行则对其强行终止
            if (Proc.HasExited == false)
            {
                Console.WriteLine("由主程序强行终止外部程序的运行！");
                Proc.Kill();
            }
            else
            {
                Console.WriteLine("由外部程序正常退出！");
            }
            if (img.Width < 10)
            {
                Console.WriteLine(fileName + "截图失败");
                return false;
            }
            else
            {
                Console.WriteLine(fileName + "截图成功");
                return true;
            }
            Console.WriteLine("截图结束运行时间：{0}", Proc.ExitTime);
            Console.WriteLine("");
        }
    }
}