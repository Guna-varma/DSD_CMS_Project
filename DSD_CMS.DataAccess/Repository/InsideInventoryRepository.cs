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
    public class InsideInventoryRepository : Repository<InsideInventory>, IInsideInventoryRepository
    {
        public ApplicationDbContext _db;

        public InsideInventoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(InsideInventory insideInventoryDetails)
        {
            _db.insideInventoryList.Update(insideInventoryDetails);
        }
    }
}
