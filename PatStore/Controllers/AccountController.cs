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
using Typesafe.Mailgun;
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
                            Password = "Unused",
                            FirstName = model.FirstName,
                            MiddleName = model.MiddleName,
                            LastName = model.LastName,
                            PhoneNumber = model.PhoneNumber,
                            Address = model.Address,
                            Address2 = model.Address2,
                            City = model.City,
                            State = model.State,
                            ZipCode = model.Zip,                           
                        }, true);

                    string apiKey = ConfigurationManager.AppSettings["SendGrid.Key"];                    
                    string subject = "Complete your PatStore Registration";                  
                    string emailContent = string.Format("<html><body><a href=\"{0}\">Complete your registration</a></body></html>", 
                        Request.Url.GetLeftPart(UriPartial.Authority) + "/Account/RegisterConfirm/" + HttpUtility.UrlEncode(token) + "?email=" + 
                        HttpUtility.UrlEncode(model.Email));
                    var client = new MailgunClient("sandbox2dc3ec1959274850aac287b7810b4055.mailgun.org", "key-234c438fb94e6d6d2b27de2f473b7193", 3);

                    var from = new System.Net.Mail.MailAddress("postmaster@sandbox2dc3ec1959274850aac287b7810b4055.mailgun.org", "MailGun Sandbox");

                    string sb = ConfigurationManager.AppSettings["MailGun.IsSandbox"];
                    bool isSandbox = bool.Parse(sb);
                    System.Net.Mail.MailAddress to = null;

                    if (isSandbox)
                    {
                        to = new System.Net.Mail.MailAddress("patrick.warren1988@gmail.com", model.FirstName + " " + model.LastName);
                    }
                    else
                    {
                        to = new System.Net.Mail.MailAddress(model.Email, model.FirstName + " " + model.LastName);
                    }
                    var message = new System.Net.Mail.MailMessage(from, to)
                    {
                        Subject = subject,
                        Body = emailContent
                    };
                    client.SendMail(message);
                    using (PatStore.Models.PatStoreDBEntities entities = new PatStoreDBEntities())
                    {
                        var user = entities.Users.Single(x => x.Email == model.Email);
                        PaymentInfo payment = new PaymentInfo();
                        payment.CreditCardNumber = model.CreditCardNumber;
                        payment.CreditCardExpiration = DateTime.Now;// model.CreditCardExpiration;
                        payment.CreditCardVerificationValue = model.CreditCardVerificationValue;
                        payment.CreditCardName = model.CreditCardName;
                        payment.CreditCardAddress1 = model.CreditCardAddress1;
                        payment.CreditCardAddress2 = model.CreditCardAddress2;
                        payment.CreditCardCity = model.CreditCardCity;
                        payment.CreditCardState = model.CreditCardState;
                        payment.CreditCardPostal = model.CreditCardPostal;
                        user.PaymentInfoes.Add(payment);
                        entities.SaveChanges();
                    }
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