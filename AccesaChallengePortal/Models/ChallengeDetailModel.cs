using AccesaChallengePortal.DatabaseLink;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccesaChallengePortal.Models
{
    public class ChallengeDetailModel : ChallengeModel
    {
        public ChallengeDetailModel()
        {
            Questions = new List<QuestionModel>();
        }

        public ChallengeDetailModel(Challenge c)
            : base(c)
        {
            Questions = c.Questions.Select(x => new QuestionModel(x)).ToList();
        }

        public List<QuestionModel> Questions { get; set; }
    }
}