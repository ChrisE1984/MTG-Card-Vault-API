using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTG_Card_Vault_API.DTOs
{
    public class SetSummaryDto
    {
        public string SetCode { get; set; }=string.Empty;
        public int CardCount { get; set; }
        public int TotalCopies { get; set; }
        public decimal TotalValue { get; set; }
        public List<CardResponseDto> Cards { get; set; } = new();
    }
}