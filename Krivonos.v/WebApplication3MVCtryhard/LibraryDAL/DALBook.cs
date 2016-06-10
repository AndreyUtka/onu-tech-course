using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL
{
    public class DALAuthor
    {
        private const int IdPos = 0;
        private const int SurnamePos = 1;
        private const int NamePos = 2;
        private const int PatronymicPos = 3;
        private const int YearPos = 4;

        public string Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Year { get; set; }

        public DALAuthor()
        {
            Id = null;
            Surname = null;
            Name = null;
            Patronymic = null;
            Year = null;
        }

        public DALAuthor(object[] input)
        {
            Id = (string)input[IdPos];
            Surname = (string)input[SurnamePos];
            Name = (string)input[NamePos];
            Patronymic = (string)input[PatronymicPos];
            Year = (string)input[YearPos];
        }
    }

    public class DALBook
    {
        private const int IdPos = 0;
        private const int NamePos = 1;
        private const int YearPos = 2;
        private const int IzdPos = 3;
        private const int NumofpagesPos = 4;
        private const int HowmanytimesPos = 5;
        private const int Number_s1Pos = 6;
        private const int NubmerOfFields = 7;

        public string Id { get; set; }
        public string Name { get; set; }
        public string Year { get; set; }
        public string Izd { get; set; }
        public string Numofpages { get; set; }
        public string Howmanytimes { get; set; }
        public string Number_s1 { get; set; }
        public List<DALAuthor> Authors { get; set; }
        public List<string> Janres { get; set; }
        
        public DALBook()
        {
            Id = null;
            Name = null;
            Year = null;
            Izd = null;
            Numofpages = null;
            Howmanytimes = null;
            Number_s1 = null;
            Authors = new List<DALAuthor>();
            Janres = new List<string>();
            //A_id = null;
            //Surname = null;
            //A_name = null;
            //aftername = null;
            //A_year = null;
        }
        
        public DALBook(object[] input)
        {
            if (input.Length != NubmerOfFields)
            {
                throw new IndexOutOfRangeException("In DAL Constructor that takes array object as parameter index is out of range");
            }
            else
            {
                Id = input[IdPos].ToString();
                Name = input[NamePos].ToString();
                Year = input[YearPos].ToString();
                Izd = input[IzdPos].ToString();
                Numofpages = input[NumofpagesPos].ToString();
                Howmanytimes = input[HowmanytimesPos].ToString();
                Number_s1 = input[Number_s1Pos].ToString();
                Authors = new List<DALAuthor>();
                Janres = new List<string>();
            }
        }

        public DALBook(object[] book, object[][] authors, object[] janres)
        {
            if (book.Length != NubmerOfFields)
            {
                throw new IndexOutOfRangeException("In DAL Constructor that takes two arrays of objects as parameters index is out of range");
            }
            else
            {
                Id = (string)book[IdPos];
                Name = (string)book[NamePos];
                Year = (string)book[YearPos];
                Izd = (string)book[IzdPos];
                Numofpages = (string)book[NumofpagesPos];
                Howmanytimes = (string)book[HowmanytimesPos];
                Number_s1 = (string)book[Number_s1Pos];
                Authors = new List<DALAuthor>();
                if (authors != null)
                {
                    foreach (object[] o in authors)
                    {
                        DALAuthor a = new DALAuthor(o);
                        Authors.Add(a);
                    }
                }
                Janres = new List<string>();
                if (janres != null)
                {
                    foreach (object o in janres)
                    {
                        Janres.Add((string)o);
                    }
                }
            }  
        }
        
        public string[] GetColumns()
        {
            string[] names = { "b_id", "b_name", "b_year",
                                 "izd", "numofpages",
                                 "howmanytimes", "number_s1",
                                 //"a_id", "surname", "a_name",
                                 //"aftername", "a_year" 
                             };
            return names;        
        }
    }
}
