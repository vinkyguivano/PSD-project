using PSDAssignment.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDAssignment.Controller
{
    public class LoginController
    {
        public static Boolean isEmpty(String input)
        {
            if (input == "") return true;
            return false;
        }


        public static Boolean LoginValidation(String email, String password)
        {
            if (isEmpty(email) || isEmpty(password))
            {
                return false;
            }
            else return true;
        }


        public static int Login(String email, String password, Boolean RememberMe)
        {
            User loginUser = UserHandler.FindUser(email, password);
            if (loginUser != null)
            {
                if (loginUser.Status == "Inactive")
                {
                    return -1;
                }
                else
                {
                    if (RememberMe)
                    {
                        // If user choose to store cookies
                        HttpCookie cookie = new HttpCookie("auth_user", loginUser.Id.ToString());
                        cookie.Expires = DateTime.Now.AddHours(1.0);
                        HttpContext.Current.Response.Cookies.Add(cookie);
                    }
                    HttpContext.Current.Session.Add("auth_user", loginUser.Id);
                    return 1;
                }

            }
            else
            {
                return -2;
            }
        }
    }
}