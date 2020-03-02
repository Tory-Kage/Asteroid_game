using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroidgame
{
    class Medkit : BaseObject
    {
        public int Power { get; set; } = 3;
        Bitmap image = new Bitmap("..\\..\\img/medkit.png");

        /// <summary>Инициализирует объект SmallStar при помощи базового конструктора BaseObject</summary>
        /// <param name="pos">Местонахождение</param>
        /// <param name="dir">Направление</param>
        /// <param name="size">Размер</param>
        public Medkit(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = Size.Width / 2;
        }

        /// <summary>Метод отрисовки объекта</summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        /// <summary>Метод обновления местоположения объекта</summary>
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0 - Size.Width)
            {
                Recreate();
            }
        }

        internal void Recreate()
        {
            Pos.X = Game.Width + Size.Width;
            Pos.Y = Convert.ToInt32((myRandom.RandomDoubleNumber() * (0.9 - 0.1) + 0.1) * (double)Game.Height);
        }
    }
}