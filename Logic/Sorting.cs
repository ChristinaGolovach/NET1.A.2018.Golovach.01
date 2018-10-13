using System;
using System.Linq;

namespace Logic
{
    /// <summary>
    /// Represents a class that performs sorting of an integer array using merge and quick algorithms
    /// </summary>
    public static class Sorting
    {
        /// <summary>
        /// Perform sorting of integer array by using merge algorithm
        /// </summary>
        /// <param name="array">
        /// The target array for sorting
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the target array is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the target array is empty
        /// </exception>
        public static void MergeSort(int[] array)
        {
            CheckInputArray(array);

            HiddenMergeSort(array);            
        }

        /// <summary>
        ///  Perform sorting of integer array by using quick algorithm
        /// </summary>
        /// <param name="array">
        /// The target array for sorting
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the target array is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the target array is empty
        /// </exception>
        public static void QuickSort(int[] array)
        {
            CheckInputArray(array);

            HiddenQuickSort(array, 0, array.Length - 1);
        }

        #region Merge Sort Logic

        private static int[] HiddenMergeSort(int[] array)
        {
            if (array.Length == 1)
            {
                return array;
            }

            int middle = array.Length / 2;

            int[] leftSubArray = HiddenMergeSort(array.Take(middle).ToArray());
            int[] rightAubArray = HiddenMergeSort(array.Skip(middle).ToArray());
            int[] result = Merge(leftSubArray, rightAubArray);

            Array.Copy(result, array, result.Length);

            return array;
        }

        private static int[] Merge(int[] leftSubArray, int[] rightSubArray)
        {
            int i = 0;
            int j = 0;
            int k = 0;
            int capacity = leftSubArray.Length + rightSubArray.Length;
            int[] arrayOut = new int[capacity];

            while (i < leftSubArray.Length && j < rightSubArray.Length)
            {
                if (leftSubArray[i] < rightSubArray[j])
                {
                    arrayOut[k++] = leftSubArray[i++];
                }
                else
                {
                    arrayOut[k++] = rightSubArray[j++];
                }
            }

            while (i < leftSubArray.Length)
            {
                arrayOut[k++] = leftSubArray[i++];
            }

            while (j < rightSubArray.Length)
            {
                arrayOut[k++] = rightSubArray[j++];
            }

            return arrayOut;
        }

        #endregion Merge Sort Logic

        #region Hidden Sort Logic
        private static void HiddenQuickSort(int[] array, int leftIndex, int rightIndex)
        {
            int i = leftIndex;
            int j = rightIndex;
            int middleIndex = (leftIndex + rightIndex) / 2;
            int middleItem = array[middleIndex];

            while (i < j)
            {
                while (array[i] < middleItem)
                {
                    i++;
                }

                while (array[j] > middleItem)
                {
                    j--;
                }

                if (i <= j)
                {
                    Swap(ref array[i], ref array[j]);
                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
            {
                HiddenQuickSort(array, leftIndex, j);
            }

            if (rightIndex > i)
            {
                HiddenQuickSort(array, i, rightIndex);
            }
        }

        #endregion Hidden Sort Logic

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        private static void CheckInputArray(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array is null.");
            }

            if (array.Length < 1)
            {
                throw new ArgumentException("Array is empty.");
            }
        }
    }
}
