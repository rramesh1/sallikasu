using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SallikasuServices.Models
{
    public class RegisterUserModel
    {
        nasthaEntities DB { get; set; }
        public RegisterUserModel()
        {
            DB = new nasthaEntities();
        }
        public List<user> GetUsers( String Type)
        {
            List<user> tUsers = (from m in DB.users from n in DB.user_types orderby m.id where m.user_type_id == n.id && n.user_type == Type select m).ToList<user>();

            return tUsers;
        }
        public user GetUser(int id)
        {
            user tuser = (from m in DB.users where m.id == id select m).SingleOrDefault();
            return tuser;
        }
        public void DeleteUser(int id)
        {
            user tUser = (from m in DB.users where m.id == id select m).SingleOrDefault();
            if ( tUser != null)
            {
                DB.users.Remove(tUser);
                DB.SaveChanges();
            }
        }
        public void SetUser(user User)
        {
            DB.users.Add(User);
            DB.SaveChanges();
        }
    }
}