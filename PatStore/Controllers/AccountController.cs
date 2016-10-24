using PatStore.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace PatStore.Controllers
{
    public class AccountController : Controller
    {
        // GET: Create/Register Account
        public async Task<ActionResult> Registration()
        {
            RegistrationModel model = new RegistrationModel();
            return View(model);
        }

        //POST: Create/Register Account
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Registration(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                //TODO: Let's create an account
                if (WebMatrix.WebData.WebSecurity.UserExists(model.Email))
                {
                    ModelState.AddModelError("Email", "Email address is already registered.");
                }
                else
                {
                    //TODO: Setup email confirmation tokens
                    string token = WebMatrix.WebData.WebSecurity.CreateUserAndAccount(model.Email, model.Password,
                        new
                        {
                            Email = model.Email,
                            Password = model.Password,
                            FirstName = model.FirstName,
                            MiddleName = model.MiddleName,
                            LastName = model.LastName,
                            PhoneNumber = model.PhoneNumber,
                            Address = model.Address,
                            Address2 = model.Address2,
                            City = model.City,
                            State = model.State,
                            ZipCode = model.Zip
                        }, true);

                    string apiKey = ConfigurationManager.AppSettings["SendGrid.Key"];
                    SendGrid.SendGridAPIClient client = new SendGrid.SendGridAPIClient(apiKey);

                    SendGrid.Helpers.Mail.Email from = new SendGrid.Helpers.Mail.Email("admin@patstore.com");
                    string subject = "Complete your PatStore Registration";
                    SendGrid.Helpers.Mail.Email to = new SendGrid.Helpers.Mail.Email(model.Email);

                    string emailContent = string.Format("<html><body><a href=\"{0}\">Complete your registration</a></body></html>", Request.Url.GetLeftPart(UriPartial.Authority) + "/Account/RegisterConfirm/" + HttpUtility.UrlEncode(token) + "?email=" + HttpUtility.UrlEncode(model.Email));
                    SendGrid.Helpers.Mail.Content content = new SendGrid.Helpers.Mail.Content("text/html", emailContent);
                    SendGrid.Helpers.Mail.Mail mail = new SendGrid.Helpers.Mail.Mail(from, subject, to, content);
                    SendGrid.CSharp.HTTP.Client.Response r = await client.client.mail.send.post(requestbody: mail.Get());
                    string sendGridResponse = await r.Body.ReadAsStringAsync();
                    return RedirectToAction("RegisterComplete", "Account");
                }
            }
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult RegisterComplete()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult RegisterConfirm(string id, string email)
        {
            if (WebMatrix.WebData.WebSecurity.ConfirmAccount(email, id))
            {
                ViewBag.Confirmed = true;
                return View();
            }
            return View();
        }

        //GET: Update account
        [Authorize] //Prevents non logged-in users from accessing this code
        public ActionResult Index()
        {
            AccountDetailModel model = new AccountDetailModel();
            using (PatStoreDBEntities entities = new PatStoreDBEntities())
            {
                var user = entities.Users.Single(x => x.Email == User.Identity.Name);
                model.FirstName = user.FirstName;
                model.MiddleName = user.MiddleName;
                model.LastName = user.LastName;
            }
            return View(model);
        }

        //GET: Post changes to account
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(AccountDetailModel model)
        {
            if (ModelState.IsValid)
            {
                //AccountDetailModel model = new AccountDetailModel();
                using (PatStoreDBEntities entities = new PatStoreDBEntities())
                {
                    var user = entities.Users.Single(x => x.Email == User.Identity.Name);
                    user.FirstName = model.FirstName;
                    user.MiddleName = model.MiddleName;
                    user.LastName = model.LastName;
                    entities.SaveChanges();
                }
            }
            return View(model);
        }

        //GET: Account/login
        public ActionResult Login()
        {
            LoginModel model = new LoginModel();
            return View(model);
        }

        //POST: Account/login
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.Email, model.Password))
                {
                    System.Web.Security.FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Email", "Email address or password is incorrect");
                }
            }
            return View();
        }

        //GET: Account/logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}