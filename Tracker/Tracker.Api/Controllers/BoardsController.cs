using Microsoft.AspNetCore.Mvc;
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
        private IBoardRepository repository;

        public BoardsController(IBoardRepository repository)
        {
            this.repository = repository;
        }

        // GET api/boards
        [HttpGet]
        public ActionResult<IEnumerable<Board>> All(int? page)
        {
            var data = repository.FindAll();
            return Ok(new PaginatedList<Board>(data, page ?? 0));
        }

        // GET api/boards/5
        [HttpGet("{id}")]
        public ActionResult<Board> One(string id)
        {
            var board = repository.FindByCondition(e => e.Id == id).FirstOrDefault();
            if (board == null)
                return NotFound();
            return Ok(board);
        }

        // POST api/boards
        [HttpPost]
        public ActionResult Save([FromBody] Board board)
        {
            board.Id = Guid.NewGuid().ToString();
            repository.Create(board);
            repository.Save();

            return CreatedAtAction(nameof(One), new { id = board.Id }, board);
        }

        // PUT api/boards/5
        [HttpPut("{id}")]
        public ActionResult Update(string id, [FromBody] Board board)
        {
            var aBoard = repository.FindByCondition(e => e.Id == id).FirstOrDefault();
            if (aBoard == null)
                return NotFound();

            aBoard.Title = board.Title;
            aBoard.Cards = board.Cards;

            repository.Update(aBoard);
            repository.Save();

            return NoContent();

        }

        // DELETE api/boards/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var board = repository.FindByCondition(e => e.Id == id).FirstOrDefault();
            if (board == null)
                return NotFound();

            repository.Delete(board);
            repository.Save();

            return NoContent();
        }
    }
}
