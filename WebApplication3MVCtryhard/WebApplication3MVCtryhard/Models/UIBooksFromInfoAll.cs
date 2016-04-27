using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryBL;

namespace WebApplication3MVCtryhard.Models
{
    public class UIBooksFromInfoAll
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
        public string A_fullname { get; set; }
        public string A_year { get; set; }
        public UIBooksFromInfoAll()
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
            A_fullname = null;
            A_year = null;
        }
        public UIBooksFromInfoAll(BLBooksFromInfoAll input)
        {
            B_id = input.B_id;
            B_name = input.B_name;
            B_year = input.B_year;
            Janre = input.Janre;
            Izd = input.Izd;
            Numofpages = input.Numofpages;
            Howmanytimes = input.Howmanytimes;
            Number_s1 = input.Number_s1;
            A_id = input.A_id;
            A_fullname = input.A_fullname;
            A_year = input.A_year;
        }
        public string[] GetColumns()
        {
            string[] names = { "b_id", "b_name", "b_year",
                                 "janre", "izd", "numofpages",
                                 "howmanytimes", "number_s1",
                                 "a_id", "fullname", "a_year" };
            return names;        
        }
        public object[] GetValues()
        {
            object[] values = { B_id, B_name, B_year, Janre, Izd, Numofpages, Howmanytimes, Number_s1, A_id, A_fullname, A_year };
            return values;
        }
    }
}