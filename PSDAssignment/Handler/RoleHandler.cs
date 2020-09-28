using PSDAssignment.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDAssignment.Handler
{
    public class RoleHandler
    {

        public static List<Role> getAllRole()
        {
            return RoleRepository.getAllRole();
        }

        public static Role getRoleByID(int roleID)
        {
            return RoleRepository.getRoleByID(roleID);
        }

        public static Role getRoleByName(String roleName)
        {
            return RoleRepository.getRoleByName(roleName);
        }
    }
}