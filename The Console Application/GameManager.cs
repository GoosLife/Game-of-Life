using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace The_Console_Application
{
    internal class GameManager
    {
        public static void DrawAndGrow(Grid grid)
        {
            grid.Grow();
            DrawGame(grid);
        }

        public static void DrawGame(Grid grid)
        {
            // If coordinate is "true", draw it in
            for (int i = 0; i < grid.Height; i++)
            {
                for (int j = 0; j < grid.Width; j++)
                {
                    if (grid.Cells[j, i])
                        ConsoleHelper.DrawRectangle();
                    else
                        ConsoleHelper.DrawEmpty();

                    // Skip to the next line when the width of the grid has been reached.
                    if (j == (grid.Width - 1))
                    {
                        Console.SetCursorPosition(0, Console.CursorTop + 3);
                        Console.GetCursorPosition();
                    }
                }
            }

            // Reset cursor position
            Console.SetCursorPosition(0, 0);
        }


        public static void RunGame(Grid grid, int maxRuns)
        {
            int runs = 0;

            while (runs++ < maxRuns)
            {
                DrawAndGrow(grid);

                // Makes game more clearly visible to user by running at a slowed pace.
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
