using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars
{
    public enum Direction
    {
        Right, Down,Left,Up
    }
    internal class Spiralizor
    {
        
        public static int[,] Spiralize(int size)
        {
            var spiral = new int[size,size];


            int x = 1;
            int y = 2;
            int horizontalLength = size - 3;
            int verticalLength = size - 5;
            Direction direction = Direction.Right;
            while (true)
            {
                if(horizontalLength <= 0)
                {
                    break;
                }
                for(int i = 0;i< horizontalLength; i++)
                {
                    if(direction == Direction.Left)
                    {
                        x--;
                    }
                    else
                    {
                        x++;
                    }
                    spiral[x,y] = 1;
                }
                if(direction == Direction.Left)
                {
                    direction = Direction.Down;
                }
                else
                {
                    direction = Direction.Up;
                }
                horizontalLength -= 2;
                if (verticalLength <= 0)
                {
                    break;
                }
                for (int i = 0; i <verticalLength; i++)
                {
                    if (direction == Direction.Up)
                    {
                        y--;
                    }
                    else
                    {
                        y++;
                    }
                    spiral[x,y] = 1;
                }
                verticalLength -= 2;
                if (direction == Direction.Down)
                {
                    direction = Direction.Right;
                }
                else
                {
                    direction = Direction.Left;
                }
            }

            return spiral;
        }
    }
}
