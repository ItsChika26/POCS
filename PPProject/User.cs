using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherApp
{

    public class Player
    {
        public string Username { get; set; }
        public int Level { get; set; }

        public List<Game> games = new List<Game>();

        public Player(string username, int level)
        {
            Username = username;
            Level = level;
        }

        public void LevelUp()
        {
            Level++;
        }

        public void AddGame(Game game)
        {
            games.Add(game);
        }
    }
    public class User : Player
    {
        private static User? user;
        public static User Instance
        {
            get
            {
                return user ??= new User("Guest", 0);
            }
        }
        private User(string username,int level) : base(username, level)
        {
        }

        public void LoadUser(string username, int level)
        {
            user = new User(username, level);
        }
        public void UpdateUsername(string username)
        {
            Username = username;
        }

   
    }
}
