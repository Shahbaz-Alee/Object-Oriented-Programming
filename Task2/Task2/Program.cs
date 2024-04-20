using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task2
{

    public class Point
    {
        private int x;
        private int y;

        public Point()
        {
            this.x = 0;
            this.y = 0;
        }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X(int x)
        {
            return x;
        }

        public int Y(int y)
        {
            return y;
        }

        public void SetXY(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        // for ui
        public override string ToString()
        {
            return "(" + this.x + ", " + this.y + ")";
        }

    }

    public class Boundary
    {
        public Point topLeft;
        public Point topRight;
        public Point bottomLeft;
        public Point bottomRight;

        public Boundary()
        {
            this.topLeft = new Point(0, 0);
            this.topRight = new Point(0, 90);
            this.bottomLeft = new Point(90, 0);
            this.bottomRight = new Point(90, 90);
        }

        public Boundary(Point topLeft, Point topRight, Point bottomLeft, Point bottomRight)
        {
            this.topLeft = topLeft;
            this.topRight = topRight;
            this.bottomLeft = bottomLeft;
            this.bottomRight = bottomRight;
        }

        public Point TopLeft
        {
            get { return this.topLeft; }
            set { this.topLeft = value; }
        }

        public Point TopRight
        {
            get { return this.topRight; }
            set { this.topRight = value; }
        }

        public Point BottomLeft
        {
            get { return this.bottomLeft; }
            set { this.bottomLeft = value; }
        }

        public Point BottomRight
        {
            get { return this.bottomRight; }
            set { this.bottomRight = value; }
        }

        public override string ToString()
        {
            return "(" + this.topLeft.X + ", " + this.topLeft.Y + ") - (" + this.topRight.X + ", " + this.topRight.Y + ") - (" + this.bottomLeft.X + ", " + this.bottomLeft.Y + ") - (" + this.bottomRight.X + ", " + this.bottomRight.Y + ")";
        }
    }

    public class GameObject
    {
        char[,] shape;
        Point startingPoint;
        Boundary premises;
        string direction;

        public GameObject()
        {
            this.shape = new char[1, 3] { '-', '-', '-' };
            this.startingPoint = new Point(0, 0);
            this.premises = new Boundary();
            this.direction = "LeftToRight";
        }

        public GameObject(char[,] shape, Point startingPoint)
        {
            this.shape = shape;
            this.startingPoint = startingPoint;
            this.premises = new Boundary();
            this.direction = "LeftToRight";
        }

        public GameObject(char[,] shape, Point startingPoint, Boundary premises, string direction)
        {
            this.shape = shape;
            this.startingPoint = startingPoint;
            this.premises = premises;
            this.direction = direction;
        }

        public char[,] Shape
        {
            get { return this.shape; }
            set { this.shape = value; }
        }

        public Point StartingPoint
        {
            get { return this.startingPoint; }
            set { this.startingPoint = value; }
        }

        public Boundary Premises
        {
            get { return this.premises; }
            set { this.premises = value; }


        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            char[,] triangle = new char[5, 3] { { '@', ' ', ' ' }, { '@', '@', ' ' }, { '@', '@', '@' }, { '@', '@', ' ' }, { '@', ' ', ' ' } };
            char[,] optriangle = new char[5, 3] { { ' ', ' ', '@' }, { ' ', '@', '@' }, { '@', '@', '@' }, { ' ', '@', '@' }, { ' ', ' ', '@' } };
            Boundary b = new Boundary(new Point(0, 0), new Point(0, 90), new Point(90, 0), new Point(90, 90));
            GameObject g1 = new GameObject(triangle, new Point(5, 5), "LefttoRight", b);
            GameObject g2 = new GameObject(optriangle, new Point(30, 60), "RighttoLeft", b);
            List < GameObject > 1st = new List<GameObject>();
            1st.Add(g1);
            1st.Add(g2);
            while (true)
            {
                Thread.Sleep(2000);
                foreach (GameObject g in 1st)
            {
                    g.erase();
                    g.move();
                    g.draw();
                }
            }
        }
    }
}
