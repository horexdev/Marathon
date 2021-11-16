using System;
using System.Windows.Controls;
using Marafon.Database;
using Marafon.Menu;

namespace Marafon.Auth
{
    public class AuthHandler
    {
        public void AuthorizeUser(users user)
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

            // Проверка на существование аватара у пользователя
            if (UserApi.IsUserHaveAvatar())
            {
                var bitmapImage = UserApi.ConvertBinaryToAvatar(user.Avatar);
                var avatar = (Image)newPage.FindName("Avatar");

                if (avatar != null)
                    avatar.Source = bitmapImage;
            }

            var loginTextBlock = (TextBlock) newPage.FindName("LoginTextBlock");

            if (loginTextBlock != null)
                loginTextBlock.Text = $"{user.FirstName} {user.LastName}";

            Navigation.Navigate(newPage);
        }
    }
}