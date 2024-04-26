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
   
    }
}
