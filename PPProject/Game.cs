using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPProject
{
    public class Game
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public int GameID { get; set; }

        public Game(string name, int score)
        {
            Name = name;
            Score = score;
        }

        public void UpdateScore(int score)
        {
            Score = score;
        }
    }
}
