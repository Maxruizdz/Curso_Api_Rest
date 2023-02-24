using Curso_Api_Rest.Services;
using Microsoft.AspNetCore.Mvc;

namespace Curso_Api_Rest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWordController: ControllerBase
    {
        IHelloWordService helloWordServices;


        public HelloWordController(IHelloWordService helloWordService) { 
        
        
        this.helloWordServices = helloWordService;
        }



        public IActionResult get() {

            return Ok(helloWordServices.GetHelloWorld());
        
        
        }
    }
}
