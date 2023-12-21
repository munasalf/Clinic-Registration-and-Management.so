using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Registration_and_Management.Model
{
    public class medical_specialization
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SpecializationID { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name must be 50 characters or less"), MinLength(3)]
        public string  SpecializationName { get; set; }
        public string  Detiles { get; set; }


    }
}
