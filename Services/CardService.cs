using System;
using System.Collections.Generic;
using System.Linq;
using MTG_Card_API.Models;
using MTG_Card_Vault_API.DTOs;
using MTG_Card_Vault_API.Repositories;

namespace MTG_Card_Vault_API.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _card;

        public CardService(ICardRepository card)
        {
            _card = card;
        }

        public List<CardResponseDto> GetAll()
        {
            return _card.GetAll().Select(ToReadDTO).ToList();
        }

        public SetSummaryDto GetSetSummary(string setCode)
        {
            List<Card> cards = _card.GetAll()
                .Where(card => string.Equals(card.SetCode, setCode, StringComparison.OrdinalIgnoreCase))
                .OrderBy(card => card.Name)
                .ToList();

            return new SetSummaryDto
            {
                SetCode = setCode,
                CardCount = cards.Count(),
                TotalCopies = cards.Sum(card => card.Quantity),
                TotalValue = cards.Sum(card => card.Quantity * card.Value),
                Cards = cards.Select(ToReadDTO).ToList()
            };
        }

        public CardResponseDto? GetById(int id)
        {
            var card = _card.GetById(id);
            if (card == null)
            {
                return null;
            }

            return ToReadDTO(card);
        }

        public CardResponseDto? Create(CreateCardDto newCard, out int createdId)
        {
            createdId = 0;

            bool exists = _card.GetAll().Any(s =>
                string.Equals(s.Name, newCard.Name, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(s.SetCode, newCard.SetCode, StringComparison.OrdinalIgnoreCase));

            if (exists)
            {
                return null;
            }

            Card card = new Card
            {
                Name = newCard.Name,
                SetCode = newCard.SetCode,
                ManaCost = newCard.ManaCost,
                ManaValue = newCard.ManaValue,
                Color = newCard.Color,
                CardType = newCard.CardType,
                Rarity = newCard.Rarity,
                Quantity = newCard.Quantity,
                Value = newCard.Value,
                IsFoil = newCard.IsFoil
            };

            Card created = _card.Create(card);
            createdId = created.Id;

            return ToReadDTO(created);
        }

        public CardResponseDto? Update(int id, UpdateCardDto updateCard)
        {
            Card? existingCard = _card.GetById(id);
            if (existingCard == null)
            {
                return null;
            }

            existingCard.Name = updateCard.Name;
            existingCard.SetCode = updateCard.SetCode;
            existingCard.ManaCost = updateCard.ManaCost;
            existingCard.ManaValue = updateCard.ManaValue;
            existingCard.Color = updateCard.Color;
            existingCard.CardType = updateCard.CardType;
            existingCard.Rarity = updateCard.Rarity;
            existingCard.Quantity = updateCard.Quantity;
            existingCard.Value = updateCard.Value;
            existingCard.IsFoil = updateCard.IsFoil;

            var updatedCard = _card.Update(existingCard);
            return updatedCard == null ? null : ToReadDTO(updatedCard);
        }

        public bool Delete(int id)
        {
            Card? existingCard = _card.GetById(id);

            if (existingCard == null)
            {
                return false;
            }

            _card.Delete(id);
            return true;
        }

        private static CardResponseDto ToReadDTO(Card card)
        {
            CardResponseDto outputDTO = new CardResponseDto
            {
                Name = card.Name,
                SetCode = card.SetCode,
                ManaCost = card.ManaCost,
                ManaValue = card.ManaValue,
                Color = card.Color,
                CardType = card.CardType,
                Rarity = card.Rarity,
                Quantity = card.Quantity,
                Value = card.Value,
                TotalValue = card.Quantity * card.Value
            };

            return outputDTO;
        }
    }
}






