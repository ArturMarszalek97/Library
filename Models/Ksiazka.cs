using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjektNET.Models
{
    [Table("Users")]
    public class Ksiazka
    {
        [Key]
        [Display(Name = "ID")]
        [Required(ErrorMessage = "ID książki jest wymagany!")]
        public int bookID { get; set; }

        [Display(Name = "Tytuł")]
        [Required(ErrorMessage = "Tytuł jest wymagany!")]
        public string title { get; set; }

        [Display(Name = "Autor")]
        [Required(ErrorMessage = "Nazwisko jest wymagane!")]
        public string lastName { get; set; }

        [Display(Name = "Cena")]
        [Range(0, 100, ErrorMessage = "Cena książki musi być z przediału 0-100!")]
        [Required(ErrorMessage = "Cena książki jest wymagana!")]
        public int price { get; set; }
    }
}