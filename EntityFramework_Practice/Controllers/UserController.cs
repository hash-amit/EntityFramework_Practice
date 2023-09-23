using EntityFramework_Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Newtonsoft.Json;
using System.Runtime.Remoting.Messaging;

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

        public void InsertUpdateUser(tblUser user)
        {
            if (user.User_ID == 0)
            {
                // Inserting data into table using DbSet
                dbEntities.tblUsers.Add(user);

                // Inserting data into table using stored procedure's method
                // dbEntities.InsertUser(user.Name, user.Email, user.Age); 

                dbEntities.SaveChanges();
            }
            else
            {
                // Updating using DbContext class' method 'Modified'
                dbEntities.Entry(user).State = EntityState.Modified;

                // using custom method (stored proc) to update any record
                // dbEntities.UpdateUser(user.User_ID, user.Name, user.Email, user.Age);
                dbEntities.SaveChanges();
            }
        }

        public JsonResult GetAllUser()
        {
            // Retrieving all data from the table using DbSet
            var data = dbEntities.tblUsers.ToList();

            // Retrieve all data from the table using a custom method
            //var data = dbEntities.GetAllUser().ToList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetOneUser(tblUser user)
        {
            // Retereving one record using DbSet and through lambda function telling which record it has to retereve
            var data = dbEntities.tblUsers.Where(M => M.User_ID == user.User_ID).ToList();

            // Using custom method to retreve only one record
            // var data = dbEntities.GetOneUser(user.User_ID).ToList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public void DeleteUser(tblUser user)
        {
            /* Retereving one record which we have to delete because Remove() takes full record instead of only ID */
            var data = dbEntities.tblUsers.Find(user.User_ID);
            dbEntities.tblUsers.Remove(data);

            // Using custom method to delete one record from table
            // dbEntities.DeleteUser(user.User_ID);

            dbEntities.SaveChanges();
        }

        public JsonResult GetCountry()
        {
            /* Using DbContext class to fetch all the data from tblCountries table */
            var data = dbEntities.tblCountries.Select(c => new { c.CountryName, c.CountryID }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetState(tblState state)
        {
            // Using LINQ to fetch the State list
            var data = (from tblS in dbEntities.tblStates
                        where tblS.CountryID == state.CountryID
                        select new SelectListItem
                        {
                            Text = tblS.StateName,
                            Value = tblS.StateID.ToString()

                        });

            // var data = dbEntities.tblStates.Where(M => M.CountryID == state.CountryID).ToList(); // this line is giving error
            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}
