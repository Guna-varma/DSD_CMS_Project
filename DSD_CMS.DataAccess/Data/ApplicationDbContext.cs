using DSD_CMS.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DSD_CMS.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ApplicationImages> applicationImagesList { get; set; }
        public DbSet<CarModel> carModelList { get; set; }

        public DbSet<Dealers> dealersList { get; set; }
        public DbSet<Devices> devicesList { get; set; }
        public DbSet<Extras> extrasList { get; set; }
        public DbSet<FeedbackQuestions> feedbackQuestionsList { get; set; }
        public DbSet<HealthCard> healthCardList { get; set; }
        public DbSet<InsideInventory> insideInventoryList { get; set; }
        public DbSet<InteractiveChecksheets> interactiveCheckSheetsList { get; set; }
        public DbSet<ServiceProduct> serviceProductList { get; set; }
        public DbSet<Settings> settingsList { get; set; }
        public DbSet<Showrooms> showroomsList { get; set; }
        public DbSet<Users> usersList { get; set; }
        public DbSet<Variant> variantList { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ApplicationImages>();
            modelBuilder.Entity<CarModel>();
            modelBuilder.Entity<Dealers>();
            modelBuilder.Entity<Devices>();
            modelBuilder.Entity<Extras>();
            modelBuilder.Entity<FeedbackQuestions>();
            modelBuilder.Entity<HealthCard>();
            modelBuilder.Entity<InsideInventory>();
            modelBuilder.Entity<InteractiveChecksheets>();
            modelBuilder.Entity<ServiceProduct>();
            modelBuilder.Entity<Settings>();
            modelBuilder.Entity<Showrooms>();
            modelBuilder.Entity<Users>();
            modelBuilder.Entity<Variant>();

        }
    }
}