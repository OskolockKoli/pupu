using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using WarehouseApp;

namespace WarehouseApp.Tests
{
    // �������� ����� ��� ������������ ���������������� ������ Pallet
    [TestFixture]
    public class PalletTests
    {
        // ���� ���������, ���������� �� ����� GetExpirationDate() ����������� ��������, 
        // ����� �� ������ ����������� �����
        [Test]
        public void GetExpirationDate_Returns_MinValue_When_No_Boxes()
        {
            var pallet = new Pallet(1, 10, 10, 10, 10, new List<Box>());
            var expirationDate = pallet.GetExpirationDate();
            ClassicAssert.AreEqual(DateTime.MaxValue, expirationDate);
        }

        // ���� ���������, ���������� �� ����� GetExpirationDate() ����������� ��������,
        // ����� �� ������ ���� �����, �� ��� �� ����� ���� ��������� ����� ��������
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

        // ���� ���������, ���������� �� ����� GetExpirationDate() ����������� ��������,
        // ����� �� ������ ���� ����� � ������� ������ ��������� ����� ��������
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

        // ���� ���������, ���������� �� ����� GetExpirationDate() ��������� ����
        // ��������� ����� ��������, ����� �� ������ ���� ����� � ������� ������ ���������
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

    // �������� ����� ��� ������������ ���������������� ������ Box
    [TestFixture]
    public class BoxTests
    {
        // ���� ���������, ���������� �� ����� GetVolume() ���������� ����� �����
        [Test]
        public void GetVolume_Returns_Correct_Volume()
        {
            var box = new Box(1, 5, 5, 5, 5, DateTime.Now);
            var volume = box.GetVolume();
            ClassicAssert.AreEqual(125, volume);
        }
    }
}
