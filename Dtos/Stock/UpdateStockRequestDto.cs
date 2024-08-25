﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinShark.Dtos.Stock
{
    public class UpdateStockRequestDto
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Symbol cannot be over 10 characters")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [MaxLength(30, ErrorMessage = "Company Name cannot be over 30 characters")]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        [Range(1, 1000000000000)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Purchase { get; set; }
        [Required]
        [Range(0.001, 100)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal LastDiv { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "Industry cannot be over 10 characters")]
        public string Industry { get; set; } = string.Empty;
        [Range(1, 5000000000)]
        public long MarketCap { get; set; }
    }
}
