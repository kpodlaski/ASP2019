using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SynchronizacjaWatkow
{
    class MonitorExample
    {
        List<int> dane = new List<int>();
        String controller = "Controller";
        double wynikA = 0.0, wynikB = 0.0, wynik = 0.0;

        static void Main(string[] args)
        {
            MonitorExample me = new MonitorExample();
            Random rand = new Random();
            for (int i = 0; i < 1000; i++)
                me.dane.Add(rand.Next() % 100);
            Thread tA = new Thread(new ThreadStart(me.sumaTypuA));
            Thread tB = new Thread(new ThreadStart(me.sumaTypuB));
            tA.Start();
            tB.Start();
            tA.Join();
            tB.Join();
            Console.WriteLine(me.wynikA + me.wynikB);
            Console.WriteLine(me.wynik);
            Console.ReadLine();
        }


        public void sumaTypuA()
        {
            double start = 0;
            for (int i=0; i<dane.Count; i++)
            {
                Monitor.Enter(controller);
                start += Math.Log(dane[i] + 1);
                wynik += Math.Log(dane[i] + 1);
                Monitor.Exit(controller);
            }
            wynikA= start;
        }

        public void sumaTypuB()
        {
            double start = 0;
            for (int i = 0; i < dane.Count; i++)
            {
                Monitor.Enter(controller);
                start += Math.Sin(dane[i] + 1);
                wynik += Math.Sin(dane[i] + 1);
                Monitor.Exit(controller);

            }
            wynikB=start;
        }




    }
}
