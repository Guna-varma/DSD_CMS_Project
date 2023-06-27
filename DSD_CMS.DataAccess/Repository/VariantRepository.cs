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
    public class VariantRepository : Repository<Variant>, IVariantRepository
    {
        public ApplicationDbContext _db;

        public VariantRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Variant variantDetails)
        {
            _db.variantList.Update(variantDetails);
        }
    }
}
