using System;
using System.Data.Entity.Migrations;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
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

        public static bool IsUserHaveAvatar() => _localUser.Avatar?.Length > 0;

        public static byte[] ConvertAvatarToBinary(string path)
        {
            using (var st = new FileStream(path, FileMode.Open))
            {
                var buffer = new byte[st.Length];
                st.Read(buffer, 0, (int)st.Length);

                return buffer;
            }
        }

        public static BitmapImage ConvertBinaryToAvatar(byte[] buffer)
        {
            using (var memoryStream = new MemoryStream(buffer))
            {
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memoryStream;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }
    }
}