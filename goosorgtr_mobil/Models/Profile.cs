﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goosorgtr_mobil.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string? ProfileImage { get; set; }
        public string? Name { get; set; }
        public int? NoPhotos { get; set; }
        public string? Konum { get; set; }
        public string? Saat { get; set; }
        public string? Descreption { get; set; }

        public string userId { get; set; }
    }
}
