using MatrixTrace;
using System.Diagnostics;

Console.WriteLine("Enter count of matrix rows:");
string? cols = Console.ReadLine();
Console.WriteLine("Enter count of matrix columns:");
string? rows = Console.ReadLine();
Matrix matrix1 = new(cols, rows);
matrix1.OutputMatrix();
if (matrix1.GetMatrixTrace() != 0)
{
    Console.WriteLine("The trace of the matrix:\n{0,4:N0}", matrix1.GetMatrixTrace());
    Console.WriteLine("Elements from the matrix going like snail shells from border to center:");
    for (int i = 0; i < matrix1.GetSnailData().Length; i++)
    {
        Console.Write("{0}  ", matrix1.GetSnailData()[i]);
    }
}