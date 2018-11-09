using System;
using System.Collections.Generic;
using NUnit.Framework;
using static Logic.Sorting;

namespace Logic.NUnitTests
{
    [TestFixture]
    public class SortingTests 
    {
        #region Merge Sort Test

        [TestCase(new int[] { 1, 3, 87, 90 })]
        [TestCase(new int[] { 1, 47, 14, 1, 9 })]
        [TestCase(new int[] { 89, -354, 1, 354, 0 })]         
        public void MergeSort_TakeUnsortedArray_ReturnSortedArray(int[] array)
        {
            // Arrange
            int[] expectedResult = new int[array.Length];
            Array.Copy(array, expectedResult, array.Length);
            Array.Sort(expectedResult);
            var comparison = Comparer<int>.Default; 

            // Act
            MergeSort(array, comparison.Compare);

            // Assert
            CollectionAssert.AreEqual(expectedResult, array);
        }
       
        [Test]
        public void MergeSort_TakeBookArray_ReturnSortedArrayByName()
        {
            BookForTests[] array = new BookForTests[] { new BookForTests() { Name = "Second", Price = 19 }, new BookForTests() { Name = "First", Price = 12 } };

            // Arrange
            BookForTests[] expectedResult = new BookForTests[array.Length];
            Array.Copy(array, expectedResult, array.Length);
            Array.Sort(expectedResult, BookForTests.CompareByName);

            // Act
            MergeSort(array, BookForTests.CompareByName);

            // Assert
            CollectionAssert.AreEqual(expectedResult, array);
        }

        [Test]
        public void MergeSort_TakeBookArray_ReturnSortedArrayByPrice()
        {
            BookForTests[] array = new BookForTests[] { new BookForTests() { Name = "Second", Price = 19 }, new BookForTests() { Name = "First", Price = 12 } };

            // Arrange
            BookForTests[] expectedResult = new BookForTests[array.Length];
            Array.Copy(array, expectedResult, array.Length);
            Array.Sort(expectedResult);

            // Act
            MergeSort(array);

            // Assert
            CollectionAssert.AreEqual(expectedResult, array);
        }

        [Test]
        public void MergeSort_TakeRandomLargeUnsortedArray_ReturnSortedArray()
        {
            // Arrange
            int[] input = GenerateLargeRandomArray(1000);
            int[] expectedResult = new int[input.Length];
            Array.Copy(input, expectedResult, input.Length);
            Array.Sort(expectedResult);
            var comparison = Comparer<int>.Default;

            // Act
            MergeSort(input, comparison.Compare);

            // Assert
            CollectionAssert.AreEqual(expectedResult, input);
        }

        [Test]
        public void MergeSort_WithNullArray_ThrowArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => MergeSort<int>(null));

        [Test]
        public void MergeSort_WithEmptyArray_ThrowArgumentException()
            => Assert.Throws<ArgumentException>(() => MergeSort<int>(new int[0]));

        #endregion Merge Sort Tests

        #region Quick Sort Tests

        [TestCase(new int[] { 1, 3, 87, 90 })]
        [TestCase(new int[] { 1, 47, 14, 1, 9 })]
        [TestCase(new int[] { 89, -354, 1, 354, 0 })]
        public void QuickSort_TakeUnsortedArray_ReturnSortedArray(int[] array)
        {
            // Arange
            int[] expectedResult = new int[array.Length];
            Array.Copy(array, expectedResult, array.Length);
            Array.Sort(expectedResult);
            var comparison = Comparer<int>.Default;

            // Act
            QuickSort(array, comparison.Compare);

            // Assert
            CollectionAssert.AreEqual(expectedResult, array);
        }

        [Test]
        public void QuickSort_TakeBookArray_ReturnSortedArrayByName()
        {
            BookForTests[] array = new BookForTests[] { new BookForTests() { Name = "Second", Price = 19 }, new BookForTests() { Name = "First", Price = 12 } };

            // Arrange
            BookForTests[] expectedResult = new BookForTests[array.Length];
            Array.Copy(array, expectedResult, array.Length);
            Array.Sort(expectedResult, BookForTests.CompareByName);

            // Act
            QuickSort(array, BookForTests.CompareByName);

            // Assert
            CollectionAssert.AreEqual(expectedResult, array);
        }

        [Test]
        public void QuickSort_TakeBookArray_ReturnSortedArrayByPrice()
        {
            BookForTests[] array = new BookForTests[] { new BookForTests() { Name = "Second", Price = 19 }, new BookForTests() { Name = "First", Price = 12 } };

            // Arrange
            BookForTests[] expectedResult = new BookForTests[array.Length];
            Array.Copy(array, expectedResult, array.Length);
            Array.Sort(expectedResult);

            // Act
            QuickSort(array);

            // Assert
            CollectionAssert.AreEqual(expectedResult, array);
        }

        [Test]
        public void QuickSort_TakeRandomLargeUnsortedArray_ReturnSortedArray()
        {
            // Arange
            int[] input = GenerateLargeRandomArray(1000);
            int[] expectedResult = new int[input.Length];
            Array.Copy(input, expectedResult, input.Length);
            Array.Sort(expectedResult);
             var comparison = Comparer<int>.Default;

            // Act
            QuickSort(input, comparison.Compare);

            // Assert
            CollectionAssert.AreEqual(expectedResult, input);
        }

        [Test]
        public void QuickSort_WithNullArray_ThrowArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => QuickSort<int>(null));

        [Test]
        public void QuickSort_WithEmptyArray_ThrowArgumentException()
            => Assert.Throws<ArgumentException>(() => QuickSort<int>(new int[0]));

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
