using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Backend.DAL.Models
{
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
