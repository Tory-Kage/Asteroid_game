using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует программа вывода отсортированного массива сотрудников");

            int numberOfWorkers = 20;
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            Console.WriteLine(Environment.NewLine + "Создадим список сотрудников:");

            ArrayOfWorkers arr = new ArrayOfWorkers();

            arr.Init(numberOfWorkers);

            arr.Print();

            Console.WriteLine(Environment.NewLine + "Отсортируем список по зарплате:");

            arr.Sort();
            arr.Print();

            Console.ReadKey();
        }
    }
}
