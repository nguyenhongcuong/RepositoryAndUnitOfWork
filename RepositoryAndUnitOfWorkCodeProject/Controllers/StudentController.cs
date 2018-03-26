using System.Linq;
using System.Web.Mvc;
using RepositoryAndUnitOfWorkCodeProject.DAL;
using RepositoryAndUnitOfWorkCodeProject.Models;

namespace RepositoryAndUnitOfWorkCodeProject.Controllers
{

    public class StudentController : Controller
    {
        private StudentRepository studentRepository = new StudentRepository();
        // GET: Student
        public ActionResult Index()
        {
            var students = studentRepository.GetAll();
            return View(students.ToList());
        }

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            Student student = studentRepository.Get(s => s.StudentId == id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                studentRepository.Add(student);
                studentRepository.Save();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            Student student = studentRepository.Get(s => s.StudentId == id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                studentRepository.Attach(student);
                studentRepository.Save();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id)
        {
            Student student = studentRepository.Get(s => s.StudentId == id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            Student student = studentRepository.Get(s => s.StudentId == id);
            studentRepository.Delete(student);
            studentRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
