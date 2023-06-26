using CMS.Model.Models;
using CMS.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DataAccess.Repository.IRepository
{
    public interface ICarModelRepository : IRepository<CarModel>
    {
        void Update(CarModel carModelDetails);
    }
}
