﻿using System;
using System.Collections.Generic;

namespace Logic
{
    public static class Search
    {
        public static int? BinarySearch<T>(T[] array, T soughtValue)
        {
            CheckInputData(array, soughtValue);

            CheckImplementationIComparable(soughtValue);

            var comparer = Comparer<T>.Default;

            return BinarySearch(array, soughtValue, comparer.Compare);
        }

        public static int? BinarySearch<T>(T[] array, T soughtValue, IComparer<T> comparer)
        {
            CheckInputData(array, soughtValue, comparer);

            return BinarySearch(array, soughtValue, comparer.Compare);
        }

        public static int? BinarySearch<T>(T[] array, T soughtValue, Comparison<T> comparison)
        {
            CheckInputData(array, soughtValue, comparison);

            int leftIndex = 0;
            int rightIndex = array.Length - 1;
            int midIndex = 0;

            while (leftIndex <= rightIndex)
            {
                midIndex = (leftIndex + rightIndex) >> 1;

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