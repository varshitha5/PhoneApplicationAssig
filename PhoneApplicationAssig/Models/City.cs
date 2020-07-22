using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneApplicationAssig.Models
{
    public class City
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(Order = 1)]
        public int CityId { get; set; }

        [Required]
        [Display(Name = "CityName")]
        public String CityName { get; set; }

        [Required]
        [ForeignKey("State")]
        public int StateId { get; set; }
        public bool IsActive { get; set; } = true;
        public virtual State State { get; set; }
    }
}