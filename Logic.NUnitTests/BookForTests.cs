using System;

namespace Logic.NUnitTests
{
    public class BookForTests : IComparable<BookForTests>
    {
        private string name;

        public int Price { get; set; }        
        public string Name
        {
            get => name;
            set => name = value ?? throw new ArgumentNullException($"The {nameof(Name)} can not be null.");
        }

        public int CompareTo(BookForTests other)
        {
            if (ReferenceEquals(other, null))
            {
                throw new ArgumentNullException($"The {nameof(other)} can not be null.");
            }

            return this.Price.CompareTo(other.Price);
        }

        public static int CompareByName(BookForTests firstBook, BookForTests secondBook)
        {
            CheckBooks(firstBook, secondBook);

            return firstBook.Name.CompareTo(secondBook.Name);
        }

        private static void CheckBooks(BookForTests firstBook, BookForTests secondBook)
        {
            if (ReferenceEquals(firstBook, null))
            {
                throw new ArgumentNullException($"The {nameof(firstBook)} can not be null.");
            }

            if (ReferenceEquals(secondBook, null))
            {
                throw new ArgumentNullException($"The {nameof(secondBook)} can not be null.");
            }
        }
    }
}
