using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDAssignment.Factory
{
    public class UserFactory
    {
        public static User createUser(String name, String email, String password, String status, String gender, int roleID) {
            return new User()
            {
                Name = name,
                Email = email,
                Password = password,
                Status = status,
                Gender = gender,
                RoleID = roleID
            };
        }

    }
}