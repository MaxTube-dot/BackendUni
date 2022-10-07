namespace Backend.DAL.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public int Score { get; set; }

        public string ImageLink { get; set; }

        public Role Role { get; set; }

        public List<Task> Tasks { get; set; }

        public List<Task> CreatedTasks { get; set; }
    }
}
