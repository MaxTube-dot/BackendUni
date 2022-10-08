﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DAL.Models
{
    public class GameRole
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Mark> Marks { get; set; }
    }
}
