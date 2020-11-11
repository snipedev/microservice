using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using myApp.catalogue.Entities;
using myApp.catalogue.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore;

namespace myApp.catalogue.Controllers
{
   
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CatalogueController:ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<CatalogueController> _logger;

        public CatalogueController(IProductRepository repository, ILogger<CatalogueController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var productsList = await _repository.GetProduct();
            return Ok(productsList);
        }

        [HttpGet("{id:length(24)}",Name = "GetProduct")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<Product>> GetProductbyId(string id)
        {
            var product = await _repository.GetProductById(id);

            if (product == null)
            {
                _logger.LogError($"product with id {id}, not found.");
                return  NotFound();
            }
            else
            {
                return Ok(product);
            }
        }

        [Route("[action]/{category}")]
        [HttpGet]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByCatgory(string category)
        {
            var product = await _repository.GetProductByCategory(category);
            if (product == null)
            {
                _logger.LogError($"product of category {category}, not found.");
                return NotFound();
            }
            return Ok(product);
        }


        [HttpPost]
        [ProducesResponseType(typeof(Product),(int)HttpStatusCode.Created)]
        public async Task<ActionResult<Product>> Create(Product product)
        {
            await _repository.create(product);
            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> updateProduct(Product product)
        {
            return Ok(await _repository.update(product));
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProduct(string Id)
        {
            return Ok(await _repository.Delete(Id));
        }


    }
}
