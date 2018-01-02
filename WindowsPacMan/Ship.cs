using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Week9_Tut_g1
{
    public abstract class Ship
    {
        private int x = 0;
        private int y = 0;
        private int dx = 0;
        private int dy = 0;
        private int speed = 0;
        private int stX = 0;
        private int stY = 0;
        private int dir = 0;

        public Ship(int sx, int sy, int s)
        {
            x = sx;
            y = sy;
            speed = s;
            stX = sx;
            stY = sy;
        }

        public void reset()
        {
            x = stX;
            y = stY;
            dx = 0;
            dy = 0;
        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

        public int getDX()
        {
            return dx;
        }

        public int getDY()
        {
            return dy;
        }

        public void setDX(int newDx)
        {
            dx = newDx;
        }

        public void setDY(int newDy)
        {
            dy = newDy;
        }

        public int getDir()
        {
            return dir;
        }

        public abstract void drawShip(Graphics g, Brush b);

        public void updatePos()
        {
            x = x + dx;
            y = y + dy;
        }

        public void moveUp()
        {
            dx = 0;
            dy = -speed;
            dir = 0;
        }

        public void moveDown()
        {
            dx = 0;
            dy = speed;
            dir = 2;
        }

        public void moveRight()
        {
            dx = speed;
            dy = 0;
            dir = 1;
        }

        public void moveLeft()
        {
            dx = -speed;
            dy = 0;
            dir = 3;
        }
    }
}
