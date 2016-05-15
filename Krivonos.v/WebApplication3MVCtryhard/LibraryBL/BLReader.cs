using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBL
{
    public class BLReader
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string AfterName { get; set; }

        public BLReader()
        {
            Id = null;
            Name = null;
            Surname = null;
            AfterName = null;
        }

        public BLReader(LibraryDAL.DALReader input)
        {
            Id = input.Id;
            Name = input.Name;
            Surname = input.Surname;
            AfterName = input.AfterName;
        }
    }
}
