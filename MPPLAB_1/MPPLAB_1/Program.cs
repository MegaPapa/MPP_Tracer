using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MPPLAB_1 {
    class Program {

        private static volatile Tracer tracer = Tracer.getInstance();
        private static List<TraceResult> tr = new List<TraceResult>();
        //private static List<T> list = new List<>(tr);

        private static void test_three() {
            Console.WriteLine("three start");
            tracer.StartTrace();
                tracer.StartTrace();
                    tracer.StartTrace();
                    tracer.StopTrace();
                    tracer.GetTraceResult();
                //Thread.Sleep(1000);
                tracer.StopTrace();
                tracer.GetTraceResult();
            //Thread.Sleep(1000);
            tracer.StopTrace();
            tracer.GetTraceResult();

            tracer.StartTrace();
            //Thread.Sleep(1000);
            tracer.StopTrace();
            tracer.GetTraceResult();
        }

        private static void test_two() {
            tracer.StartTrace();
            //Thread.Sleep(1000);
            tracer.StopTrace();
            tracer.GetTraceResult();

            Thread tr1 = new Thread(test_three);
            tr1.Start();

            tracer.StartTrace();
            //Thread.Sleep(1000);
            tracer.StopTrace();
            tracer.GetTraceResult();

            tracer.StartTrace();

                tracer.StartTrace();
                tracer.StopTrace();
                tracer.GetTraceResult();

            tracer.StopTrace();
            tracer.GetTraceResult();
        }

        private static void test_one() {
            tracer.StartTrace();
            tracer.StopTrace();
            tracer.GetTraceResult();

            Thread tr = new Thread(test_two);
            tr.Start();
            tracer.StartTrace();
                tracer.StartTrace();
                    tracer.StartTrace();
                    tracer.StopTrace();
                    tracer.GetTraceResult();
                    tracer.StartTrace();
                    tracer.StopTrace();
                    tracer.GetTraceResult();
                tracer.StopTrace();
                tracer.GetTraceResult();
            tracer.StopTrace();
            tracer.GetTraceResult();

            tracer.StartTrace();
            tracer.StopTrace();
            tracer.GetTraceResult();

            tracer.StartTrace();
            tracer.StopTrace();
            tracer.GetTraceResult();

            tracer.StartTrace();
            tracer.StopTrace();
            tracer.GetTraceResult();


        }

        static void Main(string[] args) {
            
            //TraceResult tr = new TraceResult();
            //kookoo(1,2,3);
            //kookoo(2,3,4);
            //Thread.Sleep(3000);
            tr = tracer.getTR();
            
            test_one();
            Thread.Sleep(1000);
            for (int i = 0; i < tr.Count; i++)
                Console.WriteLine("{0} {1} {2}",tr.ElementAt(i).getMethodName(),tr.ElementAt(i).getParametersCount(),tr.ElementAt(i).getTime());
            //Thread.Sleep(100);
            //Console.WriteLine(tracer.getLVL());
            Serializator<List<TraceResult>> ser = new Serializator<List<TraceResult>>();
            ser.serialization(tr,"kek.xml");
            Console.ReadKey();
            /*DateTime dt = DateTime.Now;
            long t1 = dt.Ticks / 10000;
            Thread.Sleep(500);
            DateTime dt1 = DateTime.Now;
            long t2 = dt1.Ticks / 10000;
            Console.WriteLine(t2-t1);
            Console.ReadKey();*/
        }
    }
}
