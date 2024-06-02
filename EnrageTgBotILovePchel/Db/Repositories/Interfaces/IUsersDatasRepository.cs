using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnrageTgBotILovePchel.Db.Models;

namespace EnrageTgBotILovePchel.Db.Repositories.Interfaces
{
    public interface IUsersDatasRepository
    {
        List<UsersDatum> GetAllUserExcept(long chatId);
        UsersDatum GetUserDataById(int id);
        UsersDatum GetUserDataByTgUsername(string username);
        UsersDatum GetLastUserDataByChatId(long chatId);
        
        UsersDatum GetFirstUserDataByChatId(long chatId);
        void AddUser(string playerName, int playerRating, int playerPos, string playerTgNick, long chatId);
        void UpdateUserById(int id, string playerName, int playerRating, int playerPos);
        void UpdateUser(UsersDatum usersData);
        void DeleteUser(UsersDatum userData);
    }
}
