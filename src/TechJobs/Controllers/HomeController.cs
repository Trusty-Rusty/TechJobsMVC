using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TechJobs.Controllers
{
    public class HomeController : Controller        //Declare Homecontroller class that inherits from Controller class
    {
        public IActionResult Index()                    //Action method for home page (index)
        {
            Dictionary<string, string> actionChoices = new Dictionary<string, string>();    //Create dict 
            actionChoices.Add("search", "Search");          //Add KVP to dict
            actionChoices.Add("list", "List");
            
            ViewBag.actions = actionChoices;                //Put actionChoices in dict
       

            return View();                                  //Return the view for the home page
        }
    }
}
