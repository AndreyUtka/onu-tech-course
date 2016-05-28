using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using LibraryDAL;

namespace LibraryBL
{
    public class BLAuthor
    {
        public string Id { get; set; }
        public string Fullname { get; set; }
        public string Year { get; set; }

        public BLAuthor()
        {
            Id = null;
            Fullname = null;
            Year = null;
        }
        public BLAuthor(DALAuthor input)
        {
            Id = input.Id;
            Year = input.Year;
            Fullname = input.Surname + ' ' + input.Name + ' ' + input.Aftername;
        }
    }
    public class BLBook
    {
        public string Id { get; set; }

        [Required(ErrorMessage="NEED NAME")]
        public string Name { get; set; }

        [Required(ErrorMessage = "NEED Year")]
        public string Year { get; set; }

        [Required(ErrorMessage = "NEED Janre")]
        public string Janre { get; set; }

        [Required(ErrorMessage = "NEED Izd")]
        public string Izd { get; set; }

        [Required(ErrorMessage = "NEED Numofpages")]
        public string Numofpages { get; set; }

        [Required(ErrorMessage = "NEED Howmanytimes")]
        public string Howmanytimes { get; set; }

        [Required(ErrorMessage = "NEED Number_s1")]
        public string Number_s1 { get; set; }
        
        private int numberOfAuthors;

        [Required(ErrorMessage = "NEED NumberOfAuthors")]
        public int NumberOfAuthors
        {
            get
            {
                return numberOfAuthors;
            }
            set
            {
                numberOfAuthors = value;
            }
        }
        public List<BLAuthor> Authors { get; set; }
        //public string Surname { get; set; }
        //public string A_name { get; set; }
        //public string aftername { get; set; }
        
        public BLBook()
        {
            Id = null;
            Name = null;
            Year = null;
            Janre = null;
            Izd = null;
            Numofpages = null;
            Howmanytimes = null;
            Number_s1 = null;
            Authors = new List<BLAuthor>();
        }
        public BLBook(DALBook input)
        {
            Id = input.Id;
            Name = input.Name;
            Year = input.Year;
            Janre = input.Janre;
            Izd = input.Izd;
            Numofpages = input.Numofpages;
            Howmanytimes = input.Howmanytimes;
            Number_s1 = input.Number_s1;
            Authors = new List<BLAuthor>();
            foreach (DALAuthor dalAuthor in input.Authors)
            {
                Authors.Add(new BLAuthor(dalAuthor));
            }
            //    A_id = input.A_id;
            //    A_fullname = input.Surname + " " + input.A_name + " " + input.aftername;
            //    A_year = input.A_year;
        }
        public string[] GetColumns()
        {
            string[] names = { "b_id", "b_name", "b_year",
                                 "janre", "izd", "numofpages",
                                 "howmanytimes", "number_s1",
                             };
            return names;        
        }
    }
}
