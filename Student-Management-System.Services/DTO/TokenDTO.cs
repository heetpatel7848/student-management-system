﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Services.DTO
{
    public class TokenDTO
    {
        public string? RefreshToken { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
