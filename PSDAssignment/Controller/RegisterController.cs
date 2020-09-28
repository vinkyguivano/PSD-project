using PSDAssignment.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDAssignment.Controller
{
    public class RegisterController
    {
        public static Boolean EmailValidation(String email)
        {
            if (isUnique(email) && email != "") return true;
            return false;
        }

        public static Boolean isUnique(String email)
        {
            User user = UserHandler.getUserbyEmail(email);
            if (user == null) return true;
            return false;
        }

        public static Boolean isEmpty(String input)
        {
            if (input == "") return true;
            return false;
        }

        public static Boolean RePasswordValidation(String password, String repassword)
        {
            if (password == repassword) return true;
            return false;
        }

        


        public static Boolean register(string name, string email, string password, string status, string gender, int roleID, string repassword)
        {
            if (!EmailValidation(email) || isEmpty(name) || isEmpty(password) || 
                !RePasswordValidation(password,repassword) || isEmpty(gender))
            {
                return false;
            }

            else
            {
                UserHandler.register(name, email, password, status, gender, roleID);
                return true;
            }
        }


    }
}