using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tracker.Contracts;
using Tracker.Models;
using Tracker.Shared;

namespace Tracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardsController : ControllerBase
    {
        private ICardRepository _repository;
        private ILogger<CardsController> _logger;

        public CardsController(ICardRepository repository, ILogger<CardsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // GET api/cards
        [HttpGet]
        public ActionResult<IEnumerable<Card>> All(int? page)
        {
            var data = _repository.FindAll();
            _logger.LogInformation("CardsController - All");
            return Ok(new PaginatedList<Card>(data, page ?? 0));
        }

        // GET api/cards/5
        [HttpGet("{id}")]
        public ActionResult<Card> One(string id)
        {
            var card = _repository.FindByCondition(e => e.Id == id).FirstOrDefault();
            if (card == null)
            {
                _logger.LogInformation($"Card for id {id} does not exists!");
                return NotFound();
            }
            return Ok(card);
        }

        // POST api/cards
        [HttpPost]
        public ActionResult Save([FromBody] Card card)
        {

            if (card == null)
            {
                _logger.LogError("Request Object was NULL");
                return BadRequest();
            }

            card.Id = Guid.NewGuid().ToString();
            _repository.Create(card);
            _repository.Save();

            return CreatedAtAction(nameof(One), new { id = card.Id }, card);
        }

        // PUT api/cards/5
        [HttpPut("{id}")]
        public ActionResult Update(string id, [FromBody] Card card)
        {
            if (card == null)
            {
                _logger.LogError("Request Object was NULL");
                return BadRequest();
            }

            var aCard = _repository.FindByCondition(e => e.Id == id).FirstOrDefault();
            if (card == null)
            {
                _logger.LogInformation($"Card for id {id} does not exists!");
                return NotFound();
            }

            aCard.Title = card.Title;
            aCard.Description = card.Description;
            aCard.Board = card.Board;

            _repository.Update(aCard);
            _repository.Save();

            return NoContent();

        }

        // DELETE api/cards/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var card = _repository.FindByCondition(e => e.Id == id).FirstOrDefault();
            if (card == null)
            {
                _logger.LogInformation($"Card for id {id} does not exists!");
                return NotFound();
            }

            _repository.Delete(card);
            _repository.Save();

            return NoContent();
        }

    }
}