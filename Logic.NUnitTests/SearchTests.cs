using System;
using System.Collections.Generic;
using NUnit.Framework;
using static Logic.Search;

namespace Logic.NUnitTests
{
    [TestFixture]
    public class SearchTests
    {
        [TestCase(new int[6] { -9, -7, 0, 4, 5, 78 }, -7, ExpectedResult = 1)]
        [TestCase(new int[] { 0, 4, 5, 78 }, 7, ExpectedResult = null)]
        public int? BinarySearch_PassSortedINTArrayAndSoughtValue_ReturnIndexOfValueOrNull(int [] array, int  soughtValue)
             => BinarySearch(array, soughtValue);


        [TestCase(new string[] { "AA", "AB", "BB", "DA" }, "DA", ExpectedResult = 3)]
        [TestCase(new string[] { "AA", "AB", "BB", "DA" }, "FF", ExpectedResult = null)]
        public int? BinarySearch_PassSortedSTRINGArrayAndSoughtValue_ReturnIndexOfValueOrNull(string[] array, string soughtValue)
             => BinarySearch(array, soughtValue);

        [Test]
        public void BinarySearch_PassSortedBookArrayAndSoughtValue_SearchByName_ReturnIndexOfValue()
        {
            // Arange
            BookForTests[] array = new BookForTests[] { new BookForTests() { Name = "First", Price = 12 },
                                                        new BookForTests() { Name = "Second", Price = 19 },
                                                        new BookForTests() { Name = "Third", Price = 22 } };

            BookForTests soughtValue = new BookForTests() { Name = "Third", Price = 99999 };
            int expectedIndex = 2;

            // Act
            int? actualIndex = BinarySearch(array, soughtValue, BookForTests.CompareByName);

            // Assert
            Assert.AreEqual(expectedIndex, actualIndex);
        }

        [Test]
        public void BinarySearch_PassSortedBookArrayAndSoughtValue_SearchByPrice_ReturnIndexOfValue()
        {
            // Arange
            BookForTests[] array = new BookForTests[] { new BookForTests() { Name = "First", Price = 12 },
                                                        new BookForTests() { Name = "Second", Price = 19 },
                                                        new BookForTests() { Name = "Third", Price = 22 } };

            BookForTests soughtValue = new BookForTests() { Name = "OTHER", Price = 12 };
            int expectedIndex = 0;

            // Act
            int? actualIndex = BinarySearch(array, soughtValue);

            // Assert
            Assert.AreEqual(expectedIndex, actualIndex);
        }

        [Test]
        public void BinarySearch_PassNullArray_ThrownException()
            =>Assert.Throws<ArgumentNullException>(() => BinarySearch(null, 3));

        [TestCase(new string[] { "AA", "AB", "BB", "DA" }, null)]
        public void BinarySearch_PassNullSoughtValue_ThrownException(string[] array, string soughtValue)
            => Assert.Throws<ArgumentNullException>(() => BinarySearch(array, soughtValue));

        [TestCase(new string[] { "AA", "AB", "BB", "DA" }, "DA")]
        public void BinarySearch_PassNullComparer_ThrownException(string[] array, string soughtValue)
            => Assert.Throws<ArgumentNullException>(() => BinarySearch(array, soughtValue, (Comparer<string>)null));

    }
}
