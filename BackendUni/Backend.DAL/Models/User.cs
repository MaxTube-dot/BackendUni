using System.Text.Json.Serialization;

namespace Backend.DAL.Models
{
    /// <summary>
    /// Сущность пользователя
    /// </summary>
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

        [JsonIgnore]
        public List<Questionnaire> Questionnaires { get; set; }

        public List<Task> CreatedTasks { get; set; }

        [JsonIgnore]
        public string Token { get; set; }

        [JsonIgnore]
        public string PrivateKey { get; set; }

        [JsonIgnore]
        public string PublicKey { get; set; }
    }
}
