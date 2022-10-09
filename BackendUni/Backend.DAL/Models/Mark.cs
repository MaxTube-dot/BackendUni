using System.Text.Json.Serialization;

namespace Backend.DAL.Models
{
    /// <summary>
    /// Сущность метки прокачиваемого скилла.
    /// </summary>
    public class Mark
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageLink { get; set; }

        [JsonIgnore]
        public List<Task> Tasks { get; set; }

        [JsonIgnore]
        public List<GameRole> GameRoles { get; set; }
    }
}
