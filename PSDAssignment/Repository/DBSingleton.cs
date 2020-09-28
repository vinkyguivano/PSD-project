using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDAssignment.Repository
{
    public class DBSingleton
    {
        private static MyDBEntities db;
        public static MyDBEntities GetInstance()
        {
            if (db == null)
            {
                db = new MyDBEntities();
            }
            return db;
        }
    }
}