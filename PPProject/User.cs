namespace LauncherApp
{

    public class Player
    {
        public string Username { get; set; }
        public int Level { get; set; }


        public Player(string username, int level)
        {
            Username = username;
            Level = level;
        }

        public void LevelUp()
        {
            Level++;
        }

    }
    public class User : Player,IDisposable
    {
        private static User? user;

        public List<Game> games = new List<Game>();

        public List<Friend> friends { get; set; } = new List<Friend>();

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

        public void UpdateFriends(List<Friend> _friends)
        {
            friends = _friends;
        }
        public void UpdateUsername(string username)
        {
            Username = username;
        }
        public void AddGame(Game game)
        {
            games.Add(game);
        }

        public void Dispose()
        {
            user = null;
        }
    }

    public class Friend : Player
    {
        public bool IsOnline { get; set; }
        public bool IsPending { get; set; }
        public Friend(string username, int level, bool isOnline, bool isPending) : base(username, level)
        {
            IsOnline = isOnline;
            IsPending = isPending;
        }
    }
}
