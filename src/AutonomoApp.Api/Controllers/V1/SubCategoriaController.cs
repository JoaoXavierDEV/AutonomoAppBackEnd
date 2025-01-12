using AutoMapper;
using AutonomoApp.Business.DTO;
using AutonomoApp.Business.Interfaces;
using AutonomoApp.Business.Interfaces.IRepository;
using AutonomoApp.Business.Interfaces.IService;
using AutonomoApp.Business.Models;
using AutonomoApp.Business.Services;
using AutonomoApp.Data.Repository;
using AutonomoApp.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace AutonomoApp.WebApi.Controllers.V1
{
    [ApiVersion("1.0", Deprecated = false)]
    [Route("api/v{version:apiVersion}/SubCategoria")]
    [Produces("application/json")]

    public class SubCategoriaController : MainController
    {
        private readonly ISubCategoriaRepository _subcategoriaRepository;
        private readonly ISubCategoriaService _subcategoriaService;
        private readonly IMapper _mapper;

        public SubCategoriaController(
                    ISubCategoriaRepository subcategoriaRepository,
                    ISubCategoriaService subcategoriaService,
                    IMapper mapper, INotificador notificador, IUser user) : base(notificador, user)
        {
            _subcategoriaRepository = subcategoriaRepository;
            _subcategoriaService = subcategoriaService;
            _mapper = mapper;
        }

        [HttpGet("ObterTodas")]
        public async Task<List<SubCategoriaViewModel>> ObterTodasCategorias()
        {
            return _mapper.Map<List<SubCategoriaViewModel>>(await _subcategoriaRepository.ObterTodasSubCategorias());
        }

        [HttpGet("Obter/{id:guid}")]
        public async Task<Subcategoria> ObterSubCategoria(Guid id)
        {
            return await _subcategoriaRepository.ObterPorId(id);
        }

        [HttpPost("AdicionarSubCategoria")]
        public async Task<ActionResult<SubCategoriaViewModel>> AdicionarSubcategoria(SubCategoriaViewModel subCategoriaViewModel)
        {
            // validação da model
            if (!ModelState.IsValid)
                return BadRequest(new
                {
                    erro = true,
                    data = subCategoriaViewModel,
                    NumeroErros = ModelState.ErrorCount,
                    Erros = string.Join(" || ", ModelState.Values.SelectMany(x => x.Errors).Select(y => y.ErrorMessage))
                });

            try
            {
                await _subcategoriaService.Adicionar(_mapper.Map<Subcategoria>(subCategoriaViewModel));
            }
            catch (Exception ex)
            {
                return BadRequest(new { erru = true, erros = ex.InnerException?.Message ?? ex.Message });
            }
            return CustomResponse(subCategoriaViewModel);
        }

        [HttpPut("Atualizar/{id:guid}")]
        public async Task<ActionResult<SubCategoriaViewModel>> Atualizar(Guid id, SubCategoriaViewModel subcategoriaViewModel)
        {
            await _subcategoriaService.Atualizar(_mapper.Map<Subcategoria>(subcategoriaViewModel));
            return Ok(subcategoriaViewModel);
        }

        [HttpDelete("Deletar/{id:guid}")]
        public async Task<ActionResult<SubCategoriaViewModel>> Deletar(Guid id)
        {
            try
            {
                var subcategoria = await ObterSubCategoria(id);
                if (subcategoria == null) return NotFound(new { erru = true, dado = "Não encontrado: " + id });
                await _subcategoriaRepository.Remover(id);
            }
            catch (Exception ex)
            {

                return BadRequest(new { erru = true, erros = ex.InnerException?.Message ?? ex.Message });
            }
            return Ok(new { erru = false, dado = id });
        }

    }

}
