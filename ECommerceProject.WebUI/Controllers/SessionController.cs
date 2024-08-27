using Microsoft.AspNetCore.Mvc;
namespace ECommerceProject.WebUI.Controllers;
public class SessionController : Controller
{
    public IActionResult Index()
    {
        HttpContext.Session.SetInt32("age",25);
        HttpContext.Session.SetString("name", "Elvin");
        return Ok();
    }

    public IActionResult Get()
    {
        string ? name = HttpContext.Session.GetString("name");
        int ? age = HttpContext.Session.GetInt32("age");
        return Ok($"Name : {name} Age : {age}");
    }
}
