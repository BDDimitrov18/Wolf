using System.IdentityModel.Tokens.Jwt;

namespace WolfAPI.Utils
{
    public static class JwtUtils
    {
        public static string GetJwtTokenFromContext(HttpContext context)
        {
            var authHeader = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);
            return authHeader;
        }

        public static string GetClientIdFromJwt(string jwtToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwtToken) as JwtSecurityToken;
            return jsonToken?.Claims.First(claim => claim.Type == "sub").Value; // Assuming "sub" is used for client ID
        }
    }

}
