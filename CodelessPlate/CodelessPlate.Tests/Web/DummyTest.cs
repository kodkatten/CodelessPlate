using NSubstitute;
using NUnit.Framework;

namespace CodelessPlate.Tests.Web
{
    [TestFixture]
    public class DummyTest
    {
        [Test]
        public void AddTwoIntegers()
        {
            var calculator = Substitute.For<ICalculator>();
            calculator.Add(1, 2).Returns(3);

            Assert.AreEqual(3,calculator.Add(1,2));
        }
    }

    public interface ICalculator
    {
        int Add(int x, int y);
    }
}
