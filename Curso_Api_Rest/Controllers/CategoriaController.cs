using Curso_Api_Rest.Services;
using Microsoft.AspNetCore.Mvc;
using webapi.Modelos;

namespace Curso_Api_Rest.Controllers
{
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        ICategoriaService categoria_services;




        public CategoriaController(ICategoriaService categoria) {

            categoria_services = categoria;


        }

        [HttpGet]
        public IActionResult Get() {

            return Ok(categoria_services.Get());


        }


        [HttpPost]


        public IActionResult Save([FromBody] Categoria categoria) {

            categoria_services.Save(categoria);

            return Ok();

        }
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Categoria categoria,  Guid id)
        {

            categoria_services.Update(id, categoria);

            return Ok();

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {

            categoria_services.Delete(id);

            return Ok();

        }


    }
}
