using CMS.DataAccess;
using DSD_CMS.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSD_CMS.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IApplicationImagesRepository ApplicationImages { get; }
        ICarModelRepository CarModel { get; }
        IDealersRepository Dealers { get; }
        IDevicesRepository Devices { get; }
        IExtrasRepository Extras { get; }
        IFeedbackQuestionsRepository FeedbackQuestions { get; }
        IHealthCardRepository HealthCard { get; }
        IInteractiveCSRepository InteractiveCS { get; }
        IServiceProductRepository ServiceProduct { get; }
        ISettingsRepository Settings { get; }
        IShowroomsRepository Showrooms { get; }
        IUsersRepository Users { get; }
        IInsideInventoryRepository InsideInventory { get; }
        IVariantRepository Variant { get; }

        void Save();

    }
}
