namespace LauncherApp
{
    public class Request : EventArgs
    {
        public string Action { get; set; }
        public string Username { get; set; }
        public string FriendUsername { get; set; }
        public string Password { get; set; }
        public int Level { get; set; }
        public bool Success { get; set; }
        public string SuccessMessage { get; set; }
        public byte[] Image { get; set; }
        public string FailureMessage { get; set; }
        public List<Friend> friends { get; set; }
        
    }
}
