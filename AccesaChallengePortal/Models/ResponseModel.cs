using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccesaChallengePortal.Models
{
    public class ResponseModel
    {
        public ResponseModel()
        {
        }

        public int Id { get; set; }
        public string UserDetails { get; set; }
        public string Question { get; set; }
        public string ResponseData { get; set; }
        public string FilePath { get; set; }
    }
}