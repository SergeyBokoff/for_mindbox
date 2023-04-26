using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneApp.Models;

namespace PhoneApp.Controllers
{
    public class OrdersController : Controller
    {
        private MobileContext _db;
        public OrdersController(MobileContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var orders = _db.Orders.ToList();
            return View(orders);
        }

        [HttpGet]
        public IActionResult Add(int phoneId)
        {
            var phone = _db.Phones.FirstOrDefault(x => x.Id == phoneId);
            var order = new Order() {Phone = phone, PhoneId = phoneId};
            return View(order);
        }

        [HttpPost]
        public IActionResult Add(Order order)
        {
            if (order != null)
            {
                _db.Orders.Add(order);
                _db.SaveChanges();
            }
            return Redirect("Index");
        }
    }
}
