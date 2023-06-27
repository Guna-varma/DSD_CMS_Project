using DSD_CMS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSD_CMS.DataAccess.Repository.IRepository;

namespace DSD_CMS.DataAccess.Repository.IRepository
{
    public interface IUsersRepository : IRepository<Users>
    {
        void Update(Users usersDetails);
    }
}
