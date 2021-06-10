using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL;
using ControleFinanceiro.DAL.Interface;

namespace ControleFinanceiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategoria()
        {
            return await _categoriaRepository.GetAll().ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            var categoria = await _categoriaRepository.GetById(id);
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
            //Verifica se nossos dados são validos
            if (ModelState.IsValid)
            {
                await _categoriaRepository.Update(categoria);
                return Ok(new
                {
                    mensagem = $"Categoria {categoria.Nome} atualizada com sucesso"
                });
            }
            return BadRequest(ModelState);
          
        }
        [HttpPost]
        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                await _categoriaRepository.Add(categoria);
                return Ok(new
                {
                    mensagem = $"Categoria {categoria.Nome} Cadastrada com sucesso"
                });
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Categoria>> DeleteCategoria (int id)
        {
            var categoria = await _categoriaRepository.GetById(id);

            if(categoria == null)
            {
                return NotFound();
            }

            await _categoriaRepository.Delete(id);
            return Ok(new
            {
                mensagem = $"Categoria {categoria.Nome} excluída com sucesso"
            });


        }
        [HttpGet("FilterCategorias/{nome}")]
        public async Task<ActionResult<IEnumerable<Categoria>>> FilterCategoria(string nomeCategoria)
        {
            return await _categoriaRepository.FilterCategoria(nomeCategoria).ToListAsync();
        }
    }
}
