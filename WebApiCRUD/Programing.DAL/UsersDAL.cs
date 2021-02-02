using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programing.DAL
{
    public class UsersDAL:BaseDAL
    {
        public Users GetUsersByApiKey(string apikey) 
        {
            return db.Users.FirstOrDefault(x => x.UserKey.ToString() == apikey);
        }

        public Users GetUserByName(string name)
        {
            return db.Users.FirstOrDefault(x => x.Name == name);
        }

    }
}
