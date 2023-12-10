using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ShopThoiTrang.BackEnd.Databases;
using ShopThoiTrang.BackEnd.Entities;

namespace ShopThoiTrang.BackEnd.Utils;
public static class UtilsAccounts {
    public static ModelUser CheckCurrentuser(this ControllerBase controllerBase) {
        var identity = controllerBase.HttpContext.User.Identities.First();
        if(identity == null) return null;
        var userClaims = identity.Claims;
        var result = new ModelUser() {
            UserName = userClaims.First(x => x.Type == ClaimTypes.Name)?.Value,
            Email = userClaims.First(x => x.Type == ClaimTypes.Email)?.Value,
            Password = userClaims.First(x => x.Type == ClaimTypes.Upn)?.Value,
        };
        return result;
    }
}