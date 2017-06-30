using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestModel;

namespace Service
{
    public class ProductService : IService
    {
        private readonly IRepository iRepo;
        public ProductService(IRepository _iRepo)
        {
            iRepo = _iRepo;
        }
        public ProductService() { }
        public bool CheckInventory(string productId, int qty)
        {
           return iRepo.CheckInventory(productId, qty);
        }

        public Product CheckValidProduct(string productId)
        {
            return iRepo.CheckValidProduct(productId);
        }

        public bool ChargePayment(string creditCardNumber, decimal moneyAmount)
        {
            return iRepo.ChargePayment(creditCardNumber, moneyAmount);
        }

        public Card CheckValidCard(string cardNumber)
        {
            return iRepo.CheckValidCard(cardNumber);
        }

        public void SendEmail(string cardName, string cardNumber, decimal account)
        {
            iRepo.SendEmail(cardName, cardNumber, account);
        }
    }
}
