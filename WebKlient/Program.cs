using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebKlient
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread[] jobs = new Thread[1000];
            for (int i = 0; i < jobs.Length; i++) { 
                jobs[i] = new Thread(
                new ThreadStart(ConnectToPage));
                }
            for (int i = 0; i < jobs.Length; i++)
            {
                jobs[i].Start();
            }
            Console.ReadLine();
        }

        static void ConnectToPage()
        {
            WebClient wc = new WebClient();
            String page = wc.DownloadString("http://localhost:39712/counter");
            Console.WriteLine(page);        
        }
    }
}
