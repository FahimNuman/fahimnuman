using DevSkill.Library.Framework;
using DevSkill.LibrarySystem.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Devskill.LibrarySystem.Web.Areas.Admin.Models
{
    public class BooksModel : AdminBaseModel
    {
        private readonly IBookService _bookService;
        public BooksModel()
        {
            _bookService = new BookService();
        }
        internal object GetBooks(DataTablesAjaxRequestModel tableModel)
        {
            
            var data = _bookService.GetBooks(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText);
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Id.ToString(),
                            record.Title,
                            record.Author,
                            record.Edition,
                            record.PublicationDate.ToString(),
                            record.Id.ToString()
                        }).ToArray()
            };
        }
    }
}
