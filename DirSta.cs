using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.ComponentModel;
using System.IO;

namespace DirectoryStatistic
{
    class DirSta
    {
        static void Main(string[] args)
        {
            try
            {
                using (Process myProcess = new Process ())
                {

                    string path = @"C:\Users\admin\Desktop";
                    string pattern = "*.pdf";
                    string fileName = path + pattern;
                    
                    myProcess.StartInfo.CreateNoWindow = true;
                    dirSta(path, pattern);
                    //myProcess.Start();
                }
            }
            catch (Exception a)
            {
                Console.WriteLine(a.Message);
            }
        }

        static void dirSta(string path,string pattern)
        {
            int count = 0;
            long size = 0;
            DateTime stime = DateTime.Now;

            

            DirectoryInfo folder = new DirectoryInfo(path);
            DirectoryInfo[] dir = folder.GetDirectories();
            FileInfo[] fil = folder.GetFiles();

            foreach (DirectoryInfo d in dir)
            {
                foreach (FileInfo f in d.GetFiles(pattern))
                {
                    count++;
                    size += f.Length;
                }
            }

            /*foreach (FileInfo file in folder.GetFiles(pattern))
            {
                count++;
                size += file.Length;
            }*/

            Console.WriteLine("File name pattern: " + pattern);
            Console.WriteLine("File count: " + count);
            Console.WriteLine("Total size: " + size / 1024.00 + " KB" + " (" + size + " bytes)");
            DateTime etime = DateTime.Now;
            TimeSpan interval = etime - stime;
            Console.WriteLine("Time elapsed: " + interval.TotalMilliseconds+" ms");
            Console.WriteLine("File list: ");
            foreach (DirectoryInfo d in dir)
            {
                foreach (FileInfo f in d.GetFiles(pattern))
                {
                    Console.WriteLine(f.FullName);
                }
            }
            Console.Read();
            /*foreach (FileInfo file in folder.GetFiles(pattern))
            {
                Console.WriteLine(file.FullName);
            }*/
        }
    }
}
