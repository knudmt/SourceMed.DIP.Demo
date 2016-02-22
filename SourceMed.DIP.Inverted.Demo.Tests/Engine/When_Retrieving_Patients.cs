using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SourceMed.DIP.Contracts;
using SourceMed.DIP.Inverted.Demo.Interfaces;

namespace SourceMed.DIP.Inverted.Demo.Tests.Engine
{
    [TestClass]
    public class When_Retrieving_Patients
    {
        private Mock<IPatientStore> _mockStore;
        private ScheduleEngine _SUT;

        [TestInitialize]
        public void Initialize()
        {
            _mockStore = new Mock<IPatientStore>();
            _SUT = new ScheduleEngine(_mockStore.Object);
        }

        [TestMethod]
        [TestCategory("Unit")]
        public void It_Returns_Patient()
        {
            var id = Guid.NewGuid();
            _mockStore.Setup(x => x.GetPatient(id.ToString()))
                .Returns(new TherapyPatient()
                {
                    AppointmentDate = DateTime.Today,
                    FirstName = "TestPatient",
                    LastName = "APatient",
                    Id = id
                });
            var actual = _SUT.GetPatient(id.ToString());
            Assert.IsInstanceOfType(actual, typeof(TherapyPatient));
            Assert.AreEqual("TestPatient", actual.FirstName);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void It_Throws_On_Null_Id()
        {
            var actual = _SUT.GetPatient(null);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [ExpectedException(typeof(Exception))]
        public void It_Throws_When_Store_Fails()
        {
            _mockStore.Setup(x => x.GetPatient(It.IsAny<string>())).Throws(new Exception());
            _SUT.GetPatient("any");
        }
    }
}
