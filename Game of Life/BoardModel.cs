using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Console_Application;

namespace Game_of_Life
{
    internal class BoardModel : Grid
    {
        public int CellSize { get; set; }
        public double LiveDensity { get; set; }
        
        public int Width { get; set; }
        public int Height { get; set; }

        public BoardModel(int r, int c, int cellSize, double liveDensity) : base(r, c)
        {
            CellSize = cellSize;
            Width = Row * CellSize;
            Height = Col * CellSize;
            LiveDensity = liveDensity;
            GenerateField(LiveDensity);
        }
        public void GenerateField(double liveDensity)
        {
            Random generator = new Random();

            for (int i = 0; i < Col; i++)
            {
                for (int j = 0; j < Row; j++)
                {
                    Cells[j, i] = generator.NextDouble() < liveDensity; // The cell is alive if the drawn number is lower than the liveDensity percentage
                }
            }
        }
    }
}
