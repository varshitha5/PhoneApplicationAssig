using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneApplicationAssig.Models
{
    public class State
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(Order = 1)]
        public int SateId { get; set; }

        [Required]
        [Display(Name = "StateName")]
        public String StateName { get; set; }

        [Required]
        [ForeignKey("Country")]
        public int CountryId { get; set; }

        public bool IsActive { get; set; } = true;
        public virtual Country Country { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}