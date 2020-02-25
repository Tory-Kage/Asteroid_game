using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroidgame
{
    /// <summary>Определяет столкновения двух объектов</summary>
    interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle Rect { get; }

    }
}