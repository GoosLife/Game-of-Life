using The_Console_Application;

// Set up game
Grid grid = new Grid(0, 0);
int maxRuns = 100;

string titleScreen = "Game of Life";
string[] titleOptions = { "1. Standard Game", "2. Custom Grid" };

ConsoleHelper.Write(titleScreen);

switch (ConsoleHelper.MultipleChoice(false, 1, titleOptions))
{
    case 0:
        {
            grid = new Grid(30, 10);
            break;
        }

    case 1:
        {
            Console.WriteLine();
            grid = new Grid(InputManager.GetGridSizeInput("width"), InputManager.GetGridSizeInput("height"));
            break;
        }
}

Console.Clear();

GameManager.RunGame(grid, maxRuns);

return -1;