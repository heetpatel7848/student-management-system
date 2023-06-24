using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Services.DTO.GetDTO
{
    public class GetGradebookDTO
    {
        public string StudentName { get; set; }
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public int Marks { get; set; }
        public int TotalMarks { get; set; }
        //public double Percentage
        //{
        //    get
        //    {
        //        if (TotalMarks == 0)
        //            return 0;

        //        return (Marks / (double)TotalMarks) * 100;
        //    }
        //}
    }
}
