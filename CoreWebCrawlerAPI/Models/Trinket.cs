using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebCrawlerAPI.Models
{
    public class Trinket
    {
        [Required]
        public string TrinketId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string ProductLink { get; set; }

        [Required]
        public double ProductPrice { get; set; }

        [Required]
        public string ProductDiscount { get; set; }

        public bool Done { get; set; }

    }
}
