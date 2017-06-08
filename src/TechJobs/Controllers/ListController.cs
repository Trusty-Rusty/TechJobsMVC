using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class ListController : Controller
    {
        internal static Dictionary<string, string> columnChoices = new Dictionary<string, string>();        //Create string/string dict 

        // This is a "static constructor" which can be used
        // to initialize static members of a class
        static ListController()                                     //????? Adds the dict values to columnChoices...but what exactly is ListController...and instance?
        {
            
            columnChoices.Add("core competency", "Skill");
            columnChoices.Add("employer", "Employer");
            columnChoices.Add("location", "Location");
            columnChoices.Add("position type", "Position Type");
            columnChoices.Add("all", "All");
        }

        public IActionResult Index()                                //List page displays the column options
        {
            ViewBag.columns = columnChoices;                            //Add columnChoices to ViewBag
            return View();                                              //Feed columnChoices to the View to be rendered
        }

        public IActionResult Values(string column)                  //Action result when a column gets clicked. Poss values for that column displayed or jump to all jobs list
        {
            if (column.Equals("all"))                                   //All is clicked
            {
                List<Dictionary<string, string>> jobs = JobData.FindAll();  //List Dict jobs contains all of the jobs in the database 
                ViewBag.title =  "All Jobs";                                //Add list title to ViewBag
                ViewBag.jobs = jobs;                                        //add jobs list dict
                return View("Jobs");                                        //Jump to Jobs view to show all job listings posted there
            }
            else                                                        //Something other than jobs is clicked
            {                       
                List<string> items = JobData.FindAll(column);               //list items is pop with postings based on the column value
                ViewBag.title =  "All " + columnChoices[column] + " Values";
                ViewBag.column = column;
                ViewBag.items = items;
                return View();
            }
        }

        public IActionResult Jobs(string column, string value)      //Action result when a value for a column value is selected or all is selected
        {
            List<Dictionary<String, String>> jobs = JobData.FindByColumnAndValue(column, value);    //list dict jobs is populated with jobs that match chosen value in chosen column
            ViewBag.title = "Jobs with " + columnChoices[column] + ": " + value;                    
            ViewBag.jobs = jobs;

            return View();
        }
    }
}
