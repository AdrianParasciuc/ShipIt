using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccesaChallengePortal.DatabaseLink;
using AccesaChallengePortal.Repository;
using AccesaChallengePortal.Models;
using System.IO;

namespace AccesaChallengePortal.Controllers
{
    public class ChallengeController : Controller
    {
        private readonly ACPRepository<Challenge> _repo;

        public ChallengeController()
        {
            _repo = new ACPRepository<Challenge>();
        }

        public ActionResult Start()
        {
            if (SessionRepository.CurrentUser == null)
            {
                return new HttpUnauthorizedResult();
            }

            if (SessionRepository.CurrentUser.IsAdmin)
            {
                var challenges = _repo.GetAll().Select(x => new ChallengeModel(x));
                return View("Index", challenges);
            }
            else
            {
                var rand = new Random((int)DateTime.Now.Ticks);
                var index = rand.Next(1, _repo.Count() + 1);
                var challenge = _repo.Nth(index);
                if (challenge == null)
                    return new HttpNotFoundResult();
                var model = new ChallengeAnswerModel(challenge);
                return View("Answer", model);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new ChallengeModel();
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult Create(ChallengeModel model)
        {
            if (ModelState.IsValid)
            {
                var challenge = new Challenge();
                MapToChallenge(model, challenge);
                _repo.Add(challenge);
                return RedirectToAction("Start");
            }
            return View("Create", model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var challenge = _repo.FindById(id);
            var model = new ChallengeModel(challenge);
            return View("Edit", model);
        }

        [HttpPost]
        public ActionResult Edit(ChallengeModel model)
        {
            if (ModelState.IsValid)
            {
                var challenge = _repo.FindById(model.Id);
                MapToChallenge(model, challenge);
                _repo.Update(challenge);
                return RedirectToAction("Start");
            }
            return View("Edit", model);
        }

        public ActionResult Delete(int id)
        {
            var challenge = _repo.FindById(id);
            _repo.Delete(challenge);
            return RedirectToAction("Start");
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var challenge = _repo.FindById(id);
            var model = new ChallengeDetailModel(challenge);
            return View("Detail", model);
        }
        

        [HttpPost]
        public ActionResult Answer(ChallengeAnswerModel model)
        {
            if(ModelState.IsValid)
            {
                foreach (var qa in model.QuestionsAndAnswers)
                {
                    var response = new Respons();
                    MapToResponse(qa, response);

                    if (qa.RequireFileUpload && qa.FileData != null)
                    {
                        var folderExists = Directory.Exists(Server.MapPath("~/Challenge"));
                        if (!folderExists)
                            Directory.CreateDirectory(Server.MapPath("~/Challenge"));
                        var extension = Path.GetExtension(qa.FileData.FileName);
                        var fileName = string.Format("{0} - {1} {2}({3}){4}", 
                            model.Title, 
                            SessionRepository.CurrentUser.FirstName, 
                            SessionRepository.CurrentUser.LastName, 
                            SessionRepository.CurrentUser.Username, 
                            extension);
                        var targetPath = Path.Combine(Server.MapPath("~/Challenge"), fileName);
                        qa.FileData.SaveAs(targetPath);
                        response.FilePath = targetPath;
                    }

                    var responseRepo = new ACPRepository<Respons>();
                    responseRepo.Add(response);
                }
                return RedirectToAction("Index","Home");
            }
            return View("Answer", model);
        }

        private void MapToResponse(QAModel from, Respons to)
        {
            to.QuestionId = from.QuestionId;
            to.ResponseData = from.Answer;
            to.UserId = SessionRepository.CurrentUser.Id;
        }

        private void MapToChallenge(ChallengeModel from, Challenge to)
        {
            to.Title = from.Title;
        }
    }
}