using System;
using System.Windows.Controls;
using Marafon.Database;
using Marafon.Menu;

namespace Marafon.Auth
{
    public static class AuthHandler
    {
        public static void AuthorizeUser(users user)
        {
            var role = Context.FindRoleNameById(user.RoleId);
            Page newPage;

            switch (role)
            {
                case RoleTypes.Administrator:
                    newPage = new AdminMenu();
                    break;
                case RoleTypes.Coordinator:
                    newPage = new CoordinatorMenu();
                    break;
                case RoleTypes.Runner:
                    newPage = new RunnerMenu();
                    break;
                default:
                    throw new NullReferenceException("Undefined Role");
            }

            UserApi.SetUser(user);
            Navigation.Navigate(newPage);
        }
    }
}