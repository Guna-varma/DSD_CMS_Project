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
    public class InteractiveCSRepository : Repository<InteractiveChecksheets>, IInteractiveCSRepository
    {
        public ApplicationDbContext _db;

        public InteractiveCSRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(InteractiveChecksheets interactiveChecksheetsDetails)
        {
            _db.interactiveCheckSheetsList.Update(interactiveChecksheetsDetails);
        }
    }
}