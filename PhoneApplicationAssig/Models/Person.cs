using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneApplicationAssig.Models
{
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(Order = 1)]
        public int ID { get; set; }

        [Required]
        [Display(Name = "FirstName")]
        [StringLength(50)]
        public String FirstName { get; set; }

        [Required]
        [Display(Name = "LastName")]
        [StringLength(50)]
        public String LastName { get; set; }

        [Required]
        [Display(Name = "EmailId")]
        [EmailAddress]
        public String EmailId { get; set; }

        [Required]
        [Display(Name = "PhoneNumber")]
        [StringLength(13)]
        public String PhoneNumber { get; set; }

        [Required]
        [Display(Name = "AddressOne")]
        public String AddressOne { get; set; }

        [Display(Name = "AddressTwo")]
        public String AddressTwo { get; set; }

        [Required]
        [Display(Name = "PinCode")]
        public int PinCode { get; set; }

        [Required]
        [ForeignKey("Country")]
        public int CountryId { get; set; }

        [Required]
        [ForeignKey("State")]
        public int StateId { get; set; }


        [Required]
        [ForeignKey("City")]
        public int CityId { get; set; }
        public bool IsActive { get; set; } = true;
        public virtual Country Country { get; set; }
        public virtual State State { get; set; }
        public virtual City City { get; set; }
    }
}