using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ShopThoiTrang.BackEnd.Utils;

public class GenerateJWT {
    public static string CreateJwtToken(List<Claim> authClaims, IConfiguration configuration) {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
        _ = int.TryParse(configuration["JWT:TokenValidityInMinutes"], out int tokenValidityInMinutes);
        var tokenInfo = new JwtSecurityToken(
            issuer: configuration["JWT:ValidIssuer"],
            audience: configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddMinutes(tokenValidityInMinutes),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );
        var token = new JwtSecurityTokenHandler().WriteToken(tokenInfo);
        return token;
    } 
}