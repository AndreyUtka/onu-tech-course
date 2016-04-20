using System.Collections.Generic;
using System.Linq;

namespace CourseApp
{
    public class GamePlaceManager
    {
        public GamePlaceRepository GamePlaceRepository { get; private set; }
        public ServiceRepository ServiceRepository { get; private set; }
    }
}
