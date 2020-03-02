using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroidgame
{
    class Asteroid : BaseObject, ICloneable, IComparable, IComparable<Asteroid>
    {
        Bitmap image = new Bitmap("..\\..\\img/asteroid.png");
        public int Power { get; set; } = 3;
        public static int numbers { get; set; } = 2;

        public static event Action<string> asteroidCreation;
        public static event Action<string> asteroidRecreation;

        /// <summary>Инициализирует объект Asteroid при помощи базового конструктора BaseObject</summary>
        /// <param name="pos">Местонахождение</param>
        /// <param name="dir">Направление</param>
        /// <param name="size">Размер</param>
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = Size.Width / 2;
            switch (myRandom.RandomIntNumber(0, 3))
            {
                case 0:
                    image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;
                case 1:
                    image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;
                case 2:
                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
            }
            asteroidCreation?.Invoke($"{DateTime.Now}: Cоздан астероид в позиции ({Pos.X}, {Pos.Y}), размера {Size.Width}");
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
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Width - Size.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height - Size.Height) Dir.Y = -Dir.Y;
        }

        /// <summary>Прересоздаёт объект при столкновении</summary>
        public void Destroed()
        {
            Pos.X = myRandom.RandomIntNumber(Game.Width / 2, Game.Width - Size.Width);
            Pos.Y = Convert.ToInt32(myRandom.RandomDoubleNumber() * (double)(Game.Height - Size.Height));
            asteroidRecreation?.Invoke($"{DateTime.Now}: Астероид был уничтожен и создан в коорданитах ({Pos.X}, {Pos.Y})");
        }

        public object Clone()
        {
            // Создаем копию нашего робота
            Asteroid asteroid = new Asteroid(new Point(Pos.X, Pos.Y), new Point(Dir.X, Dir.Y),
                new Size(Size.Width, Size.Height))
            { Power = Power };
            // Не забываем скопировать новому астероиду Power нашего астероида
            return asteroid;
        }

        /// <summary>Реализация обобщённого интерфейса IComparable</summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns></returns>
        int IComparable.CompareTo(object obj)
        {
            if (obj is Asteroid temp)
            {
                if (Power > temp.Power)
                    return 1;
                if (Power < temp.Power)
                    return -1;
                else
                    return 0;
            }
            throw new ArgumentException("Parameter is not а Asteroid!");
        }

        /// <summary>Реализация необобщённого интерфейса IComparable</summary>
        /// <param name="obj">Объект астероид дял сравнения</param>
        /// <returns></returns>
        int IComparable<Asteroid>.CompareTo(Asteroid obj)
        {
            if (Power > obj.Power)
                return 1;
            if (Power < obj.Power)
                return -1;
            return 0;
        }

    }
}