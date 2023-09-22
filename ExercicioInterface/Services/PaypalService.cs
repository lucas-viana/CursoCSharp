

using ExercicioInterface.Entities;

namespace ExercicioInterface.Services
{
    internal class PaypalService : IOnlinePaymentService
    {
        const double taxPayment = 0.02;
        const double interestRate = 0.01;

        private ContractService ContractService { get; }
        public double Interest(double amount, int months)
        {
            return amount += amount * (interestRate * months);
        }

        public double PaymentFee(double amount)
        {
            amount = amount*taxPayment;
            return amount;
        }
    }
}
