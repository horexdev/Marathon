using System;
using System.Data.Entity.Migrations;
using Marafon.Database;

namespace Marafon
{
    public class UserApi
    {
        private static users _localUser;

        public static void SetUser(users user)
        {
            _localUser = user ?? throw new Exception("User Set Null Reference Exception");
        }

        private static void ResetUser()
        {
            _localUser = null;
        }

        public static void UpdateUser()
        {
            if (_localUser == null)
                return;

            using (var context = new marathonEntities())
            {
                context.users.AddOrUpdate(_localUser);
                context.SaveChanges();
            }
        }

        public static void Logout()
        {
            ResetUser();
            Navigation.Navigate(new MainPage());
        }
    }
}