using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestDemo.Models;

namespace TestDemo.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeEntities db = new EmployeeEntities();
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult GetAll()
        {
            List<EmployeeDetail> lst = db.EmployeeDetails.ToList();
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        public string insertEmp(EmployeeDetail emp)
        {
            db.EmployeeDetails.Add(emp);
            db.SaveChanges();
            return("Data Inserted");
        }

        public string deleteEmp(int id)
        {

            EmployeeDetail et = db.EmployeeDetails.Find(id);
            db.EmployeeDetails.Remove(et);
            db.SaveChanges();
            return "Deleted Sucessfully";

        }


        public JsonResult GetById(int id)
        {
            EmployeeDetail lst = db.EmployeeDetails.Find(id);
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        public string updateEmp(EmployeeDetail et)
        {
            db.Entry<EmployeeDetail>(et).State = EntityState.Modified;
            db.SaveChanges();
            return "Record Updated Sucessfully";
        }
	}
}