using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DAL.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        public User User { get; set; }

        public Product Product { get; set; }

        public DateTime AddDate { get; set; }

        public bool IsDone { get; set; }
    }
}
