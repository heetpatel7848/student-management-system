using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Models.Interface
{
    public interface IRTokenRepository
    {
        RToken GetRefreshToken(int id, string refreshToken);
        bool AddRefreshToken(RToken token);
        bool ExpireRefreshToken(RToken token);
    }
}
