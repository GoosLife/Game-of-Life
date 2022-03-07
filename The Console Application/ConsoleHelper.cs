using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Console_Application
{
    /// <summary>
    /// Handles reading and writing to console.
    /// </summary>
    internal class ConsoleHelper
    {
        /// <summary>
        /// Write to console at predetermined location
        /// </summary>
        /// <param name="text">The string to write to console.</param>
        public static void Write(string text)
        {
            const int startX = 8;
            int startY = Console.GetCursorPosition().Top + 1;

            if (startY == 0)
            {
                startY = 3;
            }

            Console.SetCursorPosition(startX, startY);

            Console.WriteLine(text);
        }

        /// <summary>
        /// Draws read-input from console at the same position as where everything else is drawn, for a consistent look.
        /// </summary>
        public static string? Read()
        {
            const int startX = 8;
            int startY = Console.GetCursorPosition().Top;

            Console.SetCursorPosition(startX, startY);
            return Console.ReadLine();
        }

        /// <summary>
        /// Allows the user to visually choose an option using arrow keys and enter.
        /// </summary>
        /// <param name="canCancel">If set to true, user can cancel having to choose an option by pressing escape.</param>
        /// <param name="options">An array of the options the user should be presented.</param>
        /// <returns>The array index of the choice the user made.</returns>
        public static int MultipleChoice(bool canCancel, params string[] options)
        {
            const int startX = 8;
            const int startY = 8;
            const int optionsPerLine = 3;
            const int spacingPerLine = 14;

            int currentSelection = 0;

            ConsoleKey key;

            Console.CursorVisible = false;

            do
            {
                for (int i = 0; i < options.Length; i++)
                {
                    // Makes menu options a little prettier in console
                    Console.SetCursorPosition(startX + (i % optionsPerLine) * spacingPerLine, startY + i / optionsPerLine);

                    // Highlights the users current choice
                    if (i == currentSelection)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    Console.Write(options[i]);
                    Console.ResetColor();
                }

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        {
                            if (currentSelection % optionsPerLine > 0)
                            {
                                currentSelection--;
                            }
                            break;
                        }

                    case ConsoleKey.RightArrow:
                        {
                            if (currentSelection % optionsPerLine < optionsPerLine - 1)
                            {
                                currentSelection++;
                            }
                            break;
                        }

                    case ConsoleKey.UpArrow:
                        {
                            if (currentSelection >= optionsPerLine)
                            {
                                currentSelection -= optionsPerLine;
                            }
                            break;
                        }

                    case ConsoleKey.DownArrow:
                        {
                            if (currentSelection + optionsPerLine < options.Length)
                            {
                                currentSelection += optionsPerLine;
                            }
                            break;
                        }

                    case ConsoleKey.Escape:
                        {
                            if (canCancel)
                            {
                                return -1;
                            }
                            break;
                        }
                }
            }

            while (key != ConsoleKey.Enter);

            Console.CursorVisible = true;

            return currentSelection;
        }

        /// <summary>
        /// Allows the user to visually choose an option using arrow keys and enter.
        /// </summary>
        /// <param name="canCancel">If set to true, user can cancel having to choose an option by pressing escape.</param>
        /// <param name="perLine">How many options to draw per console line.</param>
        /// <param name="options">An array of the options the user should be presented.</param>
        /// <returns>The array index of the choice the user made.</returns>
        public static int MultipleChoice(bool canCancel, int perLine, params string[] options)
        {
            const int startX = 8;
            int startY = Console.GetCursorPosition().Top + 1;
            int optionsPerLine = perLine;
            const int spacingPerLine = 14;

            int currentSelection = 0;

            ConsoleKey key;

            Console.CursorVisible = false;

            do
            {
                for (int i = 0; i < options.Length; i++)
                {
                    // Makes menu options a little prettier in console
                    Console.SetCursorPosition(startX + (i % optionsPerLine) * spacingPerLine, startY + i / optionsPerLine);

                    // Highlights the users current choice
                    if (i == currentSelection)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    Console.Write(options[i]);
                    Console.ResetColor();
                }

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        {
                            if (currentSelection % optionsPerLine > 0)
                            {
                                currentSelection--;
                            }
                            break;
                        }

                    case ConsoleKey.RightArrow:
                        {
                            if (currentSelection % optionsPerLine < optionsPerLine - 1)
                            {
                                currentSelection++;
                            }
                            break;
                        }

                    case ConsoleKey.UpArrow:
                        {
                            if (currentSelection >= optionsPerLine)
                            {
                                currentSelection -= optionsPerLine;
                            }
                            break;
                        }

                    case ConsoleKey.DownArrow:
                        {
                            if (currentSelection + optionsPerLine < options.Length)
                            {
                                currentSelection += optionsPerLine;
                            }
                            break;
                        }

                    case ConsoleKey.Escape:
                        {
                            if (canCancel)
                            {
                                return -1;
                            }
                            break;
                        }
                }
            }

            while (key != ConsoleKey.Enter);

            Console.CursorVisible = true;

            return currentSelection;
        }

        /// <summary>
        /// Draws an ASCII rectangle to the console.
        /// </summary>
        public static void DrawRectangle()
        {
            Console.Write("┌─┐");
            Console.SetCursorPosition(Console.CursorLeft - 3, Console.CursorTop + 1);
            Console.Write("│1│");
            Console.SetCursorPosition(Console.CursorLeft - 3, Console.CursorTop + 1);
            Console.Write("└─┘");
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 2);
        }

        /// <summary>
        /// Draws empty space in the console, in an area the same size as DrawRectangle.
        /// </summary>
        public static void DrawEmpty()
        {
            Console.Write("   ");
            Console.SetCursorPosition(Console.CursorLeft - 3, Console.CursorTop + 1);
            Console.Write("   ");
            Console.SetCursorPosition(Console.CursorLeft - 3, Console.CursorTop + 1);
            Console.Write("   ");
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 2);
        }
    }
}
