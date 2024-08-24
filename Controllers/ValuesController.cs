using FinShark.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinShark.Controllers
{
    [ApiController]
    [Route("api/stock")]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public StockController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            //Deferred execution.
            var stocks = _context.Stocks.ToList();
            return Ok(stocks);
        }
        //extract ID from url
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            //Can use first or default too
            var stock = _context.Stocks.Find(id);

            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock);
        }
    }
}
