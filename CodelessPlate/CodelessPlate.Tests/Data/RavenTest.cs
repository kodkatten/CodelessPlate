using CodelessPlate.Data;
using NUnit.Framework;
using Raven.Client;

namespace CodelessPlate.Tests.Data
{
    [TestFixture]
    public class RavenTest
    {
        [Test]
        public void TestDb()
        {
            var productId = this.StoreSomeProductInDatabase();

            Product product = RavenInstance.Current.Session.Load<Product>(productId);

            Assert.AreEqual("Codeless", product.Name);
        }

        private string StoreSomeProductInDatabase()
        {
            var product = new Product
            {
                Id = "",
                Name = "Codeless"
            };

            return RavenInstance.Current.Store(product);
        }
    }

    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
