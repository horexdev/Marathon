using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;

namespace Marafon.Database
{
    public class Context
    {
        public static users FindUserByEmail(string email)
        {
            using (var context = new marathonEntities())
            {
                var user = context.users.FirstOrDefault(u => u.Email == email);

                return user;
            }
        }

        public static string FindRoleNameById(string roleId)
        {
            using (var context = new marathonEntities())
            {
                var role = context.role.FirstOrDefault(r => r.RoleId == roleId);

                return role?.RoleName;
            }
        }

        public static string GetCountryCodeByName(string countryName)
        {
            using (var context = new marathonEntities())
            {
                var country = context.country.FirstOrDefault(c => c.CountryName == countryName);

                return country?.CountryCode;
            }
        }

        public static runner GetRunnerByUser(users user)
        {
            using (var context = new marathonEntities())
            {
                return context.runner.FirstOrDefault(r => r.Email == user.Email);
            }
        }

        /// <summary>
        /// Возвращает список названий стран
        /// </summary>
        /// <returns></returns>
        public static List<string> GetCountriesList()
        {
            using (var context = new marathonEntities())
            {
                return context.country.Select(c => c.CountryName).ToList();
            }
        }

        /// <summary>
        /// Возвращает список названий гендеров
        /// </summary>
        /// <returns></returns>
        public static List<string> GetGendersList()
        {
            using (var context = new marathonEntities())
            {
                return context.gender.Select(g => g.Gender1).ToList();
            }
        }

        /// <summary>
        /// Возвращает список объектов благотворительных организаций
        /// </summary>
        /// <returns></returns>
        public static List<charity> GetFundsList()
        {
            using (var context = new marathonEntities())
            {
                return context.charity.ToList();
            }
        }
    }
}