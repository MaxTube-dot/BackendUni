using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Backend.DAL.Models
{
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
