using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPProject
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int UserID { get; set; }
        public int Level { get; set; }

        public List<Game> games = new List<Game>();

        public User(string username, string password)
        {
            Username = username;
            Password = password;
            Level = 0;
        }

        public void LevelUp()
        {
            Level++;
        }

        public void UpdatePassword(string password)
        {
            Password = password;
        }

        public void UpdateUsername(string username)
        {
            Username = username;
        }

        public void UpdateLevel(int level)
        {
            Level = level;
        }
        
        public void UpdateUserID(int userID)
        {
            UserID = userID;
        }
        public void AddGame(Game game)
        {
            games.Add(game);
        }
   
    }
}
