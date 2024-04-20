using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using WarehouseApp;

namespace WarehouseApp.Tests
{
    // “естовый класс дл€ тестировани€ функциональности класса Pallet
    [TestFixture]
    public class PalletTests
    {
        // “ест провер€ет, возвращает ли метод GetExpirationDate() минимальное значение, 
        // когда на палете отсутствуют €щики
        [Test]
        public void GetExpirationDate_Returns_MinValue_When_No_Boxes()
        {
            var pallet = new Pallet(1, 10, 10, 10, 10, new List<Box>());
            var expirationDate = pallet.GetExpirationDate();
            ClassicAssert.AreEqual(DateTime.MaxValue, expirationDate);
        }

        // “ест провер€ет, возвращает ли метод GetExpirationDate() минимальное значение,
        // когда на палете есть €щики, но они не имеют даты истечени€ срока годности
        [Test]
        public void GetExpirationDate_Returns_MinExpirationDate_When_Boxes_With_No_ExpirationDate()
        {
            var boxes = new List<Box>
            {
                new Box(1, 5, 5, 5, 5, DateTime.Now)
            };
            var pallet = new Pallet(1, 10, 10, 10, 10, boxes);
            var expirationDate = pallet.GetExpirationDate();
            ClassicAssert.AreEqual(DateTime.MaxValue, expirationDate);
        }

        // “ест провер€ет, возвращает ли метод GetExpirationDate() минимальное значение,
        // когда на палете есть €щики с разными датами истечени€ срока годности
        [Test]
        public void GetExpirationDate_Returns_MinExpirationDate_When_Boxes_Have_Different_ExpirationDates()
        {
            var boxes = new List<Box>
            {
                new Box(1, 5, 5, 5, 5, DateTime.Now),
                new Box(2, 5, 5, 5, 5, DateTime.Now.AddDays(10)),
                new Box(3, 5, 5, 5, 5, DateTime.Now.AddDays(20))
            };
            var pallet = new Pallet(1, 10, 10, 10, 10, boxes);
            var expirationDate = pallet.GetExpirationDate();
            ClassicAssert.AreEqual(DateTime.MaxValue, expirationDate);
        }

        // “ест провер€ет, возвращает ли метод GetExpirationDate() ближайшую дату
        // истечени€ срока годности, когда на палете есть €щики с разными датами истечени€
        [Test]
        public void GetExpirationDate_Returns_Closest_ExpirationDate_When_Boxes_Have_Different_ExpirationDates()
        {
            // Arrange
            var now = DateTime.Now;
            var boxes = new List<Box>
            {
                new Box(1, 5, 5, 5, 5, now.AddDays(10)),
                new Box(2, 5, 5, 5, 5, now.AddDays(5)),
                new Box(3, 5, 5, 5, 5, now.AddDays(20))
            };
            var pallet = new Pallet(1, 10, 10, 10, 10, boxes);
            var expirationDate = pallet.GetExpirationDate();
            ClassicAssert.AreEqual(now.AddDays(5), expirationDate);
        }
    }

    // “естовый класс дл€ тестировани€ функциональности класса Box
    [TestFixture]
    public class BoxTests
    {
        // “ест провер€ет, возвращает ли метод GetVolume() корректный объЄм €щика
        [Test]
        public void GetVolume_Returns_Correct_Volume()
        {
            var box = new Box(1, 5, 5, 5, 5, DateTime.Now);
            var volume = box.GetVolume();
            ClassicAssert.AreEqual(125, volume);
        }
    }
}
