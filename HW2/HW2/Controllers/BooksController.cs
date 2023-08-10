using HW2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HW2.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BooksController : ControllerBase
	{
		[HttpGet]
		public ActionResult<List<Book>> GetAllBooks()
		{
			return Ok(StaticDb.Books);
		}

		[HttpGet("queryStrings")]
		public ActionResult<Book> GetBookByIndex(int? index)
		{
			try
			{
				if(index == null)
				{
					return BadRequest("Index is a required paramter.");
				}

				if(index < 0)
				{
					return BadRequest("Index cannot be a negative value.");
				}

				if(index >= StaticDb.Books.Count)
				{
					return NotFound($"There is no book with an index of {index}");
				}

				return Ok(StaticDb.Books[index.Value]);
			}
			catch(Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "A server error occured, please contact the support team.");
			}
		}

		[HttpGet("multipleQueryParams")]
		public ActionResult<List<Book>> FilterBooksByMultipleParams(string? author, string? title)
		{
			try
			{
				if(string.IsNullOrEmpty(author) && string.IsNullOrEmpty(title))
				{
					return BadRequest("Insert at least one query paramater");
				}

				if(string.IsNullOrEmpty(author))
				{
					return Ok(StaticDb.Books.Where(x => x.Title.ToLower() == title.ToLower()).ToList());
				}

				if (string.IsNullOrEmpty(title))
				{
					return Ok(StaticDb.Books.Where(x => x.Author.ToLower() == author.ToLower()).ToList());
				}

				return Ok(StaticDb.Books.Where(x => x.Author.ToLower() == author.ToLower() && x.Title.ToLower() == title.ToLower()).ToList());
			}
			catch(Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "A server error occured, please contact the support team.");
			}
		}

		[HttpPost] 
		public IActionResult CreateBook([FromBody] Book book)
		{
			try
			{
				if(string.IsNullOrEmpty(book.Title) && string.IsNullOrEmpty(book.Author))
				{
					return BadRequest("Insert some text.");
				}

				StaticDb.Books.Add(book);
				return StatusCode(StatusCodes.Status201Created);
			}
			catch(Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "A server error occured, please contact the support team.");
			}
		}
	}
}
