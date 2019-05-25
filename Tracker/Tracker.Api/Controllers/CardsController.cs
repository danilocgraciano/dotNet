using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Tracker.Contracts;
using Tracker.Models;
using Tracker.Shared;

namespace Tracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardsController : ControllerBase
    {
        private ICardRepository repository;

        public CardsController(ICardRepository repository)
        {
            this.repository = repository;
        }

        // GET api/cards
        [HttpGet]
        public ActionResult<IEnumerable<Card>> All(int? page)
        {
            var data = repository.FindAll();
            return Ok(new PaginatedList<Card>(data, page ?? 0));
        }

        // GET api/cards/5
        [HttpGet("{id}")]
        public ActionResult<Card> One(string id)
        {
            var card = repository.FindByCondition(e => e.Id == id).FirstOrDefault();
            if (card == null)
                return NotFound();
            return Ok(card);
        }

        // POST api/cards
        [HttpPost]
        public ActionResult Save([FromBody] Card card)
        {
            card.Id = Guid.NewGuid().ToString();
            repository.Create(card);
            repository.Save();

            return CreatedAtAction(nameof(One), new { id = card.Id }, card);
        }

        // PUT api/cards/5
        [HttpPut("{id}")]
        public ActionResult Update(string id, [FromBody] Card card)
        {
            var aCard = repository.FindByCondition(e => e.Id == id).FirstOrDefault();
            if (card == null)
                return NotFound();

            aCard.Title = card.Title;
            aCard.Description = card.Description;
            aCard.Board = card.Board;

            repository.Update(aCard);
            repository.Save();

            return NoContent();

        }

        // DELETE api/cards/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var card = repository.FindByCondition(e => e.Id == id).FirstOrDefault();
            if (card == null)
                return NotFound();

            repository.Delete(card);
            repository.Save();

            return NoContent();
        }

    }
}