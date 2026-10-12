using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MTG_Card_API.Models;

namespace MTG_Card_Vault_API.Repositories
{
    public interface ICardRepository
    {
        IEnumerable<Card> GetAll(); 
        Card? GetById(int id); 
        Card Create(Card card); 
        Card Update(Card card);
         bool Delete(int id);
    }
}