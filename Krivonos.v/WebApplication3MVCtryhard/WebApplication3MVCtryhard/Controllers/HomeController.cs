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
        
        //
        // GET: /Home/
        //BookContext db = new BookContext();

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
        public ActionResult SubmitBook(BLBooksFromInfoAll model)
        {
            // make data validation
            bool succeded = HomeControllerManager.SubmitBook(model);
            return View(succeded);
        }

        public ActionResult AddAuthorForBook(BLBooksFromInfoAll model)
        {
            for (int i = 0; i < model.NumberOfAuthors; i++)
            {
                BLAuthor a = new BLAuthor();
                model.Authors.Add(a);
            }
            // make data validation
            // bool succeded = HomeControllerManager.SubmitBook(model);
            return View(model);
        }

        public ActionResult AddTestBook(BLBooksFromInfoAll model)
        {
            for (int i = 0; i < model.NumberOfAuthors; i++)
            {
                BLAuthor a = new BLAuthor();
                model.Authors.Add(a);
            }
                // make data validation
                // bool succeded = HomeControllerManager.SubmitBook(model);
                return View(model);
        }

        public ActionResult AddSingleAuthorForBook(UIBooksFromInfoAll book)
        {
            UIAuthor a = new UIAuthor();
            book.Authors.Add(a);
            // make data validation
            // bool succeded = HomeControllerManager.SubmitBook(model);
            return View(book);
        }    

        public ActionResult AddBook()
        {
            return View();
        }

        public ActionResult AddBook3()
        {
            return View();
        }

        public ActionResult RemoveBook()
        {
            return Index();
        }

        public ActionResult RemoveSingleBook(int bid)
        {
            bool succeded = HomeControllerManager.RemoveBook(bid);
            return View(succeded);
        }

        public ActionResult EditSingleBook()
        {
            //NpgsqlConnection dbconn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["HomeLibrary"].ConnectionString);
            //dbconn.Open();
            //NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM booksinlibrarycolumns", dbconn);
            //NpgsqlDataReader reader;
            //reader = com.ExecuteReader();
            DataTable dtAll = new DataTable();
            //dtAll.TableName = "Book";
            //while (reader.Read())
            //{
            //    dtAll.Columns.Add(reader.GetString(0));
            //}
            //reader.Close();

            ////            string first = reader.GetString(0);
            //com = new NpgsqlCommand("SELECT * FROM booksinlibrary WHERE b_id=" + Request.QueryString["bid"], dbconn);
            //reader = com.ExecuteReader();
            //while (reader.Read())
            //{
            //    object[] newrow = new object[reader.FieldCount];
            //    for (int i = 0; i < reader.FieldCount; i++)
            //        newrow[i] = reader.GetString(i);
            //    dtAll.Rows.Add(newrow);
            //}
            //reader.Close();
            ////GridView1.DataSource = dtAll;
            ////GridView1.DataBind();
            //reader.Close();
            //dbconn.Close();

            //DataSet ds = new DataSet();
            //ds.Tables.Add(dtAll);
            //return View(ds);
            return View();
        }

        public ActionResult SingleBook(string bid)
        {
            List<BLBooksFromInfoAll> BLBooks = HomeControllerManager.GetData();
            List<UIBooksFromInfoAll> UIBooks = new List<UIBooksFromInfoAll>();
            foreach (BLBooksFromInfoAll b in BLBooks)
            {
                UIBooks.Add(new UIBooksFromInfoAll(b));
            }
            return View(UIBooks);
        }

        [HttpPost]
        public FileStreamResult SaveChanges(string bid)
        {
            string str = bid;
            str += "10";
            return null;
        }

        protected override void Dispose(bool disposing)
        {
            //db.Dispose();

            base.Dispose(disposing);
        }

        public ActionResult Readers()
        {
            List<BLReader> BLreaders = HomeControllerManager.GetAllReaders();
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
            bool succeded = HomeControllerManager.RemoveReader(rid);
            return View(succeded);
        }

        public ActionResult AddReader()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddReaderPost(BLReader model)
        {
            bool succeded = HomeControllerManager.AddReader(model);
            return View(succeded);
        }

        public ActionResult GiveBook(int Id)
        {
            DataTable dtAll;
            if (HomeControllerManager.HasBookOnHands(Id))
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
            bool result = HomeControllerManager.GiveBookToReader(bid, rid);
            return View(result);
        }

        public ActionResult TakeBook(int Id)
        {
            BLBooksFromInfoAll BLBook = HomeControllerManager.GetBookBookOnHandsForReader(Id);
            UIBooksFromInfoAll UIBook = new UIBooksFromInfoAll(BLBook);
            
            DataTable dtAll = new DataTable();
            string[] columns = UIBook.GetColumns();
            foreach (string col in columns)
                dtAll.Columns.Add(col);

            dtAll.Rows.Add(UIBook.GetValues());

            // HomeControllerManager.TakeBook(Id);
            return View(dtAll);
        }

        private DataTable AllBooks()
        {
            List<BLBooksFromInfoAll> BLBooks = HomeControllerManager.GetData();
            List<UIBooksFromInfoAll> UIBooks = new List<UIBooksFromInfoAll>();
            foreach (BLBooksFromInfoAll b in BLBooks)
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
            List<BLBooksFromInfoAll> BLBooks = HomeControllerManager.GetDataForReaders();
            List<UIBooksFromInfoAll> UIBooks = new List<UIBooksFromInfoAll>();
            foreach (BLBooksFromInfoAll b in BLBooks)
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

        public ActionResult GiveOrTakeBook(int Id)
        {
            if (HomeControllerManager.HasBookOnHands(Id))
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
            bool succeded = HomeControllerManager.TakeBook(bid);
            return View(succeded);
        }
    }
}
