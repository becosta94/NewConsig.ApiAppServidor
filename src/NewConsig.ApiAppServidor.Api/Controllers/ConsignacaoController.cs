using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewConsig.ApiAppServidor.Api.Extensions;
using NewConsig.ApiAppServidor.Application.DTOs;
using NewConsig.ApiAppServidor.Application.Services.Interfaces;

namespace NewConsig.ApiAppServidor.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConsignacaoController : ControllerBase
{
    private readonly IConsignacaoService _service;

    public ConsignacaoController(IConsignacaoService service) => _service = service;
    [Authorize]
    [HttpGet("consignacoes")]
    public IActionResult GetConsignacoesServidorAsync(long idServidor, string dbName, CancellationToken ct)
    {
        return _service.GetConsignacoesServidorAsync(idServidor, dbName, ct).ToActionResult();
    }
    [Authorize]
    [HttpGet("consignacoesProposta")]
    public IActionResult GetConsignacoesPropostaServidorAsync(long idServidor, string dbName, CancellationToken ct)
    {
        return _service.GetConsignacoesPropostaServidorAsync(idServidor, dbName, ct).ToActionResult();
    }
    [Authorize]
    [HttpPost("aceiteProposta")]
    public async Task<IActionResult> AceitePropostaAsync([FromBody]AceitePropostaDto aceitePropostaDto, CancellationToken ct)
    {
        return (await _service.AceitePropostaAsync(aceitePropostaDto)).ToActionResult();
    }

}
