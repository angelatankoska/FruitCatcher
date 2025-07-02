using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitCatcher
{
    public enum FruitType
    {
        Good,
        Bad
    }

    public enum ShapeType { Circle, Square, Triangle }

    public class Fruit
    {
        public Rectangle Bounds;
        public Brush Color;
        public FruitType Type;
        public ShapeType Shape;

        public Fruit(Rectangle bounds, Brush color, FruitType type, ShapeType shape)
        {
            Bounds = bounds;
            Color = color;
            Type = type;
            Shape = shape;
        }

        public void MoveDown(int speed)
        {
            Bounds = new Rectangle(Bounds.X, Bounds.Y + speed, Bounds.Width, Bounds.Height);
        }

        public void Draw(Graphics g)
        {
            switch (Shape)
            {
                case ShapeType.Circle:
                    g.FillEllipse(Color, Bounds);
                    break;
                case ShapeType.Square:
                    g.FillRectangle(Color, Bounds);
                    break;
                case ShapeType.Triangle:
                    Point p1 = new Point(Bounds.X + Bounds.Width / 2, Bounds.Y);
                    Point p2 = new Point(Bounds.X, Bounds.Y + Bounds.Height);
                    Point p3 = new Point(Bounds.X + Bounds.Width, Bounds.Y + Bounds.Height);
                    g.FillPolygon(Color, new Point[] { p1, p2, p3 });
                    break;
            }
        }
    }


}
