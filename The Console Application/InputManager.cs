using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Console_Application
{
    /// <summary>
    /// Manages user input.
    /// </summary>
    internal class InputManager
    {
        // Handle user input for setting up custom game

        /// <summary>
        /// Keeps asking the user for input until user inputs an integer for board size.
        /// </summary>
        /// <param name="parameterToSet">The parameter the user is currently inputting (fx height or width).</param>
        /// <returns>The input as integer.</returns>
        public static int GetGridSizeInput(string parameterToSet)
        {
            int x;
            ConsoleHelper.Write($"Enter a value for {parameterToSet} (int): ");
            while (!int.TryParse(ConsoleHelper.Read(), out x))
                ConsoleHelper.Write("The value must be of integer type, try again: ");
            return x;
        }
    }
}
