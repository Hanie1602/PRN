using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using PRN231_SU25_SE171916.Repositories.Models;
using PRN231_SU25_SE171916.Services;

namespace PRN231_SU25_SE171916.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HandbagsController : Controller
    {
        private readonly IHandbagService _handbagService;
        public HandbagsController(IHandbagService handbagService)
        {
            _handbagService = handbagService;
        }

        [Authorize(Roles = "1,2,3,4")] // all đc phép getAll
        [HttpGet]
        public async Task<IEnumerable<Handbag>> Get()
        {
            return await _handbagService.GetAllAsync();
        }

        [Authorize(Roles = "1,2,3,4")]
        [HttpGet("{id}")]
        public async Task<Handbag> Get(int id)
        {
            return await _handbagService.GetByIdAsync(id);
        }

        [Authorize(Roles = "1,2")]
        [HttpPost]
        public async Task<int> Post(Handbag bag)
        {
            return await _handbagService.CreateAsync(bag);
        }

        [Authorize(Roles = "1,2")]
        [HttpPut("{id}")]
        public async Task<int> Put(Handbag bag)
        {
            return await _handbagService.UpdateAsync(bag);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _handbagService.DeleteAsync(id);
        }

        [HttpGet("Search")]
        [Authorize(Roles = "1,2,3,4")]
        [EnableQuery]
        public async Task<List<Handbag>> SearchAsync(string modelName, string material)
        {
            return await _handbagService.SearchAsync(modelName, material);
        }
    }
}
