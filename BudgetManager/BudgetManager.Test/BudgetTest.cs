using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BudgetManager.Controllers;
using System.Web.Mvc;
using BudgetManager.Models;
using System.ComponentModel.DataAnnotations;

namespace BudgetManager.Test
{
    [TestClass]
    public class BudgetTest
    {
        [TestMethod]
        public void Index_Returns_ActionResult()
        {
            BudgetController controller = new BudgetController();

            var actual = controller.Index();

            Assert.IsInstanceOfType(actual, typeof(ActionResult));
        }

        [TestMethod]
        public void Create_Returns_Bad_Request_If_Errors()
        {
            BudgetController controller = new BudgetController();
            controller.ModelState.AddModelError("fakeError", "fakeError");
            var actual = controller.Create(new Budget());
            Assert.IsInstanceOfType(actual, typeof(HttpStatusCodeResult));
        }
    }
}
