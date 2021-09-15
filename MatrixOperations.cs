using System;
namespace CodingAssessment
{
    public class MatrixOperations
    {
        double[,] m1;
        double[,] m2;

        //Default constructor
        public MatrixOperations()
        {
            m1 = Global.matrix1;
            m2 = Global.matrix2;
        }

        /* Function that performs addition of matrices*/
        public void add()
        {
            double[,] ans = new double[Global.row1, Global.col1];
            for(int i = 0; i < Global.row1; i++)
            {
                for(int j = 0; j < Global.col1; j++)
                {
                    ans[i, j] = m1[i, j] + m2[i, j];
                    //Console.WriteLine(ans[i, j] + "\t\t\n");
                }
            }
            Console.WriteLine("\nSum of Matrices:\n");
            for (int i = 0; i < Global.row1; i++)
            {
                for (int j = 0; j < Global.col1; j++)
                {
                    Console.Write(ans[i, j] + "\t");
                }

                Console.WriteLine();
            }
        }

        /* Function that performs subtraction of matrices*/
        public void sub()
        {
            double[,] ans = new double[Global.row1, Global.col1];
            for (int i = 0; i < Global.row1; i++)
            {
                for (int j = 0; j < Global.col1; j++)
                {
                    ans[i, j] = m1[i, j] - m2[i, j];
                    //Console.WriteLine(ans[i, j] + "\t\t\n");
                }
            }
            Console.WriteLine("\nDifference of Matrices:\n");
            for (int i = 0; i < Global.row1; i++)
            {
                for (int j = 0; j < Global.col1; j++)
                {
                    Console.Write(ans[i, j] + "\t");
                }

                Console.WriteLine();
            }
        }

        /* Function that performs matrix multiplication*/
        public void product()
        {
            double[,] ans = new double[Global.row1, Global.col2];

            for(int i = 0; i < Global.row1; i++)
            {
                for(int j = 0; j < Global.col2; j++)
                {
                    for(int k = 0; k < Global.col1; k++)
                    {
                        ans[i, j] += m1[i, k] * m2[k, j];
                    }
                }
            }

            Console.WriteLine("\nProduct of Matrices:\n");
            for (int i = 0; i < Global.row1; i++)
            {
                for(int j = 0; j < Global.col2; j++)
                {
                    Console.Write(ans[i, j] + "\t");
                }

                Console.WriteLine();
            }
        }

        /* Function that performs multiplication with a scalar*/
        public void scalar(int scalar)
        {
            Console.WriteLine("\nScalar Multiplication of Matrices:\n");
            for (int i = 0; i < Global.row1; i++)
            {
                for (int j = 0; j < Global.col1; j++)
                {
                    Console.Write(scalar*m1[i, j] + "\t");
                }

                Console.WriteLine();
            }
        }

        /* Function that finds transpose of a matrix*/
        public void transpose()
        {
            double[,] ans = new double[Global.col1, Global.row1];

            for(int i = 0; i < Global.row1; i++)
            {
                for(int j = 0; j < Global.col1; j++)
                {
                    ans[j, i] = m1[i, j];
                }
            }

            Console.WriteLine("\nTranspose Matrix\n");
            for(int i = 0; i < Global.col1; i++)
            {
                for(int j = 0; j < Global.row1; j++)
                {
                    Console.Write(ans[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        /* Function that finds determinant of a matrix*/
        public double determinant(double[,] matrix, int dimension)
        {
            double det = 0;
            double[,] smallMatrix = new double[dimension, dimension];
            int smallI, smallJ;

            if(dimension == 2)
            {
                det = ((matrix[0, 0] * matrix[1, 1]) - (matrix[1, 0] * matrix[0, 1]));
                return det;
            }
            for (int p = 0; p < dimension; p++)
            {
                smallI = 0;
                for(int i = 1; i < dimension; i++)
                {
                    smallJ = 0;
                    for(int j = 0; j < dimension; j++)
                    {
                        if (j == p)
                        {
                            continue;
                        }

                        smallMatrix[smallI, smallJ] = m1[i, j];
                        smallJ++;
                    }
                    smallI++;
                }

                det += Math.Pow(-1, p) * m1[0, p] * determinant(smallMatrix, dimension - 1);
            }
            return det;
        }
    }
}
