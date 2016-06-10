using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL
{
    public class DALReader
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string AfterName { get; set; }

        public DALReader()
        {
            Id = null;
            Name = null;
            Surname = null;
            AfterName = null;
        }

        public DALReader(object[] input)
        {
            Id = input[0].ToString();
            Surname = input[1].ToString();
            Name = input[2].ToString();
            AfterName = input[3].ToString();
        }
    }
}
