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
        }

        public int Id { get; set; }
        public string Body { get; set; }
    }
}
