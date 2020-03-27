using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Devskill.LibrarySystem.Web.Areas.Admin.Models;
using DevSkill.LibrarySystem.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace Devskill.LibrarySystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BooksController : Controller
    {
        public IActionResult Index()
        {
            var model = new BooksModel();
            return View(model);
        }

        public IActionResult GetBooks()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new BooksModel();
            var data = model.GetBooks(tableModel);
            return Json(data);
        }
    }
}