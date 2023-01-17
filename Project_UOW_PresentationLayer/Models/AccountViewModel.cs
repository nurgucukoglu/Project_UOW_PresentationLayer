namespace Project_UOW_PresentationLayer.Models
{
    public class AccountViewModel
    {
        //para gönderen, alan ve miktar bilgilerini tutan model
        public int SenderID { get; set; }
        public int ReceiverID { get; set; }
        public decimal Amount { get; set; }
    }
}
