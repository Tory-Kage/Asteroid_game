using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroidgame
{
    class Ship : BaseObject
    {
        private static int maxEnergy = 100;

        private int _energy = maxEnergy;

        public int Energy => _energy;

        public int Width => Size.Width;

        public int Height => Size.Height;

        Bitmap image = new Bitmap("..\\..\\img/ship.png");

        public static event Action<string> shipDie;
        public static event Action<string> shipEnergyLow;
        public static event Action<string> shipEnergyHigh;

        public static event Message MessageDie;


        /// <summary>Инициализирует объект Ship при помощи базового конструктора BaseObject</summary>
        /// <param name="pos">Местонахождение</param>
        /// <param name="dir">Направление</param>
        /// <param name="size">Размер</param>
        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        /// <summary>Метод получения урона кораблём</summary>
        /// <param name="n">Величина урона</param>
        public void EnergyLow(int n)
        {
            _energy -= n;
            shipEnergyLow?.Invoke($"{DateTime.Now}: Корабль получил повреждения");
        }

        /// <summary>Метод отрисовки объекта</summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        /// <summary>Метод обновления местоположения объекта</summary>
        public override void Update()
        {
        }

        /// <summary>Метод перемещения корабля вверх</summary>
        public void Up()
        {
            if (Pos.Y > 0) Pos.Y = Pos.Y - Dir.Y;
        }

        /// <summary>Метод перемещения корабля вниз</summary>
        public void Down()
        {
            if (Pos.Y < Game.Height) Pos.Y = Pos.Y + Dir.Y;
        }

        /// <summary>Метод уничтожения корабля</summary>
        public void Die()
        {
            shipDie?.Invoke($"{DateTime.Now}: Корабль был уничтожен");
        }

        /// <summary>Метод восстановления уровня здоровья корабля</summary>
        internal void EnergyHigh(int power)
        {
            if (_energy < maxEnergy)
            {
                if (_energy + power > maxEnergy)
                {
                    _energy = maxEnergy;
                }
                else
                {
                    _energy += power;
                }
                shipEnergyHigh?.Invoke($"{DateTime.Now}: Корабль восстановил энергию");
            }
        }
    }

}