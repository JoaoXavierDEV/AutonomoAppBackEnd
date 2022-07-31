using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AutonomoApp.WebApi.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase{
        protected MainController()
        {
            
        }
    }
}
