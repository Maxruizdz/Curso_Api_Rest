using Microsoft.AspNetCore.Mvc;
using Curso_Api_Rest.Services;
using webapi.Modelos;

namespace Curso_Api_Rest.Controllers
{
    [Route ("Api/{controller}")]
    public class TareaController: ControllerBase
    {
        ITareaServices services;
        public TareaController(ITareaServices tareaServices) {


            services = tareaServices;

        
        
        }


        [HttpGet]

        public IActionResult Get() {

            services.Get();
            return Ok();
        
        }
        [HttpPost("{id_categoria}")]


        public IActionResult Post([FromBody]Tarea tarea, Guid id_categoria)
        {

            services.Save(tarea, id_categoria);

            return Ok();
        }
        [HttpPut("{id_tarea}/{id_categoria}")]


        public IActionResult Put(Guid id_tarea, Guid id_categoria, Tarea tarea) {
            services.Update(id_tarea,tarea, id_categoria);

            return Ok();
        
        }

        [HttpDelete("{id_tarea}")]



        public IActionResult Delete(Guid id_tarea) {


            services.Delete(id_tarea);

            return Ok();
        
        
        
        
        }




    }




    }
}
