using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SorterVisualizer.Tools
{
    public static class Utils
    {
        /// <summary>
        /// This method converts a array-of-arrays (jagged) to one-dimensional array
        /// </summary>
        /// <param name="inputArray">Array-of-arrays to convert</param>
        /// <param name="sizeOfOneDArray">Size of future one-dimensional array</param>
        /// <returns>One-dimensional array from converting the array-of-arrays</returns>
        public static int[] ConvertToOneDimensionalArray(int[][] inputArray, int sizeOfOneDArray)
        {
            int[] array = new int[sizeOfOneDArray];

            for (int i = 0, k = 0; i < inputArray.Length; i++)
            {
                for (int j = 0; j < inputArray[i].Length; j++, k++)
                {
                    array[k] = inputArray[i][j];
                }
            }

            return array;
        }
        /// <summary>
        /// This method converts two dimension array to one-dimensional array
        /// </summary>
        /// <param name="inputArray">Two dimension array to convert</param>
        /// <returns>One-dimensional array from converting the two dimension array</returns>
        public static int[] ConvertToOneDimensionalArray(int[,] inputArray)
        {
            int[] array = new int[inputArray.GetLength(0) * inputArray.GetLength(1)];

            for (int i = 0, k = 0; i < inputArray.GetLength(0); i++)
            {
                for (int j = 0; j < inputArray.GetLength(1); j++, k++)
                {
                    array[k] = inputArray[i, j];
                }
            }

            return array;
        }
        /// <summary>
        /// This method converts a string with numbers that are delimited with space to two dimensional arrays. 
        /// It might retrun null if the transformation was not successful 
        /// </summary>
        /// <param name="arrayContent">Numbers delimited with space</param>
        /// <param name="rows">Array rows</param>
        /// <param name="columns">Array columns</param>
        /// <returns>If the transformation was not successful method retruns null, otherwise - two dimensional array</returns>
        public static int[,] ConvertToTwoDimensionArray(string arrayContent, int rows, int columns)
        {
            int[,] array = new int[rows, columns];

            string[] substrings = arrayContent.Split(' ');

            for (int i = 0, k = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++, k++)
                {
                    int tmp;

                    if (!Int32.TryParse(substrings[k], out tmp))
                    {
                        return null;
                    }

                    array[i, j] = tmp;
                }
            }

            return array;
        }
        /// <summary>
        /// This method returns an array that is initialized with random numbers within the specified limits
        /// </summary>
        /// <param name="arraySize">Size of future array</param>
        /// <param name="minimumValue">Minimum value</param>
        /// <param name="maximumValue">Maximum value</param>
        /// <returns>Array initialized with random numbers.</returns>
        public static int[] GetRandomArray(int arraySize, int minimumValue, int maximumValue)
        {
            if (arraySize <= 0)
            {
                throw new ArgumentException("Array size cannot be zero or less.", "arraySize");
            }

            if (minimumValue >= maximumValue)
            {
                throw new ArgumentOutOfRangeException("minimumValue", minimumValue, "Minimum value cannot be bigger or equal  to maximum value");
            }

            Random rand = new Random(DateTime.Now.Millisecond);

            int[] array = new int[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                array[i] = rand.Next(minimumValue, maximumValue);
            }

            return array;
        }
        /// <summary>
        /// Convert index of one dimensional array into pair of indices of two dimensional array
        /// </summary>        
        /// <returns>Pair of indices</returns>
        public static Tuple<int, int> ConvertIndexOfOneDimensionalArray(int index, int widthOfTwoDimensionalArray)
        {
            int firstDimension = index / widthOfTwoDimensionalArray;
            int secondDimension = index % widthOfTwoDimensionalArray;

            return new Tuple<int, int>(firstDimension, secondDimension);
        }
        /// <summary>
        /// Convert indices of two dimensional array into index of one dimensional array
        /// </summary>      
        /// <returns>Index</returns>
        public static int ConvertIndexOfTwoDimensionalArray(int firstDimensionIndex, int secondDimensionIndex, int width)
        {
            return firstDimensionIndex + (secondDimensionIndex * width);
        }
        /// <summary>
        /// Get name of any provided member
        /// </summary>
        /// <returns>Provided member name</returns>
        public static string GetMemberName<T>(Expression<Func<T>> memberExpression)
        {
            MemberExpression expressionBody = (MemberExpression)memberExpression.Body;

            return expressionBody.Member.Name;
        }
    }

}
