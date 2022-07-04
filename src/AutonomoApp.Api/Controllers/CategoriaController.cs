using ASPNET.Api.Controllers;
using AutonomoApp.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutonomoApp.Api.Controllers
{
    [ApiController]
    public class CategoriaController : MainController
    {
        //private readonly CategoriaService _categoriaServiceservice;

        //public CategoriaController(CategoriaService categoriaServiceservice)
        //{
        //    _categoriaServiceservice = categoriaServiceservice;
        //}

        [HttpGet("categoria/{categoria:int}/subcategoria/{subcategoria:int}")]
        public ActionResult<string> ObterCategoria(int categoria, int subcategoria)
        {
            try
            {
                ArgumentNullException.ThrowIfNull((categoria ,subcategoria));
              //  if (categoria == null || subcategoria == null) 
              //      throw new ArgumentNullException("Todos os campos são obrigatórios");
                // lembrando que ele deve chamar a service, falta instanciar ela via dependencia
                var result = new CategoriaBuilder(categoria, subcategoria);



                return Ok(result.ToString());

            }
            catch (Exception e)
            {
               return NotFound(e.Message);

            }
            // var result = _categoriaServiceservice.CreatCat(categoria, subcategoria);
        }
    }
}
