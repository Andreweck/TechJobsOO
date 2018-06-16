using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TechJobs.Data;
using TechJobs.Models;

namespace TechJobs.ViewModels
{
    public class NewJobViewModel
    {
        

        
        [Display(Name = "Employer")]
        public int EmployerID { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set;  }
        
        [Display(Name = "Skill")]
        public CoreCompetency CoreCompetency { get; set; }
        
        [Display(Name = "Postition Type")]
        public PositionType PositionType { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        // TODO #3 - Included other fields needed to create a job,
        // with correct validation attributes and display names.

        public List<SelectListItem> Employers { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Locations { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> CoreCompetencies { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> PositionTypes { get; set; } = new List<SelectListItem>();

        public NewJobViewModel()
        {

            JobData jobData = JobData.GetInstance();

            foreach (Employer field in jobData.Employers.ToList())
            {
                Employers.Add(new SelectListItem {
                    Value = field.ToString(),
                    Text = field.Value
                });
            }
            foreach (Location field in jobData.Locations.ToList())
            {
                Locations.Add(new SelectListItem
                {
                    Value = field.ToString(),
                    Text = field.Value
                });
            }
            foreach (PositionType field in jobData.PositionTypes.ToList())
            {
                PositionTypes.Add(new SelectListItem
                {
                    Value = field.ToString(),
                    Text = field.Value
                });
            }
            foreach (CoreCompetency field in jobData.CoreCompetencies.ToList())
            {
                CoreCompetencies.Add(new SelectListItem
                {
                    Value = field.ToString(),
                    Text = field.Value
                });
            }
            // TODO #4 - populate the other List<SelectListItem> 
            // collections needed in the view

        }
    }
}
