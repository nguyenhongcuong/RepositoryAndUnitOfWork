using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using RepositoryAndUnitOfWorkMS.DAL;
using RepositoryAndUnitOfWorkMS.Models;

namespace RepositoryAndUnitOfWorkMS.Controllers
{
    public class StudentRepositoryController : Controller
    {
        private IStudentRepository studentRepository;

        // Hàm khởi tạo không tham số
        public StudentRepositoryController()
        {
            studentRepository = new StudentRepository(new SchoolContext());
        }

        // Hàm khởi tạo có tham số
        public StudentRepositoryController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }
        // GET: StudentRepository
        public ActionResult Index()
        {
            var students = from student in studentRepository.GetStudents()
                           select student;
            return View(students);
        }

        // GET: StudentRepository/Details/5
        public ActionResult Details(int? id)
        {
            Student student = studentRepository.GetStudentById(id);
            return View(student);
        }

        // GET: StudentRepository/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentRepository/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LastName, FirstMidName, EnrollmentDate")] Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    studentRepository.InsertStudent(student);
                    studentRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
            }

            return View(student);
        }

        // GET: StudentRepository/Edit/5
        public ActionResult Edit(int? id)
        {
            Student student = studentRepository.GetStudentById(id);
            return View(student);
        }

        // POST: StudentRepository/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LastName, FirstMidName, EnrollmentDate")]
         Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    studentRepository.UpdateStudent(student);
                    studentRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
            }
            return View(student);
        }

        // GET: StudentRepository/Delete/5
        public ActionResult Delete(int? id)
        {
            Student student = studentRepository.GetStudentById(id);
            return View(student);
        }

        // POST: StudentRepository/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Student student = studentRepository.GetStudentById(id);
            studentRepository.DeleteStudent(id);
            studentRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            studentRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
