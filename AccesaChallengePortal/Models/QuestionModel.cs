using AccesaChallengePortal.DatabaseLink;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccesaChallengePortal.Models
{
    public class QuestionModel
    {
        public QuestionModel()
        {
        }

        public QuestionModel(Question q)
        {
            this.Id = q.Id;
            this.Body = q.Body;
            this.ChallengeId = q.ChallengeId.GetValueOrDefault(0);
            this.RequiresFile = q.RequiresFile.GetValueOrDefault(false);
        }

        public int Id { get; set; }
        public string Body { get; set; }
        public bool RequiresFile { get; set; }
        public int ChallengeId { get; set; }
    }
}
