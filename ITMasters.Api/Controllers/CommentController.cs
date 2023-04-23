using Microsoft.AspNetCore.Mvc;

namespace ITMasters.Api.Controllers;

public class CommentController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}