using System.Text.Json.Serialization;

namespace Backend.DAL.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public string Login { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        public int Score { get; set; }

        public string ImageLink { get; set; }

        public Role Role { get; set; }

        public List<Task> Tasks { get; set; }

        public List<Task> CreatedTasks { get; set; }
    }
}
