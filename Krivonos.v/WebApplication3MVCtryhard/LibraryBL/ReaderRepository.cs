using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryDAL;

namespace LibraryBL
{
    public class ReaderRepository
    {
        private DAL dal = new DAL();

        public BLBook GetBookBookOnHandsForReader(int rid)
        {
            BLBook book = new BLBook(dal.GetBookBookOnHandsForReader(rid));
            return book;
        }

        public bool RemoveReader(int rid)
        {
            return dal.RemoveReader(rid);
        }

        public bool AddReader(BLReader submittedReader)
        {
            object[] newReader = { submittedReader.Surname, submittedReader.Name, submittedReader.Patronymic };
            return dal.AddReader(newReader);

        }

        public bool HasBookOnHands(int rid)
        {
            return dal.HasBookOnHands(rid);
        }
    }
}
