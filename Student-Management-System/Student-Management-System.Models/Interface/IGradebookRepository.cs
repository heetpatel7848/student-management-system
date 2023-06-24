using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Models.Interface
{
    public interface IGradebookRepository
    {
        IEnumerable<Gradebook> GetGradebook();
        int AddGradebook(Gradebook gradebook);
        bool UpdateGradebook(Gradebook gradebook);
        Gradebook GetGradebookById(int Id);
    }
}
