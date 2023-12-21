using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Registration_and_Management.Model
{
    public class Book_appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppointmentID { get; set; }

        [Required]
        public string Appointment_Date { get; set; }

        [Required]
        public string Appointment_Time { get; set; }

        public string Appointment_Status { get; set; }

        [ForeignKey("PatientID")]
        public int Idcard { get; set; }
        public Patients Patient { get; set; }

        [ForeignKey("SpecializationID")]
        public int? SpecializationID { get; set; }
        public medical_specialization specializations { get; set; }

    }
}
