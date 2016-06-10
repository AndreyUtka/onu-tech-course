using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3MVCtryhard.Models;
using Npgsql;
using LibraryBL;

namespace WebApplication3MVCtryhard.Controllers
{
    public class HomeController : Controller
    {
        #region private fields and methods

        private BookRepository bookRepository = new BookRepository();
        private ReaderRepository readerRepository = new ReaderRepository();

        private DataTable AllBooks()
        {
            List<BLBook> BLBooks = bookRepository.GetAllBooks();
            List<UIBooksFromInfoAll> UIBooks = new List<UIBooksFromInfoAll>();
            foreach (BLBook b in BLBooks)
            {
                UIBooks.Add(new UIBooksFromInfoAll(b));
            }
            DataTable dtAll = new DataTable();
            string[] columns = UIBooks[0].GetColumns();
            foreach (string col in columns)
                dtAll.Columns.Add(col);
            foreach (UIBooksFromInfoAll b in UIBooks)
                dtAll.Rows.Add(b.GetValues());

            return dtAll;
        }

        private DataTable AllBooksForReaders()
        {
            List<BLBook> BLBooks = bookRepository.GetBooksForReaders();
            List<UIBooksFromInfoAll> UIBooks = new List<UIBooksFromInfoAll>();
            foreach (BLBook b in BLBooks)
            {
                UIBooks.Add(new UIBooksFromInfoAll(b));
            }
            DataTable dtAll = new DataTable();
            string[] columns = UIBooks[0].GetColumns();
            foreach (string col in columns)
                dtAll.Columns.Add(col);
            foreach (UIBooksFromInfoAll b in UIBooks)
                dtAll.Rows.Add(b.GetValues());

            return dtAll;
        }

        #endregion

        #region Book Actions

        public ActionResult Index()
        {
            DataTable dtAll = AllBooks();
            return View(dtAll);
        }

        public ActionResult AddRemoveBooks()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SubmitBook(BLBook model)
        {
            bool succeded = bookRepository.SubmitBook(model);
            return View(succeded);
        }

        public ActionResult AddAuthorForBook(BLBook model)
        {
            for (int i = 0; i < model.NumberOfAuthors; i++)
            {
                BLAuthor a = new BLAuthor();
                model.Authors.Add(a);
            }
            string[] janres = model.StringOfJanres.Split(' ');
            foreach (string s in janres)
            {
                model.Janres.Add(s);
            }
            // make data validation
            // bool succeded = HomeControllerManager.SubmitBook(model);
            return View(model);
        }

        public ActionResult AddBook()
        {
            return View();
        }

        public ActionResult RemoveBook()
        {
            return Index();
        }

        public ActionResult RemoveSingleBook(int bid)
        {
            int succeded = bookRepository.RemoveBook(bid);
            return View(succeded);
        }

        public ActionResult SingleBook(string bid)
        {
            List<BLBook> BLBooks = bookRepository.GetAllBooks();
            List<UIBooksFromInfoAll> UIBooks = new List<UIBooksFromInfoAll>();
            foreach (BLBook b in BLBooks)
            {
                UIBooks.Add(new UIBooksFromInfoAll(b));
            }
            return View(UIBooks);
        }

        public ActionResult GiveBook(int Id)
        {
            DataTable dtAll;
            if (readerRepository.HasBookOnHands(Id))
            {
                dtAll = new DataTable();
                dtAll.Columns.Add("Этому читателю уже была выдана книга!");

            }
            else 
            {
                dtAll = AllBooksForReaders();
                dtAll.Rows.Add(Id);
            }
            return View(dtAll);
        }

        public ActionResult GiveCertainBook(int bid, int rid)
        {
            bool result = bookRepository.GiveBookToReader(bid, rid);
            return View(result);
        }

        public ActionResult TakeBook(int Id)
        {
            BLBook BLBook = readerRepository.GetBookBookOnHandsForReader(Id);
            UIBooksFromInfoAll UIBook = new UIBooksFromInfoAll(BLBook);
            
            DataTable dtAll = new DataTable();
            string[] columns = UIBook.GetColumns();
            foreach (string col in columns)
                dtAll.Columns.Add(col);

            dtAll.Rows.Add(UIBook.GetValues());

            // HomeControllerManager.TakeBook(Id);
            return View(dtAll);
        }

        public ActionResult GiveOrTakeBook(int Id)
        {
            if (readerRepository.HasBookOnHands(Id))
            {
                //Response.Redirect("~/Home/TakeBook/"+Id);
                return RedirectToAction("TakeBook", new { Id = Id });
            }
            else
            {
                return RedirectToAction("GiveBook", new { Id = Id });
                //Response.Redirect("~/Home/GiveBook/" + Id);
            }
        }

        public ActionResult TakeCertainBook(int bid)
        {
            bool succeded = bookRepository.TakeBook(bid);
            return View(succeded);
        }

        [HttpPost]
        public ActionResult SearchForBookWithParams(BLBook model)
        {
            DataTable result = bookRepository.SearchForBookWithParams(model);
            return View(result);
        }

        public ActionResult SearchForBook(BLBook model)
        {
            return View();
        }

        public ActionResult EditBookWithId(string Id)
        {
            BLBook result = bookRepository.SearchForBookWithId(Id);
            return View(result);
        }

        [HttpPost]
        public ActionResult SaveBook(BLBook model)
        {
            return View(bookRepository.SaveBook(model));
        }

        #endregion

        #region Reader Actions

        public ActionResult Readers()
        {
            List<BLReader> BLreaders = bookRepository.GetAllReaders();
            List<UIReader> UIreaders = new List<UIReader>();
            foreach (BLReader r in BLreaders)
            {
                UIreaders.Add(new UIReader(r));
            }
            DataTable dtAll = new DataTable();
            string[] columns = UIreaders[0].GetColumns();
            foreach (string col in columns)
                dtAll.Columns.Add(col);
            foreach (UIReader r in UIreaders)
                dtAll.Rows.Add(r.GetValues());
            return View(dtAll);
        }

        public ActionResult AddRemoveReaders()
        {
            return Readers();
        }

        public ActionResult RemoveReader(int rid)
        {
            bool succeded = readerRepository.RemoveReader(rid);
            return View(succeded);
        }

        public ActionResult AddReader()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddReaderPost(BLReader model)
        {
            bool succeded = readerRepository.AddReader(model);
            return View(succeded);
        }

        #endregion

        protected override void Dispose(bool disposing)
        {
            //db.Dispose();

            base.Dispose(disposing);
        }
    }
}
