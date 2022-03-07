using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Life
{
    internal class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Neighbors { get; set; }
        public bool IsAlive { get; set; }

        public Cell(int x, int y, int neighbors)
        {
            X = x;
            Y = y;
            Neighbors = neighbors;
        }
    }
}
