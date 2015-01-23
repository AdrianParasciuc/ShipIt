using AccesaChallengePortal.DatabaseLink;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace AccesaChallengePortal.Models
{
    public class QAModel
    {
        public QAModel()
        {
        }

        public QAModel(Question q)
        {
            this.QuestionId = q.Id;
            this.Question = q.Body;
            this.RequireFileUpload = q.RequiresFile.GetValueOrDefault(false);
        }

        public int QuestionId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        [DataType(DataType.Upload)]
        [DisplayName("Upload Solution")]
        public HttpPostedFileBase FileData { get; set; }
        public bool RequireFileUpload { get; set; }
    }
}