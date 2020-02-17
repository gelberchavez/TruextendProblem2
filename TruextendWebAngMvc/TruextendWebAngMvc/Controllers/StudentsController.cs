using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Truextend.StudentManagement.Core.Bussiness;
using Truextend.StudentManagement.Core.Entities;
namespace TruextendWebAngMvc.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetStudents()
        {
            clsStudent oStudent = new clsStudent();// used Business
            List<clsStudent> ListaStudents = new List<clsStudent>();
            ListaStudents = ConvertDataTable<clsStudent>(oStudent.GetStudentsSortedName());
            return Json(ListaStudents, JsonRequestBehavior.AllowGet);
        }

        //methods privates
        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
    }
}