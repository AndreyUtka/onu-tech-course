using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryDAL;

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
                            submittedbook.Janre, submittedbook.Izd, submittedbook.Numofpages,
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


            bool succeded = dal.SubmitBook(book, authors);
            return succeded;
        }

        public bool RemoveBook(int bid)
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

        
    }
}
