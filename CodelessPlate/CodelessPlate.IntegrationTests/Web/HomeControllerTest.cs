using System.Web.Mvc;
using CodelessPlate.Controllers;
using CodelessPlate.Data;
using CodelessPlate.Models;
using NSubstitute;
using NUnit.Framework;

namespace CodelessPlate.IntegrationTests.Web
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void Index_IsWorking()
        {
            var ravenMock = Substitute.For<IRavenInstance>();
            ravenMock.Store(Arg.Any<DummyModel>()).Returns("the Id");
            ravenMock.Load<DummyModel>("the Id").Returns(new DummyModel {Description = "It is working"});

            var controller = new HomeController(ravenMock);

            var result = controller.Index() as ViewResult;
            var model = result.ViewData.Model as DummyModel;

            Assert.AreEqual("It is working", model.Description);
        }
    }
}
