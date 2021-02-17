using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Odev2.Data.Entities;
using Odev2.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepository<Product> _repository;

        public ProductsController(IRepository<Product> repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _repository.GetAllAsync();
            return Ok(products);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Product product)
        {
          await _repository.AddAsync(product);
            return Created(string.Empty, product);
        }

        [HttpPut]
        public IActionResult Update([FromBody]Product product)
        {
            _repository.Update(product);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            _repository.Remove(product);
            return NoContent();
        }


    }
}
