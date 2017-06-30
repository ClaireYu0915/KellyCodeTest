using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestModel;

namespace Repository
{
    public class Repo : IRepository
    {
        List<Product> listProduct = new List<Product>()
        {
            new Product {ProductID="1",Quentity=30,Price=10 },
            new Product {ProductID="2",Quentity=50,Price=5 }
        };
        List<Card> listCard = new List<Card>()
        {
            new Card {CardID=1,CardName="Mike",CardNumber="1234567898765432",Year=2022,Month=01,Amount=500 }
        };
        public bool ChargePayment(string creditCardNumber, decimal moneyAmount)
        {

            Card card = listCard.Where(x => x.CardNumber == creditCardNumber).FirstOrDefault();
            if (card != null&&card.Amount>=moneyAmount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckInventory(string productId, int qty)
        {
        
            Product product = listProduct.Where(x => x.ProductID == productId && x.Quentity >= qty&&qty>0).SingleOrDefault();
            if (product != null)
            {
                return true;
            }else
            {
                return false;
            }
        }

        public Card CheckValidCard(string cardNumber)
        {
            Card card = listCard.Where(x => x.CardNumber == cardNumber).FirstOrDefault();
            if (card != null)
            {
                return card;
            }
            else
            {
                return null;
            }

        }

        public Product CheckValidProduct(string productId)
        {
            Product product = listProduct.Where(x => x.ProductID == productId).SingleOrDefault();
            return product;
        }

        public void SendEmail(string cardName, string cardNumber, decimal account)
        {
            
        }
    }
}
