using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjektNET.ViewModels.Zawodnik;


namespace ProjektNET.ViewModels.Zawodnik
{
    public class DeleteVM : KsiazkaVM
    {
        public KsiazkaVM user { get; set; }
        public string username { get; set; }
    }
}