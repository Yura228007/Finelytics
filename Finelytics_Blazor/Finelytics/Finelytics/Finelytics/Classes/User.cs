namespace Finelytics.Classes
{
    public class User
    {
        public int Id { get; set; }
        /*public string Nickname { get; set; }*/
        public string Email { get; set; }
        public string Password { get; set; }
        public User() { }
        public User(/*string nickname, */string email, string password)
        {
            /*Nickname = nickname;*/
            Email = email;
            Password = password;
        }
    }
}
