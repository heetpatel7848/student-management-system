﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Services.DTO.UpdateDTO
{
    public class UpdateAttendanceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Subject { get; set; }
        public bool IsPresent { get; set; }
    }
}
