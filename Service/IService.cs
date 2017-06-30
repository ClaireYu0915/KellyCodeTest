using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestModel;

namespace Service
{
    public interface IService
    {
        bool CheckInventory(string productId, int qty);
        Product CheckValidProduct(string productId);
        bool ChargePayment(string creditCardNumber, decimal moneyAmount);
        Card CheckValidCard(string cardNumber);
        void SendEmail(string cardName, string cardNumber, decimal account);
    }
}
