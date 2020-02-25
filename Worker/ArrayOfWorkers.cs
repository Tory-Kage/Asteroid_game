using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worker
{
    class ArrayOfWorkers : IEnumerable, IEnumerator
    {
        BaseWorker[] workers;
        Random rand = new Random();

        // Первоначально индекс указывает на -1, так как к переходу к следующему мы увеличим его на 1
        private int _i = -1;

        /// <summary>Реализация интерфейса IEnumerable</summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return this;
        }

        /// <summary>Реализация интерфейса IEnumerator: MoveNext</summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            if (_i == workers.Length - 1)
            {
                Reset();
                return false;
            }
            _i++;
            return true;
        }
        /// <summary>Реализация интерфейса IEnumerator: Reset</summary>
        /// <returns></returns>
        public void Reset()
        {
            _i = -1;
        }

        public object Current => workers[_i];

        /// <summary>Сортует массив сотрудников</summary>
        public void Sort()
        {
            Array.Sort(workers);
        }

        /// <summary>Выводит содержимое массива на экран</summary>
        public void Print()
        {
            foreach (BaseWorker worker in workers)
            {
                Console.WriteLine(worker.ToString());
            }
        }

        /// <summary>Заполняет массив случайными данными</summary>
        /// <param name="numberOfWorkers">Число сотрудников</param>
        public void Init(int numberOfWorkers)
        {
            workers = new BaseWorker[numberOfWorkers];
            for (int i = 0; i < numberOfWorkers; i++)
            {
                switch (rand.Next(0, 2))
                {
                    case 0:
                        workers[i] = new HourlyWorker("Имя_" + i, "Фамилия_" + i, Convert.ToSByte(rand.Next(18, 65)));
                        break;
                    case 1:
                        workers[i] = new FixedWorker("Имя_" + i, "Фамилия_" + i, Convert.ToSByte(rand.Next(18, 65)));
                        break;
                }

                if (workers[i] is HourlyWorker)
                    workers[i].CountSalary(rand.NextDouble() * (1000 - 150) + 150);
                else if (workers[i] is FixedWorker)
                    workers[i].CountSalary(rand.NextDouble() * (150000 - 30000) + 30000);
            }
        }

    }
}