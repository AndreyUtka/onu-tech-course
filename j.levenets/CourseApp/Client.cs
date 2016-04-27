using System;
using System.Collections.Generic;


namespace CourseApp
{
    public class Client
    {
        public int Id { get; set; }
        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
        public int GNum { get; set; }
        public List<Service> Services { get; set; }

    }
}
