using Reserve_My_Game.Model;
using Stripe;

namespace Reserve_My_Game.Services
{
    public class PaymentService : IPaymentService
    {
        public PaymentResult ProcessPayment(int userId, decimal amount)
        {
            try
            {
                var options = new PaymentIntentCreateOptions
                {
                    Amount = (long)(amount * 100), // Stripe expects cents
                    Confirm = true, // immediately confirm payment
                    Metadata = new Dictionary<string, string>
                {
                    { "UserId", userId.ToString() }
                }
                };

                var service = new PaymentIntentService();
                var intent = service.Create(options);

                return new PaymentResult
                {
                    Success = intent.Status == "succeeded",
                    TransactionId = intent.Id,
                    Amount = amount,
                    PaymentDate = DateTime.UtcNow,
                    ErrorMessage = intent.Status != "succeeded" ? $"Payment status: {intent.Status}" : null
                };
            }
            catch (StripeException ex)
            {
                return new PaymentResult
                {
                    Success = false,
                    ErrorMessage = ex.Message,
                    Amount = amount,
                    PaymentDate = DateTime.UtcNow
                };
            }
        }
    }
}
