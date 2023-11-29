using System.Security.Claims;

namespace TEMPLATE_ELDOS_BACKEND.App
{
    public static class UserHelper
    {
        public static int GetCompanyId(this System.Security.Principal.IPrincipal CurrentUser)
        {
            ClaimsIdentity? identity = CurrentUser.Identity as ClaimsIdentity;

            var CompanyId = 0;

            if (identity != null && identity?.Claims != null)
            {
                var companyClaim = identity.Claims.FirstOrDefault(c => c.Type == "CompanyId");

                if (companyClaim?.Value != null)
                {
                    CompanyId = int.Parse(companyClaim.Value);
                }
            }

            return Convert.ToInt32(CompanyId);
        }

        public static int GetPuId(this System.Security.Principal.IPrincipal CurrentUser)
        {
            var identity = (ClaimsIdentity)CurrentUser.Identity;

            var PuId = identity.Claims.FirstOrDefault(c => c.Type == "PuId").Value;

            return Convert.ToInt32(PuId);
        }

        public static int GetId(this System.Security.Principal.IPrincipal CurrentUser)
        {
            var identity = CurrentUser.Identity as ClaimsIdentity;

            var Id = 0;

            if (identity != null && identity?.Claims != null)
            {
                var companyClaim = identity.Claims.FirstOrDefault(c => c.Type == "UserId");

                if (companyClaim?.Value != null)
                {
                    Id = int.Parse(companyClaim.Value);
                }
            }

            return Id;
        }

        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        // Метод для проверки хеша пароля
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}