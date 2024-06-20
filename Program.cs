using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleOS
{
    internal class Program
    {
        static void Main()
        {
            Console.Clear();

            while(true)
            {
            PaintColorText("Welcome to the ConsoleOS.");
               PaintColorText("\n\nThis application was created by Eduard Okhotnikov" +
                "\nfor portfolio and showing my knowledge of C#", ConsoleColor.Yellow);


                Console.SetCursorPosition(0, 10);
                PaintColorText("The list of Applications:", ConsoleColor.Cyan);
                    Console.WriteLine("\n\n1. - The Library.\n2. - ConsoleTreasureGame." +
                    "\n3. - The calculator\n0. - Exit.");
                Console.Write("\nChoose the point of the menu: ");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Library();
                        break;
                    case 2:
                        ConsoleTreasureGame();
                        break;
                    case 3:
                        Calculator();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Invalid command entered");
                        break;
                };


                Console.ReadKey();
                Console.Clear();
            }
        }

        static void PaintColorText(string text, ConsoleColor color = ConsoleColor.Green)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = defaultColor;
        }

        static void Library()
        {
            Console.Clear();
            bool isOpen = true;
            string[,] books =
            {
            { "Charles Dickens", "John Donne", "George Eliot", },
            { "Robert Martin", "Jessy Shell",  "Harold Pinter" },
            { "George Orwell", "Ian Fleming",  "William Shakespeare" }
        };

            while (isOpen = true)
            {
                Console.SetCursorPosition(0, 20);
                PaintColorText("The list of authors:\n\n", ConsoleColor.Yellow);
                for (int i = 0; i < books.GetLength(0); i++)
                {
                    for (int j = 0; j < books.GetLength(1); j++)
                    {
                        Console.Write(books[i, j] + " | ");
                    }
                    Console.WriteLine();
                }
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Library");
                Console.WriteLine("\n1. - Find out the author's name by book index." +
                                "\n\n2. - Find the book by author.\n\n0. - Exit.");
                Console.Write("\nChoose the point of the menu. ");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        int line, column;
                        Console.Write("Enter number of line: ");
                        line = Convert.ToInt32(Console.ReadLine()) - 1;
                        Console.Write("Enter number of column: ");
                        column = Convert.ToInt32(Console.ReadLine()) - 1;
                        Console.WriteLine("This author: " + books[line, column]);
                        break;
                    case 2:
                        string author;
                        bool authorIsFound = false;
                        Console.Write("Enter your author: ");
                        author = Console.ReadLine();
                        for (int i = 0; i < books.GetLength(0); i++)
                        {
                            for (int j = 0; j < books.GetLength(1); j++)
                            {
                                if (author.ToLower() == books[i, j].ToLower())
                                {
                                    Console.Write($"Author {books[i, j]} is in the adres of shelf {i + 1}" +
                                        $", place {j + 1}.");
                                    authorIsFound = true;
                                }
                            }
                        }
                        if (authorIsFound == false)
                        {
                            Console.WriteLine("This author is not find.");
                        }
                        break;
                    case 0:
                        isOpen = false;
                        Main();
                        break;
                    default:
                        Console.WriteLine("Invalid command entered");
                        break;
                }

                if (isOpen)
                {
                    Console.WriteLine("\nPress key to continue...");
                }
                Console.ReadKey();
                Console.Clear();
            }

        }

        static void ConsoleTreasureGame()
        {
            Console.Clear();
            Console.CursorVisible = false;
            char[,] map =
            {
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            { '#', ' ', '#', 'X', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'X', ' ', ' ', '#' },
            { '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', '#', '#', '#', ' ', ' ', '#' },
            { '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', 'X', '#', ' ', ' ', '#' },
            { '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', '#', ' ', ' ', '#' },
            { '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', '#', ' ', ' ', '#' },
            { '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', '#', '#', '#', '#', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', 'X', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'X', ' ', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }

        };

            int userX = 6, userY = 6;
            char[] bag = new char[1];

            while (true)
            {
                Console.SetCursorPosition(0, 15);
                Console.Write("Bag: ");
                for (int i = 0; i < bag.Length; i++)
                {
                    Console.Write(bag[i] + " ");
                }


                Console.SetCursorPosition(0, 0);
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        Console.Write(map[i, j]);
                    }
                    Console.WriteLine();
                }

                Console.SetCursorPosition(userY, userX);
                Console.Write('@');
                ConsoleKeyInfo charKey = Console.ReadKey();
                switch (charKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (map[userX - 1, userY] != '#')
                        {
                            userX--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (map[userX + 1, userY] != '#')
                        {
                            userX++;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (map[userX, userY - 1] != '#')
                        {
                            userY--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (map[userX, userY + 1] != '#')
                        {
                            userY++;
                        }
                        break;
                }

                if (map[userX, userY] == 'X')
                {
                    map[userX, userY] = 'o';
                    char[] tempBag = new char[bag.Length + 1];
                    for (int i = 0; i < bag.Length; i++)
                    {
                        tempBag[i] = bag[i];
                    }
                    tempBag[tempBag.Length - 1] = 'X';
                    bag = tempBag;

                }


                if (bag.Length == 6)
                {
                    Console.SetCursorPosition(0, 20);
                    PaintColorText("You won. Press Enter for a menu!");
                    while (Console.ReadKey().Key != ConsoleKey.Enter)
                    {
                        continue;
                    }

                    Main();
                }

                Console.ReadKey();
                Console.Clear();

            }
        }

        static void Calculator()
        {
            Console.Clear();
            PaintColorText("Calculator", ConsoleColor.Yellow);

            Console.WriteLine("\n1. - Addition.\n2. - Subtraction.\n3. - Multiplication.\n4. - Division.\n0. - Exit.");
            Console.Write("\nChoose your operation: ");

            int x, y;
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    Console.Write("Write first number: ");
                    x = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Write second number: ");
                    y = Convert.ToInt32(Console.ReadLine());
                    Console.Write($"The sum is {Sum(x,y)}");
                    Thread.Sleep(1000);
                    Calculator();
                    break;
                case 2:
                    Console.Write("Write first number: ");
                    x = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Write second number: ");
                    y = Convert.ToInt32(Console.ReadLine());
                    Console.Write($"The Subtraction is {Subtraction(x, y)}");
                    Thread.Sleep(1000);
                    Calculator();
                    break;
                case 3:
                    Console.Write("Write first number: ");
                    x = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Write second number: ");
                    y = Convert.ToInt32(Console.ReadLine());
                    Console.Write($"The Subtraction is {Multiplication(x, y)}");
                    Thread.Sleep(1000);
                    Calculator();
                    break;
                case 4:
                    break;
                case 0:
                    Main();
                    break;
                default:
                    PaintColorText("Invalid Command Try Again", ConsoleColor.Red);
                    Thread.Sleep(1000);
                    Calculator();
                    break;
            }
        }

        private static int Sum(int x, int y)
        {

            return x + y;
        }

        private static int Subtraction(int x, int y)
        {

            return x - y;
        }
        private static int Multiplication(int x, int y)
        {

            return x * y;
        }

    }
}
