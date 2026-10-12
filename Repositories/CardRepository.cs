using System.Collections.Generic;
using System.Linq;
using MTG_Card_Vault_API;
using MTG_Card_Vault_API.Data;
using MTG_Card_API.Models;
namespace MTG_Card_Vault_API.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly AppDbContext _db;

        public CardRepository(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Card> GetAll()
        {
            return _db.Cards.ToList();
        }

        public Card? GetById(int id)
        {
            return _db.Cards.FirstOrDefault(c => c.Id == id);
        }

        public Card Create(Card card)
        {
            _db.Cards.Add(card);
            _db.SaveChanges();
            return card;
        }

        public Card Update(Card card)
        {
            _db.Cards.Update(card);
            _db.SaveChanges();
            return card;
        }

        public bool Delete(int id)
        {
            var card = _db.Cards.FirstOrDefault(c => c.Id == id);
            if (card == null)
            {
                return false;
            }

            _db.Cards.Remove(card);
            _db.SaveChanges();
            return true;
        }
    }
}