using System;

namespace Pac_ManV4
{
    public class Movement
    {
        
        private Maze maze;
        
        public Movement(Maze maze)
        {
            this.maze = maze;
        }

        public void Start()
        {
            try
            {
                while (true)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    int newX = maze.PlayerX;
                    int newY = maze.PlayerY;

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.W:
                        case ConsoleKey.UpArrow:
                            while (maze.IsValidMove(maze.PlayerX - 1, maze.PlayerY))
                            {
                                newX = maze.PlayerX - 1;
                                if (Console.KeyAvailable)
                                    break;
                                maze.MovePlayer(newX, newY);
                                Console.Clear();
                                maze.PrintMaze();
                                System.Threading.Thread.Sleep(200);
                            }
                            break;
                        case ConsoleKey.S:
                        case ConsoleKey.DownArrow:
                            while (maze.IsValidMove(maze.PlayerX + 1, maze.PlayerY))
                            {
                                newX = maze.PlayerX + 1;
                                if (Console.KeyAvailable)
                                    break;
                                maze.MovePlayer(newX, newY);
                                Console.Clear();
                                maze.PrintMaze();
                                System.Threading.Thread.Sleep(200);
                            }
                            break;
                        
                        case ConsoleKey.A:
                        case ConsoleKey.LeftArrow:
                            while (maze.IsValidMove(maze.PlayerX, maze.PlayerY - 1))
                            {
                                newY = maze.PlayerY - 1;
                                if (Console.KeyAvailable)
                                    break;
                                maze.MovePlayer(newX, newY);
                                Console.Clear();
                                maze.PrintMaze();
                                System.Threading.Thread.Sleep(200);
                            }
                            break;
                        case ConsoleKey.D:
                        case ConsoleKey.RightArrow:
                            while (maze.IsValidMove(maze.PlayerX, maze.PlayerY + 1))
                            {
                                newY = maze.PlayerY + 1;
                                if (Console.KeyAvailable)
                                    break;
                                maze.MovePlayer(newX, newY);
                                Console.Clear();
                                maze.PrintMaze();
                                System.Threading.Thread.Sleep(200);
                            }
                            break;
                    }

                    if (maze.IsValidMove(newX, newY))
                    {
                        maze.MovePlayer(newX, newY);
                        Console.Clear();
                        maze.PrintMaze();
                    }
                }
            }
            catch (Exception ex) when (ex.Message == "Exit")
            {
                // Print the final state of the maze
                maze.PrintMaze();
                Console.Clear();
            }
        }
    }
}