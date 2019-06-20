using System;
using System.ComponentModel.DataAnnotations;

namespace MegaDesk3.Models
{
    public class RushOrder
    {
        public int RushOrderId { get; set; }
        public string RushOrderName { get; set; }

        [DataType(DataType.Currency)]
        public decimal TierOnePrice { get; set; }

        [DataType(DataType.Currency)]
        public decimal TierTwoPrice { get; set; }

        [DataType(DataType.Currency)]
        public decimal TierThreePrice { get; set; }

        [DataType(DataType.Currency)]
        public decimal StandardPrice { get; set; }
    }
}
