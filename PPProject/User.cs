using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherApp
{
    public class User
    {
        public string Username { get; set; }
        public int Level { get; set; }

        public List<Game> games = new List<Game>();

        public User(string username, int level)
        {
            Username = username;
            Level = level;
        }

        public void LevelUp()
        {
            Level++;
        }


        public void UpdateUsername(string username)
        {
            Username = username;
        }

        public void UpdateLevel(int level)
        {
            Level = level;
        }
        
        public void AddGame(Game game)
        {
            games.Add(game);
        }
   
    }
}
