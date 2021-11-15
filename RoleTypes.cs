namespace Marafon
{
    public class RoleTypes
    {
        public const string Administrator = "Administrator";
        public const string Coordinator = "Coordinator";
        public const string Runner = "Runner";

        public static string GetAbbreviation(string role)
        {
            if (role == Administrator || role == Coordinator || role == Runner)
                return role.Remove(1);

            return null;
        }
    }
}