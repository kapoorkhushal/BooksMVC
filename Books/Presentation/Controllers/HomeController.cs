using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shared;
using BusinessFacade;
using FluentValidation.Results;

namespace Presentation.Controllers
{
    
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public UserObject userObject;

        #region Get Events
        public ActionResult PastEvent(EventObject eventObject)
        {
            var data = new GetEventLogic().GetPastEvent(eventObject);
            return View(data);
        }

        public ActionResult FutureEvent(EventObject eventObject)
        {
            var data = new GetEventLogic().GetFutureEvent(eventObject);
            return View(data);
        }

        public ActionResult EventDetails(int id)
        {
            var data = new GetEventLogic().GetEventDetails(id);
            return View(data);
        }

        [Authorize]
        public ActionResult MyEvents(string email)
        {
            var data = new GetEventLogic().GetMyEvents(email);
            return View(data);
        }

        [Authorize]
        public ActionResult EventsInvitedTo(string email)
        {
            var data = new GetEventLogic().GetEventsInvitedTo(email);
            return View(data);
        }
        #endregion

        #region Loggedin
        [Authorize]
        public ActionResult LoggedIn(UserObject userObject)
        {
            userObject.FullName = Session["FullName"].ToString();
            userObject.Email = Session["Email"].ToString();
            return View(userObject);
        }
        #endregion

        #region Create Event
        [Authorize]
        public ActionResult CreateEvent(string email)
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult CreateEvent(EventObject eventObject, UserObject userObject)
        {
            CreateEventLogic createEventLogic = new CreateEventLogic();
            userObject.Email = Session["Email"].ToString();
            ValidationResult result = createEventLogic.AddEvent(eventObject, userObject);
            if (result.IsValid)
            {
                ModelState.Clear();
                ViewBag.IsSuccess = "Event created successfully!";
                return RedirectToAction("LoggedIn");
            }
            else
            {
                foreach (var failure in result.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
            }
            return View();
        }
        #endregion

        #region Event Edit
        [Authorize]
        public ActionResult EventEdit(int id)
        {
            var data = new GetEventLogic().GetEventDetails(id);
            return View(data);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EventEdit(EventObject eventObject)
        {
            CreateEventLogic createEventLogic = new CreateEventLogic();
            ValidationResult result = createEventLogic.UpdateEvent(eventObject.Id, eventObject);
            if (result.IsValid)
            {
                ModelState.Clear();
                ViewBag.IsSuccess = "Event Updated successfully!";
                return RedirectToAction("LoggedIn");
            }
            else
            {
                foreach (var failure in result.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
            }
            return View();
        }
        #endregion

        [Authorize]
        public ActionResult EventDelete(int id)
        {
            bool isValid = new CreateEventLogic().DeleteEvent(id);
            if(isValid)
            {
                return RedirectToAction("LoggedIn");
                
            }
            else
            {
                ModelState.AddModelError("", "Event cannot be deleted");
                return View();
            }
            
        }
    }
}