using Jalasoft.BackEnd.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jalasoft.BackEnd.Dao
{
    interface IChatUserRepository
    {
        void AddUser(ChatUser user);
        IEnumerable<ChatUser> GetUsers();
        bool DeleteUser(long id);
        ChatUser GetUser(long id);
    }
}
