using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnrageTgBotILovePchel.Db.Models;
using EnrageTgBotILovePchel.Db.Repositories.Interfaces;
using EnrageTgBotILovePchel.Db.DbConnector;
using Telegram.Bot.Types;

namespace EnrageTgBotILovePchel.Db.Repositories.Implemintations
{
    class UsersDatasRepository : IUsersDatasRepository
    {
        private EnrageBotVovodyaDbContext _dbContext;

        public UsersDatasRepository(EnrageBotVovodyaDbContext db)
        {
            _dbContext = db;
        }

        public List<UsersDatum> GetAllUserExcept(long chatId)
        {
            List<UsersDatum> usersDatasList = new List<UsersDatum>();
            IQueryable<UsersDatum> usersDatasFromDb = _dbContext.UsersData.Where(x => x.ChatId != chatId);

            foreach (var item in usersDatasFromDb)
            {
                usersDatasList.Add(item);
            }

            return usersDatasList;
        }

        public UsersDatum GetUserDataById(int id)
        {
            return _dbContext.UsersData.Where(x => x.Id == id).FirstOrDefault();
        }

        public UsersDatum GetUserDataByTgUsername(string username)
        {
            return _dbContext.UsersData.Where(x => x.PlayerTgNick == username).FirstOrDefault();
        }

        public UsersDatum GetLastUserDataByChatId(long chatId)
        {
            var user = _dbContext.UsersData.Where(x => x.ChatId == chatId).OrderBy(x => x.Id).LastOrDefault();
            if (user == null)
            {
                return null;
            }
            else
            {
                return user;
            }
        }

        public UsersDatum GetFirstUserDataByChatId(long chatId)
        {
            var user = _dbContext.UsersData.Where(x => x.ChatId == chatId).FirstOrDefault();
            if (user == null)
            {
                return null;
            }
            else
            {
                return user;
            }
        }

        public void AddUser(string playerName, int playerRating, int playerPos, string playerTgNick, long chatId)
        {
            _dbContext.UsersData.Add(new UsersDatum()
            {
                PlayerName = playerName,
                PlayerPosition = playerPos,
                PlayerRating = playerRating,
                PlayerTgNick = playerTgNick,
                ChatId = chatId
            });

            _dbContext.SaveChanges();
        }

        public void DeleteUser(UsersDatum userData)
        {
            UsersDatum userDatum = _dbContext.UsersData.Where(x => x.Id == userData.Id).FirstOrDefault();

            _dbContext.UsersData.Remove(userDatum);
            _dbContext.SaveChanges();
        }

        public void UpdateUserById(int id, string playerName, int playerRating, int playerPos)
        {
            UsersDatum usersDatum = _dbContext.UsersData.Where(x => x.Id == id).FirstOrDefault();
            usersDatum.PlayerName = playerName;
            usersDatum.PlayerRating = playerRating;
            usersDatum.PlayerPosition = playerPos;

            _dbContext.UsersData.Update(usersDatum);
            _dbContext.SaveChanges();
        }

        public void UpdateUser(UsersDatum inputUsersData)
        {
            UsersDatum usersDatumFromBd = _dbContext.UsersData.Where(x => x.Id == inputUsersData.Id).FirstOrDefault();
            usersDatumFromBd.PlayerPosition = inputUsersData.PlayerPosition;
            
            _dbContext.UsersData.Update(usersDatumFromBd);
            _dbContext.SaveChanges();
        }
    }
}