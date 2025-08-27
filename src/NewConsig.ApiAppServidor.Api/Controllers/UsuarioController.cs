using Microsoft.AspNetCore.Mvc;
using NewConsig.ApiAppServidor.Application.Services;
using NewConsig.ApiAppServidor.Application.DTOs;
using NewConsig.ApiAppServidor.Api.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace NewConsig.ApiAppServidor.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _service;

    public UsuarioController(IUsuarioService service) => _service = service;

    [HttpPost("login")]
    public IActionResult GetById([FromBody] AuthDto auth, CancellationToken ct)
    {
        return _service.AuthAsync(auth, ct).ToActionResult();
    }
    [Authorize]
    [HttpGet("buscardadosservidor")]
    public IActionResult GetDadosServidor(long id, string dbName, CancellationToken ct)
    {
        return _service.GetDadosServidor(id, dbName, ct).ToActionResult();
    }

    [HttpPost("resetar-senha")]
    public async Task<IActionResult> ResetarSenha([FromBody] ResetarSenhaDto resetarSenha, CancellationToken ct)
    {
        return (await _service.ResetarSenha(resetarSenha, ct)).ToActionResult();
    }

    [HttpPost("validar-senha")]
    public IActionResult ValidarSenha([FromBody] ValidarSenhaDto validarSenha, CancellationToken ct)
    {
        return _service.ValidarSenha(validarSenha, ct).ToActionResult();
    }

    [HttpPost("trocar-senha")]
    public async Task<IActionResult> TrocarSenha([FromBody] TrocarSenhaDto trocaSenha, CancellationToken ct)
    {
        return (await _service.TrocarSenha(trocaSenha, ct)).ToActionResult();
    }
}
