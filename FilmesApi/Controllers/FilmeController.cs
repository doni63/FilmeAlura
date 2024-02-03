using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{

    private static List<Filme> filmes = new List<Filme>();
    private static int id = 0;

    //[HttpPost]
    //public void AdicionaFilme([FromBody] Filme filme)
    //{
    //    filme.Id = id++;
    //    filmes.Add(filme);
    //    //confirmando se esta recebendo os parametros
    //    Console.WriteLine(filme.Titulo);
    //    Console.WriteLine(filme.Duracao);
    //}
    [HttpPost]
    public IActionResult AdicionaFilme([FromBody] Filme filme)
    {
        filme.Id = id++;
        filmes.Add(filme);
        //confirmando se esta recebendo os parametros
        //Console.WriteLine(filme.Titulo);
        //Console.WriteLine(filme.Duracao);
        return CreatedAtAction(nameof(RecuperaFilmePorId), new { id = filme.Id }, filme);
    }

    [HttpGet]
    //public List<Filme> RetornarFilmes()
    //{
    //    return filmes;
    //}
    public IEnumerable<Filme> RetornarFilmes([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    //public Filme? RecuperaFilmePorId(int id)
    //{
    //    return filmes.FirstOrDefault(f => f.Id == id);

    //}
    public IActionResult RecuperaFilmePorId(int id)
    {
        var filme = filmes.FirstOrDefault(f => f.Id == id);
        if (filme == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(filme);
        }
    }
}
