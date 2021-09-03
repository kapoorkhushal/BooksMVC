using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shared;
using BusinessFacade;
using System.Web.Security;
using FluentValidation.Results;

namespace Presentation.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        #region Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserObject userObject)
        {
            UserBusinessLogic userBusinessLogic = new UserBusinessLogic();
            var user = userBusinessLogic.UserValidate(userObject);
            if (user != null)
            {
                HomeController homeController = new HomeController();
                homeController.userObject = user;
                Session["FullName"] = user.FullName;
                Session["Email"] = user.Email;
                FormsAuthentication.SetAuthCookie(userObject.Email, false);
                return RedirectToAction("LoggedIn","Home");
            }
            ModelState.AddModelError("", "Invalid Email or Password");
            return View();
        }
        #endregion

        #region Signup
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(UserObject userObject)
        {
            UserBusinessLogic userBusinessLogic = new UserBusinessLogic();
            ValidationResult result = userBusinessLogic.AddUser(userObject);
            if(result == null)
            {
                ModelState.AddModelError("", "User Already Exist");
            }
            else if(result.IsValid)
            {
                ViewBag.IsSuccess = "User added successfully!";
                ModelState.Clear();

                return RedirectToAction("Login");
            }
            else
            {
                foreach(var failure in result.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
            }
            return View();
        }
        #endregion

        #region Logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        #endregion

    }
}