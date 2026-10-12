using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MTG_Card_Vault_API.DTOs;
using MTG_Card_Vault_API.Services;

namespace MTG_Card_Vault_API.Controllers
{
    [ApiController]
    [Route("api/cards")]
    public class CardController : ControllerBase
    {
              private readonly ICardService _card;

        public CardController(ICardService card)
        {
            _card = card;
        } 

        [HttpGet]
        public ActionResult<List<CardResponseDto>> GetAll()
        {
            return Ok(_card.GetAll());
        }

        [HttpGet("GetById/{id}")] 
        public ActionResult<CardResponseDto> GetById (int id)
        {
            CardResponseDto? card = _card.GetById(id);
            if (card is null)
            {
                return NotFound("No card listing with that Id found.");
            }

            return Ok(card);
        }
        [HttpPost]
        public ActionResult<CardResponseDto> Create([FromBody] CreateCardDto createCard)
        {
            CardResponseDto? created = _card.Create(createCard, out int createdId);

            if(created is null)
            {
                return BadRequest("No listing created. You did not add a listing that followed the required conventions.");
            }

            return CreatedAtAction(nameof(GetById), new { id = createdId }, created);
        }

        [HttpPut("{id}")]
        public ActionResult<CardResponseDto> Update(int id, [FromBody] UpdateCardDto updateCard)
        {
            CardResponseDto? updated = _card.Update(id, updateCard);

            if (updated is null)
            {
                return NotFound("No card listing with that Id found.");
            }

            return Ok(updated);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            CardResponseDto? card = _card.GetById(id);
            if (card is null)
            {
                return NotFound("No card listing with that Id found.");
            }

            if (card.Quantity > 0)
            {
                return BadRequest("Cannot delete a card with 1 or more copies. Update the quantity to 0 first.");
            }

            if (!_card.Delete(id))
            {
                return NotFound("No card listing with that Id found.");
            }

            return NoContent();
        }

        [HttpGet("Set/{setCode}")]
        public ActionResult<SetSummaryDto> GetBySet(string setCode)
        {
            return Ok(_card.GetSetSummary(setCode));
        }
    }
}