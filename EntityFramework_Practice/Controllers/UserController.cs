using EntityFramework_Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFramework_Practice.Controllers
{
    public class UserController : Controller
    {
        dbDatabaseEntities dbEntities = new dbDatabaseEntities();
        // GET: User
        public ActionResult UserForm()
        {
            return View("UserForm");
        }

        public void InsertUser(tblUser user)
        {
            dbEntities.InsertUser(user.Name, user.Email, user.Age);
            dbEntities.SaveChanges();
        }

        public JsonResult GetAllUser()
        {
            var data = dbEntities.GetAllUser().ToList();
            return Json(data,JsonRequestBehavior.AllowGet);
        }
    }
}