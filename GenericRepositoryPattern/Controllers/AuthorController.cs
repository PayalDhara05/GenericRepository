using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GenericRepositoryPattern.AppCode;
using GenericRepositoryPattern.Models;
using GenericRepositoryPattern.Repository;
using Microsoft.AspNetCore.JsonPatch;

namespace GenericRepositoryPattern.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private IGenericRepository<AuthorModel> _Authorrepository;

        public AuthorController(IGenericRepository<AuthorModel> Authorrepository)
        {
            _Authorrepository = Authorrepository;
        }

        [HttpPost]
        public async Task<IActionResult> addNewAuthor(AuthorModel objAuthorModel)
        {
            if (objAuthorModel == null)
                return BadRequest();

            var result = await _Authorrepository.addNew(objAuthorModel);
            if (result == -1)
                return StatusCode(500, "Something went wrong while processing the request");

            return CreatedAtAction(nameof(getSingleAuthor), new { id = objAuthorModel.Id }, objAuthorModel);
        }

        [HttpGet("deleteNewAuthor/{id}")]
        public async Task<IActionResult> deleteNewAuthor(int id)
        {
            var result = await _Authorrepository.deleteNew(id);
            if (result == -1)
                return NoContent();

            return Ok(new { response = "Deleted Author successfully !!" });
        }

        [HttpGet]
        public async Task<IActionResult> getAllAuthors()
        {
            var result = await _Authorrepository.getAll();
            if (result == null)
                return NoContent();

            return Ok(result);
        }

        [HttpGet("getSingleAuthor/{id}")]
        public async Task<IActionResult> getSingleAuthor(int id)
        {
            var result = await _Authorrepository.getSingle(id);
            if (result == null)
                return NoContent();

            return Ok(result);
        }

        [HttpPatch("updateNewAuthor/{id}")]
        public async Task<IActionResult> updateNewAuthor([FromRoute] int id, [FromBody] JsonPatchDocument AuthorModel)
        {
            if (AuthorModel == null)
                return BadRequest();

            var Author = await _Authorrepository.getSingle(id);
            if (Author == null)
                return NotFound();

            AuthorModel.ApplyTo(Author);

            var result = await _Authorrepository.updateNew(Author);
            if (result == -1)
                return StatusCode(500, "Something went wrong while processing the request");

            return Ok(new { response = "Author updated successfully!" });
        }

    }
}
