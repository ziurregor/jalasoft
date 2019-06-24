using Jalasoft.BackEnd.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jalasoft.BackEnd.Dao
{
    interface IChatUserRepository
    {
        void AddUser(chatUser user);
        IEnumerable<chatUser> GetUsers();
        bool DeleteUser(long id);
        chatUser GetUser(long id);
    }
}
