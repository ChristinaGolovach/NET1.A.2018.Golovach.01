using System;
using System.Linq;
using System.Collections.Generic;

namespace Logic
{
    /// <summary>
    /// Represents a class that performs sorting of an integer array using merge and quick algorithms
    /// </summary>
    public static class Sorting
    {
        /// <summary>
        /// Perform sorting of integer array by using merge algorithm.
        /// </summary>
        /// <param name="array">
        /// The target array for sorting.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the target array is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when:
        /// The target array is empty.
        /// The length of target array more than 10000.
        /// </exception>
        public static void MergeSort<T>(T[] array, Comparison<T> comparison)
        {
            CheckInputArray(array);

            HiddenMergeSort(array, comparison);             
        }

        /// <summary>
        ///  Perform sorting of integer array by using quick algorithm.
        /// </summary>
        /// <param name="array">
        /// The target array for sorting.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the target array is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when:
        /// The target array is empty.
        /// The  length of target array more than 10000.
        /// </exception>
        public static void QuickSort<T>(T[] array, Comparison<T> comparison)
        {
            CheckInputArray(array);

            HiddenQuickSort(array, 0, array.Length - 1, comparison);
        }

        #region Merge Sort Logic

        private static T[] HiddenMergeSort<T>(T[] array, Comparison<T> comparison)
        {
            if (array.Length == 1)
            {
                return array;
            }

            int middle = array.Length / 2;

            T[] lefPart = new T[middle];
            T[] rightPArt = new T[array.Length - middle];

            Array.Copy(array, 0, lefPart, 0, middle);
            Array.Copy(array, middle, rightPArt, 0, array.Length - middle);

            T[] leftSubArray = HiddenMergeSort(lefPart, comparison);
            T[] rightAubArray = HiddenMergeSort(rightPArt, comparison);
            T[] result = Merge(leftSubArray, rightAubArray, comparison);

            Array.Copy(result, array, result.Length);

            return array;
        }

        private static T[] Merge<T>(T[] leftSubArray, T[] rightSubArray, Comparison<T> comparison)
        {
            int i = 0;
            int j = 0;
            int k = 0;
            int capacity = leftSubArray.Length + rightSubArray.Length;
            T[] arrayOut = new T[capacity];

            while (i < leftSubArray.Length && j < rightSubArray.Length)
            {
                if (comparison(leftSubArray[i], rightSubArray[j]) < 0) //(leftSubArray[i] < rightSubArray[j])
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
       private static void HiddenQuickSort<T>(T[] array, int leftIndex, int rightIndex, Comparison<T> comparison)
       {
            int i = leftIndex;
            int j = rightIndex;
            int middleIndex = (leftIndex + rightIndex) / 2;     
            T middleItem = array[middleIndex];

            while (i < j)
            {
                while (comparison(array[i], middleItem) < 0) 
                {
                    i++;
                }

                while (comparison(array[j], middleItem) > 0)
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
                HiddenQuickSort(array, leftIndex, j, comparison);
            }

            if (rightIndex > i)
            {
                 HiddenQuickSort(array, i, rightIndex, comparison);
            }
        }

        #endregion Hidden Sort Logic

        private static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        private static void CheckInputArray<T>(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"The {nameof(array)} is null.");
            }

            if (array.Length < 1)
            {
                throw new ArgumentException($"The {nameof(array)} is empty.");
            }

            if (array.Length > 10000)
            {
                throw new ArgumentNullException($"The length of {nameof(array)} must be less than 10000.");
            }
        }
    }
}
