using AutoMapper;
using AutonomoApp.Business.DTO;
using AutonomoApp.Business.Interfaces;
using AutonomoApp.Business.Interfaces.IRepository;
using AutonomoApp.Business.Interfaces.IService;
using AutonomoApp.Business.Models;
using AutonomoApp.Business.Services;
using AutonomoApp.Data.Repository;
using AutonomoApp.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace AutonomoApp.WebApi.Controllers.V1
{
    [Authorize]
    [ApiVersion("1.0", Deprecated = false)]
    [Route("api/v{version:apiVersion}/Categoria")]
    [Produces("application/json")]

    public class CategoriaController : MainController
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ICategoriaService _categoriaService;
        private readonly IMapper _mapper;

        public CategoriaController(
                    ICategoriaRepository categoriaRepository,
                    ICategoriaService categoriaService,
                    IMapper mapper, INotificador notificador, IUser user) : base(notificador, user)
        {
            _categoriaRepository = categoriaRepository;
            _categoriaService = categoriaService;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtem todas as categorias e suas respectivas subcategorias
        /// </summary>
        /// <returns>Lista</returns>
        [AllowAnonymous]
        [HttpGet("ObterTodas")]
        public async Task<List<CategoriaViewModel>> ObterTodasCategorias()
        {
            return _mapper.Map<List<CategoriaViewModel>>(await _categoriaRepository.ObterTodasCategorias());
        }
        [AllowAnonymous]
        [HttpGet("ObterTodasCategoriasESubCategorias")]
        public async Task<List<Categoria>> ObterTodasCategoriasESubCategorias()
        {
            return await _categoriaRepository.ObterTodasCategoriasESubcategorias();
        }
        [AllowAnonymous]
        [HttpGet("Obter/{id:guid}")]
        public async Task<Categoria> ObterCategoria(Guid id)
        {
            return await _categoriaRepository.ObterPorId(id);
        }

        [HttpPost("AdicionarCategoria")]
        public async Task<ActionResult<CategoriaViewModel>> Adicionar(CategoriaViewModel categoriaViewModel)
        {
            // validação da model
            if (!ModelState.IsValid)
                return BadRequest(new
                {
                    erro = true,
                    data = categoriaViewModel,
                    NumeroErros = ModelState.ErrorCount,
                    Erros = string.Join(" || ", ModelState.Values.SelectMany(x => x.Errors).Select(y => y.ErrorMessage))
                });

            try
            {
                await _categoriaService.Adicionar(_mapper.Map<Categoria>(categoriaViewModel));
            }
            catch (Exception ex)
            {
                return BadRequest(new { erru = true, erros = ex.InnerException?.Message ?? ex.Message });
            }
            return CustomResponse(categoriaViewModel);
        }

        [HttpPut("Atualizar/{id:guid}")]
        public async Task<ActionResult<CategoriaViewModel>> Atualizar(Guid id, CategoriaViewModel categoriaViewModel)
        {
            // TODO criar ToViewModel
            await _categoriaService.Atualizar(_mapper.Map<Categoria>(categoriaViewModel));
            return Ok(categoriaViewModel);
        }

        [HttpDelete("DeletarCategoria/{id:guid}")]
        public async Task<ActionResult<CategoriaViewModel>> Deletar(Guid id)
        {
            try
            {
                var categoria = await ObterCategoria(id);
                if (categoria == null) return NotFound(new { erru = true, dado = "Não encontrado: " + id });
                await _categoriaRepository.Remover(id);
            }
            catch (Exception ex)
            {

                return BadRequest(new { erru = true, erros = ex.InnerException?.Message ?? ex.Message });
            }
            return Ok(new { erru = false, dado = id });
        }


        ///// <summary>
        ///// Obter Categoria e SubCategoria (EnumDescription)
        ///// </summary>
        ///// <param name="categoria"></param>
        ///// <param name="subcategoria"></param>
        ///// <returns>String</returns>
        //[HttpGet("categoria/{categoria:int}/subcategoria/{subcategoria:int}")]
        //[Produces("application/json")]
        //[NonAction]
        //public ActionResult ObterCategoria(int categoria, int subcategoria)
        //{
        //    try
        //    {
        //        var result = new CategoriaBuilder(categoria, subcategoria);
        //        return Ok(result.GetDictionary());
        //    }
        //    catch (Exception e)
        //    {
        //        return NotFound(e.Message);
        //    }
        //}






    }

}
