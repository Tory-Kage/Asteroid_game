using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Asteroidgame
{
    class Bullet : BaseObject
    {

        public static event Action<string> bulletOutOfScreen;
        public static event Action<string> bulletDestroed;

        /// <summary>Инициализирует объект Bullet при помощи базового конструктора BaseObject</summary>
        /// <param name="pos">Местонахождение</param>
        /// <param name="dir">Направление</param>
        /// <param name="size">Размер</param>
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        /// <summary>Метод отрисовки объекта</summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        /// <summary>Метод обновления местоположения объекта</summary>
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
        }

        /// <summary>Прересоздаёт объект при столкновении</summary>
        public void Recreate()
        {
            Pos.X = 0;
            Pos.Y = Convert.ToInt32(myRandom.RandomDoubleNumber() * (double)(Game.Height - Size.Height));
        }

        /// <summary>Метод возвращает истину, если объект вышел за экран</summary>
        /// <returns></returns>
        public bool OutOfScreen()
        {
            if (Pos.X > Game.Width)
            {
                bulletOutOfScreen?.Invoke($"{DateTime.Now}: Пуля вышла за пределы экрана");
                return true;
            }
            else
                return false;
        }

        /// <summary>Метод уничтожения пули</summary>
        internal void Destroed()
        {
            bulletDestroed?.Invoke($"{DateTime.Now}: Пуля уничтожена");
        }
    }

}