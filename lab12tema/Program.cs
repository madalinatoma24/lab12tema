using System;
using System.Diagnostics;

namespace lab12tema
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             Exercițiu
             Scrieti o clasa care va implementa o structura de date generica de tipul coada. (queue)
             Coada va functiona pe principiul FIFO (first in first out) si va avea urmatoarele metode si proprietati:
             • Enqueue – va adauga un element la capatul cozii
             • Dequeue – va extrage primul element din coada si il va returna ca rezultat
             • Count – va returna numarul de elemente din coada.
             La initializarea cozii va fi stabilita capacitatea maxima a cozii.
             In interiorul clasei, folositi o structura de tip vector pentru a stoca datele.
             Initializati mai multe cozi (intregi, obiecte), adaugati elemente, extrageti elemente, afisati-le.
             */

            var queue = new Queue<int>(5);
            Console.WriteLine($"Added value to queue => [{queue.Enqueue(1)}]");
            Console.WriteLine($"Added value to queue => [{queue.Enqueue(2)}]");
            Console.WriteLine($"Added value to queue => [{queue.Enqueue(3)}]");
            Console.WriteLine($"Added value to queue => [{queue.Enqueue(4)}]");
            Console.WriteLine($"Added value to queue => [{queue.Enqueue(5)}]");
            Console.WriteLine($"Added value to queue => [{queue.Enqueue(6)}]");

            Console.WriteLine($"Removed first value({queue.Dequeue()}) => [{queue}]");
            Console.WriteLine($"Number of elements in queue: {queue.Count()}");

            var queue1 = new SimpleQueue<String>(4);
            Console.WriteLine($"Added value to queue => [{queue1.Enqueue("A")}]");
            Console.WriteLine($"Added value to queue => [{queue1.Enqueue("B")}]");
            Console.WriteLine($"Added value to queue => [{queue1.Enqueue("C")}]");

            Console.WriteLine($"Removed first value({queue1.Dequeue()}) => [{queue1}]");
            Console.WriteLine($"Number of elements in queue: {queue1.Count()}");

            var listQueue = new ListQueue<Element<String>,String>();
            Console.WriteLine($"Added value to ListQueue => [{listQueue.Enqueue("A")}]");
            Console.WriteLine($"Added value to ListQueue => [{listQueue.Enqueue("B")}]");
            Console.WriteLine($"Added value to ListQueue => [{listQueue.Enqueue("C")}]");

            Console.WriteLine($"Removed first value({listQueue.Dequeue()}) => [{listQueue}]");
            Console.WriteLine($"Number of elements in queue: {listQueue.Count()}");

            Console.WriteLine($"________");
            Console.WriteLine($"________");
            BenchMarkQueue(new Queue<int>(10, 10), 100);
            BenchMarkQueue(new ListQueue<Element<int>, int>(), 100);
            BenchMarkQueue(new SimpleQueue<int>(10), 100);
        }


        public static void BenchMarkQueue<Q>(Q queue, int newSize)
            where Q: IQueue<int>
        {
            Console.WriteLine($"Queue[{queue}].Length({queue.Length})");

            var timmer = new Stopwatch();
            timmer.Start();
            for (var i = 0; i < newSize; i++)
            {
                try {
                    queue.Enqueue(i);
                }
                catch { 
                }
            }
            timmer.Stop();
            Console.WriteLine($"Time to insert using {queue.GetType().Name}: {timmer.Elapsed.TotalMilliseconds} ms");
        }
    }
}
