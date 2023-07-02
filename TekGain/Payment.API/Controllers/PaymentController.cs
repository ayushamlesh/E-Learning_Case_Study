using Microsoft.AspNetCore.Mvc;
using Payment.API.Repository;
namespace Payment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        // Implement the Services here
        private readonly IPaymentRepository _paymentRepository;

        public PaymentController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        [HttpPost("initialize")]
        public async Task<ActionResult<string>> InitializePayment([FromQuery] double amount)
        {
            try
            {
                string result = _paymentRepository.InitializePayment(amount);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while initializing the payment: {ex.Message}");
            }
        }
    }
}