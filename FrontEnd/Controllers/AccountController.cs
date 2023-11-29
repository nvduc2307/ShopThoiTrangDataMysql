using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers;

public class AccountController : Controller {
    private readonly ILogger<AccountController> _ilogger;
    public AccountController(ILogger<AccountController> logger)
    {
        _ilogger = logger;
    }
}