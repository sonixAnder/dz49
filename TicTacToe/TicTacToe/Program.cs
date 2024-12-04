using System;

namespace TicTacToe
{
    class Program
    {
        static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static char player = 'X';
        static bool isSinglePlayer = true;

        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в игру Крестики-Нолики!");
            Console.WriteLine("Выберите режим:");
            Console.WriteLine("1 - Играть с компьютером");
            Console.WriteLine("2 - Играть с другим пользователем");

            var choice = Console.ReadLine();
            isSinglePlayer = choice == "1";

            Random random = new Random();
            if (random.Next(2) == 0)
            {
                Console.WriteLine("Игру начинает игрок X.");
            }
            else
            {
                player = 'O';
                Console.WriteLine("Игру начинает игрок O.");
            }

            while (true)
            {
                Console.Clear();
                DisplayBoard();
                if (isSinglePlayer && player == 'O')
                {
                    ComputerMove();
                }
                else
                {
                    PlayerMove();
                }

                if (CheckWin())
                {
                    Console.Clear();
                    DisplayBoard();
                    Console.WriteLine($"Победил игрок {player}!");
                    break;
                }
                if (CheckDraw())
                {
                    Console.Clear();
                    DisplayBoard();
                    Console.WriteLine("Ничья!");
                    break;
                }

                player = player == 'X' ? 'O' : 'X';
            }
        }

        static void DisplayBoard()
        {
            Console.WriteLine("-------------");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"| {board[i * 3]} | {board[i * 3 + 1]} | {board[i * 3 + 2]} |");
                Console.WriteLine("-------------");
            }
        }

        static void PlayerMove()
        {
            int move;
            while (true)
            {
                Console.WriteLine($"Ход игрока {player}. Введите номер клетки:");
                if (int.TryParse(Console.ReadLine(), out move) && move >= 1 && move <= 9 && board[move - 1] != 'X' && board[move - 1] != 'O')
                {
                    board[move - 1] = player;
                    break;
                }
                Console.WriteLine("Некорректный ввод. Попробуйте снова.");
            }
        }

        static void ComputerMove()
        {
            Random random = new Random();
            int move;
            while (true)
            {
                move = random.Next(1, 10);
                if (board[move - 1] != 'X' && board[move - 1] != 'O')
                {
                    board[move - 1] = player;
                    Console.WriteLine($"Компьютер выбрал клетку {move}");
                    break;
                }
            }
        }

        static bool CheckWin()
        {
            int[,] winConditions =
            {
                { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, // Горизонтальные
                { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, // Вертикальные
                { 0, 4, 8 }, { 2, 4, 6 } // Диагональные
            };

            for (int i = 0; i < winConditions.GetLength(0); i++)
            {
                if (board[winConditions[i, 0]] == player && board[winConditions[i, 1]] == player && board[winConditions[i, 2]] == player)
                {
                    return true;
                }
            }
            return false;
        }

        static bool CheckDraw()
        {
            foreach (var cell in board)
            {
                if (cell != 'X' && cell != 'O') return false;
            }
            return true;
        }
    }
}