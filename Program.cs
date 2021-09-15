using System;

namespace CodingAssessment
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Initializing the Global variables
            Global.row1 = Global.row2 = Global.col1 = Global.col2 = 0;

            // Defining a variable
            int scalar = 1;

            // Getting the user input about which operation to perform
            Console.WriteLine("Which matrix operation do you want to perform:\n1. Addition\n2. Subtraction\n3. Product\n4. Scalar Multiplication\n5. Transpose\n6. Determinant\n");
            Console.Write("Enter the option:");
            int option = Convert.ToInt16(Console.ReadLine());

            switch(option)
            {
                // Addition
                case 1:
                    matrixDimension(ref Global.row1, ref Global.col1, 1);
                    Global.matrix1 = new double[Global.row1, Global.col1];
                    matrixDimension(ref Global.row2, ref Global.col2, 2);
                    Global.matrix2 = new double[Global.row2, Global.col2];
                    if (Global.row1 == Global.row2 && Global.col1 == Global.col2)
                    {
                        Console.WriteLine("Populate the Matrices (enter the elements row wise by pressing enter)\n");
                        Console.WriteLine("For Ex: 1<enter>2<enter>3<enter>4\nGives:\n1\t2\n3\t4\n");
                        Global.matrix1 = populateMatrix(Global.matrix1, Global.row1, Global.col1, 1);

                        Global.matrix2 = populateMatrix(Global.matrix2, Global.row2, Global.col2, 2);
                    }
                    else
                    {
                        Console.WriteLine("Both the matrix should be of same dimensions");
                        return;
                    }
                    break;

                // Subtraction
                case 2:
                    matrixDimension(ref Global.row1, ref Global.col1, 1);
                    Global.matrix1 = new double[Global.row1, Global.col1];
                    matrixDimension(ref Global.row2, ref Global.col2, 2);
                    Global.matrix2 = new double[Global.row2, Global.col2];
                    if (Global.row1 == Global.row2 && Global.col1 == Global.col2)
                    {
                        Console.WriteLine("Populate the Matrices (enter the elements row wise by pressing enter)\n");
                        Console.WriteLine("For Ex: 1<enter>2<enter>3<enter>4\nGives:\n1\t2\n3\t4\n");

                        Global.matrix1 = populateMatrix(Global.matrix1, Global.row1, Global.col1, 1);
                        Global.matrix2 = populateMatrix(Global.matrix2, Global.row2, Global.col2, 2);
                    }
                    else
                    {
                        Console.WriteLine("Both the matrix should be of same dimensions");
                        return;
                    }
                    break;

                // Product
                case 3:
                    matrixDimension(ref Global.row1, ref Global.col1, 1);
                    Global.matrix1 = new double[Global.row1, Global.col1];
                    matrixDimension(ref Global.row2, ref Global.col2, 2);
                    Global.matrix2 = new double[Global.row2, Global.col2];
                    if (Global.col1 == Global.row2)
                    {
                        Console.WriteLine("Populate the Matrices (enter the elements row wise by pressing enter)\n");
                        Console.WriteLine("For Ex: 1<enter>2<enter>3<enter>4\nGives:\n1\t2\n3\t4\n");

                        Global.matrix1 = populateMatrix(Global.matrix1, Global.row1, Global.col1, 1);
                        Global.matrix2 = populateMatrix(Global.matrix2, Global.row2, Global.col2, 2);
                    }
                    else
                    {
                        Console.WriteLine("You can only multiply two matrices if the number of columns in first matrix is equal to the number of rows in second matrix\n");
                        return;
                    }
                    break;

                // Scalar Multiplication
                case 4:
                    matrixDimension(ref Global.row1, ref Global.col1, 1);
                    Global.matrix1 = new double[Global.row1, Global.col1];
                    Console.WriteLine("Populate the Matrices (enter the elements row wise by pressing enter)\n");
                    Console.WriteLine("For Ex: 1<enter>2<enter>3<enter>4\nGives:\n1\t2\n3\t4\n");

                    Global.matrix1 = populateMatrix(Global.matrix1, Global.row1, Global.col1, 1);
                    Console.WriteLine("Enter the number you want to multipy the matrix with:");
                    scalar = Convert.ToInt16(Console.ReadLine());
                    break;

                // Transpose
                case 5:
                    matrixDimension(ref Global.row1, ref Global.col1, 1);
                    Global.matrix1 = new double[Global.row1, Global.col1];
                    Console.WriteLine("Populate the Matrices (enter the elements row wise by pressing enter)\n");
                    Console.WriteLine("For Ex: 1<enter>2<enter>3<enter>4\nGives:\n1\t2\n3\t4\n");

                    Global.matrix1 = populateMatrix(Global.matrix1, Global.row1, Global.col1, 1);
                    break;

                // Determinant
                case 6:
                    matrixDimension(ref Global.row1, ref Global.col1, 1);
                    Global.matrix1 = new double[Global.row1, Global.col1];
                    if (Global.row1 == Global.col1)
                    {
                        Console.WriteLine("Populate the Matrices (enter the elements row wise by pressing enter)\n");
                        Console.WriteLine("For Ex: 1<enter>2<enter>3<enter>4\nGives:\n1\t2\n3\t4\n");

                        Global.matrix1 = populateMatrix(Global.matrix1, Global.row1, Global.col1, 1);
                    }
                    else
                    {
                        Console.WriteLine("Determinant can only be found of square matrix\n");
                        return;
                    }

                    break;
            }

            // Initialize the Object
            MatrixOperations calc = new MatrixOperations();
          
            switch(option)
            {
                // Add
                case 1:
                    calc.add();
                    break;

                // Subtract
                case 2:
                    calc.sub();
                    break;

                // Multiply
                case 3:
                    calc.product();
                    break;

                // Multiply with scalar
                case 4:
                    calc.scalar(scalar);
                    break;

                // Transpose
                case 5:
                    calc.transpose();
                    break;

                // Determinant
                case 6:
                    double det = calc.determinant(Global.matrix1, Global.row1);
                    Console.WriteLine("Determinant of Matrix is: {0}", det);
                    break;
            }

            return;
        }

        /* Function to get the dimensions of the matrices*/
        public static void matrixDimension(ref int row, ref int col, int n)
        {
            Console.WriteLine("Enter the number of Rows for Matrix{0}", n);
            row = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Enter the number of Columns for Matrix{0}", n);
            col = Convert.ToInt16(Console.ReadLine());
        }

        /* Function to populate the matrix*/
        public static double[,] populateMatrix(double[,] matrix, int row, int col, int n)
        {
            Console.WriteLine("Enter the elements in Matrix {0}\n", n);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = Convert.ToDouble(Console.ReadLine());
                }
            }
            return matrix;
        }
    }
}
