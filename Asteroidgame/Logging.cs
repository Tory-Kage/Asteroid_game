using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroidgame
{
    /// <summary>Класс логирования действий программы</summary>
    class Logging
    {
        /// <summary>Метод записи в файл</summary>
        /// <param name="Msg">Текст сообщения</param>
        internal static void Log(string Msg)
        {
            using (var sw = new System.IO.StreamWriter("data.log", true))
            {
                Debug.WriteLine(Msg);
                sw.WriteLine(Msg);
            }
        }
    }
}