using Lab2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab2.Controllers
{
    public class PatientsController : Controller
    {
        private readonly IRepository<Patient> _patientRepository;
        private readonly IRepository<Hospital> _hospitalRepository;


        public PatientsController(IRepository<Patient> patientRepository, IRepository<Hospital> hospitalRepository)
        {
            _patientRepository = patientRepository;
            _hospitalRepository = hospitalRepository;
        }

        // GET: PatientsController
        public ActionResult Index()
        {
            var patients = _patientRepository.GetAll();
            return View(patients);
        }

        // GET: PatientsController/Details/5
        public ActionResult Details(int id)
        {
            var patient = _patientRepository.Get(id);
            return View(patient);
        }

        // GET: PatientsController/Create
        public ActionResult Create()
        {
            // Получите список больниц. Это может быть репозиторий или сервис.
            var hospitals = _hospitalRepository.GetAll();

            // Передайте список больниц в представление с помощью ViewBag.
            ViewBag.Hospitals = new SelectList(hospitals, "Id", "ChiefDoctor");

            return View();
        }
        // POST: PatientsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Patient patient)
        {
            try
            {
                _patientRepository.Add(patient);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PatientsController/Edit/5
        public ActionResult Edit(int id)
        {
            var patient = _patientRepository.Get(id);
            return View(patient);
        }
        // POST: PatientsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Patient patient)
        {
            try
            {
                _patientRepository.Update(patient);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PatientsController/Delete/5
        public ActionResult Delete(int id)
        {
            var patient = _patientRepository.Get(id);
            return View(patient);
        }
        // POST: PatientsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _patientRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
