using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SourceMed.DIP.Contracts;
using SourceMed.DIP.Inverted.Demo.Interfaces;

namespace SourceMed.DIP.Inverted.Demo.Tests.Engine
{
    [TestClass]
    public class When_Updating_Patients
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
        public void It_Can_Update_Patient()
        {
            _mockStore.Setup(x => x.UpdatePatient(It.IsAny<IPatient>())).Returns(true);
            _SUT.UpdatePatient(new TherapyPatient()
            {
                AppointmentDate = DateTime.Now,
                FirstName = "Test",
                LastName = "Patient",
                Id = Guid.NewGuid()
            });
        }

        [TestMethod]
        [TestCategory("Unit")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void It_Throws_On_Null_Patient()
        {
            _SUT.UpdatePatient(null);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [ExpectedException(typeof (Exception))]
        public void It_Throws_When_Store_Fails()
        {
            _mockStore.Setup(x => x.UpdatePatient(It.IsAny<IPatient>())).Throws(new Exception());
            _SUT.UpdatePatient(new TherapyPatient() {
                AppointmentDate = DateTime.Now,
                FirstName = "Test",
                LastName = "Patient",
                Id = Guid.NewGuid()
            });
        }

        [TestMethod]
        [TestCategory("Unit")]
        [ExpectedException(typeof (Exception))]
        public void It_Throws_When_Store_Returns_False()
        {
            _mockStore.Setup(x => x.UpdatePatient(It.IsAny<IPatient>())).Returns(false);
            _SUT.UpdatePatient(new TherapyPatient()
            {
                AppointmentDate = DateTime.Now,
                FirstName = "Test",
                LastName = "Patient",
                Id = Guid.NewGuid()
            });
        }
    }
}
