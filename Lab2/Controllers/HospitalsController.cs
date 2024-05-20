using Lab2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab2.Controllers
{
    public class HospitalsController : Controller
    {
        private readonly IRepository<Hospital> _hospitalRepository;

        public HospitalsController(IRepository<Hospital> hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;
        }

        // GET: HospitalsController
        public ActionResult Index()
        {
            var hospitals = _hospitalRepository.GetAll();
            return View(hospitals);
        }

        // GET: HospitalsController/Details/5
        public ActionResult Details(int id)
        {
            var hospital = _hospitalRepository.Get(id);
            return View(hospital);
        }

        // GET: HospitalsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HospitalsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Hospital hospital)
        {
            try
            {
                _hospitalRepository.Add(hospital);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HospitalsController/Edit/5
        public ActionResult Edit(int id)
        {
            var hospital = _hospitalRepository.Get(id);
            return View(hospital);
        }

        // POST: HospitalsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Hospital hospital)
        {
            try
            {
                _hospitalRepository.Update(hospital);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HospitalsController/Delete/5
        public ActionResult Delete(int id)
        {
            var hospital = _hospitalRepository.Get(id);
            return View(hospital);
        }

        // POST: HospitalsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _hospitalRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

