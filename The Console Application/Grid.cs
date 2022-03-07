using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Console_Application
{
    internal class Grid
    {
        /// <summary>
        /// Width of grid
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Height of grid
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// The cells of the grid
        /// </summary>
        public bool[,] Cells { get; set; }

        public Grid(int w, int h)
        {
            Width = w;
            Height = h;
            Cells = new bool[Width, Height];
            GenerateField();
        }

        public void GenerateField()
        {
            Random generator = new Random();
            int num = 0;

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    num = generator.Next(2);

                    Cells[i, j] = ((num == 0) ? true : false);
                }
            }
        }

        public void Grow()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    int numOfAliveNeighbors = GetNeighbors(i, j);

                    if (Cells[i, j])
                    {
                        if (numOfAliveNeighbors < 2)
                        {
                            Cells[i, j] = false;
                        }

                        if (numOfAliveNeighbors > 3)
                        {
                            Cells[i, j] = false;
                        }
                    }
                    else
                    {
                        if (numOfAliveNeighbors == 3)
                        {
                            Cells[i, j] = true;
                        }
                    }
                }
            }
        }

        private int GetNeighbors(int x, int y)
        {
            int NumOfAliveNeighbors = 0;

            for (int i = x - 1; i < x + 2; i++)
            {
                for (int j = y - 1; j < y + 2; j++)
                {
                    if (!((i < 0 || j < 0) || (i >= Height || j >= Width)))
                    {
                        if (Cells[i, j] == true) NumOfAliveNeighbors++;
                    }
                }
            }
            return NumOfAliveNeighbors;
        }
    }
}
