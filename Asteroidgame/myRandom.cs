using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroidgame
{
    class myRandom
    {
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();

        /// <summary>Возвращает целочисленное значение</summary>
        /// <param name="min">Минимум</param>
        /// <param name="max">Максимальное, не включенное в интервал</param>
        /// <returns></returns>
        public static int RandomIntNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }

        /// <summary>Возвращает вещественное число от 0 до 1</summary>
        /// <returns></returns>
        public static double RandomDoubleNumber()
        {
            lock (syncLock)
            { // synchronize
                return random.NextDouble();
            }
        }
    }
}