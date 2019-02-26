using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ProjektNET.Models;
using ProjektNET.ViewModels.Uwierzytelnianie;

namespace ProjektNET.BazaDanych
{
    public class DB : DbContext
    {
        public DB() : base("gr2")
        {

        }

        public DbSet<Ksiazka> userDB { get; set; }

        public DbSet<LoginVM> adminsDB { get; set; }


    }
}