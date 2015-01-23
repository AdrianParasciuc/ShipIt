using AccesaChallengePortal.DatabaseLink;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccesaChallengePortal.Models
{
    public class ChallengeAnswerModel : ChallengeModel
    {
        public ChallengeAnswerModel()
        {
            QuestionsAndAnswers = new List<QAModel>();
        }

        public ChallengeAnswerModel(Challenge c)
            : base(c)
        {
            QuestionsAndAnswers = new List<QAModel>();
            foreach (var q in c.Questions)
            {
                QuestionsAndAnswers.Add(new QAModel(q));
            }
        }

        public List<QAModel> QuestionsAndAnswers { get; set; }
    }
}