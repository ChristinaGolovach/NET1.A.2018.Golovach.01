﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Logic.Sorting;

namespace Logic.Tests
{
    [TestClass]
    public class SortingTests
    {
        #region Merge Sort Tests

        [TestMethod]
        public void MergeSort_TakeUnsortedArray_ReturnSortedArray()
        {
            // Arange
            int[] input = new int[] { 1, 47, 14, 1, 9 };
            int[] expectedResult = new int[] { 1, 1, 9, 14, 47 };

            // Act
            MergeSort(input);

            // Assert
            CollectionAssert.AreEqual(expectedResult, input);
        }

        [TestMethod]
        public void MergeSort_TakeUnsortedArrayWithNegativeValues_ReturnSortedArray()
        {
            // Arange
            int[] input = new int[] { 89, -354, 1, 354, 0 };
            int[] expectedResult = new int[] { -354, 0, 1, 89, 354 };

            // Act
            MergeSort(input);

            // Assert
            CollectionAssert.AreEqual(expectedResult, input);
        }

        [TestMethod]
        public void MergeSort_TakeSortedArray_ReturnTheSameArray()
        {
            // Arange
            int[] input = new int[] { 1, 3, 87, 90 };
            int[] expectedResult = new int[] { 1, 3, 87, 90 };

            // Act
            MergeSort(input);

            // Assert
            CollectionAssert.AreEqual(expectedResult, input);
        }

        [TestMethod]
        public void MergeSort_TakeRandomLargeUnsortedArray_ReturnSortedArray()
        {
            // Arange
            int[] input = GenerateLargeRandomArray(1000);
            int[] expectedResult = new int[input.Length];
            Array.Copy(input, expectedResult, input.Length);
            Array.Sort(expectedResult);

            // Act
            MergeSort(input);

            // Assert
            CollectionAssert.AreEqual(expectedResult, input);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MergeSort_TakeNullArray_ThrowArgumentNullException()
            => MergeSort<int>(null);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MergeSort_TakeEmptyArray_ThrowArgumentException()
            => MergeSort(new int[0]);

        #endregion Merge Sort Tests

        #region Quick Sort Tests

        [TestMethod]
        public void QuickSort_TakeUnsortedArray_ReturnSortedArray()
        {
            // Arange
            int[] input = new int[] { 1, 47, 14, 1, 9 };
            int[] expectedResult = new int[] { 1, 1, 9, 14, 47 };

            // Act
            QuickSort(input);

            // Assert
            CollectionAssert.AreEqual(expectedResult, input);
        }

        [TestMethod]
        public void QuickSort_TakeUnsortedArrayWithNegativeValues_ReturnSortedArray()
        {
            // Arange
            int[] input = new int[] { 89, -354, 1, 354, 0 };
            int[] expectedResult = new int[] { -354, 0, 1, 89, 354 };

            // Act
            QuickSort(input);

            // Assert
            CollectionAssert.AreEqual(expectedResult, input);
        }

        [TestMethod]
        public void QuickSort_TakeSortedArray_ReturnTheSameArray()
        {
            // Arange
            int[] input = new int[] { 1, 3, 87, 90 };
            int[] expectedResult = new int[] { 1, 3, 87, 90 };

            // Act
            QuickSort(input);

            // Assert
            CollectionAssert.AreEqual(expectedResult, input);
        }

        [TestMethod]
        public void QuickSort_TakeRandomLargeUnsortedArray_ReturnSortedArray()
        {
            // Arange
            int[] input = GenerateLargeRandomArray(1000);
            int[] expectedResult = new int[input.Length];
            Array.Copy(input, expectedResult, input.Length);
            Array.Sort(expectedResult);

            // Act
            QuickSort(input);

            // Assert
            CollectionAssert.AreEqual(expectedResult, input);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void QuickSort_TakeNullArray_ThrowArgumentNullException()
            => QuickSort<int>(null);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void QuickSort_TakeEmptyArray_ThrowArgumentException()
            => QuickSort(new int[0]);

        #endregion Quick Sort Tests

        private static int[] GenerateLargeRandomArray(int capacity)
        {
            int[] array = new int[capacity];
            Random random = new Random();
            for (int i = 0; i < capacity; i++)
            {
                array[i] = random.Next();
            }

            return array;
        }
    }
}