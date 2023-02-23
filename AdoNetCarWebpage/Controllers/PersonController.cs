using AdoNetCarWebpage.Models;
using AdoNetCarWebpage.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdoNetCarWebpage.Controllers
{
    public class PersonController : Controller

    {
        private readonly IPersonRepository personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        // GET: PersonController
        public async Task< ActionResult> Index()
        {
            var person = await personRepository.GetPerson();
            return View(person);
        }

        // GET: PersonController/Details/5
        public async Task< ActionResult> Details(int id)
        {
            Person p= await personRepository.GetPersonById(id);
            return View(p);
        }

        // GET: PersonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Person p)
        {
            try
            {
                int result = await personRepository.Create(p);
                if (result > 0) {
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonController/Edit/5
        public async Task <ActionResult> Edit(int id)
        {
            Person p = await personRepository.GetPersonById(id);
            return View();
        }

        // POST: PersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< ActionResult >Edit(int id, Person p)
        {
            try
            {
                int result = await personRepository.Update(p);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Person p)
        {
            try
            {
                int result = await personRepository.Delete(id);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }
    }
}
