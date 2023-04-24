using Microsoft.AspNetCore.Mvc;
using PhoneApp.Models;

namespace PhoneApp.Controllers
{
    public class PhonesController : Controller
    {
        private MobileContext _db;
        public PhonesController(MobileContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Phone> phones = _db.Phones.ToList();
            return View(phones);
        }
        public IActionResult Add() 
        {
            return View();
        }
        public IActionResult Company()
        {
            return Redirect("http://apple.com");
        }

        [HttpPost]
        public IActionResult Add(Phone phone)
        {
            if (phone != null)
            {
                _db.Phones.Add(phone);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int phoneId)
        {
            if (phoneId != null)
            {
                Phone phone = _db.Phones.FirstOrDefault(x => x.Id == phoneId);
                if (phone != null)
                {
                    return View(phone);
                }
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(Phone phone)
        {
            if (phone != null)
            {
                _db.Phones.Update(phone);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int phoneId)
        {
            if (phoneId != null)
            {
                Phone phone = _db.Phones.FirstOrDefault(x => x.Id == phoneId);
                if (phone != null)
                {
                    _db.Phones.Remove(phone);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}
