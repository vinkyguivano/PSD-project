using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDAssignment.Repository
{
    public class RoleRepository
    {
        private static MyDBEntities DB = DBSingleton.GetInstance();
        public static List<Role> getAllRole() {
            return DB.Roles.ToList();
        }
        
        public static Role getRoleByID(int roleID) {
                  return (from x in DB.Roles
                             where x.Id == roleID
                          select x).FirstOrDefault();
        }
        public static Role getRoleByName(String roleName) {
            return (from x in DB.Roles
                    where x.Name == roleName
                    select x).FirstOrDefault();
        }
    }
}