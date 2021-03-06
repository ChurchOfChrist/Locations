﻿using System.Linq;
using System.Transactions;
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
        private TransactionScope _tranScope;
        private ChurchService Service { get; set; }
        public ChurchServiceTests()
        {
            _manager = new Manager();
            var repo = new ChurchRepository(_manager.Db);
            Service = new ChurchService(repo);
        }
        [SetUp]
        public void Setups()
        {
            _tranScope = new TransactionScope();
        }

        [TearDown]
        public void Dispose()
        {
            _tranScope.Dispose();
        }
        #region Add
        [Test]
        public void AddChurchShouldNotSaveTheChurchAndReturnFalseIfTheModelDoesnotContainContacts()
        {
            var church = new ChurchViewModel
            {
                Latitude = 18.765913990627432,
                Longitude = -69.6533203125,
            };
            Service.Add(church).ShouldBeFalse();
            _manager.Db.Churches.Any(c => c.Lat == church.Latitude && c.Lng == church.Longitude).ShouldBeFalse();
        }


        [Test]
        public void AddChurchShouldAddTheContactsCorrectlyIfItContainsContacts()
        {
            var contactList = EntitySeed.DefaultContacts.ToList();
            var church = new ChurchViewModel
            {
                Latitude = 18.765913990627432,
                Longitude = -69.6533203125,
                Contacts = contactList,
                WorshipDays = EntitySeed.DefaultWorshipDays,
            };
            Service.Add(church).ShouldBeTrue();
            var added = _manager.Db.Churches.FirstOrDefault(c =>
                c.Lat == church.Latitude &&
                c.Lng == church.Longitude);

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
                Latitude = 18.765913990627432,
                Longitude = -69.6533203125,
                Contacts = EntitySeed.DefaultContacts.ToList()
            };
            Service.Add(church).ShouldBeFalse();
            _manager.Db.Churches.Any(c => c.Lat == church.Latitude && c.Lng == church.Longitude).ShouldBeFalse();
        }


        [Test]
        public void AddChurchShouldAddChurchCorrectlyIfItContainsWorshipDays()
        {
            var worshipDays = EntitySeed.DefaultWorshipDays;
            var church = new ChurchViewModel
            {
                Latitude = 18.765913990627432,
                Longitude = -69.6533203125,
                Contacts = EntitySeed.DefaultContacts.ToList(),
                WorshipDays = worshipDays
            };
            Service.Add(church).ShouldBeTrue();
            var added = _manager.Db.Churches.FirstOrDefault(c =>
                c.Lat == church.Latitude &&
                c.Lng == church.Longitude);

            added.ShouldNotBeNull();
            added.Contacts.Any().ShouldBeTrue();
            worshipDays.ForEach(c => added.WorshipDays.Any(a => a.Day == c.Day && a.Description == c.Description
                && a.Start == c.Start && a.End == c.End).ShouldBeTrue());

        }
        #endregion
        #region Get
        [Test]
        public void GetChurchesByBoundingBoxShouldReturnTheChurchesInsideTheBox()
        {
            var church = new ChurchViewModel
            {
                Latitude = 18.765913990627432,
                Longitude = -69.6533203125,
                Contacts = EntitySeed.DefaultContacts,
                WorshipDays = EntitySeed.DefaultWorshipDays,
            };
            var coords = new CoordinatesViewModel(19.9708, -68.8540, 16.9492, -73.7374);
            Service.Add(church).ShouldBeTrue();
            Service.GetInBox(coords).Count().ShouldEqual(1);
        }
        #endregion
    }
}
