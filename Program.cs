// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
        // Create an instance of ProductManager
        ProductManager productManager = new ProductManager();

        // Add sample products
        productManager.AddProduct("Soap", 10.99, "Santoor", new DateTime(2022, 1, 1), new DateTime(2023, 1, 1));
        productManager.AddProduct("Powder", 15.99, "Ponds", new DateTime(2022, 3, 1), new DateTime(2023, 3, 1));
        productManager.AddProduct("Face cream", 12.49, "fairandlovely", new DateTime(2022, 2, 1), new DateTime(2023, 2, 1));
        productManager.AddProduct("Face wash", 8.99, "Neem", new DateTime(2022, 5, 1), new DateTime(2023, 5, 1));
        productManager.AddProduct("lipstick", 18.75, "Mac", new DateTime(2022, 4, 1), new DateTime(2023, 4, 1));

        // Display sorted product details
        productManager.DisplayProducts();

        // Search for a product by name
        Console.Write("Enter product name to search: ");
        string searchProductName = Console.ReadLine();

        Product foundProduct = productManager.SearchProduct(searchProductName);

        if (foundProduct != null)
        {
            Console.WriteLine($"Product found: {foundProduct.PName}, Price: {foundProduct.PPrice}, Brand: {foundProduct.PBrand}, Manufacturing Date: {foundProduct.ManufacturingDate}, Expiry Date: {foundProduct.ExpiryDate}");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }
}

public class Product
{
    public string PName { get; }
    public double PPrice { get; }
    public string PBrand { get; }
    public DateTime ManufacturingDate { get; }
    public DateTime ExpiryDate { get; }

    public Product(string name, double price, string brand, DateTime manufacturingDate, DateTime expiryDate)
    {
        PName = name;
        PPrice = price;
        PBrand = brand;
        ManufacturingDate = manufacturingDate;
        ExpiryDate = expiryDate;
    }
}

public class ProductManager
{
    private SortedList<string, Product> productList;

    public ProductManager()
    {
        productList = new SortedList<string, Product>();
    }

    public void AddProduct(string name, double price, string brand, DateTime manufacturingDate, DateTime expiryDate)
    {
        productList.Add(name, new Product(name, price, brand, manufacturingDate, expiryDate));
    }

    public void DisplayProducts()
    {
        foreach (var product in productList.Values)
        {
            Console.WriteLine($"Product Name: {product.PName}, Price: {product.PPrice}, Brand: {product.PBrand}, Manufacturing Date: {product.ManufacturingDate}, Expiry Date: {product.ExpiryDate}");
        }
    }

    public Product SearchProduct(string productName)
    {
        if (productList.ContainsKey(productName))
        {
            return productList[productName];
        }

        return null;
    }
}
