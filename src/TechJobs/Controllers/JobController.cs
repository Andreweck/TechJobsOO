using Microsoft.AspNetCore.Mvc;
using TechJobs.Data;
using TechJobs.ViewModels;
using System.Net;
using TechJobs.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TechJobs.Controllers
{
    public class JobController : Controller
    {

        // Our reference to the data store
        private static JobData jobData;

        static JobController()
        {
            jobData = JobData.GetInstance();
        }

        // The detail display for a given Job at URLs like /Job?id=17
        
        public IActionResult Index(int id)
        {
            // TODO #1 - get the Job with the given ID and pass it into the view

           ViewBag.Columns = jobData.Find(id);    

            return View();
        }

        public IActionResult New()
        {
            NewJobViewModel newJobViewModel = new NewJobViewModel();
            return View(newJobViewModel);
        }

        [HttpPost]
        public IActionResult New(NewJobViewModel newJobViewModel)
        {
            // TODO #6 - Validate the ViewModel and if valid, create a 
            // new Job and add it to the JobData data store. Then
            // redirect to the Job detail (Index) action/view for the new Job.
            string Name = Request.Form["Name"];
            
            if (Name != "")
            {
                
                Job newJob = new Job
                {
                    Name = Name,
                    Employer = jobData.Employers.AddUnique(Request.Form["EmployerID"]),
                    Location = jobData.Locations.AddUnique(Request.Form["Location"]),
                    PositionType = jobData.PositionTypes.AddUnique(Request.Form["PositionType"]),
                    CoreCompetency = jobData.CoreCompetencies.AddUnique(Request.Form["CoreCompetency"])
                };
                jobData.Jobs.Add(newJob);
                JobFieldsViewModel view = new JobFieldsViewModel();
                int Columns = newJob.ID;
                string pass = string.Format("Index?id={0}", Columns);
                return Redirect(pass);
            }
            else
            {
                NewJobViewModel newJobView = new NewJobViewModel();
                return View(newJobView);
            }
        }
    }
}
