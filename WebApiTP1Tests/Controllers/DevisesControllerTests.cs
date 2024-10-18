using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiTP1.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiTP1.Models;

namespace WebApiTP1.Controllers.Tests
{
    [TestClass]
    public class DevisesControllerTests
    {
        private static DevisesController controller;
        private static List<Object> cleanupList;
        [TestInitialize]
        public void InitializeTest()
        {
            controller = new DevisesController();
            cleanupList = new List<Object>();
        }

        [TestCleanup]
        public void CleanUpTest()
        {
            GC.Collect();
        }
        [TestMethod]
        public void GetAllTest()
        {
            Assert.Fail();
        }


        [TestMethod]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            // Arrange
            
            // Act
            var result = controller.GetById(1);
            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<Devise>),
                "Pas un ActionResult"); // Test du type de retour
            Assert.IsNull(result.Result, "Erreur est pas null"); //Test de l'erreur
            Assert.IsInstanceOfType(result.Value, typeof(Devise),
                "Pas une Devise"); // Test du type du contenu (valeur) du retour
            Assert.AreEqual(new Devise(1, "Dollar", 1.08), (Devise?)result.Value,
                "Devises pas identiques"); //Test de la devise 
            cleanupList.Add(result);
        }

        [TestMethod]
        public void GetById_NonExistingId_ReturnsNotFoundStatus()
        {
            // Act
            var result = controller.GetById(10);
            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<Devise>),
                "Pas un ActionResult"); // Test du type de retour
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult), "Pas NotFoundResult");
            Assert.IsNull(result.Value, "Resultat pas null");
            cleanupList.Add(result);
        }

        [TestMethod]
        public void GetAll_ReturnsRightItem()
        {
            // Act
            var result = controller.GetAll();
            // Assert
            Assert.IsInstanceOfType(result, typeof(IEnumerable<Devise>),
                "Pas un Enumerable"); // Test du type de retour
            CollectionAssert.AllItemsAreInstancesOfType(result.ToList() ,typeof(Devise), "Pas Devise");
            CollectionAssert.AllItemsAreNotNull(result.ToList(), "Devise null");
            cleanupList.Add(result);
        }

        [TestMethod]
        public void Post_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Act
            var result = controller.Post(new Devise(4, null, 1.0));
            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<Devise>),
                "Pas un Enumerable"); // Test du type de retour
            Assert.IsInstanceOfType(result.Result, typeof(BadRequestResult));
            cleanupList.Add(result);
        }

        [TestMethod]
        public void Post_ValidObjectPassed_ReturnsObject()
        {
            // Act
            var result = controller.Post(new Devise(4, "Euros", 1.0));
            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<Devise>),
                "Pas un Enumerable"); // Test du type de retour
            Assert.IsInstanceOfType(result.Result, typeof(CreatedAtRouteResult));

            CreatedAtRouteResult routeResult = (CreatedAtRouteResult) result.Result;
            Assert.AreEqual(routeResult.StatusCode, StatusCodes.Status201Created);
            Assert.AreEqual(routeResult.Value, new Devise(4, "Euros", 1.0));
            cleanupList.Add(result);
            cleanupList.Add(routeResult);
        }

        [TestMethod]
        public void Put_InvalideObject_ReturnsBadRequest()
        {
            // Act
            var result = controller.Put(1, new Devise(4, "Euros", 1.0));

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<Devise>),
                "Pas un Enumerable"); // Test du type de retour
            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));
            cleanupList.Add(result);
        }

        [TestMethod]
        public void Put_InvalideObject_ReturnsNotFoundRequest()
        {
            // Act
            var result = controller.Put(5, new Devise(5, "Dollars Canadien", 0.67));

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<Devise>),
                "Pas un Enumerable"); // Test du type de retour
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
            cleanupList.Add(result);
        }

        [TestMethod]
        public void Put_ValidUpdate_ReturnsNoContent()
        {
            // Act
            var result = controller.Put(3, new Devise(3, "Euros", 1.20));

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<Devise>),
                "Pas un Enumerable"); // Test du type de retour
            Assert.IsInstanceOfType(result.Result, typeof(NoContentResult));
            cleanupList.Add(result);
        }

        [TestMethod]
        public void Delete_InvalideId_ReturnsNotFound()
        {
            // Act
            var result = controller.Delete(4);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<Devise>),
                "Pas un Enumerable"); // Test du type de retour
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
            cleanupList.Add(result);
        }

        [TestMethod]
        public void Delete_ValidId_ReturnsOk()
        {
            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<Devise>),
                "Pas un Enumerable"); // Test du type de retour
            OkObjectResult okResult = result.Result as OkObjectResult;
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            Assert.IsNotNull(okResult.Value);

            cleanupList.Add(result);
            cleanupList.Add(okResult);
        }
    }
}