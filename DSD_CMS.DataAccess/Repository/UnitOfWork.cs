using DSD_CMS.DataAccess.Data;
using DSD_CMS.DataAccess.Repository.IRepository;
using DSD_CMS.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSD_CMS.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext _db;

        public ICarModelRepository CarModel { get; set; }

    public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;

            CarModel = new CarModelRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
