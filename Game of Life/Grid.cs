using Game_of_Life;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Console_Application
{
    public class Grid
    {
        /// <summary>
        /// Width of grid
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// Height of grid
        /// </summary>
        public int Col { get; set; }

        /// <summary>
        /// The cells of the grid
        /// </summary>
        public bool[,] Cells { get; set; }

        public int LivingCells { get; set; }

        public Grid(int r, int c)
        {
            Row = r;
            Col = c;
            Cells = new bool[Row, Col];
            GenerateField();
            LivingCells = 0;
        }

        public void GenerateField()
        {
            Random generator = new Random();
            int num = 0;

            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    num = generator.Next(2);

                    Cells[i, j] = ((num == 0) ? true : false);
                }
            }
        }

        public void Grow()
        {
            LivingCells = 0;

            // Make a list of cell information objects
            List <Cell> list = new List<Cell>();

            // Iterate every cell in the game and get its number of neighbors
            for (int i = 0; i < Col; i++)
            {
                for (int j = 0; j < Row; j++)
                {
                    int aliveNeighbors = GetNeighbors(j, i);

                    Cell c = new Cell(j, i, aliveNeighbors);

                    if (Cells[j,i])
                    {
                        c.IsAlive = true;
                    }

                    list.Add(c);
                }
            }

            // Kill and restore cells
            foreach (Cell cell in list)
            {
                if (cell.IsAlive)
                {
                    LivingCells++;
                }

                if (Cells[cell.X, cell.Y])
                {
                    // If cell has less than 3 neighbors, it dies of loneliness.
                    if (cell.Neighbors < 2)
                    {
                        Cells[cell.X, cell.Y] = false;

                        LivingCells--;
                    }

                    // If cell has more than 4 neighbors, it dies of overcrowding.
                    if (cell.Neighbors > 3)
                    {
                        Cells[cell.X, cell.Y] = false;
                        LivingCells--;
                    }
                }

                // If a cell has exactly 3 neighbors, it comes back to life.
                if (cell.Neighbors == 3)
                {
                    Cells[cell.X, cell.Y] = true;
                    LivingCells++;
                }
            }
        }

        public int GetNeighbors(int x, int y)
        {
            int neighbors = 0;

            for (int i = x - 1; i <= x + 1; i++) // Iterates this cells x-coordinate, plus 1 and two coordinates above it.
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (!((i < 0) || (j < 0) || (i >= Row) || (j >= Col))) // Make sure we're only checking inside of index bounds
                    {

                        // DEBUG
                        //string result = Cells[i, j] ? "alive" : "dead";
                        //Console.WriteLine($"Checking {i},{j}: This cell is {result}");

                        if (Cells[i, j] == true) // Checks if the cell is alive
                        {
                            if (!(i == x && y == j)) // Only count as neighbor if it's not the cell we're checking neighbors for 
                            {
                                neighbors++; // Add neighbor
                            }
                                
                        }
                    }
                }
            }

            return neighbors;
        }
    }
}
