using Clinic_Registration_and_Management.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Registration_and_Management.ApplicationDBclinicDb
{
    public class ApplicationDBClining : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-H0S7VNS\\MSSQLSERVER02;Initial catalog = Clinic Registration and Management ;Integrated Security=True;");
        }
        public DbSet<Patients> patientss { get; set; }
        public DbSet<Book_appointment> book_appointment { get; set; }
        public DbSet<medical_specialization> specializations { get; set; }
        
      
    }
}
