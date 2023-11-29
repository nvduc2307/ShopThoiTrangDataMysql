using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using ShopThoiTrang.BackEnd.Entities;
using ShopThoiTrang.BackEnd.UnitOfWorks;
using ShopThoiTrang.BackEnd.Utils;

namespace ShopThoiTrang.BackEnd.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase {
    private IConfiguration _configuration;
    private IUnitOfWork _unitOfWork;
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger, IUnitOfWork unitOfWork, IConfiguration configuration)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _configuration = configuration;
    }
    [Route("/api/users")]
    [HttpGet]
    public async Task<List<UserEntity>> GetUsers() {
        var users = await _unitOfWork.IUserRepository.GetUsers();
        return users;
    }

    [Route("/api/users/login")]
    [HttpPost]
    public async Task<string> Login(LogginInfo logginInfo) {
        var token = "";
        var user = await _unitOfWork.IUserRepository.Login(logginInfo);
        if (user != null)
        {
            var claims = new List<Claim>() {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Upn, user.Password),
            };
            token = GenerateJWT.CreateJwtToken(claims, _configuration);
        } else
        {
            token = "-1";
        }
        
        return token;
    }
}