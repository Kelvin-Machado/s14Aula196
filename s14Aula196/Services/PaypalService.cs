using System;
namespace s14Aula196.Services
{
    class PaypalService : IOnlinePaymentService
    {
        public double Interest(double amount, int months)
        {
            return amount * months * 0.01;
        }

        public double PaymentFee(double amount)
        {
            return amount * 0.02;
        }
    }
}
