using System;
using System.Collections.Generic;

namespace Logic
{
    /// <summary>
    /// Represents a class that performs sorting of an array using merge and quick algorithms.
    /// </summary>
    public static class Sorting
    {
        /// <summary>
        /// Perform sorting of array by using merge algorithm according to <paramref name="comparison"/>. 
        /// </summary>
        /// <param name="array">
        /// The target array for sorting.
        /// </param>
        /// <param name="comparison">
        /// Delegate that performs the comparison of two value.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="array"/> or <paramref name="comparison"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when:
        /// The <paramref name="array"/> is empty.
        /// The length of <paramref name="array"/> more than 10000.
        /// </exception>
        public static void MergeSort<T>(T[] array, Comparison<T> comparison)
        {
            CheckInputData(array, comparison);

            HiddenMergeSort(array, comparison);             
        }

        /// <summary>
        /// Perform sorting of array by using merge algorithm according to <paramref name="comparer"/>.
        /// </summary>
        /// <typeparam name="T">
        /// Any type.
        /// </typeparam>
        /// <param name="array">
        /// The target array for sorting.
        /// </param>
        /// <param name="comparer">
        /// Type that implements IComparer interface.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="array"/> or <paramref name="comparer"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when: 
        /// The <paramref name="array"/> is empty.
        /// The length of <paramref name="array"/> more than 10000.
        /// </exception>
        public static void MergeSort<T>(T[] array, IComparer<T> comparer)
        {
            CheckInputData(array, comparer);

            HiddenMergeSort(array, comparer.Compare);
        }

        /// <summary>
        /// Perform sorting of array by using merge algorithm according to default comparer for <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">
        /// Any type that implements IComparable<typeparamref name="T"/>.
        /// </typeparam>
        /// <param name="array">
        /// The target array for sorting.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="array"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when:
        /// The type <typeparamref name="T"/> does not implements IComparable<T>.
        /// The target array is empty.
        /// The length of target array more than 10000.
        /// </exception>
        public static void MergeSort<T>(T[] array)
        {
            CheckInputArray(array);
            
            CheckImplementationIComparable(array);

            var comparer = Comparer<T>.Default;

            HiddenMergeSort(array, comparer.Compare);
        }

        /// <summary>
        /// Perform sorting of array by using quick algorithm according to <paramref name="comparison"/>. 
        /// </summary>
        /// <param name="array">
        /// The target array for sorting.
        /// </param>
        /// <param name="comparison">
        /// Delegate that performs the comparison of two value.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="array"/> or <paramref name="comparison"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when:
        /// The <paramref name="array"/> is empty.
        /// The length of <paramref name="array"/> more than 10000.
        /// </exception>
        public static void QuickSort<T>(T[] array, Comparison<T> comparison)
        {
            CheckInputData(array, comparison);

            HiddenQuickSort(array, 0, array.Length - 1, comparison);
        }

        /// <summary>
        /// Perform sorting of array by using quick algorithm according to <paramref name="comparer"/>.
        /// </summary>
        /// <typeparam name="T">
        /// Any type.
        /// </typeparam>
        /// <param name="array">
        /// The target array for sorting.
        /// </param>
        /// <param name="comparer">
        /// Type that implements IComparer<typeparamref name="T"/> interface.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="array"/> or <paramref name="comparer"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when: 
        /// The <paramref name="array"/> is empty.
        /// The length of <paramref name="array"/> more than 10000.
        /// </exception>
        public static void QuickSort<T>(T[] array, IComparer<T> comparer)
        {
            CheckInputData(array, comparer);

            HiddenQuickSort(array, 0, array.Length - 1, comparer.Compare);
        }

        /// <summary>
        /// Perform sorting of array by using quick algorithm according to default comparer for <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">
        /// Any type that implements IComparable<typeparamref name="T"/>.
        /// </typeparam>
        /// <param name="array">
        /// The target array for sorting.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="array"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when:
        /// The type <typeparamref name="T"/> does not implements IComparable<T>.
        /// The target array is empty.
        /// The length of target array more than 10000.
        /// </exception>
        public static void QuickSort<T>(T[] array)
        {
            CheckInputArray(array);

            CheckImplementationIComparable(array);

            var comparer = Comparer<T>.Default;

            HiddenQuickSort(array, 0, array.Length - 1, comparer.Compare);
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
                if (comparison(leftSubArray[i], rightSubArray[j]) < 0) 
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

        private static void CheckInputData<T>(T[] array, Comparison<T> comparison)
        {
            CheckInputArray(array);

            if (ReferenceEquals(comparison, null))
            {
                throw new ArgumentNullException($"The {nameof(comparison)} is null.");
            }
        }


        private static void CheckInputData<T>(T[] array, IComparer<T> comparison)
        {
            CheckInputArray(array);

            if (ReferenceEquals(comparison, null))
            {
                throw new ArgumentNullException($"The {nameof(comparison)} is null.");
            }
        }

        private static void CheckImplementationIComparable<T>(T[] array)
        {
            //TODO ask: why this type of check does not work correct
            //if ((typeof(T) as IComparable<T>) == null)
            //if(!(array.GetType() == typeof(IComparable<T>)))
            //if ((array.GetType() as IComparable<T>) == null)

            if (!typeof(IComparable<T>).IsAssignableFrom(typeof(T)))
            {
                throw new ArgumentException($"The {typeof(T)} must implement the IComparable<{typeof(T)}> interface.");
            }
        }
    }
}
