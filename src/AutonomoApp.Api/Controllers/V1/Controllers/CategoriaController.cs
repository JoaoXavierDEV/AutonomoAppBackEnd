using AutonomoApp.Business.DTO;
using AutonomoApp.Business.Interfaces.IRepository;
using AutonomoApp.Business.Interfaces.IService;
using AutonomoApp.Business.Models;
using AutonomoApp.Business.Services;
using AutonomoApp.Data.Repository;
using AutonomoApp.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AutonomoApp.WebApi.Controllers.V1.Controllers
{
    [ApiVersion("1.5",Deprecated = false)]
    [Route("api/v{version:apiVersion}/categorias")]
    [Produces("application/json")]
    public class CategoriaController : MainController
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IServicoRepository _servicoRepository;
        private readonly IServicoService _servicoService;

        public CategoriaController(ICategoriaRepository categoriaRepository, IServicoRepository servicoRepository, IServicoService servicoService)
        {
            _categoriaRepository = categoriaRepository;
            _servicoRepository = servicoRepository;
            _servicoService = servicoService;
        }

        [HttpPost("categoria/{categoria:int}/subcategoria/{subcategoria:int}")]
        public ActionResult<string> ObterCategoria(int categoria, int subcategoria)
        {
            try
            {
                ArgumentNullException.ThrowIfNull((categoria, subcategoria));
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

        [HttpGet("ObterTodasCategorias")]
        public async Task<List<Categoria>> ObterTodasCat()
        {
            var tt = await _categoriaRepository.ObterTodasCategorias();

            return tt;
        }

        [HttpGet("ObterSubcategorias")]
        public async Task<List<Subcategoria>> ObterSubcat()
        {
            return await _categoriaRepository.ObterTodasCategoriasESubcategorias();
        }

        [HttpGet("ObterServicoPorID")]
        public async Task<ServicoDTO> ObterServico()
        {
            var idServico = Guid.Parse("062932e5-7aa2-4cf0-8bea-a406233fdcf0");

            var tt = await _categoriaRepository.ObterTodos();
            var result = _servicoRepository
                .Consultar<Categoria>().ToList();


            var dto = await _servicoService.ObterServicoDTO(idServico);

            return dto;
        }


    }

}
