using AutoMapper;
using AutonomoApp.Business.DTO;
using AutonomoApp.Business.Interfaces.IRepository;
using AutonomoApp.Business.Interfaces.IService;
using AutonomoApp.Business.Models;
using AutonomoApp.Business.Services;
using AutonomoApp.Data.Repository;
using AutonomoApp.WebApi.Controllers;
using AutonomoApp.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace AutonomoApp.WebApi.Controllers.V1.Controllers
{
    [ApiVersion("1.0", Deprecated = false)]
    [ApiVersion("1.1", Deprecated = false)]
    [Route("api/v{version:apiVersion}/categorias")]
    [Produces("application/json")]
    public class CategoriaController : MainController
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IServicoRepository _servicoRepository;
        private readonly IServicoService _servicoService;
        private readonly IMapper _mapper;

        public CategoriaController(
                    ICategoriaRepository categoriaRepository,
                    IServicoRepository servicoRepository,
                    IServicoService servicoService,
                    IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _servicoRepository = servicoRepository;
            _servicoService = servicoService;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtem todas as categorias e suas respectivas subcategorias
        /// </summary>
        /// <returns></returns>
        [HttpGet("ObterCategorias")]
        public async Task<List<CategoriaViewModel>> ObterTodasCategorias()
        {
            return _mapper.Map<List<CategoriaViewModel>>(await _categoriaRepository.ObterTodasCategorias());
        }

        [HttpPost("AdicionarCategoria")]
        public async Task<ActionResult<CategoriaViewModel>> Adicionar(CategoriaViewModel categoriaViewModel)
        {
            if (!ModelState.IsValid) 
                return BadRequest(new { erro = true, data = categoriaViewModel, NumeroErros = ModelState.ErrorCount,
                    Erros = string.Join(" || ", ModelState.Values.SelectMany(x => x.Errors).Select(y => y.ErrorMessage))});
            await _categoriaRepository.Adicionar(_mapper.Map<Categoria>(categoriaViewModel));
            return Ok(categoriaViewModel);            
        }

        [HttpDelete("DeletarCategoria/{id:guid}")]
        public async Task<ActionResult<CategoriaViewModel>> Deletar(Guid id)
        {
            var categoria = await ObterCategoria(id);
            if (categoria == null) return NotFound(new { erru = true , dado = id});
            await _categoriaRepository.Remover(id);
            return Ok(new { erru = true, dado = id });
        }

        private async Task<Categoria> ObterCategoria(Guid id)
        {
            return await _categoriaRepository.ObterPorId(id);
        }


        [HttpGet("ObterTodasCategoriasESubCategorias")]
        public async Task<List<Categoria>> ObterTodasCategoriasESubCategorias()
        {
            return await _categoriaRepository.ObterTodos();
        }

        /// <summary>
        /// Obter Categoria e SubCategoria (EnumDescription)
        /// </summary>
        /// <param name="categoria"></param>
        /// <param name="subcategoria"></param>
        /// <returns>String</returns>
        [HttpGet("categoria/{categoria:int}/subcategoria/{subcategoria:int}")]
        [Produces("application/json")]
        private ActionResult ObterCategoria(int categoria, int subcategoria)
        {
            try
            {
                var result = new CategoriaBuilder(categoria, subcategoria);
                return Ok(result.GetDictionary());
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }






    }

}
