using System;
using System.Collections.Generic;
using System.Linq;

namespace GroupMethodClause
{
    class Product
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }

    class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }

    public class Program
    {
        public static void Main()
        {
            List<Product> products = new List<Product>
    {
        new Product { Name = "Cola", CategoryId = 0 },
        new Product { Name = "Tea", CategoryId = 0 },
        new Product { Name = "Apple", CategoryId = 1 },
        new Product { Name = "Kiwi", CategoryId = 1 },
        new Product { Name = "Carrot", CategoryId = 2 },
    };

            List<Category> categories = new List<Category>
    {
        new Category { Id = 0, CategoryName = "Beverage" },
        new Category { Id = 1, CategoryName = "Fruit" },
        new Category { Id = 2, CategoryName = "Vegetable" }
    };

            // Join categories and product based on CategoryId and grouping result
            /*var productGroups = from product in products
                                join category in categories on product.CategoryId equals category.Id into productGroup
                                select productGroup;
            */
            var productGroups = from category in categories
                                join product in products on category.Id equals product.CategoryId into productGroup
                                select productGroup;

            foreach (IEnumerable<Product> productGroup in productGroups)
            {
                Console.WriteLine("Group");
                foreach (Product product in productGroup)
                {
                    Console.WriteLine($"{product.Name,8}");
                }
            }
            Console.WriteLine();

            // This code produces the following output:
            //
            // Group
            //     Cola
            //      Tea
            // Group
            //    Apple
            //     Kiwi
            // Group
            //   Carrot
            var productGroupsMtd = categories.GroupJoin(products, (cat) => cat.Id, (prod) => prod.CategoryId,(cat,prod)=>prod);

            foreach (IEnumerable<Product> productGroup in productGroupsMtd)
            {
                Console.WriteLine("Group");
                foreach (Product product in productGroup)
                {
                    Console.WriteLine($"{product.Name,8}");
                }
            }
        }
    }
}
