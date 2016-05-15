using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryDAL;

namespace LibraryBL
{
    public class HomeControllerManager
    {
        public static List<BLBooksFromInfoAll> GetData()
        {
            DALBooksFromInfoAll[] BooksFromInfoAll = LibraryDAL.InfoAll.GetInfo();
            List<BLBooksFromInfoAll> Books = new List<BLBooksFromInfoAll>();
            foreach (DALBooksFromInfoAll b in BooksFromInfoAll)
            {
                Books.Add(new BLBooksFromInfoAll(b));
            }
            return Books;
        }

        public static List<BLBooksFromInfoAll> GetDataForReaders()
        {
            List<DALBooksFromInfoAll> BooksFromInfoAll = LibraryDAL.InfoAll.GetInfoForReaders();
            List<BLBooksFromInfoAll> Books = new List<BLBooksFromInfoAll>();
            foreach (DALBooksFromInfoAll b in BooksFromInfoAll)
            {
                Books.Add(new BLBooksFromInfoAll(b));
            }
            return Books;
        }

        /*
          public DALBooksFromInfoAll(object[] input)
        {
            B_id = input[0].ToString();
            B_name = input[1].ToString();
            B_year = input[2].ToString();
            Janre = input[3].ToString();
            Izd = input[4].ToString();
            Numofpages = input[5].ToString();
            Howmanytimes = input[6].ToString();
            Number_s1 = input[7].ToString();
            A_id = input[8].ToString();
            Surname = input[9].ToString();
            A_name = input[10].ToString();
            aftername = input[11].ToString();
            A_year = input[12].ToString();
        }
         */
        public static bool SubmitBook(BLBooksFromInfoAll submittedbook)
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


            bool succeded = InfoAll.SubmitBook(book, authors);
            return succeded;
        }

        public static bool RemoveBook(int bid)
        {
            return InfoAll.RemoveBookWithId(bid);
        }

        public static List<BLReader> GetAllReaders()
        {
            List<BLReader> BLreaders = new List<BLReader>();
            List < DALReader > DALreaders = InfoAll.GetAllReaders(); 
            foreach (DALReader r in DALreaders)
            {
                BLreaders.Add(new BLReader(r));                
            }
            return BLreaders;
        }

        public static bool GiveBookToReader(int bid, int rid)
        {
            bool result = InfoAll.GiveBookToReader(bid, rid);
            return result;
        }

        public static bool HasBookOnHands(int rid)
        {
            return InfoAll.HasBookOnHands(rid);
        }

        public static bool TakeBook(int bid)
        {
            return InfoAll.TakeBookFromReader(bid);
        }

        public static BLBooksFromInfoAll GetBookBookOnHandsForReader(int rid)
        {
            BLBooksFromInfoAll book = new BLBooksFromInfoAll(InfoAll.GetBookBookOnHandsForReader(rid));
            return book;
        }

        public static bool RemoveReader(int rid)
        {
            return InfoAll.RemoveReader(rid);
        }

        public static bool AddReader(BLReader submittedReader)
        {
            object[] newReader = {submittedReader.Surname, submittedReader.Name, submittedReader.AfterName};
            return InfoAll.AddReader(newReader);
        }
    }
}
