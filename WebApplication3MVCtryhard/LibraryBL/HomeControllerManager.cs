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
    }
}
