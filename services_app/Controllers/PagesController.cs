using Microsoft.AspNetCore.Mvc;
using services_app.Models;
using services_app.Services;

namespace services_app.Controllers
{
    public class PagesController : Controller
    {
        private readonly IServiceUsers _serviceUsers;

        public PagesController(IServiceUsers serviceUsers)
        {
            _serviceUsers = serviceUsers;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Users()
        {
            var users = _serviceUsers.Read();
            return View(users);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {

            if (ModelState.IsValid)
            {
                _serviceUsers.Create(user); // Додайте дані користувача
                return RedirectToAction("Index"); // Перенаправлення на головну сторінку
            }
            return View(user); // Повернення до форми, якщо модель недійсна
        }




        public IActionResult Details(int id)
        {
            var user = _serviceUsers.GetUserById(id);
            return View(user);
        }
    }
}
