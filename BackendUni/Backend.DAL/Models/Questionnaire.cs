using System.Text.Json.Serialization;

namespace Backend.DAL.Models
{
    /// <summary>
    /// Сущность опроса
    /// </summary>
    public class Questionnaire
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //public User Creator { get; set; }

        public DateTime Created { get; set; }

        [JsonIgnore]
        public List<User> TargetUsers { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int Price { get; set; }

        public List<AnswerVariant> AnswerVariants { get; set; }
    }
}
