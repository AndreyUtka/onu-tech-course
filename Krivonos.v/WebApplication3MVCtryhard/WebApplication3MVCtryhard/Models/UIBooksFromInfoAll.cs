using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using LibraryBL;

namespace WebApplication3MVCtryhard.Models
{
    public class UIAuthor
    {
        public string Id { get; set; }
        public string Fullname { get; set; }
        public string Year { get; set; }

        public UIAuthor()
        {
            Id = null;
            Fullname = null;
            Year = null;
        }

        public UIAuthor (BLAuthor blAuthor)
        {
            Id = blAuthor.Id;
            Fullname = blAuthor.Fullname;
            Year = blAuthor.Year;
        }

        public string[] GetColumns()
        {
            string[] columns = { "ID", "Полное Имя", "Год Рождения" };
            return columns;
        }
    }
    public class UIBooksFromInfoAll
    {
        public string Id { get; set; }
        

        public string Name { get; set; }
        public string Year { get; set; }
        public string Janre { get; set; }
        public string Izd { get; set; }
        public string Numofpages { get; set; }
        public string Howmanytimes { get; set; }
        public string Number_s1 { get; set; }
        private int numberOfAuthors;
        public int NumberOfAuthors { 
            get
                {
                    return numberOfAuthors;
                }
            set 
                {
                    numberOfAuthors = value;
                }
        }
        public List<UIAuthor> Authors { get; set; }

        public UIBooksFromInfoAll()
        {
            Id = null;
            Name = null;
            Year = null;
            Janre = null;
            Izd = null;
            Numofpages = null;
            Howmanytimes = null;
            Number_s1 = null;
            Authors = new List<UIAuthor>();
        }
        public UIBooksFromInfoAll(BLBooksFromInfoAll input)
        {
            Id = input.Id;
            Name = input.Name;
            Year = input.Year;
            Janre = input.Janre;
            Izd = input.Izd;
            Numofpages = input.Numofpages;
            Howmanytimes = input.Howmanytimes;
            Number_s1 = input.Number_s1;
            Authors = new List<UIAuthor>();
            foreach (BLAuthor blAuthor in input.Authors)
            {
                Authors.Add(new UIAuthor(blAuthor));
            }
        }
        public string[] GetColumns()
        {
            string[] names = { "ID", "Название", "Год издания",
                                 "Жанр", "Издание", "Кол-во страниц",
                                 "Сколько раз брали", "Номер полки", "Кол-во авторов"
                                 };
            return names;        
        }
        public object[] GetValues()
        {
            object[] values = { Id, Name, Year, Janre, Izd, Numofpages, Howmanytimes, Number_s1, Authors.Count };
            return values;
        }
    }
}