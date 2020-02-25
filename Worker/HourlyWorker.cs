using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worker
{
    class HourlyWorker : BaseWorker
    {

        /// <summary>Инициализирует объект HourlyWorker при помощи базового конструктора BaseWorker</summary>
        /// <param name="pos">Местонахождение</param>
        /// <param name="dir">Направление</param>
        /// <param name="size">Размер</param>
        public HourlyWorker(string Name, string Surname, sbyte Age) : base(Name, Surname, Age)
        {
        }

        /// <summary>Подсчёт зарплаты работника с почасовой оплатой</summary>
        /// <param name="hourlyRate">Ставка в час</param>
        public override void CountSalary(double hourlyRate)
        {
            this.monthSalary = Convert.ToDecimal(20.8 * 8 * hourlyRate);
        }

    }
}