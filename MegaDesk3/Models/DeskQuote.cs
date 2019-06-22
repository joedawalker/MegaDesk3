using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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
        private List<RushOrder> _rushOrderData;

        /// <summary>
        /// Calculates the Quote of a Desk order based on the Desk customization and Rush Order selection.
        /// </summary>
        public decimal GetQuote( List<RushOrder> rushOrderData )
        {
            _rushOrderData = rushOrderData;
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
            if ( surfaceArea < 1000 )
            {
                switch ( RushOrderType )
                {
                    case RushOrderType.ThreeDay:
                        return _rushOrderData.FirstOrDefault( r => r.RushOrderName.Equals( "3-day" ) ).TierOnePrice;
                    case RushOrderType.FiveDay:
                        return _rushOrderData.FirstOrDefault( r => r.RushOrderName.Equals( "5-day" ) ).TierOnePrice;
                    case RushOrderType.SevenDay:
                        return _rushOrderData.FirstOrDefault( r => r.RushOrderName.Equals( "7-day" ) ).TierOnePrice;
                    default:
                        return 0;
                }
            }

            if ( surfaceArea >= 1000 && surfaceArea <= 2000 )
            {
                switch ( RushOrderType )
                {
                    case RushOrderType.ThreeDay:
                        return _rushOrderData.FirstOrDefault( r => r.RushOrderName.Equals( "3-day" ) ).TierTwoPrice;
                    case RushOrderType.FiveDay:
                        return _rushOrderData.FirstOrDefault( r => r.RushOrderName.Equals( "5-day" ) ).TierTwoPrice;
                    case RushOrderType.SevenDay:
                        return _rushOrderData.FirstOrDefault( r => r.RushOrderName.Equals( "7-day" ) ).TierTwoPrice;
                    default:
                        return 0;
                }
            }

            switch ( RushOrderType )
            {
                case RushOrderType.ThreeDay:
                    return _rushOrderData.FirstOrDefault( r => r.RushOrderName.Equals( "3-day" ) ).TierThreePrice;
                case RushOrderType.FiveDay:
                    return _rushOrderData.FirstOrDefault( r => r.RushOrderName.Equals( "5-day" ) ).TierThreePrice;
                case RushOrderType.SevenDay:
                    return _rushOrderData.FirstOrDefault( r => r.RushOrderName.Equals( "7-day" ) ).TierThreePrice;
                default:
                    return 0;
            }
        }
    }
}
