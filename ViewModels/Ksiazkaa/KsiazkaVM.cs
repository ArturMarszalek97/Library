using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjektNET.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjektNET.ViewModels.Zawodnik
{
    public class KsiazkaVM : ProjektNET.Models.Ksiazka
    {
        public KsiazkaVM() { }

        public KsiazkaVM(ProjektNET.Models.Ksiazka s)
        {
            bookID = s.bookID;
            title = s.title;
            lastName = s.lastName;
            price = s.price;
        }
       /* [Display(Name = "Nazwisko i imię")]
        public string name
        {
            get
            {
                return lastName + "" + firstName;
            }
        }
        public string colorAge
        {
            get
            {
                if (age < 18)
                {
                    return "yellow";
                }
                return "white";
            }
        }*/
    }
}