using Microsoft.AspNetCore.Mvc;
namespace FrontEnd.Utils;
public static class UtilsCookie {
    public const string UserLoginToken = "soTayKetCauToken";
    public static void SetCookie(this Controller controller, string value) {
        controller.Response.Cookies.Append(UserLoginToken, value);
    }
    public static string GetCookie(this Controller controller) {
        var token = controller.Request.Cookies[UserLoginToken];
        return string.IsNullOrEmpty(token) ? "" : token.Replace("\"", "");
    }
}