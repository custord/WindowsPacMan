using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Week9_Tut_g1
{
    public class MonkeyShip : Ship
    {
        private Random rdm;
        private bool alive;
        public MonkeyShip(int sx, int sy, int s, bool alives) : base(sx, sy, s)
        {
            alive = alives;
            rdm = new Random(sx + DateTime.Now.Millisecond);
        }

        public bool getAlive() {
            return alive;
        }

        public void setAlive(bool alives) {
            alive = alives;
            Form1.setMonkey();
  
        }
        public override void drawShip(Graphics g, Brush b)
        {
            int x = base.getX();
            int y = base.getY();
            Point[] myShape = new Point[4];
            
            int dir = base.getDir();
            if (dir == 0)
            {
                myShape[0] = new Point(x + 7, y);
                myShape[1] = new Point(x + 18, y);
                myShape[2] = new Point(x + 25, y + 25);
                myShape[3] = new Point(x, y + 25);
            }
            
            
            if (dir == 2)
            {
                myShape[0] = new Point(x, y);
                myShape[1] = new Point(x + 25 , y);
                myShape[2] = new Point(x + 18, y + 25);
                myShape[3] = new Point(x + 7, y + 25);
            }
          
            if (dir == 1)
            {
                myShape[0] = new Point(x, y);
                myShape[1] = new Point(x + 25, y + 7);
                myShape[2] = new Point(x + 25, y + 18);
                myShape[3] = new Point(x, y + 25);
            }
            if (dir == 3)
            {
                myShape[0] = new Point(x, y +7);
                myShape[1] = new Point(x + 25, y);
                myShape[2] = new Point(x + 25, y + 25);
                myShape[3] = new Point(x, y + 18);
            }
            
            g.FillPolygon(b, myShape);
        }

        public void moveAway(int jx, int jy)
        {
            int dir = rdm.Next(1, 7);
            int x = base.getX();
            int y = base.getY();
            if (dir == 1) base.moveLeft();
            else if (dir == 2) base.moveRight();
            else if (dir == 3) base.moveUp();
            else if (dir == 4) base.moveDown();
            else if (dir == 5)
            {
                if (x < jx)
                    base.moveLeft();
                else
                    base.moveRight();
            }
            else
            {
                if (y < jy)
                    base.moveUp();
                else
                    
                    base.moveDown();
            }
        }

        public void handleBorderCollision(int scrX, int scrY)
        {
            int x = base.getX();
            int y = base.getY();
            int dx = base.getDX();
            int dy = base.getDY();
            if ((y <= 5) | (y >= (scrY - 25)) | (x <= 5) | (x >= (scrX - 25)))
            {
                base.setDX(-dx);
                base.setDY(-dy);
                updatePos();
            }
        }

        public bool collideWithRoody(int jx, int jy)
        {
            bool collide = false;
            int x = base.getX();
            int y = base.getY();
            if ((jx >= (x - 30)) & (jx <= (x + 30)) & (jy >= (y - 30)) & (jy <= (y + 30)))
                collide = true;
            return collide;
        }

    }

}
