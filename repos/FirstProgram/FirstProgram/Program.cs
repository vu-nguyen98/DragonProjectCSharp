using System;
using System.Text;

namespace FirstProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program prints a matrix based on the" +
                " number the user typed in by converting that number into" +
                " binary form");

            int selection;

            do
            {

                Console.WriteLine("Please insert a number between 0 and 511");
                Console.Write("Desired number: ");

                selection = int.Parse(Console.ReadLine());

                if (selection < 0 | selection > 511)
                {
                    Console.WriteLine("This is an invalid input!");
                    Console.WriteLine("Please try again\n");
                }

            } while (selection < 0 | selection > 511);

            StringBuilder binary = new StringBuilder();

            int originalNumber = selection;

            while (selection != 0)
            {
                binary.Append(selection % 2);
                selection /= 2;
            }

            StringBuilder correctbin = new StringBuilder();
            for (int i = binary.Length - 1; i >= 0; i--)
            {
                correctbin.Append(binary[i]);
            }

            binary = correctbin;

            while (binary.Length < 9)
            {
                binary.Insert(0, "0");
            }

            String displayBinary = binary.ToString();

            Console.WriteLine("The number {0} after being converted to binary is {1}", originalNumber, displayBinary);
            Console.WriteLine("Here is a matrix of {0} in binary", originalNumber);

            String[,] matrix = new String[3, 3];

            int binarypos = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (correctbin[binarypos++] == '0' )
                    {
                        matrix[i, j] = "0";

                        Console.Write(matrix[i, j] + " ");
                    }
                    else
                    {
                        matrix[i, j] = "1";

                        Console.Write(matrix[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
