using System.Text;

namespace TicTacToeCMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] xoArray =
            {
                {1,0,1}, // Game board: 1 represents 'X', 0 represents an empty cell
                {2,1,0},
                {1,0,1}
            };

            DisplayGameDials(xoArray);

        }

        static void DisplayGameDials(int[,] array)
        {
            StringBuilder screenBuffer = new StringBuilder();

            for (int i = 0; i<3; i++)
            {
                screenBuffer.AppendLine("     |     |     "); 
                screenBuffer.AppendLine($"  {DisplaySign(array[i, 0])}  |  {DisplaySign(array[i, 1])}  |  {DisplaySign(array[i, 2])}  ");
                screenBuffer.AppendLine("     |     |     ");
                if(i!=2) screenBuffer.AppendLine("-----|-----|-----");
            }

            Console.Write(screenBuffer.ToString());
        }

        // Returns the symbol corresponding to the numerical value on the board
        static char DisplaySign(int number)
        {
            return number switch
            {
                1 => 'X',
                2 => 'O',
                _ => ' ' // Default to an empty cell
            };
        }
    }
}