using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Walkhome.Controllers
{
    public class MainController : Controller
    {
        private LoginEntities db = new LoginEntities(); // Gör ett nytt objekt av databasen som alla metoder i klassen kan använda.
        // GET: Main
        public ActionResult Index() //Main controller för projektet. Projektets inloggnings sida, defineras i webconfig.
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult AboutGame()
        {
            return View();
        }
        public ActionResult AboutThreeSirs()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost] //HttPost gör att metoden lysnar efter post från metodens sida.
        public ActionResult Create(Login nyLogin) //skikar in en variabel nyLogin av databas tabelen Login.
        {
            db.Logins.Add(nyLogin); //Lägger in variabeln nyLogin i databasen.
            db.SaveChanges(); // Sparar ändringarna i databasen.
            return RedirectToAction("Index"); //skickar tilbaka användaren till index sidan.
        }
        [Authorize] // Måste logat in från index sidan för att få komma till.
        public ActionResult Inloggad()
        {
            return View(db.Logins.ToList());// skickar en lista av databasen.

        }
        [Authorize]
        public ActionResult ToCentrum()
        {
            return View();
        }
        [Authorize]
        public ActionResult ToCentrum1()
        {
            return View();
        }
        [Authorize]
        public ActionResult ToCentrum2()
        {
            return View();
        }
        [Authorize]
        public ActionResult ToCentrum3()
        {
            return View();
        }
        [Authorize]
        public ActionResult ToCentrum4()
        {
            return View();
        }
        [Authorize]
        public ActionResult ToCentrum5()
        {
            return View();
        }
        [Authorize]
        public ActionResult ToCentrum6()
        {
            return View();
        }
        [Authorize]
        public ActionResult FastFood()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Walkhome.Login inloggning) //Tar upp inlognings upgifterna från sidan och kör dem genom bool metoden under för att se validitet.
        {
            if (inloggning.Usr == null || inloggning.Psw == null) //Kontrollerar att båda fälten är ifyllda.
            {
                ModelState.AddModelError("", "You must enter both a User Name and a Password"); //Felmedelande om inte båda fälten är ifylda.
            }
            bool validUser = false; //skapar en bool variabel med värde false.
            validUser = CheckUser(inloggning.Usr, inloggning.Psw);// Skickar in Usr o Psw till bool CeckUser och sätter validuser till resultatet utifrån det.
            if (validUser == true) // Om validuser är true när den når hit så acepteras inlogningen och du skickas vidare till inloggad sidan.
            {
                System.Web.Security.FormsAuthentication.RedirectFromLoginPage(inloggning.Usr, true);
            }
            ModelState.AddModelError("", "inloggning ej godkänd");
            return View();
        }
        
        private bool CheckUser (string Usr, string Psw) //Metod för att kontrollera Psw och Usr mot databasen och returnera true eller false till CheckUser.
        {
            var user = from rader in db.Logins
                       where rader.Usr.ToUpper() == Usr.ToUpper()
                       && rader.Psw == Psw
                       select rader;
            if (user.Count()==1)
            {
                return true;
            }
            else
            {
                return false;
            }
                       
        }
    }
}