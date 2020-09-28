using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDAssignment.Repository
{
    
    public class UserRepository
    {
        private static MyDBEntities DB = DBSingleton.GetInstance();
        public static User FindUser(String email, String password)
        {
            return DB.Users.Where(x => x.Email.Equals(email) && x.Password.Equals(password)).FirstOrDefault();
        }

        public static void createUser(User user) {
            DB.Users.Add(user);
            DB.SaveChanges();
        }

        public static List<User> getAllUser() {
            return DB.Users.ToList();
        }

        public static void updateUserStatus(int Id, String status) {
            User user = UserRepository.getUserByID(Id);
            
            user.Status = status;
            DB.SaveChanges();
        }

        public static User getUserByID(int userID) {
            return DB.Users.Where(x => x.Id.Equals(userID)).FirstOrDefault();
        }

        public static User getUserByEmail(String email)
        {
            return DB.Users.Where(x => x.Email.Equals(email)).FirstOrDefault();
        }
        public static void updateUserRole(int Id, int roleID)
        {
            User user = UserRepository.getUserByID(Id);
            user.RoleID = roleID;
            DB.SaveChanges();
        }
        public static Boolean isAvailableEmail(String email)
        {
            User user = UserRepository.getUserByEmail(email);
            if (user != null)
            {
                return false;
            }
            return true;

        }
        public static void updateUser(int id, String name, String email, String gender) {
            User user = UserRepository.getUserByID(id);
            user.Name = name;
            user.Email = email;
            user.Gender = gender;
            DB.SaveChanges();
        }
      
        public static void updateUserPassword(int id, String password) {
            User user = UserRepository.getUserByID(id);
            user.Password = password;
            DB.SaveChanges();
        }
        
    }
}