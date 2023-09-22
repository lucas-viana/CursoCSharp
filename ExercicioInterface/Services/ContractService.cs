using ExercicioInterface.Entities;

namespace ExercicioInterface.Services
{
    internal class ContractService
    {
        private IOnlinePaymentService _onlinePaymentService;

        public ContractService(IOnlinePaymentService onlinePaymentService)
        {
            _onlinePaymentService = onlinePaymentService;
        }

        public void ProcessContract(Contract contract, int months)
        {
            for (int i = 1; i <= months; i++)
            {
                DateTime dueDate = contract.Date.AddMonths(i);
                double amount = _onlinePaymentService.Interest(contract.TotalValue, i);
                amount += _onlinePaymentService.PaymentFee(amount);
                Installment installment = new Installment(dueDate, amount);
                contract.AddInstallments(installment);
            }

            Console.WriteLine("Installments: ");

            foreach (Installment installment in contract.Installments)
            {
                Console.WriteLine(installment);
            }
        }
    }
}
