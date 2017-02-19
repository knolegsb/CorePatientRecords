using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CorePatientRecords.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CorePatientRecords.Controllers
{
    [Route("api/[controller]")]
    public class PatientController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id, string name = "Unknown")
        {
            ViewData["PatientId"] = id;
            ViewData["PatientName"] = name;
            return View();
        }

        Patient[] patients = new Patient[]
        {
            new Patient
            {
                Id = 1,
                FirstName = "John",
                LastName = "Smith",
                SocialSecurityNumber = "324251562"
            },
            new Patient
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Doe",
                SocialSecurityNumber = "452120353"
            },
            new Patient
            {
                Id = 3,
                FirstName = "Lisa",
                LastName = "Mulbren",
                SocialSecurityNumber = "210230012"
            }
        };

        // GET: api/patient
        [HttpGet]
        public IEnumerable<Patient> Get()
        {
            return patients;
        }

        // Get api/patients
        [HttpGet("{id}")]
        public Patient Get(int id)
        {
            var patient = patients.FirstOrDefault(p => p.Id == id);
            if (patient == null)
            {
                return null;
            }
            return patient;
        }
    }
}
