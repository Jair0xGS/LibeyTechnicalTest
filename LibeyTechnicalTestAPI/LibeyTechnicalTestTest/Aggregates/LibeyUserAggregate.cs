using LibeyTechnicalTestDomain.LibeyUserAggregate.Application;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using Moq;

namespace LibeyTechnicalTestTest.Aggregates
{
    [TestClass]
    public class LibeyUserAggregateTests
    {
        private Mock<ILibeyUserRepository> _mockRepository;
        private LibeyUserAggregate _libeyUserAggregate;

        [TestInitialize]
        public void Setup()
        {
            _mockRepository = new Mock<ILibeyUserRepository>();
            _libeyUserAggregate = new LibeyUserAggregate(_mockRepository.Object);
        }

        [TestMethod]
        public void List_ShouldReturnCorrectUsers_WhenParametersAreValid()
        {
            var expectedUsers = new List<LibeyUserResponse>
            {
                new LibeyUserResponse(),
                new LibeyUserResponse(),
            };
            _mockRepository.Setup(repo => repo.List(0, 5)).Returns(expectedUsers);

            var result = _libeyUserAggregate.List(0, 5);

            Assert.AreEqual(expectedUsers.Count, result.Count());
        }

        [TestMethod]
        public void Create_ShouldThrowException_WhenUserExists()
        {
            var command = new UserUpdateorCreateCommand { DocumentNumber = "123" };
            _mockRepository.Setup(repo => repo.Exists(command.DocumentNumber)).Returns(true);

            var exception = Assert.ThrowsException<Exception>(() => _libeyUserAggregate.Create(command));
            Assert.AreEqual("usuario ya existe", exception.Message);
        }

        [TestMethod]
        public void Create_ShouldCallRepositoryCreate_WhenUserDoesNotExist()
        {
            var command = new UserUpdateorCreateCommand { DocumentNumber = "123" };
            _mockRepository.Setup(repo => repo.Exists(command.DocumentNumber)).Returns(false);

            _libeyUserAggregate.Create(command);

            //repo create was called one time
            _mockRepository.Verify(repo => repo.Create(It.IsAny<LibeyUser>()), Times.Once);
        }

        [TestMethod]
        public void Update_ShouldThrowException_WhenUserDoesNotExist()
        {
            var command = new UserUpdateorCreateCommand { DocumentNumber = "123" };
            _mockRepository.Setup(repo => repo.Exists(command.DocumentNumber)).Returns(false);

            var exception = Assert.ThrowsException<Exception>(() => _libeyUserAggregate.Update(command));
            Assert.AreEqual("usuario no existe", exception.Message);
        }

        [TestMethod]
        public void Delete_ShouldThrowException_WhenUserDoesNotExist()
        {
            var documentNumber = "123";
            _mockRepository.Setup(repo => repo.Exists(documentNumber)).Returns(false);

            var exception = Assert.ThrowsException<Exception>(() => _libeyUserAggregate.Delete(documentNumber));
            Assert.AreEqual("usuario no existe", exception.Message);
        }

        [TestMethod]
        public void FindResponse_ShouldReturnUser_WhenExists()
        {
            var documentNumber = "123";
            var expectedResponse = new LibeyUserResponse();
            _mockRepository.Setup(repo => repo.FindResponse(documentNumber)).Returns(expectedResponse);

            var result = _libeyUserAggregate.FindResponse(documentNumber);

            Assert.AreEqual(expectedResponse, result);
        }
    }
}