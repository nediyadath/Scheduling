using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIMultipleAPICallsSingleMethod.Models
{
    public class Patient
    {
        public int id { get; set; }
        public string name { get; set; }
        public string ailment { get; set; }
        public string photo { get; set; }
        public string allergies { get; set; }
    }

    public class Doctor
    {

        public int id { get; set; }
        public string name { get; set; }
        public string speciality { get; set; }
    }

    public class HospitalContext: DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options): base(options)
        {

        }
        public DbSet<Patient> patients{ get; set; }
        public DbSet<Doctor> doctors { get; set; }
    }

    [NotMapped]
    public class Request
    {
        public Patient pt { get; set; }
        public Doctor doc { get; set; }
        public int id { get; set; }
        public string type { get; set; }
        public string action { get; set; }

    }
}
