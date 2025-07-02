using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitCatcher
{
     public class Player
     {
         public Rectangle Bounds;

         public Player(int x, int y, int size)
         {
             Bounds = new Rectangle(x, y, size, size);
         }

         public void MoveTo(int x)
         {
             Bounds = new Rectangle(x - Bounds.Width / 2, Bounds.Y, Bounds.Width, Bounds.Height);
         }
     } 

}
