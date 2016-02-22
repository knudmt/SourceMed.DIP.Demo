using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SourceMed.DIP.Contracts;
using SourceMed.DIP.Inverted.Demo.Interfaces;

namespace SourceMed.DIP.Inverted.Demo.Tests.Engine
{
    [TestClass]
    public class When_Creating_New_Patients
    {
        #region Members

        private Mock<IPatientStore> _mockStore;
        private ScheduleEngine _SUT;

        #endregion

        #region Initialize

        [TestInitialize]
        public void Initialize()
        {
            _mockStore = new Mock<IPatientStore>();
            _SUT = new ScheduleEngine(_mockStore.Object);
        }
        #endregion

        [TestMethod]
        [TestCategory("Unit")]
        public void It_Can_Add_Therapy_Patient()
        {
            var patient = new TherapyPatient()
            {
                AppointmentDate = DateTime.Now,
                FirstName = "Matthew",
                LastName = "Knudsen",
                Id = Guid.NewGuid()
            };

            _mockStore.Setup(x => x.CreateNewPatient(patient)).Returns(true);
            _SUT.AddPatient(patient);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void It_Throws_On_Null_Patient()
        {
            _SUT.AddPatient(null);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [ExpectedException(typeof (ArgumentNullException))]
        public void It_Throws_On_Null_First_Name()
        {
            var patient = new TherapyPatient()
            {
                AppointmentDate = DateTime.Now,
                Id = Guid.NewGuid(),
                FirstName = null,
                LastName = "Knudsen"
            };

            
            _SUT.AddPatient(patient);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [ExpectedException(typeof (ArgumentNullException))]
        public void It_Throws_On_Null_Last_Name()
        {
            var patient = new TherapyPatient()
            {
                AppointmentDate = DateTime.Now,
                Id = Guid.NewGuid(),
                FirstName = "Matthew",
                LastName = null
            };

            _SUT.AddPatient(patient);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [ExpectedException(typeof (Exception))]
        public void It_Throws_When_Store_Returns_Null()
        {
            _mockStore.Setup(x => x.CreateNewPatient(It.IsAny<IPatient>())).Returns(false);
            _SUT.AddPatient(new TherapyPatient() {
                AppointmentDate = DateTime.Now,
                Id = Guid.NewGuid(),
                FirstName = "Matthew",
                LastName = "Knudsen"
            });
        }
    }
}
