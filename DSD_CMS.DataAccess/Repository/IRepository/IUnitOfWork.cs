using CMS.DataAccess;
using DSD_CMS.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSD_CMS.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICarModelRepository CarModel { get; }

        void Save();
    }
}
