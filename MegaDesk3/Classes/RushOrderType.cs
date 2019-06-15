using System;
using System.ComponentModel.DataAnnotations;

namespace MegaDesk3.Models
{
    public enum RushOrderType
    {
        [Display(Name = "3 Day")]
        ThreeDay,
        [Display(Name = "5 Day")]
        FiveDay,
        [Display(Name = "7 Day")]
        SevenDay
    }
}
