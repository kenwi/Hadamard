using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Hadamard.Common.Model;

namespace Hadamard.Tests
{
    [TestClass]
    public class SatelliteRepositoryTest
    {
        [TestMethod]
        public void OnSatelliteAdded()
        {
            var satellite = new Satellite(25544);
            ISatelliteRepository repository = new SatelliteRepository();

            repository.OnSatelliteAdded += (s, e) =>
            {
                Assert.AreSame(satellite, e.Satellite);
                Assert.AreEqual(repository.Count, 1);
                Assert.AreEqual(satellite, repository.GetSatelliteByIndex(0));
            };
            repository.Add(satellite);
            var addedSatellite = repository.GetSatelliteById(satellite.Id);
            Assert.AreSame(addedSatellite, satellite);
        }

        [TestMethod]
        public void OnSatelliteValuesUpdated()
        {
            var satellite = new Satellite(25544);
            ISatelliteRepository repository = new SatelliteRepository();
            repository.Add(satellite);
            repository.UpdateAll();

            repository.OnSatelliteValuesUpdated += (s, e) =>
            {
                Assert.AreSame(satellite, e.Satellite);
            };
        }

        [TestMethod]
        public void VerifyCount()
        {
            ISatelliteRepository repository = new SatelliteRepository();
            repository.Add(new Satellite(36516));
            repository.Add(new Satellite(25544));

            Assert.AreEqual(repository.Count, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void FailsOnAddingDuplicateSatellite()
        {
            ISatelliteRepository repository = new SatelliteRepository();
            repository.Add(new Satellite(36516));
            repository.Add(new Satellite(36516));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void FailsOnNonExistingSatellite()
        {
            ISatelliteRepository repository = new SatelliteRepository();
            repository.Add(new Satellite(-1000));
            repository.Add(new Satellite(999999));
        }

        [TestMethod]
        public void GetAllsatellites()
        {
            ISatelliteRepository repository = new SatelliteRepository();
            repository.Add(new Satellite(36516));
            repository.Add(new Satellite(25544));

            var addedSatellites = repository.GetAllSatellites();
            Assert.AreEqual(addedSatellites.Count(), 2);
        }

        [TestMethod]
        public void AddNoDataUpdate()
        {
            var satellite = new Satellite(36516);
            ISatelliteRepository repository = new SatelliteRepository();
            repository.Add(satellite);

            Assert.AreEqual(repository.Count, 1);
            Assert.AreEqual(repository.GetSatelliteById(satellite.Id), satellite);
        }

        [TestMethod]
        public void AddWithDataUpdate()
        {
            var satellite = new Satellite(36516);
            var oldValue = satellite.Azimuth;

            ISatelliteRepository repository = new SatelliteRepository();
            repository.Add(satellite, true);

            Assert.AreEqual(repository.Count, 1);
            Assert.AreEqual(repository.GetSatelliteById(satellite.Id), satellite);
            Assert.AreNotSame(repository.GetSatelliteById(satellite.Id).Azimuth, oldValue);
        }

        [TestMethod]
        public void GetSatellitebyIndex()
        {
            var satellite = new Satellite(36516);
            ISatelliteRepository repository = new SatelliteRepository();
            repository.Add(satellite);

            Assert.AreSame(repository.GetSatelliteByIndex(0), satellite);
        }

        [TestMethod]
        public void GetSatellitebyId()
        {
            var satellite = new Satellite(36516);
            ISatelliteRepository repository = new SatelliteRepository();
            repository.Add(satellite);

            Assert.AreSame(repository.GetSatelliteById(36516), satellite);
        }

        [TestMethod]
        public void ReturnsNullGetSatelliteByNonExistingIndex()
        {
            ISatelliteRepository repository = new SatelliteRepository();
            var satellite = repository.GetSatelliteByIndex(0);
            Assert.AreEqual(satellite, null);
        }

        [TestMethod]
        public void ReturnsNullGetSatelliteByNonExistingId()
        {
            ISatelliteRepository repository = new SatelliteRepository();
            var satellite = repository.GetSatelliteById(0);
            Assert.AreEqual(satellite, null);
        }
    }
}
