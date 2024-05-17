namespace LauncherApp
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

        public void UpdateName(string name)
        {
            Name = name;
        }

        public void UpdateGameID(int gameID)
        {
            GameID = gameID;
        }
    }
}
