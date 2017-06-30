using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using Service;
using TestModel;

namespace UnitTest
{
    [TestClass]
    public class TestCases
    {
        readonly IRepository repo;
        readonly IService service;
        public TestCases()
        {
            repo = new Repo();
            service = new ProductService(repo);
        }
        [TestMethod]
        [ExpectedException(typeof(FormatException), "Quantity you order is more than inventory")]
        public void TestForMoreThanQuantity()
        {
           //total quantity of the product is 30
            bool result=service.CheckInventory("1", 40);
            if (!result)
            {
                throw new FormatException("Quantity you order is more than inventory");
            }
        }
        [TestMethod]
        [ExpectedException(typeof(FormatException), "Invalid quantity")]
        public void TestForInvalidQuantity()
        {
            //quantity of the product should greater than 0
            bool result = service.CheckInventory("1", -10);
            if (!result)
            {
                throw new FormatException("Invalid quantity");
            }
        }
        [TestMethod]
        [ExpectedException(typeof(FormatException), "Invalid product")]
        public void TestForInvalidProduct()
        {
            //productid=1and2
            bool result = service.CheckInventory("10", 20);
            if (!result)
            {
                throw new FormatException("Invalid product");
            }
        }
        [TestMethod]
        public void TestForValidProduct()
        {
            bool result = service.CheckInventory("2", 20);
            Assert.IsTrue(result);
        }
        [TestMethod]
        [ExpectedException(typeof(FormatException),"Card number is not true")]
        public void TestForInvalidCardNumber()
        {
            //card number is 1234567898765432
            Card card = service.CheckValidCard("123456789");
            if (card == null)
            {
                throw new FormatException("Card number is not true");
            }
        }
        [TestMethod]
        public void TestForValidCardNumber()
        {
            //card number is 1234567898765432
            Card card = service.CheckValidCard("1234567898765432");
            Assert.IsTrue(card != null);
        }
        [TestMethod]
        [ExpectedException(typeof(FormatException), "Money in card is not enough for the product")]
        public void TestForMoneyAccountInCardIsNotEnough()
        {
            //card number is 1234567898765432
            //money in card is 500
            bool result = service.ChargePayment("1234567898765432", 1000);
            if (!result)
            {
                throw new FormatException("Money in card is not enough for the product");
            }
        }
        
    }
}
