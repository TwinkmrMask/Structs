using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    
    delegate void push(string value);
    delegate void pushback(string value);
    delegate int getlvls();
    delegate void show();
    delegate int getheapcount();

    class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            Heap heap = new Heap();
            while (flag) {
                string[] choose = Console.ReadLine().Split(' ');
                switch(choose[0]) {
                    case "push": 
                        heap.PushLast(choose[1]);
                        break;
                    case "pushback":
                        heap.PushFirst(choose[1]);
                        break;
                    case "get":
                        Console.WriteLine(heap.GetLevels());
                        break;
                    case "stop":
                        flag = false;
                        break;
                    case "show":
                        heap.Show();
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда");
                        break;
                }
            }
            Console.ReadKey(true);
        }
    }

    class Heap
    {
        delegate int geomprogsum(int value);
        static List<string> heap;
        
        public Heap()
        { 
            heap = new List<string>();
        }
       
        public push PushFirst = (value) => heap.Insert(0, value);
        public pushback PushLast = (value) => heap.Add(value);
        public getlvls GetLevels = () =>
        {
            int len = heap.Count;
            int i = 0;
            while (len > 0)
            {
                len = (len--) / 2;
                i++;
            }
            return i;
        };
        public getheapcount Getheapcount = () => heap.Count;
        
        public show Show = () => 
        {
            Console.WriteLine(heap[0]);
            for (int i = 1; i < heap.Count; i = (i * 2) + 1)
            {
                for (int j = i; (j < heap.Count) && (j <= i * 2); Console.Write(heap[j]+" "), j++) ;
                Console.WriteLine($"i = {i}");
            }
        };
        geomprogsum Geomprogsum = (int value) =>
        {
            Heap heap = new Heap();
            return Math.Abs(heap.GetLevels() * 2 - 1);
        };



    }
}
