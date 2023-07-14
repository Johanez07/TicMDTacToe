using System;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TicTacToeCMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] xoArray =
            {
                {0,0,0}, // Game board: 1 represents 'O', 2 represents 'X', 0 represents an empty cell
                {0,0,0},
                {0,0,0}
            };

            int i = 0;
            int turn = 1; //Player turn: 1 represents 'O', 2 represents 'X'

            while (true)
            {
                DisplayGameBoard(xoArray);

                int check = Checker(xoArray);

                if (check!=0)
                {
                    Console.WriteLine(DisplaySign(check) + " won the game!");
                    break;
                }
                else if (i == 9)
                {
                    Console.WriteLine("End game and no one has won!");
                    break;
                }
                else
                {
                    Console.WriteLine("Now it's turn for {0}", DisplaySign(turn));
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                char userInput = keyInfo.KeyChar;

                int inputValue;
                if (int.TryParse(userInput.ToString(), out inputValue) && inputValue >= 1 && inputValue <= 9)
                {

                    int row = (inputValue - 1) / 3; //Get x, y position of array from 1-9 input
                    int col = (inputValue - 1) % 3;
                    if (xoArray[row, col] != 0) continue;

                    xoArray[row, col] = turn;

                    i++;
                    turn = i % 2 == 0 ? 1 : 2;
                }

            }
        }

        static int Checker(int[,] array)
        {
            //Check horizontal and vertical results
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int sign = 1; sign <= 2; sign++)
                {
                    if (array[i, 0] == sign && array[i, 1] == sign && array[i, 2] == sign) return sign;
                    else if (array[0, i] == sign && array[1, i] == sign && array[2, i] == sign) return sign;
                }

            }

            //Check diagonals results
            for (int sign = 1; sign <= 2; sign++)
            {
                if (array[0, 0] == sign && array[1, 1] == sign && array[2, 2] == sign) return sign;
                else if (array[0, 2] == sign && array[1, 1] == sign && array[2, 0] == sign) return sign;
            }

            return 0;
        }

        static void DisplayGameBoard(int[,] array)
        {
            Console.Clear();

            StringBuilder screenBuffer = new StringBuilder();

            for (int i = 0; i < 3; i++)
            {
                screenBuffer.AppendLine("     |     |     ");
                screenBuffer.AppendLine($"  {DisplaySign(array[i, 0])}  |  {DisplaySign(array[i, 1])}  |  {DisplaySign(array[i, 2])}  ");
                screenBuffer.AppendLine("     |     |     ");
                if (i != 2) screenBuffer.AppendLine("-----|-----|-----");
            }

            Console.Write(screenBuffer.ToString());
        }

        // Returns the symbol corresponding to the numerical value on the board
        static char DisplaySign(int number)
        {
            char result = number switch
            {
                1 => 'X',
                2 => 'O',
                _ => ' '
            };

            return result;
        }
    }
}
