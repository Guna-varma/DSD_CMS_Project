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
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext _db;
        public IApplicationImagesRepository ApplicationImages {  get; set; }    
        public ICarModelRepository CarModel { get; set; }
        public IDealersRepository Dealers { get; set; }
        public IDevicesRepository Devices { get; set; }
        public IExtrasRepository Extras { get; set; }
        public IFeedbackQuestionsRepository FeedbackQuestions { get; set; } 
        public IHealthCardRepository HealthCard { get; set; }
        public IInsideInventoryRepository InsideInventory { get; set; }
        public IInteractiveCSRepository InteractiveCS { get; set; }
        public IServiceProductRepository ServiceProduct { get; set; }
        public ISettingsRepository Settings { get; set; }
        public IShowroomsRepository Showrooms { get; set; }
        public IUsersRepository Users { get; set; }
        public  IVariantRepository Variant { get; set; }

    public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;

            ApplicationImages = new ApplicationImagesRepository(_db);
            CarModel = new CarModelRepository(_db);
            Dealers = new DealersRepository(_db);
            Devices = new DevicesRepository(_db);
            Extras = new ExtrasRepository(_db);
            FeedbackQuestions = new FeedbackQuestionsRepository(_db);
            HealthCard = new HealthCardRepository(_db);
            InsideInventory = new InsideInventoryRepository(_db);
            InteractiveCS = new InteractiveCSRepository(_db);
            ServiceProduct = new ServiceProductRepository(_db);
            Settings = new SettingsRepository(_db); 
            Showrooms = new ShowroomsRepository(_db);
            Users = new UsersRepository(_db);
            Variant = new VariantRepository(_db);
            InsideInventory = new InsideInventoryRepository(_db);   
        }

        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
