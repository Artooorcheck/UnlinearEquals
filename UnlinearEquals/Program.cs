using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnlinearEquals
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите X0");
            var x = Double.Parse(Console.ReadLine());
            Console.WriteLine("Введите максимальную погрешность");
            var eps = Double.Parse(Console.ReadLine());
            Console.WriteLine("Введите максимальное число итераций");
            var k = Double.Parse(Console.ReadLine());

            var eq = new SolveEquals(x, eps, k);

            if (!eq.OnError)
                Console.WriteLine($"Решение = {eq.xx}\nЧисло итераций = {eq.l}\nF(x) = {eq.fx}");
            else
                Console.WriteLine(eq.IER);
            Console.Read();
        }
    }
}
