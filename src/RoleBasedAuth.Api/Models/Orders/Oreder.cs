using RoleBasedAuth.Api.Models.Products;

namespace RoleBasedAuth.Api.Models.Orders;

public class Oreder
{
    public Guid Id { get; set; }    
    public string OrderNumber { get; set; } = string.Empty; 
    public string? CustomerId { get; set; } 
    public Customer? Customer { get; set; }
    public List<OrderDetail>? Details { get; set; }

    public decimal Total { get; set; }  
    public decimal SubTotal { get; set; }
    public decimal TotalDiscount { get; set; }  
    public decimal SaleTax { get; set; }


}

public class OrderDetail
{
    public Guid Id { get; set; }
    public string? ProductId { get; set; }
    public Product? Product { get; set; }
    public int QuantitySale { get; set; }   
    public decimal PriceSale { get; set; }
    public decimal PriceDiscount { get; set; }
    public decimal Total { get; set; }


}

public class Customer
{
    public Guid Id { get; set; }
    public string? Name { get; set; } = string.Empty;
    public string? Email { get; set; }   
    public string? Phone { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }


}
