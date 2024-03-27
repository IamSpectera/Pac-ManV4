using System;

namespace Pac_ManV4
{
    public class Maze
    {
        bool canexit = false;
        int gold = 0;
        public char[,] maze;
        
        // Used to get the player's position
        public int PlayerX { get; private set; }
        public int PlayerY { get; private set; }
        
        // Creates the maze
        public Maze()
        {
            maze = new char[,]
            {
                {'|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', ' ', '|', '|', '|', '|', ' ', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', ' ', '|'},
                {'|', ' ', '|', '|', '|', '|', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', '|', ' ', '|', '|', '|', '|', '|', ' ', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', '|', '|', '|', '|', '|', ' ', '|', '|', ' ', '|', ' ', '|', '|', '|', '|', ' ', '|', '|', ' ', '|', '|', '|', '|', '|', '|', '|', '|'},
                {' ', ' ', ' ', ' ', ' ', '|', ' ', '|', '|', ' ', '|', ' ', '|', '|', '|', '|', ' ', '|', '|', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {'|', '|', '|', '|', '|', '|', ' ', '|', '|', ' ', '|', ' ', '|', '|', '|', '|', ' ', '|', '|', ' ', '|', '|', '|', '|', '|', '|', '|', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '|', '|', '|', '|', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', ' ', '|', '|', '|', '|', ' ', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', ' ', '|', '|', '|', '|', ' ', '|'},
                {'|', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|', '|'},
            };
            
            // Set the player's initial position
            PlayerX = 1;
            PlayerY = 1;
            maze[PlayerX, PlayerY] = 'P';
        }
        
        // Check if x and y are within the maze and not a wall
        public bool IsValidMove(int x, int y)
        {
            return maze[x, y] != '|';
        }

        // This is used to check if player is over gold, key, or exit
        public void MovePlayer(int x, int y)
        {
            // Check if the player has reached the exit
            if (maze[x, y] == 'E')
            {
                // Throws exception to stop the game loop and print the final state of the maze
                if (canexit)
                {
                    System.Console.WriteLine("You won! You have " + gold + " gold! You have exited the maze.");
                    throw new Exception("Exit");
                } else {
                    System.Console.WriteLine("You need the key to exit!");
                    return;
                }
            }
            
            // The key to gain the exit
            if (maze[x, y] == 'K')
            {
                System.Console.WriteLine("You gave gained the key to exit!");
                canexit = true;
            }
            if (maze[x, y] == 'G')
            {
                gold++;
            }

            // Clear the old player position only if it's not the exit
            if (maze[PlayerX, PlayerY] != 'E')
            {
                maze[PlayerX, PlayerY] = ' ';
            }
            
            PlayerX = x;
            PlayerY = y;
            maze[PlayerX, PlayerY] = 'P';
        }
        
        // Simple loop to print the maze
        public void PrintMaze()
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    // Switch Statement to change the color of the console
                    switch (maze[i, j])
                    {
                        case 'P':
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case 'E':
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case '|':
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                    }
                    System.Console.Write(maze[i, j]); 
                }
                System.Console.WriteLine();
            }
        }
    }
}