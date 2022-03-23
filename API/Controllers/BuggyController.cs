using Data.ApplicationContext;
using Hamnava.Core.Errors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  
    public class BuggyController : BaseApiController
    {
        private readonly Context _context;
        public BuggyController(Context context)
        {
            _context = context;
        }

        [HttpGet("notfound")]
        public IActionResult GetNotFoundRequest()
        {
            var things = _context.Products.Find(-1);
            if (things == null)
            {
                return NotFound( new ApiResponse(404));
            }
            return Ok();
        }


        [HttpGet("servererror")]
        public IActionResult GetServerError()
        {
            var things = _context.Products.Find(-1);
            var thingsReturn = things.ToString();
            return Ok();
        }

        [HttpGet("badRequest")]
        public IActionResult GetBadRequest()
        {
            return BadRequest();
        }

        [HttpGet("badrequest/{id}")]
        public IActionResult GetNotFoundRequest(int id)
        {
            
            return Ok();
        }
    }
}
