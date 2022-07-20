using AutonomoApp.Business.DTO;
using AutonomoApp.Business.Interfaces.IRepository;

namespace AutonomoApp.Business.Services;

public class ServicoService : BaseService
{
    private readonly IServicoRepository _servicoRepository;

    public ServicoService(IServicoRepository servicoRepository)
    {
        _servicoRepository = servicoRepository;
    }

    public ServicoDTO CtorServicoDTO()
    {
        return new ServicoDTO();
    }
}