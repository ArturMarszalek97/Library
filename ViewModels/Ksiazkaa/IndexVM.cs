using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjektNET.ViewModels.Zawodnik;


namespace ProjektNET.ViewModels.Zawodnik
{
    public class IndexVM : KsiazkaVM
    {
        public List<KsiazkaVM> userList { get; set; }
        public string username { get; set; }
    }
}