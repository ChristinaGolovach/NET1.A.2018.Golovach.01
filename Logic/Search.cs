using System;
using System.Collections.Generic;

namespace Logic
{
    /// <summary>
    /// Represents a class that performs search value in array.
    /// </summary>
    public static class Search
    {
        /// <summary>
        /// Method performs binary search in sorted array.
        /// </summary>
        /// <typeparam name="T">
        /// Any type that implements IComparable<T>.
        /// </typeparam>
        /// <param name="array">
        /// The sorted array.
        /// </param>
        /// <param name="soughtValue">
        /// The value to search.
        /// </param>
        /// <returns>
        /// The value's index of the first position found or null if this value does not exists in array.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="array"/> of <paramref name="soughtValue"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when:
        /// The type <typeparamref name="T"/> does not implements IComparable<T>.
        /// The <paramref name="array"/> is empty.
        /// </exception>
        public static int? BinarySearch<T>(T[] array, T soughtValue)
        {
            CheckInputData(array, soughtValue);

            CheckImplementationIComparable(soughtValue);

            var comparer = Comparer<T>.Default;

            return BinarySearch(array, soughtValue, comparer.Compare);
        }

        /// <summary>
        /// Method performs binary search in sorted array according to <paramref name="comparer"/>.
        /// </summary>
        /// <typeparam name="T">
        /// Any type.
        /// </typeparam>
        /// <param name="array">
        /// The sorted array.
        /// </param>
        /// <param name="soughtValue">
        /// The value to search.
        /// </param>
        /// <param name="comparer">
        /// Type that implements IComparer<typeparamref name="T"/> interface.
        /// </param>
        /// <returns>
        /// The value's index of the first position found or null if this value does not exists in array.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="array"/> of <paramref name="soughtValue"/> or <paramref name="comparer"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when:
        /// The type <typeparamref name="T"/> does not implements IComparable<T>.
        /// The <paramref name="array"/> is empty.
        /// </exception>
        public static int? BinarySearch<T>(T[] array, T soughtValue, IComparer<T> comparer)
        {
            CheckInputData(array, soughtValue, comparer);

            return BinarySearch(array, soughtValue, comparer.Compare);
        }

        /// <summary>
        /// Method performs binary search in sorted array according to <paramref name="comparison"/>.
        /// </summary>
        /// <typeparam name="T">
        /// Any type.
        /// </typeparam>
        /// <param name="array">
        /// The sorted array.
        /// </param>
        /// <param name="soughtValue">
        /// The value to search.
        /// </param>
        /// <param name="comparison">
        /// Delegate that performs the comparison of two value.
        /// </param>
        /// <returns>
        /// The value's index of the first position found or null if this value does not exists in array.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="array"/> of <paramref name="soughtValue"/> or <paramref name="comparison"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when:
        /// The type <typeparamref name="T"/> does not implements IComparable<T>.
        /// The <paramref name="array"/> is empty.
        /// </exception>
        public static int? BinarySearch<T>(T[] array, T soughtValue, Comparison<T> comparison)
        {
            CheckInputData(array, soughtValue, comparison);

            return BinarySearch(array, soughtValue, 0, array.Length - 1, comparison);
        }

        /// <summary>
        /// Method performs binary search in sorted array according to <paramref name="comparison"/> from start to end indexes.
        /// </summary>
        /// <typeparam name="T">
        /// Any type.
        /// </typeparam>
        /// <param name="array">
        /// The sorted array.
        /// </param>
        /// <param name="soughtValue">
        /// The value to search.
        /// </param>
        /// <param name="comparer">
        /// Type that implements IComparer<typeparamref name="T"/> interface.
        /// </param>
        /// <param name="startIndex">
        /// The start index for the search.
        /// </param>
        /// <param name="endIndex">
        /// The start index for the search.
        /// </param>
        /// <returns>
        /// The value's index of the first position found or null if this value does not exists in array.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="array"/> of <paramref name="soughtValue"/> or <paramref name="comparison"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when:
        /// The type <typeparamref name="T"/> does not implements IComparable<T>.
        /// The <paramref name="array"/> is empty.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the <paramref name="startIndex"/> is less than zero of <paramref name="endIndex"/> is more or equal length of array.
        /// </exception>
        public static int? BinarySearch<T>(T[] array, T soughtValue, int startIndex, int endIndex, IComparer<T> comparer)
        {
            CheckInputData(array, soughtValue, comparer);

            return BinarySearch(array, soughtValue, 0, array.Length - 1, comparer.Compare);
        }

