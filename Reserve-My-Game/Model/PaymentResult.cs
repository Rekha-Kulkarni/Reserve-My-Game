namespace Reserve_My_Game.Model
{
    public class PaymentResult
    {

        /// <summary>
        /// True if payment was successful, false otherwise.
        /// </summary>
        public bool Success { get; set; }
        public string TransactionId { get; set; }
        public string ErrorMessage { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
    }

}
