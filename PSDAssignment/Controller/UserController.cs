using PSDAssignment.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDAssignment.Controller
{
    public class UserController
    {
        public static User getUserByID(int userid)
        {
            return UserHandler.findUserByID(userid);
        }
        public static List<User> getAllUsers()
        {
            return UserHandler.getAllUsers();
        }

        public static void updateUserRole(int Id, int roleID)
        {
            UserHandler.updateUserRole(Id, roleID);
        }

        public static void updateUserStatus(int Id, String status)
        {
            UserHandler.updateUserStatus(Id, status);
        }

        public static Boolean emailValidation (String email, String oldEmail)
        {
           if(email != oldEmail)
            {
                return RegisterController.EmailValidation(email);
            }
            return true;

        }
        
        public static Boolean isEmpty(String input)
        {
            return RegisterController.isEmpty(input);
        }

        public static Boolean userValidation (String email, String name, String gender, String oldEmail)
        {
                if (isEmpty(name) || !emailValidation(email,oldEmail) || isEmpty(gender)) return false;
                return true;       
        }

        public static int passwordValidation(String oldPass, String newPass, String confirm)
        {
            User user = getUserByID(Convert.ToInt32(HttpContext.Current.Session["auth_user"]));
            String password = user.Password;
            int id = user.Id;
            if (oldPass != password)
            {
                return -1;
            }
            else if (newPass == "")
            {
                return -2;
            }
            else if (newPass == password)
            {
                return -3;
            }
            else if (confirm != newPass)
            {
                return -4;
            }
            else
            {
                updatePassword(user.Id, newPass);
                return 1;
            }
           
        }

        public static void update(int id, String email, String name, String gender)
        {
            UserHandler.update(id, email, name, gender);
        }

        public static void updatePassword(int id, String password)
        {
            UserHandler.updatePassword(id, password);
        }
    }
}