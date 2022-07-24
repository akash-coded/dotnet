namespace ObjectInitializerSyntax
{
    class ObjectInitializerSyntaxDemo
    {
        public static void Main()
        {

            Seller seller = new Seller { Name = "Jethalal", SellerId = 007 };
            Console.WriteLine("Seller Name: {0}, Seller ID: {1}", seller.Name, seller.SellerId);

            IList<Product> products = Product.GetSampleProducts();
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }
    }
}
