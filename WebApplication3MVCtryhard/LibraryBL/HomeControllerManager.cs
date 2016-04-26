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
            submittedbook.B_id = "";
            submittedbook.A_id = "";
            int space = submittedbook.A_fullname.IndexOf(' ');
            string fullname = submittedbook.A_fullname;
            string[] fullnamesplit = fullname.Split(' ');
            string a_surname = fullnamesplit[0];
            string a_name = fullnamesplit[1];
            string a_aftername = "";
            if (fullnamesplit.Length > 2)
                a_aftername = fullnamesplit[2];
            
            object[] arr = {
                            submittedbook.B_id, submittedbook.B_name, submittedbook.B_year,
                            submittedbook.Janre, submittedbook.Izd, submittedbook.Numofpages,
                            submittedbook.Howmanytimes, submittedbook.Number_s1, submittedbook.A_id,
                            a_surname, a_name, a_aftername, submittedbook.A_year
                           };
            bool succeded = InfoAll.SubmitBook(arr);
            return succeded;
        }
    }
}
