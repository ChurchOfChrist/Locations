using System.Linq;
using Locations.Core.Services;
using Locations.Core.ViewModels;
using Locations.DataAccessLayer.Context;
using Locations.DataAccessLayer.Repositories;
using NUnit.Framework;
using Should;

namespace Locations.Core.Tests.Services
{
    [TestFixture]
    public class ChurchServiceTests
    {
        private readonly Manager _manager;
        private ChurchService Service { get; set; }
        public ChurchServiceTests()
        {
            _manager = new Manager();
        }
        [SetUp]
        public void Setups()
        {
            var repo = new ChurchRepository(_manager.Db);
            Service = new ChurchService(repo);
        }
        #region Add
        [Test]
        public void AddChurchShouldNotSaveTheChurchAndReturnFalseIfTheModelDoesnotContainContacts()
        {
            var church = new ChurchViewModel
            {
                Lat = 18.765913990627432,
                Lng = -69.6533203125,
                Address = "Someplace",
            };
            Service.Add(church).ShouldBeFalse();
            _manager.Db.Churches.Any(c => c.Address == church.Address).ShouldBeFalse();
        }


        [Test]
        public void AddChurchShouldAddTheContactsCorrectlyIfItContainsContacts()
        {
            var contactList = EntitySeed.DefaultContacts.ToList();
            var church = new ChurchViewModel
            {
                Lat = 18.765913990627432,
                Lng = -69.6533203125,
                Contacts = contactList,
                WorshipDays = EntitySeed.DefaultWorshipDays,
            };
            Service.Add(church).ShouldBeTrue();
            var added = _manager.Db.Churches.FirstOrDefault(c =>
                c.Lat == church.Lat &&
                c.Lng == church.Lng &&
                c.Address == church.Address);

            added.ShouldNotBeNull();
            added.Contacts.Any().ShouldBeTrue();
            contactList.ForEach(c => added.Contacts.Any(a => a.FullName == c.FullName && a.PhoneNumber == c.PhoneNumber
                && a.Email == c.Email).ShouldBeTrue());

        }
        [Test]
        public void AddChurchShouldNotSaveTheChurchAndReturnFalseIfItDoesNotContainWorshipDays()
        {
            var church = new ChurchViewModel
            {
                Lat = 18.765913990627432,
                Lng = -69.6533203125,
                Address = "Someplace",
                Contacts = EntitySeed.DefaultContacts.ToList()
            };
            Service.Add(church).ShouldBeFalse();
            _manager.Db.Churches.Any(c => c.Address == church.Address).ShouldBeFalse();
        }


        [Test]
        public void AddChurchShouldAddChurchCorrectlyIfItContainsWorshipDays()
        {
            var worshipDays = EntitySeed.DefaultWorshipDays;
            var church = new ChurchViewModel
            {
                Lat = 18.765913990627432,
                Lng = -69.6533203125,
                Contacts = EntitySeed.DefaultContacts.ToList(),
                WorshipDays = worshipDays
            };
            Service.Add(church).ShouldBeTrue();
            var added = _manager.Db.Churches.FirstOrDefault(c =>
                c.Lat == church.Lat &&
                c.Lng == church.Lng &&
                c.Address == church.Address);

            added.ShouldNotBeNull();
            added.Contacts.Any().ShouldBeTrue();
            worshipDays.ForEach(c => added.WorshipDays.Any(a => a.Day == c.Day && a.Description == c.Description
                && a.Start == c.Start && a.End == c.End).ShouldBeTrue());

        }
        #endregion
        [Test]
        public void GetChurchesByBoundingBoxShouldReturnTheChurchesInsideTheBox()
        {
            var church = new ChurchViewModel
            {
                Lat = 18.765913990627432,
                Lng = -69.6533203125,
                Contacts = EntitySeed.DefaultContacts,
                WorshipDays = EntitySeed.DefaultWorshipDays,
            };
            Service.Add(church).ShouldBeTrue();
            Service.GetInBox(19.9708, -68.8540, 16.9492, -73.7374).Count().ShouldEqual(1);
        }


    }
}
