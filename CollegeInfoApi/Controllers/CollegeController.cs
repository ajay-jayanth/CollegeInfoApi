using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Models;

namespace Controllers
{
    [Produces("application/json")]
    [Route("api/colleges")]
    public class CollegeController
    {
        College[] colleges = new College[] // Array of Colleges FIXME: Reference to database
        {
            new College {Pk = "1", Name = "University of North Texas", Location = "Texas"},
            new College {Pk = "2", Name = "Stanford University", Location = "California"},
            new College {Pk = "3", Name = "University of Austin at Texas", Location = "Texas"},
            new College {Pk = "4", Name = "Harvard University", Location = "Massachusetts"}
        };

        [HttpGet]
        public IEnumerable<College> ListAllColleges() // Return all colleges
        {
            return colleges;
        }

        [HttpGet("pk/{pkart}")]
        public IEnumerable<College> ListCollegesByPk(string pkart) // Search by Pk
        {
             IEnumerable<College> retVal =
                from g in colleges 
                where g.Pk.Equals(pkart) 
                select g;

            return retVal;

        }

        [HttpGet("name/{namart}")]
        public IEnumerable<College> ListCollegesByName(string namart) // Search by name
        {
            IEnumerable<College> retVal = 
                from g in colleges
                where g.Name.ToUpper().Contains(namart.ToUpper())
                orderby g.Pk
                select g;
                
            return retVal;
            
        }

        [HttpGet("location/{locart}")]
        public IEnumerable<College> ListCollegesByLocation(string locart) // Search by Location
        {
            IEnumerable<College> retVal = 
                from g in colleges
                where g.Location.ToUpper().Contains(locart.ToUpper())
                orderby g.Pk
                select g;
                
            return retVal;
        }
    }
}
