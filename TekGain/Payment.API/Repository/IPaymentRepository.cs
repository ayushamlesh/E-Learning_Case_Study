namespace Payment.API.Repository
{
    public interface IPaymentRepository
    {
        String InitializePayment(double amount);
    }
}
