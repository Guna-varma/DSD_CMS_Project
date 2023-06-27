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
    public class FeedbackQuestionsRepository : Repository<FeedbackQuestions>, IFeedbackQuestionsRepository
    {
        public ApplicationDbContext _db;

        public FeedbackQuestionsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(FeedbackQuestions feedbackQuestionsDetails)
        {
            _db.feedbackQuestionsList.Update(feedbackQuestionsDetails);
        }
    }
}
