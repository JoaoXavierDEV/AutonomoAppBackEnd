using ASPNET.Api.Controllers;
using AutonomoApp.Business.DTO;
using AutonomoApp.Business.Interfaces.IRepository;
using AutonomoApp.Business.Interfaces.IService;
using AutonomoApp.Business.Models;
using AutonomoApp.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutonomoApp.Api.Controllers
{
    [ApiController]
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

        [HttpGet("ObterTodasCategorias")]
        public async Task<List<Categoria>> ObterTodasCat()
        {
            var tt = await _categoriaRepository.ObterTodos();
            return tt;
        }

        [HttpGet("ObterServicoPorID")]
        public async Task<ServicoDTO> ObterServico()
        {
            var idServico = Guid.Parse("062932e5-7aa2-4cf0-8bea-a406233fdcf0");
            var dto = await _servicoService.ObterServicoDTO(idServico);
            return dto;
        }
    }

}
