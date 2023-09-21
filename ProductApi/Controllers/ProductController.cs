﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static ProductApi.DTOS;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static readonly List<ProductDTO> products = new()
        {
            new ProductDTO(Guid.NewGuid(),"Termék1",2500,DateTimeOffset.UtcNow,DateTimeOffset.UtcNow),
            new ProductDTO(Guid.NewGuid(),"Termék2",2400,DateTimeOffset.UtcNow,DateTimeOffset.UtcNow),
            new ProductDTO(Guid.NewGuid(),"Termék3",2300,DateTimeOffset.UtcNow,DateTimeOffset.UtcNow)
        };
        [HttpGet]
        public IEnumerable<ProductDTO> GetAll()
        {
            return products;
        }
        [HttpGet("{id}")]
        public ActionResult<ProductDTO> GetById(Guid id)
        {
            var product = products.Where(x => x.Id == id).FirstOrDefault();

            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<ProductDTO> PostProduct(CreateProductDTO createProduct)
        {
            var product = new ProductDTO(Guid.NewGuid(), createProduct.ProductName, createProduct.ProductPrice, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow);
            products.Add(product);
            return CreatedAtAction(nameof(GetById), new{id = product.Id}, product);
        }

        [HttpPut]
        public ProductDTO PutProduct(Guid id, UpdateProductDTO updateProduct)
        {
            var exisitingProduct = products.Where(x=>x.Id == id).FirstOrDefault();
            var product = exisitingProduct with
            {
                ProductName = updateProduct.ProductName,
                ProductPrice = updateProduct.ProductPrice,
                ModifiedTime = DateTimeOffset.UtcNow
            };
            var index = products.FindIndex(x => x.Id == id);
            products[index] = product;
            return product;
        }
        [HttpDelete]
        public ActionResult DeleteProduct(Guid id) 
        {
            var index = products.FindIndex(x => x.Id == id);
            products.RemoveAt(index);

            return NoContent();
        }


    }
}
