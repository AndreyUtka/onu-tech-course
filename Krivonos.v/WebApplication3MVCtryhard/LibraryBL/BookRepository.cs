using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryDAL;
using System.Data;

namespace LibraryBL
{
    public class BookRepository
    {
        private DAL dal = new DAL();

        public List<BLBook> GetAllBooks()
        {
            DALBook[] BooksFromInfoAll = dal.GetAllBooks();
            List<BLBook> Books = new List<BLBook>();
            foreach (DALBook b in BooksFromInfoAll)
            {
                Books.Add(new BLBook(b));
            }
            return Books;
        }

        public List<BLBook> GetBooksForReaders()
        {
            List<DALBook> BooksFromInfoAll = dal.GetBooksForReaders();
            List<BLBook> Books = new List<BLBook>();
            foreach (DALBook b in BooksFromInfoAll)
            {
                Books.Add(new BLBook(b));
            }
            return Books;
        }

        public bool SubmitBook(BLBook submittedbook)
        {
            submittedbook.Id = "";
            object[] book = {
                                submittedbook.Id, submittedbook.Name, submittedbook.Year,
                             submittedbook.Izd, submittedbook.Numofpages,
                            submittedbook.Howmanytimes, submittedbook.Number_s1
                            };
            object[][] authors = new object[submittedbook.Authors.Count][];

            for (int i = 0; i < submittedbook.Authors.Count; i++ )
            {
                string fullname = submittedbook.Authors[i].Fullname;
                string[] fullnamesplit = fullname.Split(' ');
                string surname = fullnamesplit[0];
                string name = fullnamesplit[1];
                string aftername = "";
                string year = submittedbook.Authors[i].Year;
                if (fullnamesplit.Length > 2)
                    aftername = fullnamesplit[2];
                object[] author = {
                                    "", surname, name, aftername, year
                                  };
                authors[i] = author;
            }

            object[] janres = new object[submittedbook.Janres.Count];

            for (int i = 0; i < submittedbook.Janres.Count; i++)
            {
                janres[i] = submittedbook.Janres[i];
            }


            bool succeded = dal.SubmitBook(book, authors, janres);
            return succeded;
        }

        public int RemoveBook(int bid)
        {
            return dal.RemoveBookWithId(bid);
        }

        public List<BLReader> GetAllReaders()
        {
            List<BLReader> BLreaders = new List<BLReader>();
            List<DALReader> DALreaders = dal.GetAllReaders(); 
            foreach (DALReader r in DALreaders)
            {
                BLreaders.Add(new BLReader(r));                
            }
            return BLreaders;
        }

        public bool GiveBookToReader(int bid, int rid)
        {
            bool result = dal.GiveBookToReader(bid, rid);
            return result;
        }

        public bool TakeBook(int bid)
        {
            return dal.TakeBookFromReader(bid);
        }

        public DataTable SearchForBookWithParams(BLBook searchforthis)
        {
            //searchforthis.ConvertNullPropertiesToEmptyStrings();
            object[] janres = searchforthis.StringOfJanres.Split(' ');

            object[] book = {
                                searchforthis.Id, searchforthis.Name,
                                searchforthis.Year,
                                searchforthis.Izd, searchforthis.Numofpages,
                                searchforthis.Howmanytimes, searchforthis.Number_s1
                            };
            
            List<DALBook> dalresults = dal.SearchForBookWithParams(book, janres);
            List<BLBook> blresults = new List<BLBook>();
            foreach (DALBook b in dalresults)
            {
                blresults.Add(new BLBook(b));
            }


            DataTable dtAll = new DataTable();
            string[] columns = blresults[0].GetColumns();
            foreach (string col in columns)
                dtAll.Columns.Add(col);
            foreach (BLBook b in blresults)
                dtAll.Rows.Add(b.GetValues());

            return dtAll;
            
        }

        public BLBook SearchForBookWithId(string id)
        {
            BLBook searchforthis = new BLBook();
            searchforthis.Id = id;
            object[] book = {
                                searchforthis.Id, searchforthis.Name,
                                searchforthis.Year,
                                searchforthis.Izd, searchforthis.Numofpages,
                                searchforthis.Howmanytimes, searchforthis.Number_s1
                            };
            List<DALBook> dalResults = dal.SearchForBookWithParams(book, null);
            BLBook foundbook = new BLBook(dalResults[0]);
            return foundbook;
        }

        public bool SaveBook(BLBook bookToUpdate)
        {
            object[] book = {
                                bookToUpdate.Id, bookToUpdate.Name,
                                bookToUpdate.Year,
                                bookToUpdate.Izd, bookToUpdate.Numofpages,
                                bookToUpdate.Howmanytimes, bookToUpdate.Number_s1
                            };
            object[] janres = new object[bookToUpdate.Janres.Count];

            for (int i = 0; i < bookToUpdate.Janres.Count; i++)
            {
                janres[i] = bookToUpdate.Janres[i];
            }

            object[][] authors = new object[bookToUpdate.Authors.Count][];

            for (int i = 0; i < bookToUpdate.Authors.Count; i++ )
            {
                string fullname = bookToUpdate.Authors[i].Fullname;
                string[] fullnamesplit = fullname.Split(' ');
                string surname = fullnamesplit[0];
                string name = fullnamesplit[1];
                string aftername = "";
                string year = bookToUpdate.Authors[i].Year;
                if (fullnamesplit.Length > 2)
                    aftername = fullnamesplit[2];
                object[] author = {
                                    bookToUpdate.Authors[i].Id, surname, name, aftername, year
                                  };
                authors[i] = author;
            }

            return dal.SaveBook(book, janres, authors);
        }
    }
}
