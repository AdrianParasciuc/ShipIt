using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccesaChallengePortal.DatabaseLink;
using AccesaChallengePortal.Interfaces;
using AccesaChallengePortal.Models.Security;
using AccesaChallengePortal.Repository;

namespace AccesaChallengePortal.Controllers
{
    public class SecurityController : Controller
    {
        private readonly ACPRepository<User> _repo;

        public SecurityController()
        {
            _repo = new ACPRepository<User>();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _repo.Where(x => x.Username == model.Username).FirstOrDefault();
                if (user != null && user.Password.Equals(model.Password))
                {
                    SessionRepository.CurrentUser = user;
                    return RedirectToLocal();
                }
                ModelState.AddModelError("", "Invalid username or password.");
            }
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _repo.Where(x => x.Username == model.Username).FirstOrDefault();
                if (user == null)
                {
                    user = ConvertRegisterModelToUser(model);
                    if (user.Username.EndsWith("@accesa.eu"))
                    {
                        user.IsAdmin = true;
                    }
                    _repo.Add(user);
                    SessionRepository.CurrentUser = user;
                    return RedirectToLocal();
                }               
                ModelState.AddModelError("", "Username already exists.");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            SessionRepository.CurrentUser = null;
            return RedirectToAction("Index", "Home");
        }

    #region PrivateMethods
        private ActionResult RedirectToLocal()
        {
            if(SessionRepository.CurrentUser.IsAdmin)
                return RedirectToAction("Index", "Home");
            return RedirectToAction("Index", "Home");
        }

        private User ConvertRegisterModelToUser(RegisterModel model)
        {
            var user = new User
            {
                Username = model.Username,
                Password = model.Password,
                FirstName = model.FirstName,
                LastName = model.LastName,
                IsAdmin = false
            };
            return user;
        }
    #endregion
    }
    
}