        /// <summary>
        /// Method performs binary search in sorted array according to <paramref name="comparison"/> from start to end indexes.
        /// </summary>
        /// <typeparam name="T">
        /// Any type.
        /// </typeparam>
        /// <param name="array">
        /// The sorted array.
        /// </param>
        /// <param name="soughtValue">
        /// The value to search.
        /// </param>
        /// <param name="comparison">
        /// Delegate that performs the comparison of two value.
        /// </param>
        /// <param name="startIndex">
        /// The start index for the search.
        /// </param>
        /// <param name="endIndex">
        /// The start index for the search.
        /// </param>
        /// <returns>
        /// The value's index of the first position found or null if this value does not exists in array.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="array"/> of <paramref name="soughtValue"/> or <paramref name="comparison"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when:
        /// The type <typeparamref name="T"/> does not implements IComparable<T>.
        /// The <paramref name="array"/> is empty.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the <paramref name="startIndex"/> is less than zero of <paramref name="endIndex"/> is more or equal length of array.
        /// </exception>
        public static int? BinarySearch<T>(T[] array, T soughtValue, int startIndex, int endIndex, Comparison<T> comparison)
        {
            CheckInputData(array, soughtValue, startIndex, endIndex, comparison);

            int leftIndex = startIndex;
            int rightIndex = endIndex;
            int midIndex = 0;

            while (leftIndex <= rightIndex)
            {
                midIndex = leftIndex + ((rightIndex - leftIndex) >> 1);

                if (comparison(array[midIndex], soughtValue) == 0)
                {
                    return midIndex;
                }

                if (comparison(array[midIndex], soughtValue) < 0)
                {
                    leftIndex = midIndex + 1;
                }
                else
                {
                    rightIndex = midIndex - 1;
                }
            }

            return null;
        }

        private static void CheckInputData<T>(T[] array, T soughtValue, int startIndex, int endIndex, Comparison<T> comparison)
        {
            CheckInputData(array, soughtValue, comparison);

            if  (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException($"The {nameof(startIndex)} can not be less zero.");
            }

            if (endIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException($"The {nameof(endIndex)} can not be more or equal length of input array.");
            }
        }

        private static void CheckInputData<T>(T[] array, T soughtValue, IComparer<T> comparer)
        {
            CheckInputData(array, soughtValue);

            if (ReferenceEquals(comparer, null))
            {
                throw new ArgumentNullException($"The {nameof(comparer)} can not be null.");
            }
        }

        private static void CheckInputData<T>(T[] array, T soughtValue, Comparison<T> comparison)
        {
            CheckInputData(array, soughtValue);

            if (ReferenceEquals(comparison, null))
            {
                throw new ArgumentNullException($"The {nameof(array)} can not be null.");
            }
        }

        private static void CheckInputData<T>(T[] array, T soughtValue)
        {
            if (ReferenceEquals(array, null))
            {
                throw new ArgumentNullException($"The {nameof(array)} can not be null.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentNullException($"The {nameof(array)} can not be emptyl.");
            }

            if (ReferenceEquals(soughtValue, null))
            {
                throw new ArgumentNullException($"The {nameof(soughtValue)} can not be null.");
            }
        }

        private static void CheckImplementationIComparable<T>(T soughtValue)
        {
            if (!typeof(IComparable<T>).IsAssignableFrom(typeof(T)))
            {
                throw new ArgumentException($"The {typeof(T)} must implement the IComparable<{typeof(T)}> interface.");
            }
        }
    }
}
