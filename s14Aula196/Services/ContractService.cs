using System;
using s14Aula196.Entities;

namespace s14Aula196.Services
{
    class ContractService
    {
        private IOnlinePaymentService _onlinePaymentService;

        public ContractService (IOnlinePaymentService onlinePaymentService)
        {
            _onlinePaymentService = onlinePaymentService;
        }

        public void ProcessContract(Contract contract, int months)
        {
            double basicQuota = contract.TotalValue / months;
            for (int i = 1; i <= months; i++)
            {
                DateTime date = contract.Date.AddMonths(i);
                double updadtedQuota = basicQuota + _onlinePaymentService.Interest(basicQuota, i);
                double fullQuota = updadtedQuota + _onlinePaymentService.PaymentFee(updadtedQuota);
                contract.AddInstallment(new Installment(date, fullQuota));

            }
        }

    }
}
