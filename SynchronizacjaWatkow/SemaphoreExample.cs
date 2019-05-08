using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SynchronizacjaWatkow
{
    class SemaphoreExample
    {
        public static bool[] isOpen = {true, true, true};
        public static Semaphore semaphore;
        public int numer { get; set; }

        public static void Main(String[] a)
        {
            semaphore = new Semaphore(0, isOpen.Length);

            Thread[] threads = new Thread[100];
            for (int i=0; i< threads.Length; i++)
            {
                SemaphoreExample me = new SemaphoreExample();
                me.numer = i;
                threads[i] = new Thread(new ThreadStart(me.client));
                threads[i].Start();
            }
            semaphore.Release(isOpen.Length);
            for (int i = 0; i < threads.Length; i++)
                threads[i].Join();
            Console.ReadLine();
        }
        public void client(Object stateInfo)
        {
            client();
        }

        public void client()
        {
            //Podchodzi do kolejki
            //Czeka na wolne okienko -- Sprawdza Mutex
            semaphore.WaitOne();
            //Sprawdza wolne okno:
            int okno = 0;
            for(; okno<isOpen.Length; okno++)
            {
                if (isOpen[okno] == true)
                {
                    isOpen[okno] = false;
                    break;
                }
            }
            Console.WriteLine("Klient " + numer + " podszedł do okna " + okno);
            Thread.Sleep(150);
            Console.WriteLine("Klient " + numer + " --odchodzi od okna " + okno);
            isOpen[okno] = true;
            //Zwalniamy Mutex
            semaphore.Release();

            
        }
    }
}
