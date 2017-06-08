using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()                        //Home page for search function
        {
            ViewBag.columns = ListController.columnChoices;     //pull column options from ListController
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        public IActionResult Results(string searchType, string searchTerm)  //method takes params with names matching the form fields from the search/index View
        {
            ViewBag.columns = ListController.columnChoices;

            List<Dictionary<string, string>> jobs = new List<Dictionary<string, string>>();

            if (searchType.Equals("all"))
            {
                jobs = JobData.FindByValue(searchTerm);
            }

            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }

            ViewBag.jobs = jobs;

            return View("Index");


        }
    }
}
