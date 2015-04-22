using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccesaChallengePortal.DatabaseLink;
using AccesaChallengePortal.Models;
using AccesaChallengePortal.Repository;

namespace AccesaChallengePortal.Controllers
{
    public class ResponseController : Controller
    {
        private readonly ACPRepository<Respons> _responseRepo;
        private readonly ACPRepository<User> _userRepo;
        private readonly ACPRepository<Question> _questionRepo;


        public ResponseController()
        {
            _responseRepo = new ACPRepository<Respons>();
            _userRepo = new ACPRepository<User>();
            _questionRepo = new ACPRepository<Question>();
        }

        public ActionResult Start()
        {
            if (SessionRepository.CurrentUser == null)
            {
                return new HttpUnauthorizedResult();
            }

            var responses = _responseRepo.GetAll().Where(x => !x.Feedbacks.Any());
            var responseModels = new List<ResponseFeedbackModel>();

            foreach (var r in responses)
            {
                var userId = r.UserId;
                var questionId = r.QuestionId;
                var userDetails = _userRepo.Where(x => x.Id == userId)
                        .Select(m => m.FirstName + m.LastName + "(" + m.Username + ")")
                        .FirstOrDefault();
                var questionText = _questionRepo.Where(x => x.Id == questionId)
                    .Select(x => x.Body)
                    .FirstOrDefault();

                responseModels.Add(new ResponseFeedbackModel(r, userDetails, questionText));
            }

            return View("Index", responseModels);
        }

        public ActionResult Feedback(FeedbackModel model)
        {
            if (ModelState.IsValid)
            {
                var feedback = new Feedback
                {
                    Comment = model.Comment,
                    Grade = model.Grade,
                    ResponseId = model.ResponseId,
                    UserId = SessionRepository.CurrentUser.Id
                };
                var feedbackRepo = new ACPRepository<Feedback>();
                feedbackRepo.Add(feedback);
            }
            return RedirectToAction("Start");
        }

        public FileResult Download(string path)
        {
            var fs = System.IO.File.OpenRead(path);
            var data = new byte[fs.Length];
            fs.Read(data, 0, data.Length);
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, Path.GetFileName(path));
        }

        public ActionResult GetUserFeedback()
        {
            if (SessionRepository.CurrentUser == null)
            {
                return new HttpUnauthorizedResult();
            }

            var responses = _responseRepo.GetAll().Where(x => x.UserId == SessionRepository.CurrentUser.Id && !x.Feedbacks.Any());
            var responseModels = new List<ResponseFeedbackModel>();

            foreach (var r in responses)
            {
                var userId = r.UserId;
                var questionId = r.QuestionId;
                var userDetails = _userRepo.Where(x => x.Id == userId)
                        .Select(m => m.FirstName + m.LastName + "(" + m.Username + ")")
                        .FirstOrDefault();
                var questionText = _questionRepo.Where(x => x.Id == questionId)
                    .Select(x => x.Body)
                    .FirstOrDefault();
                responseModels.Add(new ResponseFeedbackModel(r, userDetails, questionText));
            }

            return View("Feedback", responseModels);
        }
    }
}