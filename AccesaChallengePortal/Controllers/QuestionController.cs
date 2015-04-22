using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Validation.Validators;
using System.Web.Mvc;
using System.Web.Routing;
using AccesaChallengePortal.DatabaseLink;
using AccesaChallengePortal.Models;
using AccesaChallengePortal.Repository;

namespace AccesaChallengePortal.Controllers
{
    public class QuestionController : Controller
    {
        private readonly ACPRepository<Question> _repo;

        public QuestionController()
        {
            _repo = new ACPRepository<Question>();
        }

        public ActionResult Create(int id)
        {
            var model = new QuestionModel {ChallengeId = id};
            return View("Create",model);
        }

        [HttpPost]
        public ActionResult Create(QuestionModel model)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(new Question{ Body = model.Body, ChallengeId = model.ChallengeId, RequiresFile = model.RequiresFile});
                return RedirectToAction("Detail", "Challenge",new {id = model.ChallengeId} );
            }
            return RedirectToAction("Create",model.ChallengeId);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var question = _repo.FindById(id);
            var model = new QuestionModel {Body = question.Body, ChallengeId = question.ChallengeId.GetValueOrDefault(),Id = question.Id,RequiresFile = question.RequiresFile.GetValueOrDefault(false)};
            return View("Edit", model);
        }

        [HttpPost]
        public ActionResult Edit(QuestionModel model)
        {
            if (ModelState.IsValid)
            {
                var question = _repo.FindById(model.Id);
                question.Body = model.Body;
                question.RequiresFile = model.RequiresFile;
                _repo.Update(question);
                return RedirectToAction("Detail", "Challenge", new { id = model.ChallengeId });
            }
            return View("Edit", model);
        }

        public ActionResult Delete(int id, int challengeId)
        {
            var question = _repo.FindById(id);
            if (question.Responses.Any())
            {
                var e = new ErrorModel { Message = "Cannot delete question with responses attached to it!"};
                return View("Error", e);
            }
            _repo.Delete(question);
            return RedirectToAction("Detail", "Challenge", new { id = challengeId });
        }
    }
}