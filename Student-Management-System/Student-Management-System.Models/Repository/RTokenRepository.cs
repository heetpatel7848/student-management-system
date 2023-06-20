using Student_Management_System.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Models.Repository
{
    public class RTokenRepository : IRTokenRepository 
    {
        #region Fields
        private readonly StudentSystemContext _context;
        #endregion

        #region Constructor
        public RTokenRepository(StudentSystemContext context)
        {
            _context = context;
        }


        #endregion

        #region Methods
        public bool AddRefreshToken(RToken token)
        {
            _context.RTokens.Add(token);
            return _context.SaveChanges() > 0;
        }

        public bool ExpireRefreshToken(RToken token)
        {
            _context.Entry(token).Property("IsStop").IsModified = true;
            return _context.SaveChanges() > 0;
        }

        public RToken GetRefreshToken(int id, string refreshToken)
        {
            return _context.RTokens.FirstOrDefault(x => x.UserId == id && x.RefreshToken == refreshToken);
        }
        #endregion

    }
}
