using System.Web.Mvc;
using RepositoryAndUnitOfWorkCodeProject.DAL;
using RepositoryAndUnitOfWorkCodeProject.Models;

namespace RepositoryAndUnitOfWorkCodeProject.Controllers
{
    public class StudentUnitOfWorkController : Controller
    {
        private UnitOfWork unitOfWork = null;

        public StudentUnitOfWorkController()
        {
            unitOfWork = new UnitOfWork();
        }

        public StudentUnitOfWorkController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        // GET: StudentUnitOfWork
        public ActionResult Index()
        {
            var students = unitOfWork.StudentRepository.GetAll();
            return View(students);
        }

        // GET: StudentUnitOfWork/Details/5
        public ActionResult Details(int id)
        {
            Student student = unitOfWork.StudentRepository.Get(s => s.StudentId == id);
            return View(student);
        }

        // GET: StudentUnitOfWork/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentUnitOfWork/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentUnitOfWork/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentUnitOfWork/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentUnitOfWork/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentUnitOfWork/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
