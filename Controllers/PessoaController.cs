using ManagerHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManagerHome.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController:ControllerBase
    {
        private readonly Contexto _contexto;
        public PessoaController(Contexto contexto)
        {
            _contexto=contexto;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> PegarTodosAsync(){
            return await _contexto.Pessoas.ToListAsync();
        }
        [HttpGet("{pessoaId}")]
        public async Task<ActionResult<Pessoa>> PegarPessoaPeloIdAsync(int pessoaId){
            Pessoa pessoa= await _contexto.Pessoas.FindAsync(pessoaId);

            if(pessoa==null){
                return NotFound();              
            }
            return pessoa;
        }
        [HttpPost]
        public async Task<ActionResult<Pessoa>> SalvarPessoasAsync(Pessoa pessoa){
             await _contexto.Pessoas.AddAsync(pessoa);
             await _contexto.SaveChangesAsync();
             return Ok();
        }
        [HttpPut]
        public async Task<ActionResult>AtualizarPessoaAsync(Pessoa pessoa){
            _contexto.Pessoas.Update(pessoa);
            await _contexto.SaveChangesAsync();

            return Ok();
        }
        [HttpDelete("{pessoaId}")]
        public async Task<ActionResult> ExcluirPessoaAsync(int pessoaId){
            Pessoa pessoa= await _contexto.Pessoas.FindAsync(pessoaId);
            if(pessoa ==null){
                return NotFound();
            }
            _contexto.Remove(pessoa);
            await _contexto.SaveChangesAsync();
            return Ok();
        }

        
        
    }
}