using System;
namespace MegaDesk3.Models
{
    public class DeskQuote
    {
        public int DeskQuoteId { get; set; }
        public string CustomerName { get; set; }
        public RushOrderType RushOrderType { get; set; }
        public Desk Desk { get; set; }
        public DateTime Date { get; set; }
        public decimal QuotePrice { get; set; }
    }
}
