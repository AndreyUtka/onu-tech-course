using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LibraryBL
{
    public class BLReader
    {
        public string Id { get; set; }
        [Required(ErrorMessage="Необходимо указать Имя")]
        [RegularExpression("[а-яА-ЯёЁ-]+", ErrorMessage="Используйте русские буквы")]
        [StringLength(100, ErrorMessage="Имена длинной более 100 символов не воспринимаются")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Необходимо указать Фамилию")]
        [RegularExpression("[а-яА-ЯёЁ-]+", ErrorMessage = "Используйте русские буквы")]
        [StringLength(100, ErrorMessage = "Фамилии длинной более 100 символов не воспринимаются")]
        public string Surname { get; set; }
        [StringLength(100, ErrorMessage = "Отчества длинной более 100 символов не воспринимаются")]
        [RegularExpression("[а-яА-ЯёЁ-]+", ErrorMessage = "Используйте русские буквы")]
        public string Patronymic { get; set; }

        public BLReader()
        {
            Id = null;
            Name = null;
            Surname = null;
            Patronymic = null;
        }

        public BLReader(LibraryDAL.DALReader input)
        {
            Id = input.Id;
            Name = input.Name;
            Surname = input.Surname;
            Patronymic = input.AfterName;
        }
    }
}
