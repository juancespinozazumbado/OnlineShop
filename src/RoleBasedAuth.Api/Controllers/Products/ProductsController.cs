using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RoleBasedAuth.Api.Controllers.Auth;
using RoleBasedAuth.Api.Interfaces;
using RoleBasedAuth.Api.Models.Products;

namespace RoleBasedAuth.Api.Controllers.Products;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{

    private readonly IRepository<Product> _repository;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(ILogger<ProductsController> logger, IRepository<Product> repo)
    {
        _repository = repo;
        _logger = logger;
    }

    [HttpGet("")]
    public async Task<ActionResult<IEnumerable<Product>>> Get()
    {
        try
        {
            var products = await _repository.GetAllAsync();
            return Ok(products);

        }
        catch (Exception ex)
        {
            return Problem(ex.Message);

        }
       
    }
    [Authorize]
    [HttpGet("/{id}")]
    public async Task<ActionResult<Product>> GetById( Guid id)
    {
        var product = await _repository.GetByIdAsync(id);
        return product is not null ? Ok(product) : NotFound();
    }


    [RoleAuthFilter("Admin")]
    [HttpPost("add")]
    public async Task<IActionResult> Create(Product product)
    {

        try
        {
             await _repository.CreateAsync(product);
            return Ok(new {Message = $"Product {product.Id} created!"});

        }
        catch (Exception ex)
        {
            return Problem(ex.Message);

        }

    }
}
