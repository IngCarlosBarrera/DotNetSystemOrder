
namespace NWOMSystem.Domain.Entities;

public class Order
{
    public int OrderId {get;set;}
    public int CustomerId {get;set;}
    public DateTime OrderDate {get;set;}
    public string ShipAddress {get;set;} = string.Empty;

    public IEnumerable<string> OrderItems {get;set;}= new List<string>();

// Business logic to calculate total price of the order
    public decimal CalculateTotalPrice(IEnumerable<OrderDetail> orderDetails)
    {
        decimal total = 0;
        foreach(var detail in orderDetails)
        {
            total += detail.TotalPrice();
        }
        return total;
    }

    

}



public class Product
{
    public int ProductId {get;set;}
    public string Name {get;set;} = string.Empty;
    public decimal UnitPrice {get;set;}
    public int StockQuantity {get;set;}

    // Business logic to check if the product is in stock
    public bool IsInStock()
    {
        return StockQuantity > 0;   
    }

    
}

public class OrderDetail
{
    public int OrderId {get;set;}
    public int ProductId {get;set;}
    public int Quantity {get;set;}
    public decimal UnitPrice {get;set;} 

    // Business logic 
       
    public decimal TotalPrice()
    {
        return Quantity * UnitPrice;
    }

    public bool IsValid()
    {
        return Quantity > 0 && UnitPrice > 0;
    }
}

//I think I am missing Entities associated with Geo Location and User Management. I will add them later.

