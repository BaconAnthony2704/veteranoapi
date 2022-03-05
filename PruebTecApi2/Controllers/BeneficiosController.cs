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
    public class BeneficiosController : ControllerBase
    {
        private readonly RepositoryValue _repo;
        public BeneficiosController(RepositoryValue repository)
        {
            _repo = repository;
        }
        // GET: api/<BeneficiosController>
        [HttpGet]
        public async Task<List<BeneficiosModel>> GetAllVeterano()
        {
            return await _repo.GetAllBeneficios();

        }

        // GET api/<BeneficiosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BeneficiosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BeneficiosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BeneficiosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
