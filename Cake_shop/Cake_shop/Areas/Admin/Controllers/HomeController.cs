using Cake_shop.Models.EF;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;

namespace Cake_shop.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private CakeShopDB _db = new CakeShopDB();
        // GET: Admin/Home
        public ActionResult Index()
        {
            var total = _db.Products.Count();
            var news = _db.News.Count();
            var Order = _db.Orsers.Count();
            var acount = _db.Users.Count();
            ViewBag.TotalCount = total;
            ViewBag.news = news;
            ViewBag.Order = Order;
            ViewBag.acount = acount;
            var userName = Session["userName"] as string;
            ViewBag.UserName = userName;
            return View();
        }
        public ActionResult DangNhap()
        {
            var userName = Session["userName"] as string;
            ViewBag.UserName = userName;
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(string user, string password)
        {
            var userFromDb = _db.Users.FirstOrDefault(u => u.password.Equals(password) && u.fullname.Equals(user));
            var admin = _db.Amdins.FirstOrDefault(u => u.password.Equals(password) && u.username.Equals(user));
                if (admin != null && admin.Roles_id == 1)
                {
                Session["user"] = "admin";
                Session["userID"] = admin.id;
                Session["userName"] = admin.username;
                return RedirectToAction("Index");
                }
                else if(userFromDb != null && userFromDb.Roles_id == 2)
                {
                Session["user"] = "user";
                Session["userID"] = userFromDb.id;
                Session["userName"] = userFromDb.fullname;
                return RedirectToAction("Index", "Home", new { area = "" });
                }
            else
            {
                TempData["error"] = "Tài khoản đăng nhập không đúng";
                return View();
            }
            
        }
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy(UserModel user)
        {
            if (ModelState.IsValid)
            {
                var checkUser = _db.Users.FirstOrDefault(u => u.email == user.email);
                if (checkUser == null)
                {
                    user.status = 1;
                    user.Roles_id = 2;
                    _db.Configuration.ValidateOnSaveEnabled = false;
                    _db.Users.Add(user);
                    _db.SaveChanges();
                    string script = "<script>alert('Đăng ký thành công!');</script>";
                    ViewBag.Script = script;
                    ViewBag.Message = "Đăng ký thành công!";
                    return View();
                }
                else
                {
                    ViewBag.errorUser = "Tài khoản đã tồn tại!";
                    return View();
                }

            }
            return View();
        }
        
        public ActionResult DanngXuat()
        {
            Session.Remove("user");
            FormsAuthentication.SignOut();
            return RedirectToAction("DangNhap");
        }
        public ActionResult SomeAction()
        {
            if (Session["user"] != null)
            {
                var userType = Session["user"].ToString();
                var userName = Session["userName"].ToString();
            }
            else
            {
                ViewBag.Message = "Xin chào! Vui lòng đăng nhập để tiếp tục.";
            }

            return View();
        }

    }
}