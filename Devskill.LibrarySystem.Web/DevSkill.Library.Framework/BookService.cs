using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DevSkill.Library.Framework
{
    public class BookService : IBookService
    {
        IList<Book> _dummyBookData;

        public BookService()
        {
            _dummyBookData = new List<Book>();

            for (var i = 0; i < 100; i++)
            {
                _dummyBookData.Add(new Book
                {
                    Id = i,
                    Author = "Author " + i,
                    Edition = "First Edition",
                    PublicationDate = DateTime.Now,
                    Title = "Title " + i
                });
            }
        }

        public (IList<Book> records, int total, int totalDisplay) GetBooks(int pageIndex,
            int pageSize, string searchText)
        {
            var filteredBooks = _dummyBookData.Where(x => x.Title.Contains(searchText)
                || x.Author.Contains(searchText));

            var filteredBooksCount = filteredBooks.Count();
            var totalBooks = _dummyBookData.Count();

            var filteredBooksList = filteredBooks.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return (filteredBooksList, totalBooks, filteredBooksCount);
        }
    }
}