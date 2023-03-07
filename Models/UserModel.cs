namespace QB_University.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public int Role { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Quyen1 { get; set; }
        public string Quyen2 { get; set; }
        public string Quyen3 { get; set; }
        public List<UserModel> user { get; set; }
    }
}
