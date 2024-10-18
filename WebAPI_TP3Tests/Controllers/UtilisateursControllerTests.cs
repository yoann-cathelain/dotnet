using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPI_TP3.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebAPI_TP3.Models.DataManager;
using WebAPI_TP3.Models.EntityFramework;
using WebAPI_TP3.Models.Repository;
using Moq;

namespace WebAPI_TP3.Controllers.Tests
{
    [TestClass()]
    public class UtilisateursControllerTests
    {
        private Mock<IDataRepository<Utilisateur>> mockRepository;
        private UtilisateursController controller;
        private static PostgresContext _context;
        [TestInitialize]
        public void InitializeTest()
        {
            var builder = new DbContextOptionsBuilder<PostgresContext>().UseNpgsql(
                "Server=localhost;port=5432;Database=postgres; uid=postgres; password=postgres;");
            _context = new PostgresContext(builder.Options);
            mockRepository = new Mock<IDataRepository<Utilisateur>>();
            controller = new UtilisateursController(mockRepository.Object);
        }

        [TestCleanup]
        public void CleanUpTest()
        {
            GC.Collect();
        }
        [TestMethod()]
        public async Task GetUtilisateursTest()
        {
            Utilisateur user1 = new Utilisateur
            {
                UtilisateurId = 1,
                Nom = "Calida",
                Prenom = "Lilley",
                Mobile = "0653930778",
                Mail = "clilleymd@last.fm",
                Pwd = "Toto1234!",
                Rue = "Impasse des bergeronnettes",
                CodePostal = "74200",
                Ville = "Allinges",
                Pays = "France",
                Latitude = 46.344795F,
                Longitude = 6.4885845F
            };

            mockRepository.Setup((e => e.GetAllAsync())).ReturnsAsync(new[]
            {
                user1

            });
            var utilisateur = _context.Utilisateurs.FirstOrDefault(u => u.Nom == user1.Nom);
         
            Assert.IsNotNull(utilisateur);
            Assert.IsInstanceOfType(user1, typeof(Utilisateur));
            Assert.AreEqual(utilisateur, user1);
        }

        [TestMethod()]
        public void  GetUtilisateurByIdTest_ReturnsRightItem()
        {
            Utilisateur user =new Utilisateur
            {
                UtilisateurId = 1,
                Nom = "Calida",
                Prenom = "Lilley",
                Mobile = "0653930778",
                Mail = "clilleymd@last.fm",
                Pwd = "Toto12345678!",
                Rue = "Impasse des bergeronnettes",
                CodePostal = "74200",
                Ville = "Allinges",
                Pays = "France",
                Latitude = 46.344795F,
                Longitude = 6.4885845F
            };
            
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(user);
            // Act
            var actionResult = controller.GetUtilisateurById(1).Result;
            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(user, actionResult.Value as Utilisateur);

        }

        [TestMethod()]
        public async Task GetUtilisateurByIdTest_ReturnsNotFound()
        {
            // Act
            var actionResult = controller.GetUtilisateurById(0).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundObjectResult));

        }

        [TestMethod()]
        public async Task GetUtilisateurByEmailTest_ReturnsRightItem()
        {
            Utilisateur user = new Utilisateur
            {
                UtilisateurId = 1,
                Nom = "Calida",
                Prenom = "Lilley",
                Mobile = "0653930778",
                Mail = "clilleymd@last.fm",
                Pwd = "Toto12345678!",
                Rue = "Impasse des bergeronnettes",
                CodePostal = "74200",
                Ville = "Allinges",
                Pays = "France",
                Latitude = 46.344795F,
                Longitude = 6.4885845F
            };

            mockRepository.Setup(x => x.GetByStringAsync("clilleymd@last.fm").Result).Returns(user);
            // Act
            var actionResult = controller.GetUtilisateurByEmail("clilleymd@last.fm").Result;
            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(user, actionResult.Value as Utilisateur);

        }

        [TestMethod()]
        public async Task GetUtilisateurByEmailTest_ReturnsNotFound()
        {
            var utilisateurAPI = await controller.GetUtilisateurByEmail("test@test.fr");

            Assert.IsNull(utilisateurAPI.Value);
            Assert.IsInstanceOfType(utilisateurAPI, typeof(ActionResult<Utilisateur>));
            Assert.IsInstanceOfType(utilisateurAPI.Result, typeof(NotFoundObjectResult), "Pas NotFoundResult");

        }

        [TestMethod]
        public void Postutilisateur_ModelValidated_CreationOK()
        {
            // Arrange
            Utilisateur user = new Utilisateur
            {
                Nom = "POISSON",
                Prenom = "Pascal",
                Mobile = "1",
                Mail = "poisson@gmail.com",
                Pwd = "Toto12345678!",
                Rue = "Chemin de Bellevue",
                CodePostal = "74940",
                Ville = "Annecy-le-Vieux",
                Pays = "France",
                Latitude = null,
                Longitude = null
            };
            // Act
            var actionResult = controller.PostUtilisateur(user).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Utilisateur>), "Pas un ActionResult<Utilisateur>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Utilisateur), "Pas un Utilisateur");
            user.UtilisateurId = ((Utilisateur)result.Value).UtilisateurId;
            Assert.AreEqual(user, (Utilisateur)result.Value, "Utilisateurs pas identiques");
        }

        [TestMethod]
        public void DeleteUtilisateurTest_Moq()
        {
            Utilisateur user = new Utilisateur
            {
                UtilisateurId = 1,
                Nom = "Calida",
                Prenom = "Lilley",
                Mobile = "0653930778",
                Mail = "clilleymd@last.fm",
                Pwd = "Toto12345678!",
                Rue = "Impasse des bergeronnettes",
                CodePostal = "74200",
                Ville = "Allinges",
                Pays = "France",
                Latitude = 46.344795F,
                Longitude = 6.4885845F
            };
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(user);
            // Act
            var actionResult = controller.DeleteUtilisateur(1).Result;
        }

        [TestMethod]
        public async Task PutUtilisateurTest_Moq()
        {
            Utilisateur user = new Utilisateur
            {
                UtilisateurId = 1,
                Nom = "Calida",
                Prenom = "Lilley",
                Mobile = "0653930778",
                Mail = "clilleymd@last.fm",
                Pwd = "Toto12345678!",
                Rue = "Impasse des bergeronnettes",
                CodePostal = "74200",
                Ville = "Allinges",
                Pays = "France",
                Latitude = 46.344795F,
                Longitude = 6.4885845F
            };

            Utilisateur userUpdated = new Utilisateur
            {
                UtilisateurId = 1,
                Nom = "Houston",
                Prenom = "Lilley",
                Mobile = "0653930778",
                Mail = "clilleymd@last.fm",
                Pwd = "Test123456789",
                Rue = "Impasse des bergeronnettes",
                CodePostal = "38080",
                Ville = "Bourgoin-Jallieu",
                Pays = "France",
                Latitude = 46.344795F,
                Longitude = 6.4885845F
            };

            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(user);
            var actionResult = await controller.PutUtilisateur(user.UtilisateurId, userUpdated);
        }
    }
}