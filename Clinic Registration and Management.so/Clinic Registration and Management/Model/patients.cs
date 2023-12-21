using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Registration_and_Management.Model
{
    public class Patients
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Idcard {  get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "First Name must be 30 characters or less"), MinLength(4)]
        public string FullName { get; set; }
        public int Age { get; set; }

        public string Description { get; set; }
        [Phone]
        [Required(ErrorMessage = "Phone no. is required")]
        public long PhoneNumber {  get; set; }

    }
}
