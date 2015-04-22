using AccesaChallengePortal.DatabaseLink;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccesaChallengePortal.Models
{
    public class ResponseFeedbackModel : ResponseModel
    {

        public ResponseFeedbackModel()
        {
            Feedback = new FeedbackModel();
        }

        public ResponseFeedbackModel(Respons r, string userDetails, string questionText)
        {
            Id = r.Id;
            ResponseData = r.ResponseData;
            FilePath = r.FilePath;
            this.UserDetails = userDetails;
            this.Question = questionText;
            Feedback = new FeedbackModel { ResponseId = r.Id };
        }

        public FeedbackModel Feedback { get; set; }
    }
}