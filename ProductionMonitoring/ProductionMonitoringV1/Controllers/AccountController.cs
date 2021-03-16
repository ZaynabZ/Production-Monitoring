using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductionMonitoringV1.Models;
using ProductionMonitoringV1.ViewModels;

namespace ProductionMonitoringV1.Controllers
{
    public class AccountController : Controller
    {
        private ProductionMonitoringDbContext _context;

        public AccountController()
        {
            _context = new ProductionMonitoringDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();

            base.Dispose(disposing);
        }
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateUser()
        {
            var _roles = _context.Roles.ToList();

            var userViewModel = new CreateUserViewModel
            {
                User = new User(),
                Roles = _roles,
            };

            return View(userViewModel);
        }

        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            if(!ModelState.IsValid)
            {
                return View("CreateUser");
            }
            if(_context.Users.Where(u => u.Email == user.Email).Any())
            {
                ModelState.AddModelError("Email", "This Email Already Exists!");
                return View("CreateUser", user);
            }
            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel user)
        {
            if(!ModelState.IsValid)
            {
                return View("Login", user);
            }

            var TheUser = _context.Users.Where(u => u.Username == user.Username
                                                 && u.Password == user.Password).FirstOrDefault();

            if(TheUser == null)
            {
                ModelState.AddModelError("Password", "Username Or Password Incorrect!");
                return View("Login");
            }
            else
            {
                Session["Username"] = TheUser.Username;
                return RedirectToAction("Index", "");
            }
            
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");

        }
    }
}






















