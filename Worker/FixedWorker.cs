using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worker
{
    class FixedWorker : BaseWorker
    {

        /// <summary>Инициализирует объект FixedWorker при помощи базового конструктора BaseWorker</summary>
        /// <param name="pos">Местонахождение</param>
        /// <param name="dir">Направление</param>
        /// <param name="size">Размер</param>
        public FixedWorker(string Name, string Surname, sbyte Age) : base(Name, Surname, Age)
        {
        }

        /// <summary>Подсчёт зарплаты работника с фиксированной оплатой</summary>
        /// <param name="hourlyRate">Месячная оплата</param>
        public override void CountSalary(double fixedSalary)
        {
            this.monthSalary = Convert.ToDecimal(fixedSalary);
        }
    }
}