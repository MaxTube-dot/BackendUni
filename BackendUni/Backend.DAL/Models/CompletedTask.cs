using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DAL.Models
{
    public class CompletedTask
    {
        public int Id { get; set; }

        public User User { get; set; }

        public Task Task { get; set; }

        public DateTime CompleteDate { get; set; }
    }
}
