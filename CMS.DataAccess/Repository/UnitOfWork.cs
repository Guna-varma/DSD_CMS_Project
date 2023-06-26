using CMS.DataAccess.Data;
using CMS.DataAccess.Repository;
using CMS.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext _db;

        public ICarModelRepository carModelSet { get; set; }

        public ICarModelRepository carModel => throw new NotImplementedException();

        //public IEmployeesSetRepository employeesSet => throw new NotImplementedException();

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            carModelSet = new CarModelRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
