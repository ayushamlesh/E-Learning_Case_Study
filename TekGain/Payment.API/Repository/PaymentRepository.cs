using Razorpay.Api;

namespace Payment.API.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        // Implement the code here
        private readonly IConfiguration _configuration;
        private readonly ILogger<PaymentRepository> _logger;

        public PaymentRepository(IConfiguration configuration, ILogger<PaymentRepository> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
        public string InitializePayment(double amount)
        {
            try
            {
                // Create Razorpay client
                string razorpayApiKey = _configuration["Razorpay:Key"];
                string razorpayApiSecret = _configuration["Razorpay:Secret"];
                var razorpayClient = new RazorpayClient(razorpayApiKey, razorpayApiSecret);

                // Create order
                var options = new Dictionary<string, object>
                {
                    { "amount", amount }, // Amount in paisa (100 paisa = 1 rupee)
                    { "currency", "USD" },
                    { "receipt", "order_receipt" },
                    { "payment_capture", 1 } // Auto-capture payment
                };

                Order order = razorpayClient.Order.Create(options);


                // Return order attributes
                //return order.Attributes.ToString();
                return "Payment Initialized";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initializing the payment.");
                throw;
            }
        }
    }
}