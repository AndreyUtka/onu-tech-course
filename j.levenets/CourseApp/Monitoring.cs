using System;


namespace CourseApp
{
    public class Monitoring
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int TimeId { get; set; }

        //TODO: verify this data type
        public int[][] Value { get; set; }
        public int MNum { get; set; }

    }
}
