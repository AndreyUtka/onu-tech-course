using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL
{
    public class DALBooksFromInfoAll
    {
        public string B_id { get; set; }
        public string B_name { get; set; }
        public string B_year { get; set; }
        public string Janre { get; set; }
        public string Izd { get; set; }
        public string Numofpages { get; set; }
        public string Howmanytimes { get; set; }
        public string Number_s1 { get; set; }
        public string A_id { get; set; }
        public string Surname { get; set; }
        public string A_name { get; set; }
        public string aftername { get; set; }
        public string A_year { get; set; }
        
        public DALBooksFromInfoAll()
        {
            B_id = null;
            B_name = null;
            B_year = null;
            Janre = null;
            Izd = null;
            Numofpages = null;
            Howmanytimes = null;
            Number_s1 = null;
            A_id = null;
            Surname = null;
            A_name = null;
            aftername = null;
            A_year = null;
        }
        
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
        
        public string[] GetColumns()
        {
            string[] names = { "b_id", "b_name", "b_year",
                                 "janre", "izd", "numofpages",
                                 "howmanytimes", "number_s1",
                                 "a_id", "surname", "a_name",
                                 "aftername", "a_year" };
            return names;        
        }
    }
}
