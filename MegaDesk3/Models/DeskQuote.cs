using System;
using System.ComponentModel.DataAnnotations;

namespace MegaDesk3.Models
{
    public class DeskQuote
    {
        public int DeskQuoteId { get; set; }

        [Display( Name = "Name" )]
        [Required]
        public string CustomerName { get; set; }

        [Display( Name = "Rush Order" )]
        public RushOrderType RushOrderType { get; set; }

        [Required]
        public Desk Desk { get; set; }

        [DataType( DataType.DateTime )]
        [DisplayFormat( DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true )]
        public DateTime Date { get; set; }

        [DataType( DataType.Currency )]
        [Display( Name = "Price" )]
        public decimal QuotePrice { get; set; }

        private const decimal BASE_DESK_PRICE = 200.00M;
        private const decimal SURFACE_AREA_RATE = 1;
        private const decimal DRAWER_RATE = 50.00M;

        /// <summary>
        /// Calculates the Quote of a Desk order based on the Desk customization and Rush Order selection.
        /// </summary>
        public decimal GetQuote()
        {
            decimal surfaceArea = Desk.Depth * Desk.Width;
            return GetDeskPrice( surfaceArea ) + GetRushOrderCost( surfaceArea );
        }

        private decimal GetDeskPrice( decimal surfaceArea )
        {
            decimal deskPrice = BASE_DESK_PRICE +
                                surfaceArea * SURFACE_AREA_RATE +
                                Desk.NumberOfDrawers * DRAWER_RATE +
                                Desk.SurfaceMaterial.Price;

            return deskPrice;
        }

        private decimal GetRushOrderCost( decimal surfaceArea )
        {
            // This is obviously bad practice, hard coding in these
            // values, but I didn't know what the expectation was. -Joseph
            decimal[,] rushOrderPrices =
            {
                { 60, 40, 30 },
                { 70, 50, 35 },
                { 80, 60, 40 }
            };

            if ( surfaceArea < 1000 )
            {
                switch ( RushOrderType )
                {
                    case RushOrderType.ThreeDay:
                        return rushOrderPrices[0, 0];
                    case RushOrderType.FiveDay:
                        return rushOrderPrices[0, 1];
                    case RushOrderType.SevenDay:
                        return rushOrderPrices[0, 2];
                    default:
                        return 0;
                }
            }

            if ( surfaceArea >= 1000 && surfaceArea <= 2000 )
            {
                switch ( RushOrderType )
                {
                    case RushOrderType.ThreeDay:
                        return rushOrderPrices[1, 0];
                    case RushOrderType.FiveDay:
                        return rushOrderPrices[1, 1];
                    case RushOrderType.SevenDay:
                        return rushOrderPrices[1, 2];
                    default:
                        return 0;
                }
            }

            switch ( RushOrderType )
            {
                case RushOrderType.ThreeDay:
                    return rushOrderPrices[2, 0];
                case RushOrderType.FiveDay:
                    return rushOrderPrices[2, 1];
                case RushOrderType.SevenDay:
                    return rushOrderPrices[2, 2];
                default:
                    return 0;
            }
        }
    }
}
