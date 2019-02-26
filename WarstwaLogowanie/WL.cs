using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjektNET.BazaDanych;
using ProjektNET.ViewModels.Uwierzytelnianie;

namespace ProjektNET.WarstwaLogowanie
{
    public class WL
    {
        public bool isValidUser(LoginVM vm)
        {
            DB mDB = new DB();
            List<LoginVM> lista = mDB.adminsDB.ToList();
            string username = vm.username;
            string password = vm.hashPassword();
            if (lista.Any(x => x.password == password && x.username == username))
            {
                return true;
            }
            return false;
            
        }
        public bool isUserNameAvailable(string username)
        {
            DB mDB = new DB();
            List<LoginVM> lista = mDB.adminsDB.ToList();
            if (lista.Any(x => x.username == username))
            {
                return false;
            }
            return true;
        }
    }
}