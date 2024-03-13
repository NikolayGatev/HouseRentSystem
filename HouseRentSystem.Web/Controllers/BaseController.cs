using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentSystem.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {        
    }
}
