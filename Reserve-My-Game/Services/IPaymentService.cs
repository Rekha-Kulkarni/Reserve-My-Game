using Reserve_My_Game.Model;

namespace Reserve_My_Game.Services
{
    public interface IPaymentService
    {
        PaymentResult ProcessPayment(int userId, decimal amount);
    }

}
