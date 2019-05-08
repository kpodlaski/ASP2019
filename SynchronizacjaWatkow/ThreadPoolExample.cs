using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SynchronizacjaWatkow
{
    class ThreadPoolExample
    {
        public static void Main()
        {
            ThreadPool.SetMaxThreads(30,30);
            SemaphoreExample.semaphore = new Semaphore(0, SemaphoreExample.isOpen.Length);

            SemaphoreExample[] se = new SemaphoreExample[200];
            for (int i = 0; i < se.Length; i++)
            {
                SemaphoreExample me = new SemaphoreExample();
                me.numer = i;
                se[i] = me;
                ThreadPool.QueueUserWorkItem(me.client);
            }
            SemaphoreExample.semaphore.Release(SemaphoreExample.isOpen.Length);
           // for (int i = 0; i < threads.Length; i++)
                //threads[i].Join();
            Console.ReadLine();
            int th, ioth;
            ThreadPool.GetMinThreads(out th, out ioth);
            Console.WriteLine("Min th:" + th + " Min ioth" + ioth);
            ThreadPool.GetMaxThreads(out th, out ioth);
            Console.WriteLine("Max th:" + th + " Max ioth" + ioth);
            Console.ReadLine();

        }


    }
}
