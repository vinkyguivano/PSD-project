using PSDAssignment.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDAssignment.Controller
{
    public class RoleController
    {
        public static List<Role> getAllRole()
        {
            return RoleHandler.getAllRole();
        }

        public static Role getRoleByID(int roleID)
        {
            return RoleHandler.getRoleByID(roleID);
        }

        public static Role getRoleByName(String roleName)
        {
            return RoleHandler.getRoleByName(roleName);
        }

        
    }
}