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
    public class ExtrasRepository : Repository<Extras>, IExtrasRepository
    {
        public ApplicationDbContext _db;

        public ExtrasRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Extras extrasDetails)
        {
            _db.extrasList.Update(extrasDetails);
        }
    }
}
