﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Logic.Sorting;

namespace Logic.Tests
{
    [TestClass]
    public class SortingTests
    {
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

            // Act
            CollectionAssert.AreEqual(expectedResult, input);
         }

        // TODO to finish this test and make tests for quick sorting
        [TestMethod]
        public void MergeSort_TakeSortedArray_ReturnTheSameArray()
        {
            // Arange
            int[] input = new int[] { 1, 3, 87, 90 };
            int[] expectedResult = new int[] { 1, 3, 87, 90 };

            // Act
            MergeSort(input);

            // Act
            CollectionAssert.AreEqual(expectedResult, input);
        }
        
        [TestMethod]
        public void MergeSort_TakeRandomLargeUnsortedArray_ReturnSortedArray()
        {
            // Arange
            int[] input = new int[1000];
            Random random = new Random();
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = random.Next();
            }                    
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MergeSort_TakeNullArray_ThrowArgumentNullException()
            => MergeSort(null);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MergeSort_TakeEmptyArray_ThrowArgumentException()
            => MergeSort(new int[0]);
    }
}