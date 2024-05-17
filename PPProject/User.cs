using LauncherApp.Properties;

namespace LauncherApp
{

    public class Player
    {
        public Image? Image { get; set; }
        public string Username { get; set; }
        public int Level { get; set; }


        public Player(string username, int level, Bitmap? image= null)
        {

            Username = username;
            Level = level;
            Image = image ?? Resources.c0589be1b84c602dae8e97419541708d;
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

        public void LoadUser(string username, int level, Bitmap? image = null)
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
        public bool IsRequestOwner { get; set; }  

        public DateTime Date { get; set; }
        public Friend(string username, int level, bool isOnline, bool isPending, bool requestOwner, DateTime date,Bitmap? image = null) : base(username, level,image)
        {
            IsOnline = isOnline;
            IsPending = isPending;
            IsRequestOwner = requestOwner;
            Date = date;
        }
    }
}
