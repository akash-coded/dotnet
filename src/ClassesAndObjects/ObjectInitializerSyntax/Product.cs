namespace ObjectInitializerSyntax
{
    class Product
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        Product() { }

        public static List<Product> GetSampleProducts()
        {
            return new List<Product>
               {
                   new Product { Name="West Side Story", Price = 9.99m },
                   new Product { Name="Assassins", Price=14.99m },
                   new Product { Name="Frogs", Price=13.99m },
                   new Product { Name="Sweeney Todd", Price=10.99m}
               };

            // var p = new Product { Name = "West Side Story", Price = 9.99m };

            // var p = new Product();
            // p.Name = "West Side Story";
            // p.Price = 9.99m;
        }

        public override string ToString()
        {
            return $"Product [Name: {Name}, Price: {Price}]";
        }
    }
}