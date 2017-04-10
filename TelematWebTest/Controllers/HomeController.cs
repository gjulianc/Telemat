using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TelematWeb;
using TelematWeb.Controllers;
using TelematWeb.Areas.Admin.Controllers;

namespace TelematWebTest.Controllers {
    [TestClass]
    public class HomeControllerTest {
        [TestMethod]
        public void Index() {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Welcome to DevExpress Extensions for ASP.NET MVC!", result.ViewBag.Message);
        }
    }
}
