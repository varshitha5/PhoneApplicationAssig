using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneApplicationAssig.Models
{
    public class Country
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(Order = 1)]
        public int ContryId { get; set; }

        [Display(Name = "CountryName")]
        [Required]
        public String CountryName { get; set; }
        public bool IsActive { get; set; } = true;
        public virtual ICollection<State> States { get; set; }
    }
}