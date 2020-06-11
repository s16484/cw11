using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace APICodeFirst.Models
{
    public class Prescription_Medicament
    {
        public  int IdPrescription { get; set; }
        public  int IdMedicament { get; set; }
        public int? Dose { get; set; }
        [MaxLength(100)]
        [Required]
        public string Details { get; set; }

        [ForeignKey("IdPrescription")]
        public virtual Prescription Prescription { get; set; }
        [ForeignKey("IdMedicament")]
        public virtual Medicament Medicament { get; set; }
    }
}
