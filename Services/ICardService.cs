using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using MTG_Card_Vault_API.DTOs;

namespace MTG_Card_Vault_API.Services
{
    public interface ICardService
    {
        List<CardResponseDto> GetAll();
        SetSummaryDto GetSetSummary(string setCode);
        CardResponseDto? GetById(int id);
        CardResponseDto? Create(CreateCardDto newCard, out int createdId);
        CardResponseDto? Update(int id, UpdateCardDto updateCard);
        bool Delete(int id);
    }
}