using CMS.DataAccess.Repository;
using DSD_CMS.DataAccess.Data;
using DSD_CMS.DataAccess.Repository.IRepository;
using DSD_CMS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSD_CMS.DataAccess.Repository
{
    public class CarModelRepository : Repository<CarModel>, ICarModelRepository
    {
        public ApplicationDbContext _db;

        public CarModelRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(CarModel carModelDetails)
        {
            _db.carModelList.Update(carModelDetails);
        }
    }
}
