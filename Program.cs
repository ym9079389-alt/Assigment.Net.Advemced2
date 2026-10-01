using System;
using System.Collections.Generic;
namespace Assigment.Net.Advemced2
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }

    class Program
    {
        static List<Product> SearchProducts(List<Product> products, Func<Product, bool> factory)
        {
            List<Product> result = new List<Product>();

            foreach (Product p in products)
            {
                if (factory(p))
                    result.Add(p);
            }

            return result;
        }

        static void PrintProducts(string title, List<Product> products)
        {
            Console.WriteLine(title);
            foreach (Product p in products)
            {
                Console.WriteLine($"  {p.Name} - ${p.Price} - Stock: {p.Stock}");
            }
            Console.WriteLine();
        }

        public static void PrintReport(List<Product> products)
        {
            List<Product> result = new List<Product>();
            Console.WriteLine("Short Report: ");
            foreach (var p in products)
            {
                Console.WriteLine($"{p.Name} - {p.Price}");
            }
            Console.WriteLine();
            Console.WriteLine("Detailed Report: ");
            foreach (var p in products)
            {
                Console.WriteLine($"[{p.Category}] {p.Name} | Price: {p.Price} | Stock: {p.Stock}");
            }
        }
        static List<string> TransformProducts(List<Product> products, Func<Product, string> factory)
        {
            List<string> result = new List<string>();
            foreach (var p in products)
            {
                result.Add(factory(p));
            }
            return result;
        }
        static void Main()
        {
            List<Product> catalog = new()
            {
                new Product { Id=1, Name="Laptop", Category="Electronics", Price=1200, Stock=10 },
                new Product { Id=2, Name="Phone", Category="Electronics", Price=800, Stock=25 },
                new Product { Id=3, Name="T-Shirt", Category="Clothing", Price=30, Stock=100 },
                new Product { Id=4, Name="Jeans", Category="Clothing", Price=60, Stock=50 },
                new Product { Id=5, Name="Chocolate", Category="Food", Price=5, Stock=200 },
                new Product { Id=6, Name="Coffee Beans", Category="Food", Price=15, Stock=80 },
                new Product { Id=7, Name="C# Book", Category="Books", Price=45, Stock=30 },
                new Product { Id=8, Name="Novel", Category="Books", Price=20, Stock=60 },
                new Product { Id=9, Name="Headphones", Category="Electronics", Price=150, Stock=40 },
                new Product { Id=10, Name="Jacket", Category="Clothing", Price=120, Stock=15 }
            };

            //var electronics = SearchProducts(catalog, p => p.Category == "Electronics");
            //PrintProducts("Electronics Products:", electronics);

            //var cheap = SearchProducts(catalog, p => p.Price < 50);
            //PrintProducts("Products under $50:", cheap);

            //var inStock = SearchProducts(catalog, p => p.Stock > 0);
            //PrintProducts("Products in stock:", inStock);

            //var cheapClothing = SearchProducts(catalog, p => p.Category == "Clothing" && p.Price < 100);
            //PrintProducts("Clothing under $100:", cheapClothing);

            //PrintReport(catalog);

            //Console.WriteLine("Summary List: ");
            //var summary = TransformProducts(catalog, p => $"{p.Name} - ${p.Price}");
            //foreach (var p in summary)
            //{
            //    Console.WriteLine(p);
            //}

            //Console.WriteLine();

            //Console.WriteLine("Price Label: ");
            //var Label = TransformProducts(catalog, p => p.Price > 100? $"{p.Name}: Expensive" :$"{p.Name}: Affordable" );
            //foreach (var l in Label)
            //{
            //    Console.WriteLine(l);
            //}

            
            var lowStock = FilterProducts(catalog, p => p.Stock < 20);
            foreach(var p in lowStock)
            {
                Console.WriteLine($"[LOW STOCK] {p.Name}: only {p.Stock} left!");
            }
        }

        static List<Product> FilterProducts(List<Product> products, Predicate<Product> predicate)
        {
            List<Product> result = new List<Product>();
            foreach (var p in products)
            {
                if (predicate(p))
                {
                    result.Add(p);
                }
            }
            return result;
        }
    }
}




