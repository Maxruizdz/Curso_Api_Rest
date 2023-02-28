using Curso_Api_Rest.Services;
using Microsoft.AspNetCore.Mvc;

namespace Curso_Api_Rest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWordController: ControllerBase
    {
        IHelloWordService helloWordServices;

        private readonly ILogger<HelloWordController> logger;

        public HelloWordController(IHelloWordService helloWordService , ILogger<HelloWordController> logger) { 
        
        this.logger= logger;
        this.helloWordServices = helloWordService;
        }



        public IActionResult get() {
            logger.LogInformation("Retornando Hola Mundo");
            return Ok(helloWordServices.GetHelloWorld());
        
        
        }
    }
}
