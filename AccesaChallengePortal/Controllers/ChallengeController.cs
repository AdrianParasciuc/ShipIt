using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccesaChallengePortal.DatabaseLink;
using AccesaChallengePortal.Repository;

namespace AccesaChallengePortal.Controllers
{
    public class ChallengeController : Controller
    {
        private readonly ACPRepository<Challenge> _repo;

        public ChallengeController()
        {
            _repo = new ACPRepository<Challenge>();
        }
    }
}