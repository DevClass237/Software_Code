﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PocheteAPI.Data;
using PocheteAPI.DTO;
using PocheteAPI.Modelo;

namespace PocheteAPI.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class TurmasController : ControllerBase {
        private readonly AppDbContext _context;

        public TurmasController(AppDbContext context) {
            _context = context;
        }

        // GET: api/turmas
        // Retorna todas as turmas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TurmasDTO>>> GetTurmas() {
            var turmas = await _context.Turmas
                .Select(t => new TurmasDTO {
                    Id = t.Id,
                    Identificador = t.Identificador
                })
                .ToListAsync();

            return Ok(turmas);
        }

        // GET: api/turmas/{id}
        // Retorna uma turma específica pelo id
        [HttpGet("{id}")]
        public async Task<ActionResult<TurmasDTO>> GetTurma(long id) {
            var turma = await _context.Turmas.FindAsync(id);

            if (turma == null) return NotFound();

            var turmaDTO = new TurmasDTO {
                Id = turma.Id,
                Identificador = turma.Identificador
            };

            return Ok(turmaDTO);
        }

        // POST: api/turmas
        // Cria uma nova turma
        [HttpPost]
        public async Task<ActionResult<TurmasDTO>> PostTurma(TurmasDTO turmaDTO) {
            var turma = new Turma {
                Identificador = turmaDTO.Identificador
            };

            _context.Turmas.Add(turma);
            await _context.SaveChangesAsync();

            turmaDTO.Id = turma.Id;

            return CreatedAtAction(nameof(GetTurma), new { id = turma.Id }, turmaDTO);
        }

        // PUT: api/turmas/{id}
        // Atualiza uma turma existente
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTurma(long id, TurmasDTO turmaDTO) {
            if (id != turmaDTO.Id) return BadRequest();

            var turma = await _context.Turmas.FindAsync(id);
            if (turma == null) return NotFound();

            turma.Identificador = turmaDTO.Identificador;

            _context.Entry(turma).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/turmas/{id}
        // Remove uma turma pelo id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTurma(long id) {
            var turma = await _context.Turmas.FindAsync(id);
            if (turma == null) return NotFound();

            _context.Turmas.Remove(turma);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}