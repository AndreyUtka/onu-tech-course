using System;


namespace CourseApp
{
    public abstract class BaseRepository
    {
        protected string connectionString;

        protected BaseRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}
