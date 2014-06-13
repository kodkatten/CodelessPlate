using NUnit.Framework;
namespace CodelessPlate.IntegrationTests
{
    [TestFixture]
    public class DummyIntegrationTest
    {

        [Test]
        public void DummyIntegrationHello()
        {
            Assert.AreNotEqual(2,1-2);
        }
    }
}
