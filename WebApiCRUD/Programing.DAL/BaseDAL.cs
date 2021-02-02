using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programing.DAL
{
    public class BaseDAL
    {
      protected ProgramingDbEntities db;
        public BaseDAL()
        {
            db = new ProgramingDbEntities();
        }
    }
}
