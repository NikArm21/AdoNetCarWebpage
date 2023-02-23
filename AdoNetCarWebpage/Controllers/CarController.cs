using AdoNetCarWebpage.Models;
using AdoNetCarWebpage.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

namespace AdoNetCarWebpage.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        // GET: CarController
        public async Task<ActionResult> Index()
        {
             List<Car> cars=await _carRepository.GetCars();
          
            return View(cars);
        }

        // GET: CarController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Car c= await _carRepository.GetCarById(id);
            if(c is null)
            {
                return RedirectToAction("Index");
            }
            return View(c);
        }

        // GET: CarController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Car c)
        {
            try
            {
                int result = await _carRepository.Create(c);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Car c = await _carRepository.GetCarById(id);
            return View(c);
        }

        // POST: CarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Edit(int id,Car c)
        {
            try
            {
                int result = await _carRepository.Update(c);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CarController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< ActionResult> Delete(int id, Car c)
        {
            try
            {

                int result = await _carRepository.Delete(id);
                return RedirectToAction(nameof(Index));
              
            }
            catch
            {
                return View();
            }
        }
    }
}
