using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worker
{
    abstract class BaseWorker : IComparable
    {
        protected string name;
        protected string surname;
        protected sbyte age;
        protected decimal monthSalary;

        /// <summary>Инициализирует объект BaseWorker</summary>
        /// <param name="Name">Имя</param>
        /// <param name="Surname">Фамилия</param>
        /// <param name="Age">Возраст</param>
        public BaseWorker(string Name, string Surname, sbyte Age)
        {
            name = Name;
            surname = Surname;
            age = Age;
        }


        public abstract void CountSalary(double salaryRate);

        public override string ToString()
        {
            return $"{name,-8} {surname,-10}, {age} лет, зарплата: {monthSalary:C}";
        }

        public int CompareTo(object obj)
        {
            if (monthSalary < ((BaseWorker)obj).monthSalary) return 1;
            if (monthSalary > ((BaseWorker)obj).monthSalary) return -1;
            return 0;
        }

    }
}