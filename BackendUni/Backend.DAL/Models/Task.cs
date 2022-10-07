using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DAL.Models
{
    public class Task
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public User Creator { get; set; }

        public DateTime Created { get; set; }

        public string ImageLink { get; set; }

        public List<User> TargetUsers { get; set; }

        public List<Mark> Marks { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int Price { get; set; }
    }
}
