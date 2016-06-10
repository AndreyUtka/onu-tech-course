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
        [Display(Name="ФИО")]
        [Required(ErrorMessage="Необходимо указать Полное Имя Автора")]
        [RegularExpression("[а-яА-ЯёЁ]+ [а-яА-ЯёЁ]+ ?[а-яА-ЯёЁ]*", ErrorMessage = "Имя и Фамилия автора разделяются пробелами первое слово - имя, второе - фамилия, третье - отчество")]
        [StringLength(150, ErrorMessage = "Полные Имена длинной более 150 символов не воспринимаются")]
        public string Fullname { get; set; }
        [Display(Name = "Год Рождения")]
        [Required(ErrorMessage="Необходимо указать год рождения Автора")]
        [Range(0,2016,ErrorMessage="Год рождения автора необходимо указать в промежутке от 0 до 2016")]
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
            Fullname = input.Surname + ' ' + input.Name + ' ' + input.Patronymic;
        }

        public string[] GetColumns()
        {
            string[] columns = { "ID", "Полное Имя", "Год Рождения" };
            return columns;
        }
    }

    public class BLBook
    {
        private const int curYear = 2016;
        public string Id { get; set; }

        [Required(ErrorMessage = "Необходимо указать Название")]
        [Display(Name="Название Книги")]
        [StringLength(200, ErrorMessage = "Названия книг длинной более 200 символов не воспринимаются")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Необходимо указать Год")]
        [Range(0, curYear, ErrorMessage = "Год должен быть в пределах от 0 до 2016")]
        [Display(Name = "Год Издания Книги")]
        public string Year { get; set; }

        [Required(ErrorMessage="Необходимо указать Издательство")]
        [Display(Name = "Издательство")]
        [RegularExpression("[а-яА-Я ёЁ]+", ErrorMessage="Используйте только русские буквы и пробел")]
        [StringLength(100, ErrorMessage = "Названия Издательств длинной более 100 символов не воспринимаются")]
        public string Izd { get; set; }

        [Required(ErrorMessage = "Необходимо указать Количество страниц")]
        [Display(Name = "Количество Страниц")]
        [Range(0,2000,ErrorMessage="Количество страниц должно быть числом в пределах от 0 до 2000")]
        public string Numofpages { get; set; }

        [Required(ErrorMessage = "Необходимо Указать Сколько раз брали книгу")]
        [Display(Name = "Сколько раз брали")]
        [Range(0,100, ErrorMessage="Необходимо указать число в пределах от 0 до 100")]
        public string Howmanytimes { get; set; }

        [Required(ErrorMessage = "Необходимо указать номер полки")]
        [Display(Name = "Номер Полки")]
        [Range(1,3, ErrorMessage="Доступные на данный момент номера полок 1,2,3")]
        public string Number_s1 { get; set; }
        
        private int numberOfAuthors;

        [Required(ErrorMessage = "Необходимо указать количество Авторов")]
        [Display(Name = "Количество Авторов")]
        [Range(0,10, ErrorMessage="Количество Авторов должно быть числом от 0 до 10")]
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

        private string stringofJanres;

        [Required(ErrorMessage="Необходимо указать как минимум 1 жанр")]
        [RegularExpression("[а-яА-Я ёЁ]+", ErrorMessage="Используйте русские буквы и пробел")]
        [StringLength(200, ErrorMessage = "Жанры длинной более 200 символов не воспринимаются")]
        public string StringOfJanres {
            get
            {
                stringofJanres = "";
                foreach (string j in Janres)
                    stringofJanres += j + ' ';
                return stringofJanres;
            }
            set
            {
                if (value != null)
                {
                    Janres = new List<string>();
                    string[] splittedJanres = value.Split(' ');
                    foreach (string j in splittedJanres)
                        if(!string.IsNullOrEmpty(j))
                            Janres.Add(j);
                }
                
            }
        }

        public List<BLAuthor> Authors { get; set; }

        public List<string> Janres { get; set; }
        
        public BLBook()
        {
            Id = null;
            Name = null;
            Year = null;
            Izd = null;
            StringOfJanres = null;
            Numofpages = null;
            Howmanytimes = null;
            Number_s1 = null;
            Authors = new List<BLAuthor>();
            Janres = new List<string>();
        }

        public BLBook(DALBook input)
        {
            Id = input.Id;
            Name = input.Name;
            Year = input.Year;
            Izd = input.Izd;
            Numofpages = input.Numofpages;
            Howmanytimes = input.Howmanytimes;
            Number_s1 = input.Number_s1;
            Authors = new List<BLAuthor>();
            foreach (DALAuthor dalAuthor in input.Authors)
            {
                Authors.Add(new BLAuthor(dalAuthor));
            }
            Janres = new List<string>();
            foreach (string s in input.Janres)
            {
                Janres.Add(s);
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
            object[] values = { Id, Name, Year, Janres[0], Izd, Numofpages, Howmanytimes, Number_s1, Authors.Count };
            return values;
        }

    }
}
