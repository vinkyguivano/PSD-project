using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSDAssignment.Repository;
using PSDAssignment.Factory;

namespace PSDAssignment.Handler
{
    public class UserHandler
    {
        public static User FindUser(String email, String password)
        {
            return UserRepository.FindUser(email, password);
        }

        public static User findUserByID(int userId) {
            return UserRepository.getUserByID(userId);
        }

        public static void register(string name, string email, string password, string status, string gender, int roleID)
        {
            User newUser = UserFactory.createUser(name, email, password, status, gender, roleID);
            UserRepository.createUser(newUser);
        }

        public static User getUserbyEmail(String email)
        {
            return UserRepository.getUserByEmail(email);
        }

        public static List<User> getAllUsers()
        {
            return UserRepository.getAllUser();
        }

        public static void updateUserRole(int Id, int roleID)
        {
            UserRepository.updateUserRole(Id, roleID);
        }

        public static void updateUserStatus(int Id, String status)
        {
            UserRepository.updateUserStatus(Id, status);
        }

        public static void update (int id, String email, String name, String gender)
        {
            UserRepository.updateUser(id, email, name, gender);
        }

        public static void updatePassword (int id, String password)
        {
            UserRepository.updateUserPassword(id, password);
        }
    }
}