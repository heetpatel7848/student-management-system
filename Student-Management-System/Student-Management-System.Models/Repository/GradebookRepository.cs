using Student_Management_System.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Models.Repository
{
    public class GradebookRepository : IGradebookRepository
    {
        #region Fields
        private readonly StudentSystemContext _context;
        #endregion


        #region Constructor
        public GradebookRepository(StudentSystemContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods
        public int AddGradebook(Gradebook gradebook)
        {
            _context.Add(gradebook);
            if (_context.SaveChanges() > 0)
                return gradebook.Id;
            else
                return 0;
        }

        public IEnumerable<Gradebook> GetGradebook()
        {
            return _context.Gradebooks.Where(a => a.IsActive == true).ToList();
        }

        public Gradebook GetGradebookById(int Id)
        {
            return _context.Gradebooks.FirstOrDefault(u => u.Id == Id && u.IsActive == true);
        }

        public bool UpdateGradebook(Gradebook gradebook)
        {
            _context.Entry(gradebook).Property("Marks").IsModified = true;
            _context.Entry(gradebook).Property("TotalMarks").IsModified = true;
            return _context.SaveChanges() > 0;
        }

        #endregion

    }
}
