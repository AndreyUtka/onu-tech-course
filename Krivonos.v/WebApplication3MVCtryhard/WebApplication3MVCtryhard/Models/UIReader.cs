using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3MVCtryhard.Models
{
    public class UIReader
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }

        public UIReader()
        {
            Id = null;
            Name = null;
            Surname = null;
            Patronymic = null;
        }

        public UIReader(LibraryBL.BLReader input)
        {
            Id = input.Id;
            Name = input.Name;
            Surname = input.Surname;
            Patronymic = input.Patronymic;
        }

        public string[] GetColumns()
        {
            return new string[]{"Id", "Имя", "Фамилия", "Отчество"};
        }

        public object[] GetValues()
        {
            return new object[] { Id, Name, Surname, Patronymic };
        }
    }
}