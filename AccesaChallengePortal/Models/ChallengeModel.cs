using AccesaChallengePortal.DatabaseLink;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccesaChallengePortal.Models
{
    public class ChallengeModel
    {
        public ChallengeModel()
        {
        }

        public ChallengeModel(Challenge c)
        {
            this.Id = c.Id;
            this.Title = c.Title;
        }

        public int Id { get; set; }
        public string Title { get; set; }
    }
}