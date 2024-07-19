using MailKit.Search;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UmbErrorSample.DB.Contexts;
using UmbErrorSample.DB.Models;
using Umbraco.Cms.Persistence.EFCore.Scoping;

namespace UmbErrorSample.Web.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly IEFCoreScopeProvider<MovieContext> _scopeProvider;

        public MovieController(IEFCoreScopeProvider<MovieContext> scopeProvider)
        {
            _scopeProvider = scopeProvider;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            using var scope = _scopeProvider.CreateScope();

            var items = await scope.ExecuteWithContextAsync(async db =>
            {
                return db.Movies.Include(x => x.Genres);
            });

            scope.Complete();

            return Ok(items);
        }
    }
}
