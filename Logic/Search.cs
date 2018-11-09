using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public static class Search
    {
        public static int? BinSearch<T>(T[] array, T soughtValue)
        {
            var comparer = Comparer<T>.Default;

            return BinSearch(array, soughtValue, comparer.Compare);
        }


        public static int? BinSearch<T>(T[] array, T soughtValue, IComparer<T> comparer)
        {
            return BinSearch(array, soughtValue, comparer.Compare);
        }

        public static int? BinSearch<T>(T[] array, T soughtValue, Comparison<T> comparison)
        {
            int leftIndex = 0;
            int rightIndex = array.Length - 1;
            int midIndex = 0;

            while (leftIndex < rightIndex)
            {
                midIndex = (leftIndex + rightIndex) >> 1;

                if (comparison(array[midIndex],soughtValue) == 0)
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

        private static void CheckImplementationIComparable<T>(T soughtValue)
        {
            if (!typeof(IComparable<T>).IsAssignableFrom(typeof(T)))
            {
                throw new ArgumentException($"The {typeof(T)} must implement the IComparable<{typeof(T)}> interface.");
            }

        }
    }
}
