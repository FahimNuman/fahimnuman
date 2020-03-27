using DevSkill.Library.Framework;
using System.Collections.Generic;

namespace DevSkill.Library.Framework
{
    public interface IBookService
    {
        (IList<Book> records, int total, int totalDisplay) GetBooks(int pageIndex,
                                                                    int pageSize,
                                                                    string searchText);
    }
}