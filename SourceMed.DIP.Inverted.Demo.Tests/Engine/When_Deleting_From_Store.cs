using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SourceMed.DIP.Inverted.Demo.Interfaces;

namespace SourceMed.DIP.Inverted.Demo.Tests.Engine
{
    [TestClass]
    public class When_Deleting_From_Store
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
        public void It_Can_Delete_Patient()
        {
            _mockStore.Setup(x => x.DeletePatient(It.IsAny<string>())).Returns(true);

            _SUT.DeletePatient("any");
        }

        [TestMethod]
        [TestCategory("Unit")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void It_Throws_On_Null_Id()
        {
            _SUT.DeletePatient(null);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [ExpectedException(typeof (Exception))]
        public void It_Throws_When_Store_Fails()
        {
            _mockStore.Setup(x => x.DeletePatient(It.IsAny<string>())).Throws(new Exception());
            _SUT.DeletePatient("any");
        }

        [TestMethod]
        [TestCategory("Unit")]
        [ExpectedException(typeof (Exception))]
        public void It_Throws_When_Store_Returns_False()
        {
            _mockStore.Setup(x => x.DeletePatient(It.IsAny<string>())).Returns(false);
            _SUT.DeletePatient("any");
        }
    }
}
