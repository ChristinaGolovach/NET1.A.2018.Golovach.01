using System;
using System.Collections.Generic;
using NUnit.Framework;
using static Logic.Sorting;


namespace Logic.NUnitTests
{
    [TestFixture]
    public class SortingTests 
    {
        private class Book: IComparable<Book>
        {
            public int Price { get; set; }
            public string Name { get; set; }

            public int CompareTo(Book other)
            {
                return this.Price.CompareTo(other.Price);
            }
        }

        #region Merge Sort Test

        [TestCase(new int[] { 1, 3, 87, 90 })]
        [TestCase(new int[] { 1, 47, 14, 1, 9 })]
        [TestCase(new int[] { 89, -354, 1, 354, 0 })]         
        public void MergeSort_TakeUnsortedArray_ReturnSortedArray(int[] array)
        {
            // Arange
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
        public void MergeSort_TakeBookArray_ReturnSortedArray()
        {
            Book[] array = new Book[] { new Book() { Name = "Second", Price = 2 }, new Book() { Name = "First", Price = 1 } };

            // Arange
            Book[] expectedResult = new Book[array.Length];
            Array.Copy(array, expectedResult, array.Length);
            Array.Sort(expectedResult);
          //  var comparison = Comparer<Book>.Default;

            // Act
            MergeSort(array);//,comparison.Compare);

            // Assert
            CollectionAssert.AreEqual(expectedResult, array);
        }



        [Test]
        public void MergeSort_TakeRandomLargeUnsortedArray_ReturnSortedArray()
        {
            // Arange
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

        //[Test]
        //public void MergeSort_WithNullArray_ThrowArgumentNullException()
        //    => Assert.Throws<ArgumentNullException>(() => MergeSort(null));

        //[Test]
        //public void MergeSort_WithEmptyArray_ThrowArgumentException()
        //    => Assert.Throws<ArgumentException>(() => MergeSort(new int[0]));

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

        //[Test]
        //public void QuickSort_WithNullArray_ThrowArgumentNullException()
        //    => Assert.Throws<ArgumentNullException>(() => QuickSort(null));

        //[Test]
        //public void QuickSort_WithEmptyArray_ThrowArgumentException()
        //    => Assert.Throws<ArgumentException>(() => QuickSort(new int[0]));

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
