using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL;


namespace ControleFinanceiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly Context _context;

        public CategoriaController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategoria()
        {
            return await _context.Categorias.Include(c=> c.Tipo).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria (int id,Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return BadRequest();
            }

            _context.Entry(categoria).State = EntityState.Modified;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return NoContent();
        }
            [HttpPost]
            public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
            {
                _context.Categorias.Add(categoria);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetCategoria", new { id = categoria.Id }, categoria);

            }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Categoria>> DeleteCategoria (int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if(categoria == null)
            {
                return NotFound();
            }
            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
            return categoria;

        }
    }
}
