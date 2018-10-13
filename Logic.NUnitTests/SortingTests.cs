﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using static Logic.Sorting;

namespace Logic.NUnitTests
{
    [TestFixture]
    public class SortingTests 
    {
       // private static int[] randomArray = GenerateLargeRandomArray(1000);

        #region Merge Sort

        //TODO ask, why for this maner of test - [Test, TestCase(nameof(randomArray))] NUnit adapter gives error

        [TestCase(new int[] { 1, 3, 87, 90 })]
        [TestCase(new int[] { 1, 47, 14, 1, 9})]
        [TestCase(new int[] { 89, -354, 1, 354, 0 })]      
        public void MergeSort_TakeUnsortedArray_ReturnSortedArray(int[] array)
        {
            // Arange
            int[] expectedResult = array.Take(array.Length).ToArray();
            Array.Sort(expectedResult);

            // Act
            MergeSort(array);

            // Assert
            CollectionAssert.AreEqual(expectedResult, array);
        }
                
        [Test]
        public void MergeSort_TakeRandomLargeUnsortedArray_ReturnSortedArray()
        {
            // Arange
            int[] input = GenerateLargeRandomArray(1000);
            int[] expectedResult = input.Take(input.Length).ToArray();
            Array.Sort(expectedResult);

            // Act
            MergeSort(input);

            // Assert
            CollectionAssert.AreEqual(expectedResult, input);            
        }

        [Test]
        public void MergeSort_WithNullArray_ThrowArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => MergeSort(null));

        [Test]
        public void MergeSort_WithEmptyArray_ThrowArgumentException()
            => Assert.Throws<ArgumentException>(() => MergeSort(new int[0]));

        #endregion Merge Sort

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
