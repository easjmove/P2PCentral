using Microsoft.AspNetCore.Mvc;
using P2PCentral.Models;
using P2PCentral.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace P2PCentral.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileEndpointsController : ControllerBase
    {
        private FileEndpointsRepository _repository;

        public FileEndpointsController(FileEndpointsRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<FileEndpointsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _repository.GetFileNames();
        }

        // GET api/<FileEndpointsController>/5
        [HttpGet("{fileName}")]
        public List<FileEndpoint>? Get(string fileName)
        {
            return _repository.GetEndpoints(fileName);
        }

        // POST api/<FileEndpointsController>
        [HttpPost("{fileName}")]
        public FileEndpoint Post(string fileName, [FromBody] FileEndpoint newEndpoint)
        {
            return _repository.Add(fileName, newEndpoint);
        }

        // DELETE api/<FileEndpointsController>/5
        [HttpDelete("{fileName}")]
        public FileEndpoint? Delete(string fileName, [FromBody] FileEndpoint endpointToBeDeleted)
        {
            return _repository.Delete(fileName, endpointToBeDeleted);
        }
    }
}
