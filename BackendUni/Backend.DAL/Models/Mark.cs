﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DAL.Models
{
    public class Mark
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageLink { get; set; }

        public List<Task> Tasks { get; set; }
    }
}
