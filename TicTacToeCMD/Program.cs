using System;
using System.Text;

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

            while (true)
            {
                DisplayGameBoard(xoArray);

                if (i == 9)
                {
                    Console.WriteLine("End game!");
                    break;
                }

                int turn = i % 2 == 0 ? 1 : 2;
                Console.WriteLine("Now it's turn for {0}", DisplaySign(turn));

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                char userInput = keyInfo.KeyChar;

                int inputValue;
                if (int.TryParse(userInput.ToString(), out inputValue) && inputValue >= 1 && inputValue <= 9)
                {
                    int row = (inputValue - 1) / 3; //Get x, y position of array from 1-9 input
                    int col = (inputValue - 1) % 3;
                    if (xoArray[row, col] != 0) continue;

                    xoArray[row, col] = turn;
                }

                i++;
            }
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
