using CMS.DataAccess;
using CMS.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICarModelRepository carModel { get; }

        void Save();
    }
}
