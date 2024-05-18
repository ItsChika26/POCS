﻿using LauncherApp.Properties;

namespace LauncherApp
{

    public class Player
    {
        public byte[] Image { get; set; }
        public string Username { get; set; }
        public int Level { get; set; }


        public Player(string username, int level, byte[]? image= null)
        {

            Username = username;
            Level = level;
            Image = image ?? Utils.DefaultImage;
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
        private User(string username,int level, byte[]? image = null) : base(username, level,image)
        {
        }

        public void LoadUser(string username, int level, byte[]? image = null)
        {
            user = new User(username, level, image);
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
        public Friend(string username, int level, bool isOnline, bool isPending, bool requestOwner, DateTime date,byte[]? image = null) : base(username, level,image)
        {
            IsOnline = isOnline;
            IsPending = isPending;
            IsRequestOwner = requestOwner;
            Date = date;
        }
    }
}
