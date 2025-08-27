using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NewConsig.ApiAppServidor.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CidadeController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public CidadeController(IConfiguration configuration) 
    {
        _configuration=configuration;
    }


    [HttpGet("cidades")]
    [AllowAnonymous]
    public IActionResult GetCidadesHabilitadas()
    {
        var cidades = _configuration
            .GetSection("CidadesHabilitadas")
            .Get<List<string>>() ?? new List<string>();

        return Ok(cidades);
    }
}
