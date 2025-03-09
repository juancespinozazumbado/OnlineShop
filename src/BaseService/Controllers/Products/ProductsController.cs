using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoleBasedAuth.Api.Controllers.Auth;
using RoleBasedAuth.Api.Dtos.Products;
using RoleBasedAuth.Api.Interfaces;
using RoleBasedAuth.Api.Models.Products;

namespace RoleBasedAuth.Api.Controllers.Products;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductsController : ControllerBase
{

    private readonly IRepository<Product> _repository;
    private readonly ILogger<ProductsController> _logger;
    private readonly IMapper _maper;

    public ProductsController(ILogger<ProductsController> logger, 
        IRepository<Product> repo, IMapper mapper)
    {
        _repository = repo;
        _logger = logger;
        _maper = mapper;
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
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetById( Guid id)
    {
        var product = await _repository.GetByIdAsync(id);
        return product is not null ? Ok(product) : NotFound();
    }


    [RoleAuthFilter("Admin")]
    [HttpPost("")]
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


    [RoleAuthFilter("Admin")]
    [HttpPut("")]
    public async Task<IActionResult> Update(ProductDto product)
    {

        try
        {
            var entity = _maper.Map<Product>(product);
            await _repository.UpdateAsync(entity);
            return Ok(new { Message = $"Product {product.Id} Updated!" });

        }
        catch (Exception ex)
        {
            return Problem(ex.Message);

        }

    }


    [RoleAuthFilter("Admin")]
    [HttpDelete("")]
    public async Task<IActionResult> Delete(Product product)
    {

        try
        {
            await _repository.DeleteAsync(product);
            return Ok(new { Message = $"Product {product.Id} Deleted!" });

        }
        catch (Exception ex)
        {
            return Problem(ex.Message);

        }

    }
}
