using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTG_Card_Vault_API.DTOs
{
    public class CreateCardDto
    {
        [Required(ErrorMessage = "Card name is required.")]
        [StringLength(60, ErrorMessage = "Card name cannot exceed 60 characters.")]
        public string Name {get; set;} = string.Empty;
        [Required(ErrorMessage = "Set code is required.")]
        [StringLength(3, ErrorMessage = "Set code cannot exceed 3 characters.")]
        public string SetCode {get;set;} = string.Empty;
        public string ManaCost {get;set;}= string.Empty;
        [Range(0, 20, ErrorMessage = "Mana value must be between 0 and 20.")]
        public int ManaValue {get; set;} =0;
        [AllowedValues("White", "Blue", "Green", "Black", "Red", "Colorless", "Multicolor",
            ErrorMessage = "Color must be White, Blue, Green, Black, Red, Colorless, or Multicolor.")]
        public string Color {get; set;}= string.Empty;
        [AllowedValues("Instant", "Creature", "Sorcery", "Artifact", "Enchantment", "Land", "Planeswalker", "Battle", "Saga",
            ErrorMessage = "Card type must be Instant, Creature, Sorcery, Artifact, Enchantment, Land, Planeswalker, Battle, or Saga.")]
        public string CardType{get; set;}= string.Empty;
        [AllowedValues("Common", "Uncommon", "Rare", "Mythic",
            ErrorMessage = "Rarity must be Common, Uncommon, Rare, or Mythic.")]
        public string Rarity {get;set;}= string.Empty;
        public int Quantity {get;set;}= 0;
        public decimal Value {get;set;}
        public bool IsFoil {get;set;}= false;
    }
}