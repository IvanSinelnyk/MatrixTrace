
using System.Diagnostics;

namespace MatrixTrace
{
    public class Matrix
    {
        private readonly int[,] data;
        private readonly int rows;
        private readonly int cols;

        private static int TryParseInput(string? input)
        {
            if (int.TryParse(input, out int numValue) && numValue > 0)
            {
                return numValue;
            }
            else
            {
                Console.WriteLine($"The Matrix can not be created with this '{input}' dimension.");
                return 0;
            }
        }

        public Matrix(string? rows, string? cols)
        {
            this.rows = TryParseInput(rows);
            this.cols = TryParseInput(cols);
            this.data = MatrixGenerator();
        }

        public Matrix(int[,] data)
        {
            this.rows = data.GetLength(0);
            this.cols = data.GetLength(1);
            this.data = data;
        }

        private int[,] MatrixGenerator()
        {
            var rand = new Random();
            int[,] matrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = rand.Next(101);
                }
            }
            return matrix;
        }

        public void OutputMatrix()
        {
            if (rows != 0 && cols != 0)
            {
                Console.WriteLine("Your matrix:");
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        Console.Write("{0,4:N0}", data[i, j]);
                    }
                    Console.WriteLine();
                }
            }
        }

        public int GetMatrixTrace()
        {
            if (rows != 0 && cols != 0)
            {
                int mtrace = 0;
                for (int i = 0; i < Math.Min(rows, cols); i++)
                {
                    mtrace += data[i, i];
                }
                return mtrace;
            }
            return 0;
        }

        public int[] GetSnailData()
        {
            if (rows != 0 && cols != 0)
            {
                int rows_passed = 0, columns_passed = 0;
                int current_row = 0, current_column = 0;
                int steps = rows * cols;
                int stopper = 0;
                int[] output = new int[rows * cols];

                for (int k = 0; k < steps; k++)
                {
                    if (stopper == steps)
                        break;
                    int direction = k % 4;
                    if (direction == 0)
                    {
                        for (int j = columns_passed; j < cols - columns_passed; j++)
                        {
                            output[stopper] = data[current_row, j];
                            current_column = j;
                            stopper++;
                        }
                        rows_passed += 1;
                    }
                    else if (direction == 1)
                    {
                        for (int i = rows_passed; i <= rows - rows_passed; i++)
                        {
                            output[stopper] = data[i, current_column];
                            current_row = i;
                            stopper++;
                        }
                        columns_passed += 1;
                    }
                    else if (direction == 2)
                    {
                        for (int j = current_column - 1; j > columns_passed - 2; j--)
                        {
                            output[stopper] = data[current_row, j];
                            current_column = j;
                            stopper++;
                        }
                    }
                    else if (direction == 3)
                    {
                        for (int i = current_row - 1; i >= rows_passed; i--)
                        {
                            output[stopper] = data[i, current_column];
                            current_row = i;
                            stopper++;
                        }
                    }
                }
                return output;
            }
            return new int[] { };
        }
    }
}
