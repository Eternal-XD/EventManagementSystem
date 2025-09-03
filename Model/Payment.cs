using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagmentSystem.Model
{
    class Payment
    {
        public int Id { get; set; }
        public int Purchase_id { get; set; }
        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public string NameOnCard { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Ccv { get; set; }
        public Payment(int purchaseId, string cardType, string cardNumber, string nameOnCard, DateTime expiryDate, string ccv)
        {
            this.Purchase_id = purchaseId;
            this.CardType = cardType;
            this.CardNumber = cardNumber;
            this.NameOnCard = nameOnCard;
            this.ExpiryDate = expiryDate;
            this.Ccv = ccv;
        }
    }
}
