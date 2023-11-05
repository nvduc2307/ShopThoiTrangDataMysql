namespace FrontEnd.Models;

public class Product {
    public int id { get; set; }
    public string name { get; set; }
    public double price { get; set; }
}

public class CreateProduct {
    public string name { get; set; }
    public double price { get; set; }
}
