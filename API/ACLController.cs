using Microsoft.AspNetCore.Mvc;
using APIASPDOTNETMSSQLServer.Data.Models;
using APIASPDOTNETMSSQLServer.Models;
using APIASPDOTNETMSSQLServer.Repositories;

namespace APIASPDOTNETMSSQLServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ACLController : ControllerBase
    {
        private readonly RepositoryACL _repository;

        public ACLController(RepositoryACL repository)
        {
            _repository = repository;
        }

        // GET: api/ACL
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }

        // GET: api/ACL/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST: api/ACL
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ACLRequestModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var acl = new ACL
            {
                Tipo = model.Tipo,
                Descricao = model.Descricao
            };

            var newId = await _repository.AddAsync(acl);
            return CreatedAtAction(nameof(GetById), new { id = newId }, model);
        }

        // PUT: api/ACL/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ACLRequestModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existingACL = await _repository.GetByIdAsync(id);
            if (existingACL == null) return NotFound();

            existingACL.Tipo = model.Tipo;
            existingACL.Descricao = model.Descricao;

            var success = await _repository.UpdateAsync(existingACL);
            if (!success) return StatusCode(500, "An error occurred while updating.");

            return NoContent();
        }

        // DELETE: api/ACL/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingACL = await _repository.GetByIdAsync(id);
            if (existingACL == null) return NotFound();

            var success = await _repository.DeleteAsync(id);
            if (!success) return StatusCode(500, "An error occurred while deleting.");

            return NoContent();
        }
    }
}
