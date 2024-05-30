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
            var hospitals = _hospitalRepository.GetAll();
            ViewBag.Hospitals = new SelectList(hospitals, "Id", "Name");
            return View(new Patient());
        }
        // POST: PatientsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Patient patient)
        {
            try
            {
                if (patient.HospitalId == 0)
                {
                    ModelState.AddModelError("HospitalId", "Выберите больницу.");
                    ViewBag.Hospitals = new SelectList(_hospitalRepository.GetAll(), "Id", "Name");
                    return View(patient);
                }
                else
                {
                    _patientRepository.Add(patient);
                    return RedirectToAction(nameof(Index));
                }
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
            var hospitals = _hospitalRepository.GetAll();
            ViewBag.Hospitals = new SelectList(hospitals, "Id", "Name", patient.HospitalId);
            return View(patient);
        }
        // POST: PatientsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Patient patient)
        {
            try
            {
                if (patient.HospitalId == 0)
                {
                    ModelState.AddModelError("HospitalId", "Выберите больницу.");
                    ViewBag.Hospitals = new SelectList(_hospitalRepository.GetAll(), "Id", "Name", patient.HospitalId);
                    return View(patient);
                }
                else
                { 
                    var existingPatient = _patientRepository.Get(id);
                     
                    existingPatient.MedicalCardNumber = patient.MedicalCardNumber;
                    existingPatient.Surname = patient.Surname;
                    existingPatient.Diagnosis = patient.Diagnosis;
                    existingPatient.Status = patient.Status;
                    existingPatient.HospitalId = patient.HospitalId;

                    _patientRepository.Update(existingPatient);
                    return RedirectToAction(nameof(Index));
                }
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
