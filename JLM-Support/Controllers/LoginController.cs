using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JLM_Support.Models.Login;
namespace JLM_Support.Controllers
{
    public class LoginController : Controller
    {

        [BindProperty]
        public Login login { get; set; }


        public IActionResult Index()
        {
            return Redirect("~/Login/Login");
        }


        [HttpPost]
        public IActionResult Login()
        {

            login.UserName = "JLMData!";
            login.Password = "Korallen!";
           
            {
                if (login.UserName == "JLMData!" & login.Password == "Korallen!")
                {
                    //Create
                    return Redirect ("~C");
                }
                else
                {
                    //Update
                    RedirectToAction("Login");
                }
              
                return RedirectToAction("Login");
            }
        }
    }
}
