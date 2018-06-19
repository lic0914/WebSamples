using CookieBaseSample.MySession;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace CookieBaseSample.Controllers
{
    public class AccountController : Controller
    {
        AdminSession _session;
        public AdminSession CurrentSession
        {
            get
            {
                if (this._session != null)
                    return this._session;

                if (this.HttpContext.User.Identity.IsAuthenticated == false)
                    return null;

                AdminSession session = AdminSession.Parse(this.HttpContext.User);
                this._session = session;
                return session;
            }
            set
            {
                AdminSession session = value;

                if (session == null)
                {
                    //注销登录
                    // this.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    this.HttpContext.User = null;
                    return;
                }

                List<Claim> claims = session.ToClaims();

                //init the identity instances 
                var userPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, "Cookies"));
                this.HttpContext.User = userPrincipal;
               
                //this.HttpContext.SignInAsync("Cookies", userPrincipal, new AuthenticationProperties
                //{
                //    ExpiresUtc = DateTime.UtcNow.AddMinutes(60),
                //    IsPersistent = false,
                //    AllowRefresh = false
                //});

                //IAuthenticationService authenticationService = this.HttpContext.RequestServices.GetService(typeof(IAuthenticationService)) as IAuthenticationService;
                //authenticationService.SignInAsync(this.HttpContext, CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, new AuthenticationProperties
                //{
                //    ExpiresUtc = DateTime.UtcNow.AddMinutes(60),
                //    IsPersistent = false,
                //    AllowRefresh = false
                //});

              

                this._session = session;
            }
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            //判断登录成功 todo
            Sys_User user = new Sys_User();
            AdminSession session = new AdminSession();
            
                session.UserId = user.Id;
            session.UserName = user.UserName;
            session.RealName = user.RealName;
            session.DepartmentId = user.DepartmentId;
            session.DutyId = user.DutyId;
            session.RoleId = user.RoleId;
            session.LoginIP = "127.0.0.1";
            session.LoginTime = DateTime.Now;
            session.IsAdmin =true;
        
            return Content("login success");
        }
        public ActionResult Logout()
        {
            return Content("logout !!!!");
        }
    }
}