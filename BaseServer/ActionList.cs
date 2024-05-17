using LauncherApp;

namespace BaseServer
{
    internal static class ActionList
    {
        public static Dictionary<string, Func<Request, string?>> Actions = new()
        {
            { "Login", Database.LoginUser },
            { "Register", Database.RegisterUser },
            { "LoadFriends", Database.LoadFriends },
            { "AddFriend",Database.AddFriend },
            { "Logout", Database.Logout},
            { "UpdateClient",Database.UpdateClient},
            { "UpdateIcon" , Database.UpdateIcon}
        };
    }
}
