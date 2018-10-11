using System;
using System.Linq;

namespace Logic
{
    public static class Sorting
    {
        public static void MergeSort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array is null.");
            }

            if (array.Length < 1)
            {
                throw new ArgumentException("Array is empty.");
            }

            HiddenMergeSort(array);            
        }

        public static void QuickSort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array is null.");
            }

            if (array.Length < 1)
            {
                throw new ArgumentException("Array is empty.");
            }

            HiddenQuickSort(array, 0, array.Length - 1);
        }

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

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
