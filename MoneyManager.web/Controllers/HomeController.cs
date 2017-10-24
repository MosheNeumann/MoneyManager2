using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoneyManager.data;

namespace MoneyManager.web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
         [HttpPost]
        public ActionResult Register(AccountOwner owner, string Password,string PasswordConfirm)
        {
            if (! ConfirmRegisterFormIsFilledOutCorrectly(owner,Password,PasswordConfirm))
            {
                TempData["errorMessage"] = (AccountOwner)owner;
                return Redirect("/home/register");
            }

            return View();
        }
        
        static bool ConfirmRegisterFormIsFilledOutCorrectly(AccountOwner owner, string Password, string PasswordConfirm)
        {
            if (Password != PasswordConfirm || owner.Email == null || owner.LastName == null || owner.FirstName == null || owner.PhoneNumber == null || Password == "")
            {
                return false;
            }
            return true;
        }
    }
      
}