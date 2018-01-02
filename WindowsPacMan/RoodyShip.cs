using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Week9_Tut_g1
{
    public class RoodyShip : Ship
    {
        public RoodyShip(int sx, int sy, int s) : base(sx, sy, s)
        {

        }

        public override void drawShip(Graphics g, Brush b)
        {
            int x = base.getX();
            int y = base.getY();
        
           
            int dir = base.getDir();
            Point[] myShape = new Point[5];
            if (dir == 0)
            {
                myShape[0] = new Point(x + 7, y);
                myShape[1] = new Point(x + 18, y);
                myShape[2] = new Point(x + 25, y + 25);
                myShape[3] = new Point(x + 12, y + 12);
                myShape[4] = new Point(x, y + 25);
            }


            if (dir == 2)
            {
                myShape[0] = new Point(x, y);
                myShape[1] = new Point(x + 12, y + 12);
                myShape[2] = new Point(x + 25, y);
                myShape[3] = new Point(x + 18, y + 25);
                myShape[4] = new Point(x + 7, y + 25);
            }

            if (dir == 1)
            {
                myShape[0] = new Point(x, y);
                myShape[1] = new Point(x + 25, y + 7);
                myShape[2] = new Point(x + 25, y + 18);
                myShape[3] = new Point(x, y + 25);
                myShape[4] = new Point(x + 12, y + 12);
            }
            if (dir == 3)
            {
                myShape[0] = new Point(x, y + 7);
                myShape[1] = new Point(x + 25, y);
                myShape[2] = new Point(x + 12, y + 12);
                myShape[3] = new Point(x + 25, y + 25);
                myShape[4] = new Point(x, y + 18);
            }

            g.FillPolygon(b, myShape);
        }

        public bool isBorderCollision(int scrX, int scrY)
        {
            int x = base.getX();
            int y = base.getY();
            bool collide = false;
            if ((y <= 0) | (y >= (scrY - 30)) | (x <= 0) | (x >= (scrX - 30)))
                collide = true;
            return collide;
        }
    }
}
