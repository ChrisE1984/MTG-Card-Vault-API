using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTG_Card_Vault_API.DTOs
{
    public class UpdateCardDto
    {
        public string Name {get; set;} = string.Empty;
        public string SetCode {get;set;} = string.Empty;
        public string ManaCost {get;set;}= string.Empty;
        public int ManaValue {get; set;} =0;
        public string Color {get; set;}= string.Empty;
        public string CardType {get;set;}= string.Empty;
        public string Rarity {get;set;}= string.Empty;
        public int Quantity {get;set;}= 0;
        public decimal Value {get;set;}
        public bool IsFoil {get;set;}
    }
}