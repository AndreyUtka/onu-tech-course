using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL
{
    public class DALAuthor
    {
        public string Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Aftername { get; set; }
        public string Year { get; set; }
    }

    public class DALBook
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Year { get; set; }
        public string Janre { get; set; }
        public string Izd { get; set; }
        public string Numofpages { get; set; }
        public string Howmanytimes { get; set; }
        public string Number_s1 { get; set; }
        public List<DALAuthor> Authors { get; set; }
        
        public DALBook()
        {
            Id = null;
            Name = null;
            Year = null;
            Janre = null;
            Izd = null;
            Numofpages = null;
            Howmanytimes = null;
            Number_s1 = null;
            Authors = new List<DALAuthor>();
            //A_id = null;
            //Surname = null;
            //A_name = null;
            //aftername = null;
            //A_year = null;
        }
        
        public DALBook(object[] input)
        {
            Id = input[0].ToString();
            Name = input[1].ToString();
            Year = input[2].ToString();
            Janre = input[3].ToString();
            Izd = input[4].ToString();
            Numofpages = input[5].ToString();
            Howmanytimes = input[6].ToString();
            Number_s1 = input[7].ToString();
            Authors = new List<DALAuthor>();
            //A_id = input[8].ToString();
            //Surname = input[9].ToString();
            //A_name = input[10].ToString();
            //aftername = input[11].ToString();
            //A_year = input[12].ToString();
        }

        public DALBook(object[] book, object[][] authors)
        {
            Id = book[0].ToString();
            Name = book[1].ToString();
            Year = book[2].ToString();
            Janre = book[3].ToString();
            Izd = book[4].ToString();
            Numofpages = book[5].ToString();
            Howmanytimes = book[6].ToString();
            Number_s1 = book[7].ToString();
            Authors = new List<DALAuthor>();
            foreach (object[] o in authors)
            {
                DALAuthor a = new DALAuthor();
                a.Id = o[0].ToString();
                a.Surname = o[1].ToString();
                a.Name = o[2].ToString();
                a.Aftername = o[3].ToString();
                a.Year = o[4].ToString();
                Authors.Add(a);
            }
        }
        
        public string[] GetColumns()
        {
            string[] names = { "b_id", "b_name", "b_year",
                                 "janre", "izd", "numofpages",
                                 "howmanytimes", "number_s1",
                                 //"a_id", "surname", "a_name",
                                 //"aftername", "a_year" 
                             };
            return names;        
        }
    }
}
