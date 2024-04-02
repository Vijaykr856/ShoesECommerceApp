using Microsoft.AspNetCore.Mvc;
using ShoesECommerceApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;


namespace ShoesECommerceApp.Controllers
{
    public class ShoesController : Controller
    {
        private readonly UserContext context;

        public ShoesController(UserContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                return RedirectToAction("Dashboard");
            }
            return View();

        }

        [HttpPost]
        public IActionResult Login(User tb)
        {
            var myUser = context.Users.FirstOrDefault(x => x.Email == tb.Email && x.Password == tb.Password);
            if (myUser != null)
            {
                HttpContext.Session.SetString("UserSession", myUser.Email);
                var userData = context.Users.Where(x => x.Email == myUser.Email).FirstOrDefault();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Login Failed...";
                return View();
            }
        }

        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                HttpContext.Session.Remove("UserSession");
                return RedirectToAction("Login");
            }
            return View();

        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(User tb1)
        {
            if (ModelState.IsValid)
            {
                await context.Users.AddAsync(tb1);
                await context.SaveChangesAsync();
                TempData["Success"] = "Registered Successfully";
                return RedirectToAction("Login");
            }
            return View();
        }


        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }




        [HttpPost]
        public IActionResult CreateData(Shoes shoes, IFormFile Shoespic)
        {
            if (Shoespic != null)
            {
                using MemoryStream stream = new MemoryStream();
                Shoespic.CopyTo(stream);
                shoes.Shoespic = stream.ToArray();
            }
            context.shoe.Add(shoes);
            context.SaveChanges();

            return RedirectToAction("Dashboard");
        }

        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public ActionResult ShowData()
        {

            var data = context.shoe.ToList();
            return Json(data);

        }

        public IActionResult MoreDetail(int id)
        {
            var send = context.shoe.Where(x => x.Id == id).ToList();
            return View(send);
        }

      


        public IActionResult UserDetails()
        {
            return View();
        }
    }




}
