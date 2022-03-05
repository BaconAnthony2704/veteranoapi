using Microsoft.AspNetCore.Mvc;
using PruebTecApi2.Models;
using PruebTecApi2.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebTecApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeteranoController : ControllerBase
    {
        private readonly RepositoryValue _repo;
        public VeteranoController(RepositoryValue repository)
        {
            _repo = repository;  
        }
        // GET: api/<VeteranoController>
        [HttpGet]
        public async Task<List<VetenanoModel>> GetAllVeterano()
        {
            return await _repo.GetAllVeterano();
            
        }
        
        [HttpPost("[action]")]
        public async Task CrearBeneficioVeterano([FromBody] VeteBeneficiosModel veteBeneficios)
        {
            await _repo.InsertBeneficioVeterano(veteBeneficios);
        }

        // GET api/<VeteranoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VeteranoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<VeteranoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VeteranoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
