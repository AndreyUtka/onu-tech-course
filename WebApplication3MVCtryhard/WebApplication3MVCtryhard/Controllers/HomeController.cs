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
            //NpgsqlConnection dbconn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["HomeLibrary"].ConnectionString);
            //dbconn.Open();
            //NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM booksinlibrarycolumns", dbconn);
            //NpgsqlDataReader reader;
            //reader = com.ExecuteReader();
            //DataTable dtAll = new DataTable();
            //while (reader.Read())
            //{
            //    dtAll.Columns.Add(reader.GetString(0));
            //}
            //reader.Close();

            ////            string first = reader.GetString(0);
            //com = new NpgsqlCommand("SELECT * FROM booksinlibrary", dbconn);
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

            //return View(dtAll);
            List<BLBooksFromInfoAll> BLBooks =  HomeControllerManager.GetData();
            List<UIBooksFromInfoAll> UIBooks = new List<UIBooksFromInfoAll>();
            foreach (BLBooksFromInfoAll b in BLBooks)
            {
                UIBooks.Add(new UIBooksFromInfoAll(b));
            }
            DataTable dtAll = new DataTable();
            string[] columns = UIBooks[0].GetColumns();
            foreach(string col in columns)
                dtAll.Columns.Add(col);
            foreach(UIBooksFromInfoAll b in UIBooks)
                dtAll.Rows.Add(b.GetValues());
            return View(dtAll);
        }

        public ActionResult AddRemoveBooks()
        {
            return View();
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
    }
}
