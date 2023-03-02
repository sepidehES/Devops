```
using Logique;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Exercices
{
    internal class Tableau2D : ICommand
    {
        public string Name => "tableau 2d";

        public void Execute()
        {

            static void CreateBoard(int sizeX, int sizeY, int[] origin)
            {
                int[] goal = { 7, 7 };
                string[,] board = new string[sizeX, sizeY];


                for (int i = 0; i < sizeX; i++)
                {
                    for (int j = 0; j < sizeY; j++)
                    {
                        if (i == 0 || j == 0 || i == sizeX - 1 || j == sizeY - 1)
                        {
                            board[i, j] = "#";
                        }
                        else if (origin[0] == goal[0] && origin[1] == goal[1] && i == origin[0] && j == origin[1])
                        {
                            board[i, j] = "P";

                        }
                        else if (i == origin[0] && j == origin[1])
                        {
                            board[i, j] = "O";
                        }
                        else if (i == goal[0] && j == goal[1])
                        {
                            board[i, j] = "X";
                        }
                        Console.Write("{0,-2}", board[i, j]);
                    }
                    Console.WriteLine();
                }
            }

            bool check = true;
            int[] origin = { 3, 3 };
            int[] size = { 20, 20 };
            CreateBoard(size[0], size[1], origin);

            while (check)
            {
                ConsoleKeyInfo movement = Console.ReadKey(true);
                switch (movement.Key)
                {
                    case ConsoleKey.RightArrow:
                        Console.Clear();
                        if (origin[1] < size[0] - 2)
                        {
                            origin[1] += 1;
                        }
                        CreateBoard(size[0], size[1], origin);
                        Console.WriteLine("Le personnage bouge à droite");
                        break;
                    case ConsoleKey.LeftArrow:
                        Console.Clear();
                        if (origin[1] > 1)
                        {
                            origin[1] -= 1;
                        }
                        CreateBoard(size[0], size[1], origin);
                        Console.WriteLine("Le personnage bouge à gauche");
                        break;
                    case ConsoleKey.DownArrow:
                        Console.Clear();

                        if (origin[0] < size[0] - 2)
                        {
                            origin[0] += 1;
                        }

                        CreateBoard(size[0], size[1], origin);
                        Console.WriteLine("Le personnage bouge en bas");
                        break;
                    case ConsoleKey.UpArrow:
                        Console.Clear();

                        if (origin[0] > 1)
                        {
                            origin[0] -= 1;
                        }

                        CreateBoard(size[0], size[1], origin);
                        Console.WriteLine("Le personnage bouge en haut");
                        break;
                    case ConsoleKey.Q:
                        check = false;
                        break;
                }
            }



        }
    }
}


```