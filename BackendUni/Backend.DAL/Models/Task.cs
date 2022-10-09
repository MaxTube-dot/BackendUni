using System.Text.Json.Serialization;

namespace Backend.DAL.Models
{
    /// <summary>
    /// Сущность ивента.
    /// </summary>
    public class Task
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public User Creator { get; set; }

        public DateTime Created { get; set; }

        public string ImageLink { get; set; }

        [JsonIgnore]
        public List<User> TargetUsers { get; set; }

        public List<Mark> Marks { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int Price { get; set; }

        /// <summary>
        /// Является ли задача мероприятием
        /// </summary>
        [JsonIgnore]
        public bool IsAnnouncement { get; set; }
    }
}
