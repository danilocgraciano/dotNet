using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Tracker.Contracts;
using Tracker.Models;
using Tracker.Shared;

namespace Tracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoardsController : ControllerBase
    {
        private IBoardRepository _repository;
        private ILogger<BoardsController> _logger;

        public BoardsController(IBoardRepository repository, ILogger<BoardsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // GET api/boards
        [HttpGet]
        public ActionResult<IEnumerable<Board>> All(int? page)
        {
            var data = _repository.FindAll();
            _logger.LogInformation("BoardsController - All");
            return Ok(new PaginatedList<Board>(data, page ?? 0));
        }

        // GET api/boards/5
        [HttpGet("{id}")]
        public ActionResult<Board> One(string id)
        {
            var board = _repository.FindByCondition(e => e.Id == id).FirstOrDefault();
            if (board == null)
            {
                _logger.LogInformation($"Board for id {id} does not exists!");
                return NotFound();
            }
            return Ok(board);
        }

        // POST api/boards
        [HttpPost]
        public ActionResult Save([FromBody] Board board)
        {
            if (board == null)
            {
                _logger.LogError("Request Object was NULL");
                return BadRequest();
            }

            board.Id = Guid.NewGuid().ToString();
            _repository.Create(board);
            _repository.Save();

            return CreatedAtAction(nameof(One), new { id = board.Id }, board);
        }

        // PUT api/boards/5
        [HttpPut("{id}")]
        public ActionResult Update(string id, [FromBody] Board board)
        {
            if (board == null)
            {
                _logger.LogError("Request Object was NULL");
                return BadRequest();
            }

            var aBoard = _repository.FindByCondition(e => e.Id == id).FirstOrDefault();
            if (aBoard == null)
            {
                _logger.LogInformation($"Board for id {id} does not exists!");
                return NotFound();
            }

            aBoard.Title = board.Title;
            aBoard.Cards = board.Cards;

            _repository.Update(aBoard);
            _repository.Save();

            return NoContent();

        }

        // DELETE api/boards/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            _logger.LogInformation("BoardsController - Delete");

            var board = _repository.FindByCondition(e => e.Id == id).FirstOrDefault();
            if (board == null)
            {
                _logger.LogInformation($"Board for id {id} does not exists!");
                return NotFound();
            }

            _repository.Delete(board);
            _repository.Save();

            return NoContent();
        }
    }
}
